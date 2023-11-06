using System;
using System.IO;
using System.Linq;
using System.Text;
using Puerts;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    public interface ITsConfigPatcher
    {
        public string Patch();
    }

    [ScriptedImporter(1, "tsconfig.json")]
    public class TsConfigImporter : ScriptedImporter
    {
        [TextArea(10, 40)]
        public string Config;
        private delegate string PatchDelegate(string obj, string patch);

        public void Generate()
        {
            var jsEnv = new JsEnv(new DefaultLoader());
            var patcher = jsEnv.ExecuteModule<PatchDelegate>("oolong/tsconfig-patch", "default");
            var result = Config;
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ITsConfigPatcher).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (ITsConfigPatcher)Activator.CreateInstance(x))
                .ToList()
                .ForEach(x => result = patcher(result, x.Patch()));
            jsEnv.Dispose();
            File.WriteAllText(assetPath, result, Encoding.UTF8);
            SaveAndReimport();
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
