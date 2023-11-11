using System.IO;
namespace TSF.Oolong.Editor
{
    public static class SourceMap
    {
        public static string Map(string path)
        {
            var cachePath = OolongEnvironment.GetCachePath();
            var mapFile = Path.Combine(cachePath, path) + ".map";
            return File.Exists(mapFile) ? mapFile : null;
        }

        public static string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
