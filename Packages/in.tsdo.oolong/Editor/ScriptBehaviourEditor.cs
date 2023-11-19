using UnityEditor;
using UnityEngine;

namespace TSF.Oolong.Editor
{
    [CustomEditor(typeof(ScriptBehaviour))]
    public class ScriptBehaviourEditor : UnityEditor.Editor
    {
        private GUIContent _scriptLabel = new GUIContent("Script");
        private SerializedProperty _script;

        public ScriptBehaviour Target => target as ScriptBehaviour;

        protected void OnEnable()
        {
            _script = serializedObject.FindProperty(nameof(ScriptBehaviour.AddressableScript));
        }

        private bool CheckIfAssetIsValid()
        {
            return Target && Target.EditorAsset;
        }

        public override void OnInspectorGUI()
        {
            var validAsset = CheckIfAssetIsValid();
            using (new EditorGUI.DisabledScope(validAsset))
            {
                EditorGUILayout.PropertyField(_script, _scriptLabel);
            }
            if (!validAsset)
            {
                EditorGUILayout.HelpBox("The associated script can not be loaded.\nPlease fix any compile errors\nand assign a valid script.", MessageType.Warning);
            }
        }
    }
}
