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
            if (!importer)
            {
                ApplyRevertGUI();
                return;
            }

            EditorGUILayout.HelpBox("This is a tsconfig.json generator.\nThis is designed to work with Unity import system.\nA tsconfig.json file will be generated to reference this generator file.", MessageType.Info);

            using (new EditorGUI.DisabledScope(!IsInAssetsFolder(importer.assetPath)))
            {
                var outputProperty = serializedObject.FindProperty("OutputFile");
                var configProperty = serializedObject.FindProperty("Config");
                var customTypingRootsProperty = serializedObject.FindProperty("CustomTypingRoots");

                if (GUILayout.Button("Generate"))
                {
                    Apply();
                    serializedObject.ApplyModifiedProperties();
                    TsConfigImporter.Generate(importer.Config, importer.assetPath, importer.OutputFile, importer.CustomTypingRoots);
                    importer.SaveAndReimport();
                }

                EditorGUILayout.PropertyField(outputProperty);
                EditorGUILayout.PropertyField(customTypingRootsProperty);
                EditorGUILayout.PropertyField(configProperty, GUIContent.none);
            }
            serializedObject.ApplyModifiedProperties();
            ApplyRevertGUI();
        }
    }
}
