using TSF.Oolong.Editor;
namespace TSF.Oolong.UGUI.Editor
{
    internal class TsConfigTsxPatcher : ITsConfigPatcher
    {
        public string Patch()
        {
            return @"{
  ""compilerOptions.jsx"": ""react"",
  ""compilerOptions.jsxFactory"": ""m"",
  ""compilerOptions.jsxFragmentFactory"": ""m.Fragment""
}";
        }
    }
}
