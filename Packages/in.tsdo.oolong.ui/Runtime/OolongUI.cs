using Puerts;
using TSF.Oolong;
using TSF.Oolong.UI;
using UnityEngine;

public static class OolongUI
{
    private delegate JSObject MithrilMount(IOolongElement element, JSObject component);
    private static MithrilMount s_mithrilMount;
    private delegate void MithrilUnmount(JSObject element);
    private static MithrilUnmount s_mithrilUnmount;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        var env = OolongEnvironment.JsEnv;
        env.ExecuteModule("InitializeDOM");
        env.ExecuteModule("InitializeMithril");

        s_mithrilMount = env.Eval<MithrilMount>("MithrilMount");
        s_mithrilUnmount = env.Eval<MithrilUnmount>("MithrilUnmount");

        OolongEnvironment.OnDispose += Dispose;
    }

    public static JSObject Mount(IOolongElement element, JSObject component)
    {
        return s_mithrilMount?.Invoke(element, component);
    }

    public static void Unmount(JSObject element)
    {
        s_mithrilUnmount?.Invoke(element);
    }

    private static void Dispose()
    {
        OolongEnvironment.OnDispose -= Dispose;
        s_mithrilMount = null;
        s_mithrilUnmount = null;
    }
}
