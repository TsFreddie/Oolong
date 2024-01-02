using UnityEditor;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    public class DebuggerSettingsWindow : EditorWindow
    {
        [MenuItem("Tools/Oolong/Debugger Settings", false, 100)]
        public static void Open()
        {
            var window = GetWindow<DebuggerSettingsWindow>();
            window.titleContent = new GUIContent("Oolong Debugger");
            window.maxSize = new Vector2(300, 100);
            window.Show();
        }

        private SerializedObject _settings;
        private SerializedProperty _port;
        private SerializedProperty _waitForDebugger;

        public void OnEnable()
        {
            _settings = new SerializedObject(DebuggerSettings.instance);
            using (new EditorGUI.DisabledScope(Application.isPlaying))
            {
                _port = _settings.FindProperty("Port");
            }
            _waitForDebugger = _settings.FindProperty("WaitForDebugger");
        }

        public void OnGUI()
        {
            _settings.Update();

            EditorGUILayout.PropertyField(_port);
            EditorGUILayout.PropertyField(_waitForDebugger);

            if (_settings.ApplyModifiedPropertiesWithoutUndo())
            {
                DebuggerSettings.instance.Save();
            }
        }
    }
}
