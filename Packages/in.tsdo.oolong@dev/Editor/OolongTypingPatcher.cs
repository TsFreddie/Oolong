using System.IO;

namespace TSF.Oolong.Editor
{
    public class OolongTypingPatcher : ITsConfigTypingPatcher
    {
        public string[] Typings() => new string[]
        {
            Path.GetFullPath("Packages/in.tsdo.oolong/Typings~"),
            Path.GetFullPath("Packages/in.tsdo.oolong/Generated/Typings~"),
        };
    }
}
