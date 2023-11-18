using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
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

    public interface ITsConfigTypingPatcher
    {
        public string[] Typings();
    }

    [ScriptedImporter(1, "tsconfig.json")]
    public class TsConfigImporter : ScriptedImporter
    {
        private static readonly string s_defaultOutputFile = "./tsconfig.json";
        private static readonly string s_defaultConfig = @"{
    ""compilerOptions"": {
        ""target"": ""ES2021"",
        ""module"": ""ES2020"",
        ""noImplicitAny"": true,
        ""esModuleInterop"": true,
        ""isolatedModules"": true,
        ""skipLibCheck"": true,
        ""emitDecoratorMetadata"": true,
        ""experimentalDecorators"": true,
        ""sourceMap"": true,
        ""noEmit"": true
    }
}
";
        public string OutputFile = s_defaultOutputFile;
        [TextArea(10, 40)]
        public string Config = s_defaultConfig;
        public string[] CustomTypingRoots;

        private delegate string PatchDelegate(string obj, string patch);

        private static bool IsPathValid(string path)
        {
            return !string.IsNullOrEmpty(path);
        }

        private static string NormalizeRelativePath(string path)
        {
            var relativePath = path.Replace("\\", "/");
            if (!relativePath.StartsWith("./") && !relativePath.StartsWith("../"))
            {
                relativePath = $"./{relativePath}";
            }
            return relativePath;
        }

        private static string ResolveTyping(string path, string basePath)
        {
            if (!Path.IsPathRooted(path))
            {
                path = Path.GetFullPath(path, basePath);
            }

            return NormalizeRelativePath(Path.GetRelativePath(basePath, path));
        }

        public static void Generate(string config, string assetPath, string tsconfigPath, string[] customTypings)
        {
            if (!IsPathValid(tsconfigPath))
            {
                EditorUtility.DisplayDialog("Invalid Output File", "Please specify a valid output file path.", "OK");
                return;
            }

            var fullAssetPath = Path.GetFullPath(assetPath);
            var assetPathDirectory = Path.GetDirectoryName(fullAssetPath);

            if (!Path.IsPathRooted(tsconfigPath))
            {
                tsconfigPath = Path.GetFullPath(tsconfigPath, assetPathDirectory);
            }

            var jsEnv = new JsEnv(new DefaultLoader());
            var patcher = jsEnv.ExecuteModule<PatchDelegate>("oolong/tsconfig-patch", "default");
            var patches = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ITsConfigPatcher).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (ITsConfigPatcher)Activator.CreateInstance(x))
                .ToList();

            patches.Sort();
            patches.ForEach(x => config = patcher(config, x.Patch()));

            var typings = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ITsConfigTypingPatcher).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (ITsConfigTypingPatcher)Activator.CreateInstance(x))
                .SelectMany(x => x.Typings()).Where(x => !string.IsNullOrEmpty(x)).ToList();

            if (customTypings != null) typings.AddRange(customTypings);

            var normalizedTypings = typings.Select(x => ResolveTyping(x, assetPathDirectory)).ToList();
            normalizedTypings.Sort();

            var typingPatchDictionary = new Dictionary<string, List<string>>()
            {
                { "compilerOptions.typeRoots", normalizedTypings }
            };

            var typingPatch = JsonConvert.SerializeObject(typingPatchDictionary);
            config = patcher(config, typingPatch);
            jsEnv.Dispose();

            File.WriteAllText(assetPath, config, Encoding.UTF8);
            var relativePath = NormalizeRelativePath(Path.GetRelativePath(Path.GetDirectoryName(tsconfigPath), fullAssetPath));
            File.WriteAllText(tsconfigPath, $"{{\n  \"extends\": \"{relativePath.Replace("\\", "/")}\",\n}}", Encoding.UTF8);
            AssetDatabase.ImportAsset(Path.GetRelativePath(Directory.GetCurrentDirectory(), tsconfigPath));
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var text = File.ReadAllText(ctx.assetPath);
            var asset = new TextAsset(text);
            var icon = Icons.TsConfigIcon;
            ctx.AddObjectToAsset("text", asset, icon);
            ctx.SetMainObject(asset);
        }

        [MenuItem("Tools/Oolong/Create tsconfig", priority = 10000)]
        public static void Create()
        {
            var assets = AssetDatabase.FindAssets(".tsconfig t:TextAsset", new[] { "Assets" });
            if (assets.Length > 0)
            {
                if (!EditorUtility.DisplayDialog("Existing tsconfig.json found", "Seems like you already have a tsconfig.json\nDo you want to create a new one anyway?\nA new base.tsconfig.json will be created ", "Yes", "No"))
                {
                    var configObject = AssetDatabase.LoadAssetAtPath<TextAsset>(AssetDatabase.GUIDToAssetPath(assets[0]));
                    EditorGUIUtility.PingObject(configObject);
                    return;
                }
            }

            var generatorPath = EditorUtility.SaveFilePanelInProject("Create tsconfig.json", "tsconfig.json", "json", "Create tsconfig.json");
            var pathFileName = Path.GetFileName(generatorPath);
            var isPathTsConfig = pathFileName == "tsconfig.json";
            var isPathTsConfigGenerator = !isPathTsConfig && pathFileName.EndsWith(".tsconfig.json");

            if (isPathTsConfig)
            {
                generatorPath = Path.Combine(Path.GetDirectoryName(generatorPath) ?? generatorPath, "base.tsconfig.json");
            }
            else if (!isPathTsConfigGenerator)
            {
                generatorPath += ".tsconfig.json";
            }

            Generate(s_defaultConfig, generatorPath, s_defaultOutputFile, null);
            AssetDatabase.ImportAsset(generatorPath);
        }
    }
}
