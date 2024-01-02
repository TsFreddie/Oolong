using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace TSF.Oolong.UGUI
{
    [Preserve]
    public static class UnityWebRequestExtension
    {
        public delegate void JsWebCallback();

        [Preserve]
        public static void SetBody(this UnityWebRequest request, Puerts.ArrayBuffer body)
        {
            request.uploadHandler = new UploadHandlerRaw(body.Bytes);
        }

        [Preserve]
        public static void SendWithCallback(this UnityWebRequest request, JsWebCallback callback)
        {
            var handler = new DownloadHandlerBuffer();
            request.downloadHandler = handler;
            var op = request.SendWebRequest();
            op.completed += (_) => callback();
        }

        [Preserve]
        public static Puerts.ArrayBuffer GetArrayBuffer(this DownloadHandler handler)
        {
            return new Puerts.ArrayBuffer(handler.data);
        }
    }
}
