using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TSF.Oolong.Editor
{
    [ScriptedImporter(1, "js", AllowCaching = false)]
    public class JavaScriptImporter : ScriptedImporter
    {
        public static string SwcConfig = Path.GetFullPath("Packages/in.tsdo.oolong/Support~/.swcrc");

        public bool ExcludeInAddressable;

        protected virtual Texture2D Icon => Icons.JavaScriptIcon;
        protected virtual string SwcConfigPath => SwcConfig;

        private static string s_compilerPath = null;

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

        private static void ClearCacheInternal()
        {
            var cachePath = OolongEnvironment.GetCachePath();
            if (Directory.Exists(cachePath))
                Directory.Delete(cachePath, true);
        }

        [MenuItem("Tools/Oolong/Clear script cache", priority = 20000)]
        public static void ClearCache()
        {
            ClearCacheInternal();
            Debug.Log("Script cache cleared");
        }

        [MenuItem("Tools/Oolong/Recompile all", priority = 20001)]
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

                    if (importers.Any(importer => typeof(TypeScriptImporter).IsAssignableFrom(importer)))
                    {
                        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
                    }
                }
            }
        }

        public void CompileFile(string outDir, string filePath)
        {
            s_compilerPath ??= GetCompilerPath();
            if (s_compilerPath == null)
                throw new FileNotFoundException("TypeScript transpiling is not supported on current platform");

            var realFilePath = Path.GetFullPath(filePath);
            var relativeFilePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), realFilePath);
            relativeFilePath = relativeFilePath.Replace("\\", "/");
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = s_compilerPath,
                ArgumentList =
                {
                    "compile",
                    "--config-file",
                    SwcConfigPath,
                    "--source-maps",
                    "true",
                    "--source-file-name",
                    realFilePath,
                    "--out-dir",
                    outDir,
                    relativeFilePath
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

        protected virtual string Compile(AssetImportContext ctx, string outDir, string compiledPath)
        {
            // Do not import definitions
            if (ctx.assetPath.EndsWith(".d.ts")) return null;

            // delete old file if exists
            if (File.Exists(compiledPath)) File.Delete(compiledPath);
            CompileFile(outDir, ctx.assetPath);
            return File.ReadAllText(compiledPath);
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var path = ctx.assetPath ?? assetPath;
            var realPath = Path.GetFullPath(path);
            var relativePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), realPath);
            var outDir = OolongEnvironment.GetCachePath();
            var compiledFileName = Path.ChangeExtension(relativePath, ".js");
            var compiledPath = Path.Combine(outDir, compiledFileName);
#if UNITY_EDITOR_WIN
            compiledPath = compiledPath.Replace("/", "\\");
#endif
            var text = Compile(ctx, outDir, compiledPath);
            if (text == null) return;
            var asset = new TextAsset(text);
            ctx.AddObjectToAsset("text", asset, Icon);
            ctx.SetMainObject(asset);
            OolongEnvironment.HotReload?.SetSource(compiledPath, text);
        }
    }
}
