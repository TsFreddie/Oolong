using System.IO;
using TSF.Oolong.Editor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TSF.Oolong.UGUI.Editor
{
    [ScriptedImporter(1, "tsx", AllowCaching = false)]
    public class TsxImporter : TypeScriptImporter
    {
        public static string JsxSwcConfig = Path.GetFullPath("Packages/in.tsdo.oolong.ugui/Support~/.swcrc");
        protected override Texture2D Icon => Icons.TsxIcon;
        protected override string SwcConfigPath => JsxSwcConfig;
    }
}
