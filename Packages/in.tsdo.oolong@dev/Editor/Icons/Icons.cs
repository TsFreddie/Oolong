using UnityEditor;
using UnityEngine;
namespace TSF.Oolong.Editor
{
    public static class Icons
    {
        private const string TypeScriptIconGuid = "12126cd669390724d827478dd075622a";
        private const string JavaScriptIconGuid = "cf4a5e1559db1224791cb8717fa2b957";
        private const string TsConfigIconGuid = "e5fb06c45e37ab44ba3dd7a96020d629";

        private static Texture2D s_typeScriptIcon;
        public static Texture2D TypeScriptIcon => s_typeScriptIcon ? s_typeScriptIcon : s_typeScriptIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(TypeScriptIconGuid));
        private static Texture2D s_javaScriptIcon;
        public static Texture2D JavaScriptIcon => s_javaScriptIcon ? s_javaScriptIcon : s_javaScriptIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(JavaScriptIconGuid));
        private static Texture2D s_tsConfigIcon;
        public static Texture2D TsConfigIcon => s_tsConfigIcon ? s_tsConfigIcon : s_tsConfigIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(TsConfigIconGuid));

    }
}
