#if OOLONG_DEV

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Puerts;
using UnityEditor;
using Puerts.Editor.Generator.DTS;
using Puerts.Editor.Generator.Wrapper;

namespace TSF.Oolong.Editor.Generator
{
    public static class Generate
    {
        private const string GeneratedDirectory = "fd1f987094e54e1482e92155e2562674";

        private static readonly List<Type> s_bindings = new()
        {
            typeof(ScriptBehaviour),
            typeof(OolongEnvironment),
        };

        [MenuItem("Oolong/Generate oolong")]
        public static void GenerateOolong()
        {
            GenerateDts();
            GenerateWrappers();
            GenerateRegisterInfo();

            AssetDatabase.ImportAsset(AssetDatabase.GUIDToAssetPath(GeneratedDirectory), ImportAssetOptions.ForceUpdate | ImportAssetOptions.ImportRecursive);
        }

        private static void GenerateDts()
        {
            var path = AssetDatabase.GUIDToAssetPath(GeneratedDirectory);
            var target = Path.Combine(path, "Typings~/csharp-oolong/index.d.ts");
            var directory = Path.GetDirectoryName(target);
            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using var jsEnv = new JsEnv(new DefaultLoader());
            jsEnv.UsingFunc<TypingGenInfo, bool, string>();
            var typingRender = jsEnv.ExecuteModule<Func<TypingGenInfo, bool, string>>("puerts/templates/dts.tpl.mjs", "default");
            using var textWriter = new StreamWriter(target, false, Encoding.UTF8);
            var fileContext = typingRender(TypingGenInfo.FromTypes(s_bindings), false);
            textWriter.Write(fileContext);
            textWriter.Flush();
        }

        private static void GenerateWrappers()
        {
            var path = AssetDatabase.GUIDToAssetPath(GeneratedDirectory);

            using var jsEnv = new JsEnv(new DefaultLoader());
            var wrapRender = jsEnv.ExecuteModule<Func<StaticWrapperInfo, string>>("puerts/templates/wrapper.tpl.mjs", "default");


            var makeFileUniqueMap = new Dictionary<string, bool>();
            var wrapperInfoMap = new Dictionary<Type, StaticWrapperInfo>();
            foreach (var type in s_bindings)
            {
                var staticWrapperInfo = StaticWrapperInfo.FromType(type, s_bindings);
                staticWrapperInfo.BlittableCopy = false;

                wrapperInfoMap[type] = staticWrapperInfo;
            }

            foreach (var item in wrapperInfoMap)
            {
                var staticWrapperInfo = item.Value;

                var filePath = Path.Combine(path, staticWrapperInfo.WrapClassName + ".cs");

                var uniqueId = 1;
                if (makeFileUniqueMap.ContainsKey(filePath.ToLower()) && staticWrapperInfo.IsGenericWrapper)
                    continue;

                while (makeFileUniqueMap.ContainsKey(filePath.ToLower()))
                {
                    filePath = Path.Combine(path, staticWrapperInfo.WrapClassName + "_" + uniqueId + ".cs");
                    uniqueId++;
                }
                makeFileUniqueMap.Add(filePath.ToLower(), true);

                var fileContent = wrapRender(staticWrapperInfo);
                using var textWriter = new StreamWriter(filePath, false, Encoding.UTF8);
                textWriter.Write(fileContent);
                textWriter.Flush();
            }
        }

        private static void GenerateRegisterInfo()
        {
            var path = AssetDatabase.GUIDToAssetPath(GeneratedDirectory);
            var type = Type.GetType("Puerts.Editor.Generator.RegisterInfoGenerator, com.tencent.puerts.core.Editor");

            var getRegisterInfos = type.GetMethod("GetRegisterInfos", BindingFlags.Static | BindingFlags.Public);
            var registerInfos = getRegisterInfos.Invoke(null, new object[] { s_bindings, new HashSet<Type>() });

            using var jsEnv = new JsEnv();
            var registerInfoRender = jsEnv.ExecuteModule<Func<object, string, string>>("oolong/templates/registerinfo.tpl.mjs", "default");
            var registerInfoContent = registerInfoRender(registerInfos, "RegisterOolong");
            var registerInfoPath = Path.Combine(path, "RegisterInfo_Gen.cs");
            using var textWriter = new StreamWriter(registerInfoPath, false, Encoding.UTF8);
            textWriter.Write(registerInfoContent);
            textWriter.Flush();
        }
    }
}

#endif
