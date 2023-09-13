using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    [ScriptedImporter(1, "js", AllowCaching = true)]
    public class JavaScriptImporter : ScriptedImporter
    {
        public bool ExcludeInAddressable;

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var text = File.ReadAllText(ctx.assetPath);
            var asset = new TextAsset(text);
            var icon = Icons.JavaScriptIcon;
            ctx.AddObjectToAsset("text", asset, icon);
            ctx.SetMainObject(asset);
        }
    }
}
