using UnityEngine;
using UnityEditor.AssetImporters;

namespace TSF.Oolong.Editor
{
    [ScriptedImporter(1, "ts", AllowCaching = false)]
    public class TypeScriptImporter : JavaScriptImporter
    {
        protected override Texture2D Icon => Icons.TypeScriptIcon;
    }
}
