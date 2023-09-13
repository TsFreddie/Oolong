using UnityEditor;

namespace TSF.Oolong.Editor
{
    [FilePath("OolongSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class OolongSettings : ScriptableSingleton<OolongSettings>
    {
        [MenuItem("PuerTS/Oolong/Config", priority = 10000)]
        public static void Create()
        {

        }
    }
}
