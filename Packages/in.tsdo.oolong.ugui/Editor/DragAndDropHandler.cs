using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TSF.Oolong.UI.Editor
{
    [InitializeOnLoad]
    public static class DragAndDropHandler
    {
        static DragAndDropHandler()
        {
            DragAndDrop.RemoveDropHandler(Drag);
            DragAndDrop.AddDropHandler(Drag);
        }

        public static bool AreSupportedScripts(Object[] targets)
        {
            foreach (var target in targets)
            {
                if (target is not TextAsset script)
                    return false;
                var path = AssetDatabase.GetAssetPath(script);
                if (!path.EndsWith(".tsx"))
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
                    if (!path.EndsWith(".tsx")) continue;
                    var scriptBehaviour = Undo.AddComponent<MithrilComponent>(gameObject);
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
