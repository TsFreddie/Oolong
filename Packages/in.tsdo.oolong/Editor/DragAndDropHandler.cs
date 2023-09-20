using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TSF.Oolong.Editor
{
    [InitializeOnLoad]
    public static class DragAndDropHandler
    {
        static DragAndDropHandler()
        {
            DragAndDrop.AddDropHandler(Drag);
        }

        public static bool AreSupportedScripts(Object[] targets)
        {
            foreach (var target in targets)
            {
                if (target is not TextAsset script)
                    return false;
                var path = AssetDatabase.GetAssetPath(script);
                if (!path.EndsWith(".ts"))
                    return false;
            }
            return true;
        }

        public static void AddScriptToObjects(Object[] scripts, Object[] targets)
        {
            foreach (var target in targets)
            foreach (var script in scripts)
            {
                if (target is GameObject gameObject && script is TextAsset)
                {
                    var path = AssetDatabase.GetAssetPath(script);
                    if (!path.EndsWith(".ts")) continue;
                    var scriptBehaviour = Undo.AddComponent<ScriptBehaviour>(gameObject);
                    scriptBehaviour.AddressableScript = new AssetReferenceT<TextAsset>(AssetDatabase.AssetPathToGUID(path));
                }
            }
        }

        private static DragAndDropVisualMode Drag(Object[] targets, bool perform)
        {
            if (AreSupportedScripts(DragAndDrop.objectReferences))
            {
                if (perform)
                {
                    AddScriptToObjects(DragAndDrop.objectReferences, targets);
                    return DragAndDropVisualMode.None;
                }
                return DragAndDropVisualMode.Generic;
            }
            return DragAndDropVisualMode.None;
        }
    }
}
