using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TSF.Oolong
{
    public delegate void WebSocketOpenEventHandler();
    public delegate void WebSocketMessageEventHandler(byte[] data);

    public enum WebSocketState
    {
        Connecting,
        Open,
        Closing,
        Closed
    }

    public class Debugger
    {
        private class DebuggerAwaiter : INotifyCompletion
        {
            private Action _continuation;
            public bool IsCompleted { get; set; }

            public void GetResult() { }

            public void Complete()
            {
                IsCompleted = true;
                _continuation?.Invoke();
            }

            void INotifyCompletion.OnCompleted(Action continuation)
            {
                _continuation = continuation;
            }
        }

        private struct WaitForUpdate
        {
            public DebuggerAwaiter GetAwaiter()
            {
                s_awaiter ??= new DebuggerAwaiter();
                return s_awaiter;
            }
        }

        public event WebSocketOpenEventHandler OnOpen;
        public event WebSocketMessageEventHandler OnMessage;

        private readonly Uri _uri;
        private ClientWebSocket _socket = new ClientWebSocket();

        private CancellationTokenSource _tokenSource;
        private CancellationToken _cancellationToken;

        private readonly object _outgoingMessageLock = new object();
        private readonly object _incomingMessageLock = new object();

        private bool _isSending = false;
        private readonly List<ArraySegment<byte>> _sendBytesQueue = new List<ArraySegment<byte>>();
        private readonly List<ArraySegment<byte>> _sendTextQueue = new List<ArraySegment<byte>>();

        private static DebuggerAwaiter s_awaiter;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void RegisterAwaiter()
        {
            OolongEnvironment.OnUpdate += () =>
            {
                s_awaiter?.Complete();
                s_awaiter = null;
            };
        }

        public Debugger(int port)
        {
            _uri = new Uri($"ws://localhost:{port}");
            OolongEnvironment.OnUpdate += DispatchMessageQueue;
        }

        public void CancelConnection()
        {
            _tokenSource?.Cancel();
        }

        public async Task Connect()
        {
            try
            {
                _tokenSource = new CancellationTokenSource();
                _cancellationToken = _tokenSource.Token;
                _socket = new ClientWebSocket();
                await _socket.ConnectAsync(_uri, _cancellationToken);
                OnOpen?.Invoke();
                await Receive();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Oolong Debugger] {ex.Message}");
                Debug.LogException(ex);
            }
            finally
            {
                if (_socket != null)
                {
                    _tokenSource.Cancel();
                    _socket.Dispose();
                }
                OolongEnvironment.OnUpdate -= DispatchMessageQueue;
            }
        }

        public WebSocketState State
        {
            get
            {
                switch (_socket.State)
                {
                    case System.Net.WebSockets.WebSocketState.Connecting:
                        return WebSocketState.Connecting;

                    case System.Net.WebSockets.WebSocketState.Open:
                        return WebSocketState.Open;

                    case System.Net.WebSockets.WebSocketState.CloseSent:
                    case System.Net.WebSockets.WebSocketState.CloseReceived:
                        return WebSocketState.Closing;

                    case System.Net.WebSockets.WebSocketState.Closed:
                        return WebSocketState.Closed;

                    default:
                        return WebSocketState.Closed;
                }
            }
        }

        public Task Send(byte[] bytes)
        {
            return SendMessage(_sendBytesQueue, WebSocketMessageType.Binary, new ArraySegment<byte>(bytes));
        }

        public Task SendText(string message)
        {
            var encoded = Encoding.UTF8.GetBytes(message);

            return SendMessage(_sendTextQueue, WebSocketMessageType.Text, new ArraySegment<byte>(encoded, 0, encoded.Length));
        }

        private async Task SendMessage(List<ArraySegment<byte>> queue, WebSocketMessageType messageType, ArraySegment<byte> buffer)
        {
            if (buffer.Count == 0)
            {
                return;
            }

            bool sending;

            lock (_outgoingMessageLock)
            {
                sending = _isSending;

                if (!_isSending)
                {
                    _isSending = true;
                }
            }

            if (!sending)
            {
                if (!Monitor.TryEnter(_socket, 1000))
                {
                    await _socket.CloseAsync(WebSocketCloseStatus.InternalServerError, string.Empty, _cancellationToken);
                    return;
                }

                try
                {
                    var t = _socket.SendAsync(buffer, messageType, true, _cancellationToken);
                    t.Wait(_cancellationToken);
                }
                finally
                {
                    Monitor.Exit(_socket);
                }

                lock (_outgoingMessageLock)
                {
                    _isSending = false;
                }

                await HandleQueue(queue, messageType);
            }
            else
            {
                lock (_outgoingMessageLock)
                {
                    queue.Add(buffer);
                }
            }
        }

        private async Task HandleQueue(List<ArraySegment<byte>> queue, WebSocketMessageType messageType)
        {
            var buffer = new ArraySegment<byte>();
            lock (_outgoingMessageLock)
            {
                if (queue.Count > 0)
                {
                    buffer = queue[0];
                    queue.RemoveAt(0);
                }
            }

            if (buffer.Count > 0)
            {
                await SendMessage(queue, messageType, buffer);
            }
        }

        private readonly List<byte[]> _messageList = new List<byte[]>();

        private void DispatchMessageQueue()
        {
            if (_messageList.Count == 0)
            {
                return;
            }

            List<byte[]> messageListCopy;

            lock (_incomingMessageLock)
            {
                messageListCopy = new List<byte[]>(_messageList);
                _messageList.Clear();
            }

            var len = messageListCopy.Count;
            for (var i = 0; i < len; i++)
            {
                OnMessage?.Invoke(messageListCopy[i]);
            }
        }

        public async Task Receive()
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            try
            {
                while (_socket.State == System.Net.WebSockets.WebSocketState.Open)
                {
                    using (var ms = new MemoryStream())
                    {
                        WebSocketReceiveResult result = null;
                        do
                        {
                            result = await _socket.ReceiveAsync(buffer, _cancellationToken);
                            ms.Write(buffer.Array, buffer.Offset, result.Count);
                        }
                        while (!result.EndOfMessage);

                        ms.Seek(0, SeekOrigin.Begin);

                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            lock (_incomingMessageLock)
                            {
                                _messageList.Add(ms.ToArray());
                            }
                        }
                        else if (result.MessageType == WebSocketMessageType.Binary)
                        {
                            lock (_incomingMessageLock)
                            {
                                _messageList.Add(ms.ToArray());
                            }
                        }
                        else if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await Close();
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                _tokenSource.Cancel();
            }
            finally
            {
                await new WaitForUpdate();
                OolongEnvironment.OnUpdate -= DispatchMessageQueue;
            }
        }

        public async Task Close()
        {
            if (State == WebSocketState.Open)
            {
                await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, _cancellationToken);
            }
        }
    }
}
