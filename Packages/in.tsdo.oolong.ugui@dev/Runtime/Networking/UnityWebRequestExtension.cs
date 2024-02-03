using System.Runtime.CompilerServices;
using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace TSF.Oolong.UGUI
{
    [Preserve]
    public static class UnityWebRequestExtension
    {
        public delegate void JsWebCallback();

        [Preserve]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityWebRequest Create()
        {
            return new UnityWebRequest();
        }

        [Preserve]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetArrayBufferBody(this UnityWebRequest request, Puerts.ArrayBuffer body)
        {
            request.uploadHandler = new UploadHandlerRaw(body.Bytes);
        }

        [Preserve]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStringBody(this UnityWebRequest request, string body)
        {
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
        }

        [Preserve]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SendWithCallback(this UnityWebRequest request, JsWebCallback callback)
        {
            var handler = new DownloadHandlerBuffer();
            request.downloadHandler = handler;
            var op = request.SendWebRequest();
            op.completed += (_) => callback();
        }

        [Preserve]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Puerts.ArrayBuffer GetArrayBuffer(this DownloadHandler handler)
        {
            return new Puerts.ArrayBuffer(handler.data);
        }
    }
}
