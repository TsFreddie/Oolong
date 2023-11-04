using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace TSF.Oolong.UGUI
{
    [Preserve]
    public static class UnityWebRequestExtension
    {
        public delegate void JsWebCallback();

        [Preserve]
        public static void SetBody(this UnityWebRequest request, string body)
        {
            var bodyRaw = System.Text.Encoding.UTF8.GetBytes(body);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        [Preserve]
        public static void SendWithCallback(this UnityWebRequest request, JsWebCallback callback)
        {
            var handler = new DownloadHandlerBuffer();
            request.downloadHandler = handler;
            var op = request.SendWebRequest();
            op.completed += (_) => callback();
        }
    }
}
