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

            var configProperty = serializedObject.FindProperty("Config");
            // draw text area
            EditorGUILayout.PropertyField(configProperty, GUIContent.none, GUILayout.Height(400));

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Generate"))
            {
                importer.Generate();
            }

            ApplyRevertGUI();
        }
    }
}
