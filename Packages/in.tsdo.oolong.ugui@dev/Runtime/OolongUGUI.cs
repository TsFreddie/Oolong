using Puerts;
using TSF.Oolong;
using TSF.Oolong.UGUI;
using UnityEngine;

public static class OolongUGUI
{
    private delegate JSObject MithrilMount(OolongElement element, JSObject component, bool partial);
    private static MithrilMount s_mithrilMount;
    private delegate void MithrilUnmount(JSObject element);
    private static MithrilUnmount s_mithrilUnmount;

    private static OolongEnvironment.JsUpdate s_tick;

    private delegate void MithrilRedraw();
    private static MithrilRedraw s_redraw;

    private static ITextTransformer s_textTransformer;
    private static IAddressTransformer s_addressTransformer;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void Initialize()
    {
        OolongEnvironment.OnInitialize += Init;
        OolongEnvironment.OnDispose += Dispose;

        OolongEnvironment.OnPreUpdate += PreUpdate;
        OolongEnvironment.OnUpdate += DocumentUtils.UpdateLayout;
        OolongEnvironment.OnLateUpdate += DocumentUtils.LateUpdateLayout;

        s_textTransformer = new IdentityTransformer();
        s_addressTransformer = new IdentityTransformer();
    }

    private static void Init()
    {
        var env = OolongEnvironment.JsEnv;
        env.ExecuteModule("dom");
        env.ExecuteModule("mithril");
        env.UsingFunc<OolongElement, JSObject, bool, JSObject>();

        s_mithrilMount = env.Eval<MithrilMount>("MithrilMount");
        s_mithrilUnmount = env.Eval<MithrilUnmount>("MithrilUnmount");
        s_tick = env.Eval<OolongEnvironment.JsUpdate>("MithrilTick");
        s_redraw = env.Eval<MithrilRedraw>("MithrilRedraw");

#if UNITY_EDITOR
        OolongEnvironment.HotReload.OnHotReload += OnHotReload;
#endif
    }

#if UNITY_EDITOR
    private static void OnHotReload()
    {
        s_redraw?.Invoke();
    }
#endif

    private static void PreUpdate()
    {
        s_tick?.Invoke();
    }

    public static JSObject Mount(OolongElement element, JSObject component, bool partial)
    {
        return s_mithrilMount?.Invoke(element, component, partial);
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
        s_tick = null;
    }

    public static string TransformText(string text, OolongTextLoader loader)
    {
        return s_textTransformer.Transform(text, loader);
    }

    public static string TransformAddress(string tag, string address)
    {
        return s_addressTransformer.Transform(tag, address);
    }
}
