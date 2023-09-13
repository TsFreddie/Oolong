using UnityEditor;
using UnityEditor.AssetImporters;
namespace TSF.Oolong.Editor
{
    [CustomEditor(typeof(TsConfigImporter))]
    public class TsConfigImporterEditor : ScriptedImporterEditor
    {
        public override void OnInspectorGUI()
        {
            ApplyRevertGUI();
        }
    }
}
