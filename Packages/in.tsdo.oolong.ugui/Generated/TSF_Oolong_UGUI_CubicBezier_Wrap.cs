#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class TSF_Oolong_UGUI_CubicBezier_Wrap 
    {
    
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {

                if (paramLen == 4)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    JsValueType argType2 = JsValueType.Invalid;
                    IntPtr v8Value3 = PuertsDLL.GetArgumentValue(info, 3);
                    object argobj3 = null;
                    JsValueType argType3 = JsValueType.Invalid;
                    if (ArgHelper.IsMatch((int)data, isolate, Puerts.JsValueType.Number, typeof(float), false, false, v8Value0, ref argobj0, ref argType0) && ArgHelper.IsMatch((int)data, isolate, Puerts.JsValueType.Number, typeof(float), false, false, v8Value1, ref argobj1, ref argType1) && ArgHelper.IsMatch((int)data, isolate, Puerts.JsValueType.Number, typeof(float), false, false, v8Value2, ref argobj2, ref argType2) && ArgHelper.IsMatch((int)data, isolate, Puerts.JsValueType.Number, typeof(float), false, false, v8Value3, ref argobj3, ref argType3))

                    {
                        float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                        float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);
                        var result = new TSF.Oolong.UGUI.CubicBezier(arg0, arg1, arg2, arg3);


                        return Puerts.Utils.GetObjectPtr((int)data, typeof(TSF.Oolong.UGUI.CubicBezier), result);
                    }
                }
                if (paramLen == 0)
                {

                    {
                        var result = new TSF.Oolong.UGUI.CubicBezier();


                        return Puerts.Utils.GetObjectPtr((int)data, typeof(TSF.Oolong.UGUI.CubicBezier), result);
                    }
                }

                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to " + typeof(TSF.Oolong.UGUI.CubicBezier).GetFriendlyName() + " constructor");
            } catch (Exception e) {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
            return IntPtr.Zero;
        }
    // ==================== constructor end ====================

    // ==================== methods start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void M_Evaluate(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var obj = (TSF.Oolong.UGUI.CubicBezier)Puerts.Utils.GetSelf((int)data, self);
        
                {
            
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    {
                        float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);

                        var result = obj.Evaluate (arg0);

                        Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
                        Puerts.Utils.SetSelf((int)data, self, obj);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
    // ==================== methods end ====================

    // ==================== properties start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_Ease(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var result = TSF.Oolong.UGUI.CubicBezier.Ease;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void S_Ease(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 = argobj0 != null ? argobj0 : StaticTranslate<TSF.Oolong.UGUI.CubicBezier>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); TSF.Oolong.UGUI.CubicBezier arg0 = (TSF.Oolong.UGUI.CubicBezier)argobj0;
                TSF.Oolong.UGUI.CubicBezier.Ease = arg0;
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_Linear(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var result = TSF.Oolong.UGUI.CubicBezier.Linear;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void S_Linear(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 = argobj0 != null ? argobj0 : StaticTranslate<TSF.Oolong.UGUI.CubicBezier>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); TSF.Oolong.UGUI.CubicBezier arg0 = (TSF.Oolong.UGUI.CubicBezier)argobj0;
                TSF.Oolong.UGUI.CubicBezier.Linear = arg0;
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_EaseIn(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var result = TSF.Oolong.UGUI.CubicBezier.EaseIn;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void S_EaseIn(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 = argobj0 != null ? argobj0 : StaticTranslate<TSF.Oolong.UGUI.CubicBezier>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); TSF.Oolong.UGUI.CubicBezier arg0 = (TSF.Oolong.UGUI.CubicBezier)argobj0;
                TSF.Oolong.UGUI.CubicBezier.EaseIn = arg0;
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_EaseOut(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var result = TSF.Oolong.UGUI.CubicBezier.EaseOut;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void S_EaseOut(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 = argobj0 != null ? argobj0 : StaticTranslate<TSF.Oolong.UGUI.CubicBezier>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); TSF.Oolong.UGUI.CubicBezier arg0 = (TSF.Oolong.UGUI.CubicBezier)argobj0;
                TSF.Oolong.UGUI.CubicBezier.EaseOut = arg0;
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_EaseInOut(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var result = TSF.Oolong.UGUI.CubicBezier.EaseInOut;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void S_EaseInOut(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 = argobj0 != null ? argobj0 : StaticTranslate<TSF.Oolong.UGUI.CubicBezier>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); TSF.Oolong.UGUI.CubicBezier arg0 = (TSF.Oolong.UGUI.CubicBezier)argobj0;
                TSF.Oolong.UGUI.CubicBezier.EaseInOut = arg0;
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
    // ==================== properties end ====================
    // ==================== array item get/set start ====================
    
    
    // ==================== array item get/set end ====================
    // ==================== operator start ====================
    // ==================== operator end ====================
    // ==================== events start ====================
    // ==================== events end ====================

    
    }
#pragma warning disable 0219
}
#endif
