using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    [ScriptedImporter(1, "js", AllowCaching = true)]
    public class JavaScriptImporter : ScriptedImporter
    {
        public bool ExcludeInAddressable;

        protected virtual Texture2D Icon => Icons.JavaScriptIcon;

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var text = Compile(ctx);
            if (text == null) return;
            var asset = new TextAsset(text);
            ctx.AddObjectToAsset("text", asset, Icon);
            ctx.SetMainObject(asset);
        }

        protected virtual string Compile(AssetImportContext ctx)
        {
            return File.ReadAllText(ctx.assetPath);
        }
    }
}
