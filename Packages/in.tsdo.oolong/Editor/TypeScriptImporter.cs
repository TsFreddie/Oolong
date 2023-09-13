using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor.AssetImporters;
using System.IO;
using System.Linq;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace TSF.Oolong.Editor
{
    [ScriptedImporter(1, "ts", AllowCaching = true)]
    public class TypeScriptImporter : JavaScriptImporter
    {
        private static string s_compilerPath = null;

        public static string SwcConfig = Path.GetFullPath("Packages/in.tsdo.oolong/Support~/.swcrc");
        public static string GetCompilerPath()
        {
            const string executable =
#if UNITY_EDITOR_WIN
                "swc-win32-x64-msvc.exe";
#else
                null;
#endif
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return executable != null ? Path.GetFullPath($"Packages/in.tsdo.oolong/Support~/swc/{executable}") : null;
        }

        public static string GetCachePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Library", "OolongCache");
        }

        private static void ClearCacheInternal()
        {
            var cachePath = GetCachePath();
            if (Directory.Exists(cachePath))
                Directory.Delete(cachePath, true);
        }

        [MenuItem("PuerTS/Oolong/Clear script cache", priority = 20000)]
        public static void ClearCache()
        {
            ClearCacheInternal();
            Debug.Log("Script cache cleared");
        }

        [MenuItem("PuerTS/Oolong/Recompile all", priority = 20001)]
        public static void RecompileAll()
        {
            ClearCacheInternal();

            // Find all ts file and reimport them
            Reimport(AssetDatabase.FindAssets("t:TextAsset"));
            Reimport(AssetDatabase.FindAssets("t:DefaultAsset"));

            Debug.Log("Recompiled all scripts");
            return;

            void Reimport(IEnumerable<string> assets)
            {
                foreach (var asset in assets)
                {
                    var path = AssetDatabase.GUIDToAssetPath(asset);
                    var importers = AssetDatabase.GetAvailableImporters(path);
                    if (importers == null)
                        continue;

                    if (importers.Any(importer => importer == typeof(TypeScriptImporter)))
                    {
                        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
                    }
                }
            }
        }

        public static void CompileFile(string outDir, string filePath)
        {
            s_compilerPath ??= GetCompilerPath();
            if (s_compilerPath == null)
                throw new FileNotFoundException("TypeScript transpiling is not supported on current platform");

            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = s_compilerPath,
                ArgumentList =
                {
                    "compile",
                    "--config-file",
                    SwcConfig,
                    "--source-maps",
                    "true",
                    "--out-dir",
                    outDir,
                    filePath
                },
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = Directory.GetCurrentDirectory()
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit(10000);
            if (process.ExitCode != 0)
            {
                var error = process.StandardError.ReadToEnd();
                throw new System.Exception(error);
            }
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            // Do not import definitions
            if (ctx.assetPath.EndsWith(".d.ts")) return;
            var cachePath = GetCachePath();
            var path = ctx.assetPath;
            var dir = Path.GetDirectoryName(path) ?? string.Empty;
            var targetFilename = Path.Combine(cachePath, dir, $"{Path.GetFileNameWithoutExtension(path)}.js");

            // delete old file if exists
            if (File.Exists(targetFilename)) File.Delete(targetFilename);

            CompileFile(cachePath, ctx.assetPath);

            var body = File.ReadAllText(targetFilename);
            var asset = new TextAsset(body);
            var icon = Icons.TypeScriptIcon;
            ctx.AddObjectToAsset("text", asset, icon);
            ctx.SetMainObject(asset);
        }
    }
}
