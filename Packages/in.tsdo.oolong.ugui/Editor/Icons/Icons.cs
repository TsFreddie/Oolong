using UnityEditor;
using UnityEngine;

namespace TSF.Oolong.UI.Editor
{
    public static class Icons
    {
        private const string TsxIconGuid = "f22104a71cfda57469fd661aaba6650d";

        private static Texture2D s_tsxIcon;
        public static Texture2D TsxIcon => s_tsxIcon ? s_tsxIcon : s_tsxIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(TsxIconGuid));
    }
}
