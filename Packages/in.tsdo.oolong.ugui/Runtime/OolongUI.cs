using Puerts;
using TSF.Oolong;
using TSF.Oolong.UGUI;
using UnityEngine;

public static class OolongUI
{
    private delegate JSObject MithrilMount(IOolongElement element, JSObject component);
    private static MithrilMount s_mithrilMount;
    private delegate void MithrilUnmount(JSObject element);
    private static MithrilUnmount s_mithrilUnmount;

    private static OolongEnvironment.JsUpdate s_tick;

    private static ITextTransformer s_textTransformer;
    private static IAddressTransformer s_addressTransformer;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void Initialize()
    {
        OolongEnvironment.OnInitialize += Init;
        OolongEnvironment.OnDispose += Dispose;

        OolongEnvironment.OnTick += Tick;
        OolongEnvironment.OnUpdate += DocumentUtils.UpdateLayout;
        OolongEnvironment.OnLateUpdate += DocumentUtils.LateUpdateLayout;

        s_textTransformer = new LocalizationTransformer();
        s_addressTransformer = new IdentityTransformer();
    }

    private static void Init()
    {
        var env = OolongEnvironment.JsEnv;
        env.ExecuteModule("dom");
        env.ExecuteModule("mithril");

        s_mithrilMount = env.Eval<MithrilMount>("MithrilMount");
        s_mithrilUnmount = env.Eval<MithrilUnmount>("MithrilUnmount");
        s_tick = env.Eval<OolongEnvironment.JsUpdate>("MithrilTick");
    }

    private static void Tick()
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
        DocumentUtils.Dispose();
        s_mithrilMount = null;
        s_mithrilUnmount = null;
    }

    public static string TransformText(string text)
    {
        return s_textTransformer.Transform(text);
    }

    public static string TransformAddress(string tag, string address)
    {
        return s_addressTransformer.Transform(tag, address);
    }
}
