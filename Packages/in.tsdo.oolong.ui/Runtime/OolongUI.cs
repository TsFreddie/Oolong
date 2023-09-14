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

    private static OolongEnvironment.JsUpdate s_tick;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        var env = OolongEnvironment.JsEnv;
        env.ExecuteModule("InitializeDOM");
        env.ExecuteModule("InitializeMithril");

        s_mithrilMount = env.Eval<MithrilMount>("MithrilMount");
        s_mithrilUnmount = env.Eval<MithrilUnmount>("MithrilUnmount");
        // TODO: I want to move window to MithrilComponent so we can technically have multiple routes
        s_tick = env.Eval<OolongEnvironment.JsUpdate>("() => {window.tick();}");

        OolongEnvironment.OnTick += Tick;
        OolongEnvironment.OnUpdate += DocumentUtils.UpdateLayout;
        OolongEnvironment.OnLateUpdate += DocumentUtils.LateUpdateLayout;
        OolongEnvironment.OnDispose += Dispose;
    }

    public static void Tick()
    {
        s_tick?.Invoke();
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
