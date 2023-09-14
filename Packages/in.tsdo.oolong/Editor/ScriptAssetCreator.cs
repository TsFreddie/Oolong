using System;
using UnityEditor;

namespace TSF.Oolong.Editor
{
    public static class ScriptAssetCreator
    {
        public const string TemplateGuid = "f5aed47e87ea7a841b4e06313404100f";

        [MenuItem("Assets/Create/TypeScript", priority = -100)]
        public static void CreateTypeScript()
        {
            try
            {
                var template = AssetDatabase.GUIDToAssetPath(TemplateGuid);
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(template, "NewTypeScript.ts");
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
