using System.Reflection;
using UnityEditor;
namespace TSF.Oolong.Editor
{
    /// <summary>
    /// Automatically disable ScriptBehaviour annotation icon
    /// </summary>
    public class AnnotationInjector
    {
        [InitializeOnLoadMethod]
        public static void InjectAnnotation()
        {
            EditorApplication.delayCall += Process;
        }

        private static void Process()
        {
            var annotationUtility = typeof(GizmoUtility).Assembly.GetType("UnityEditor.AnnotationUtility");
            var setIcon = annotationUtility.GetMethod("SetIconEnabled", BindingFlags.Static | BindingFlags.NonPublic);
            setIcon?.Invoke(null, new object[] { 114, "ScriptBehaviour", 0 });
        }
    }
}
