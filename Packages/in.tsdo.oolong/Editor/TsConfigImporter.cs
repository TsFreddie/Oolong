using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

namespace TSF.Oolong.Editor
{
    [ScriptedImporter(1, "tsconfig.json")]
    public class TsConfigImporter : ScriptedImporter
    {
        public string[] Typings = Array.Empty<string>();
        public string JsxProvider = null;

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var text = File.ReadAllText(ctx.assetPath);
            var asset = new TextAsset(text);
            var icon = Icons.TsConfigIcon;
            ctx.AddObjectToAsset("text", asset, icon);
            ctx.SetMainObject(asset);
        }
    }
}
