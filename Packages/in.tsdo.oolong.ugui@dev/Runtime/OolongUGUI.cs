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

    private delegate void MithrilRedraw(JSObject element);
    private static MithrilRedraw s_redraw;

    private delegate void MithrilRedrawId(int mountId);
    private static MithrilRedrawId s_redrawMountId;

#if UNITY_TMP || UNITY_UGUI_2
    private static ITextTransformer s_textTransformer;
    public static ITextTransformer TextTransformer
    {
        get => s_textTransformer;
        set => s_textTransformer = value ?? new IdentityTransformer();
    }
#endif

    private static IAddressTransformer s_addressTransformer;
    public static IAddressTransformer AddressTransformer
    {
        get => s_addressTransformer;
        set => s_addressTransformer = value ?? new IdentityTransformer();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void Initialize()
    {
        OolongEnvironment.OnInitialize += Init;
        OolongEnvironment.OnDispose += Dispose;

        OolongEnvironment.OnPreUpdate += PreUpdate;
        OolongEnvironment.OnUpdate += DocumentUtils.UpdateLayout;
        OolongEnvironment.OnLateUpdate += DocumentUtils.LateUpdateLayout;

#if UNITY_TMP || UNITY_UGUI_2
        s_textTransformer = new IdentityTransformer();
#endif

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
        s_redrawMountId = env.Eval<MithrilRedrawId>("CustomRedraw");

        DocumentUtils.Initialize();

#if UNITY_EDITOR
        OolongEnvironment.HotReload.OnHotReload += OnHotReload;
#endif
    }

#if UNITY_EDITOR
    private static void OnHotReload()
    {
        s_redraw?.Invoke(null);
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

    public static void Redraw(JSObject element = null)
    {
        s_redraw?.Invoke(element);
    }

    public static void Redraw(int mountId = 0)
    {
        s_redrawMountId?.Invoke(mountId);
    }

    private static void Dispose()
    {
        OolongEnvironment.OnDispose -= Dispose;
        DocumentUtils.Dispose();
        s_mithrilMount = null;
        s_mithrilUnmount = null;
        s_tick = null;
    }

#if UNITY_TMP || UNITY_UGUI_2
    public static string TransformText(string text, OolongTextLoader loader)
    {
        return s_textTransformer.Transform(text, loader);
    }
#endif

    public static string TransformAddress(string tag, string address)
    {
        return s_addressTransformer.Transform(tag, address);
    }
}
