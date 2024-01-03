#if UNITY_EDITOR
using UnityEditor;

namespace TSF.Oolong
{
    [FilePath("UserSettings/OolongDebuggerSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class DebuggerSettings : ScriptableSingleton<DebuggerSettings>
    {
        public int Port = 9229;
        public bool WaitForDebugger;

        public void Save()
        {
            Save(true);
        }
    }
}
#endif
