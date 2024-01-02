using System;
using UnityEditor;

namespace TSF.Oolong.UGUI.Editor
{
    public static class ScriptAssetCreator
    {
        public const string TemplateGuid = "33d4d3565711766418b478d27d910417";

        [MenuItem("Assets/Create/Mithril Component", priority = -101)]
        public static void CreateTypeScript()
        {
            try
            {
                var template = AssetDatabase.GUIDToAssetPath(TemplateGuid);
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(template, "NewComponent.tsx");
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
