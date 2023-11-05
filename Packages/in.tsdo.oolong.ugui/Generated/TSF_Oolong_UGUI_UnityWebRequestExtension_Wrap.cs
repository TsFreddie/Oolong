#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class TSF_Oolong_UGUI_UnityWebRequestExtension_Wrap 
    {
    
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {

                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to " + typeof(TSF.Oolong.UGUI.UnityWebRequestExtension).GetFriendlyName() + " constructor");
            } catch (Exception e) {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
            return IntPtr.Zero;
        }
    // ==================== constructor end ====================

    // ==================== methods start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_SetBody(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
        
                {
            
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    ;
                    {
                        argobj0 = argobj0 != null ? argobj0 : StaticTranslate<UnityEngine.Networking.UnityWebRequest>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); UnityEngine.Networking.UnityWebRequest arg0 = (UnityEngine.Networking.UnityWebRequest)argobj0;
                        argobj1 = argobj1 != null ? argobj1 : StaticTranslate<Puerts.ArrayBuffer>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value1, false); Puerts.ArrayBuffer arg1 = (Puerts.ArrayBuffer)argobj1;

                        TSF.Oolong.UGUI.UnityWebRequestExtension.SetBody (arg0, arg1);

                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_SendWithCallback(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
        
                {
            
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    ;
                    {
                        argobj0 = argobj0 != null ? argobj0 : StaticTranslate<UnityEngine.Networking.UnityWebRequest>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); UnityEngine.Networking.UnityWebRequest arg0 = (UnityEngine.Networking.UnityWebRequest)argobj0;
                        argobj1 = argobj1 != null ? argobj1 : StaticTranslate<TSF.Oolong.UGUI.UnityWebRequestExtension.JsWebCallback>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value1, false); TSF.Oolong.UGUI.UnityWebRequestExtension.JsWebCallback arg1 = (TSF.Oolong.UGUI.UnityWebRequestExtension.JsWebCallback)argobj1;

                        TSF.Oolong.UGUI.UnityWebRequestExtension.SendWithCallback (arg0, arg1);

                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_GetArrayBuffer(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
        
                {
            
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    {
                        argobj0 = argobj0 != null ? argobj0 : StaticTranslate<UnityEngine.Networking.DownloadHandlerBuffer>.Get((int)data, isolate, NativeValueApi.GetValueFromArgument, v8Value0, false); UnityEngine.Networking.DownloadHandlerBuffer arg0 = (UnityEngine.Networking.DownloadHandlerBuffer)argobj0;

                        var result = TSF.Oolong.UGUI.UnityWebRequestExtension.GetArrayBuffer (arg0);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
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
