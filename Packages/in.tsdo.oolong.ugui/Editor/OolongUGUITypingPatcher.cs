using System.IO;
using TSF.Oolong.Editor;

namespace TSF.Oolong.UGUI.Editor
{
    public class OolongUGUITypingPatcher : ITsConfigTypingPatcher
    {
        public string[] Typings() => new string[]
        {
            Path.GetFullPath("Packages/in.tsdo.oolong.ugui/Typings~"),
            Path.GetFullPath("Packages/in.tsdo.oolong.ugui/Generated/Typings~"),
        };
    }
}
