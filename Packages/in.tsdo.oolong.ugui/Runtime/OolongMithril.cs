namespace TSF.Oolong.UGUI
{
    public static class OolongMithril
    {
        private delegate void MithrilCallDelegate();
        private delegate string MithrilGetDelegate();
        private delegate void MithrilSetDelegate(string value);

        private static MithrilCallDelegate s_callDelegate;
        private static MithrilGetDelegate s_getDelegate;
        private static MithrilSetDelegate s_setDelegate;

        // TODO: Add routing control, probably to a script behaviour
        // public static void SetRoute(string route)
        // {
        //     s_setDelegate ??= FRScriptEnvironment.Instance.Eval<MithrilSetDelegate>("(s)=>{require('mithril').route.set(s);}");
        //     s_setDelegate?.Invoke(route);
        // }
        //
        // public static string GetRoute()
        // {
        //     s_getDelegate ??= FRScriptEnvironment.Instance.Eval<MithrilGetDelegate>("(s)=>{require('mithril').route.get();}");
        //     return s_getDelegate?.Invoke();
        // }
        //
        // public static void Redraw()
        // {
        //     s_callDelegate ??= FRScriptEnvironment.Instance.Eval<MithrilCallDelegate>("(s)=>{require('mithril').redraw();}");
        //     s_callDelegate?.Invoke();
        // }
    }
}
