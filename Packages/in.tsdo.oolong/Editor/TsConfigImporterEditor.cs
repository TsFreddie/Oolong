using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    [CustomEditor(typeof(TsConfigImporter))]
    public class TsConfigImporterEditor : ScriptedImporterEditor
    {
        private bool IsInAssetsFolder(string path)
        {
            return path.StartsWith("Assets/");
        }

        public override void OnInspectorGUI()
        {
            var importer = target as TsConfigImporter;
            if (!importer) return;

            if (!IsInAssetsFolder(importer.assetPath)) return;

            if (GUILayout.Button("Generate"))
            {
                Apply();
                importer.Generate();
            }

            var configProperty = serializedObject.FindProperty("Config");
            // draw text area
            EditorGUILayout.PropertyField(configProperty, GUIContent.none);

            serializedObject.ApplyModifiedProperties();
            ApplyRevertGUI();
        }
    }
}
