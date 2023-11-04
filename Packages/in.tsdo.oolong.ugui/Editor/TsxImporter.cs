using TSF.Oolong.Editor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TSF.Oolong.UI.Editor
{
    [ScriptedImporter(1, "tsx", AllowCaching = true)]
    public class TsxImporter : TypeScriptImporter
    {
        protected override Texture2D Icon => Icons.TsxIcon;
    }
}
