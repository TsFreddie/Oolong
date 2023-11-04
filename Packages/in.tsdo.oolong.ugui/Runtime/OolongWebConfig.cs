using System;
using UnityEngine.Networking;

namespace TSF.Oolong.UI
{
    public static class OolongWebConfig
    {
        public static string BaseURL = null;
        public static bool RestrictToBaseURL = false;
        public static Action<UnityWebRequest> Authenticator;

        public static void Authenticate(UnityWebRequest request)
        {
            Authenticator?.Invoke(request);
        }
    }
}
