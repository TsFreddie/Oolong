using System.IO;
using Puerts;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    [ScriptedImporter(1, "tsconfig.json")]
    public class TsConfigImporter : ScriptedImporter
    {
        [Multiline]
        public string Config;
        private delegate string PatchDelegate(string obj, string patch);

        public void Generate()
        {
            var jsEnv = new JsEnv(new DefaultLoader());
            var patcher = jsEnv.ExecuteModule<PatchDelegate>("oolong/tsconfig-patch", "default");
            var result = patcher(File.ReadAllText(assetPath), File.ReadAllText(assetPath + ".patch"));
            Debug.Log(result);
            jsEnv.Dispose();
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var text = File.ReadAllText(ctx.assetPath);
            var asset = new TextAsset(text);
            var icon = Icons.TsConfigIcon;
            ctx.AddObjectToAsset("text", asset, icon);
            ctx.SetMainObject(asset);
        }

        [MenuItem("Tools/PuerTS/Oolong/Create tsconfig", priority = 10000)]
        public static void Create()
        {
            var assets = AssetDatabase.FindAssets(".tsconfig t:TextAsset", new[] { "Assets" });
            if (assets.Length > 0)
            {
                if (!EditorUtility.DisplayDialog("Existing tsconfig.json found", "Seems like you already have a tsconfig.json\nDo you want to create a new one anyway?", "Yes", "No"))
                {
                    var configObject = AssetDatabase.LoadAssetAtPath<TextAsset>(AssetDatabase.GUIDToAssetPath(assets[0]));
                    EditorGUIUtility.PingObject(configObject);
                }
            }
        }
    }
}
