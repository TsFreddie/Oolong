using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace TSF.Oolong
{
    [Serializable]
    public struct ScriptParsedEvent
    {
        [Serializable]
        public struct ScriptParsedParams
        {
            public string scriptId;
            public string url;
        }

        public string method;
        public ScriptParsedParams @params;
    }

    [Serializable]
    public struct SetSourceMethod
    {
        [Serializable]
        public struct SetSourceParams
        {
            public string scriptId;
            public string scriptSource;
        }

        public int id;
        public string method;
        public SetSourceParams @params;
    }

    public class HotReload
    {
        private Debugger _socket;
        private int _requestId = 0;
        private Dictionary<string, string> _scriptMap = new Dictionary<string, string>();

        public void Connect(int port)
        {
            _socket = new Debugger(port);
            _socket.OnMessage += SocketOnOnMessage;
            _socket.OnOpen += SocketOnOnOpen;
            _socket.Connect();
        }

        private void SocketOnOnOpen()
        {
            // get source from v8 debugger
            var message = $"{{\"id\":{_requestId++},\"method\":\"Debugger.enable\"}}";
            _socket.SendText(message);
        }

        private void SocketOnOnMessage(byte[] data)
        {
            var message = System.Text.Encoding.UTF8.GetString(data);
            var result = JsonUtility.FromJson<ScriptParsedEvent>(message);
            if (result.method == "Debugger.scriptParsed")
            {
                _scriptMap[result.@params.url] = result.@params.scriptId;
            }
        }

        public async Task SetSource(string filePath, string source)
        {
            if (_socket == null || _socket.State != WebSocketState.Open)
                return;

            if (!_scriptMap.TryGetValue(filePath, out var scriptId))
                return;

            var message = new SetSourceMethod()
            {
                id = _requestId++,
                method = "Debugger.setScriptSource",
                @params = new SetSourceMethod.SetSourceParams()
                {
                    scriptId = scriptId,
                    scriptSource = source
                }
            };

            var json = JsonUtility.ToJson(message);
            await _socket.SendText(json);
        }

        public void Dispose()
        {
            _socket?.Close();
        }
    }
}
