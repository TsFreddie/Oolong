using Puerts.TypeMapping;
using Puerts;

namespace PuertsStaticWrap
{
#if ENABLE_IL2CPP
    [UnityEngine.Scripting.Preserve]
#endif
    public static class RegisterOolong
    {
        
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_ScriptBehaviour_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {".ctor", new MemberRegisterInfo { Name = ".ctor", IsStatic = false, MemberType = MemberType.Constructor, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Constructor = TSF_Oolong_ScriptBehaviour_Wrap.Constructor
#endif
                    }},
                    {"SetHooks", new MemberRegisterInfo { Name = "SetHooks", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_ScriptBehaviour_Wrap.M_SetHooks
#endif
                    }},
                    {"Call", new MemberRegisterInfo { Name = "Call", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_ScriptBehaviour_Wrap.M_Call
#endif
                    }},
                    {"ClearHooks", new MemberRegisterInfo { Name = "ClearHooks", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_ScriptBehaviour_Wrap.M_ClearHooks
#endif
                    }},
                    {"KeepAsset", new MemberRegisterInfo { Name = "KeepAsset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_ScriptBehaviour_Wrap.M_KeepAsset
#endif
                    }},
                    {"GetScriptInstanceID", new MemberRegisterInfo { Name = "GetScriptInstanceID", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_ScriptBehaviour_Wrap.M_GetScriptInstanceID
#endif
                    }},
                    {"GetGameObjectInstanceID", new MemberRegisterInfo { Name = "GetGameObjectInstanceID", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_ScriptBehaviour_Wrap.M_GetGameObjectInstanceID
#endif
                    }},
                    {"HasScript", new MemberRegisterInfo { Name = "HasScript", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_HasScript
#endif
                    }},
                    {"EditorAsset", new MemberRegisterInfo { Name = "EditorAsset", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_EditorAsset
#endif
                    }},
                    {"AddressableScript", new MemberRegisterInfo { Name = "AddressableScript", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_AddressableScript, PropertySetter = TSF_Oolong_ScriptBehaviour_Wrap.S_AddressableScript
#endif
                    }},
                    {"JsAwake", new MemberRegisterInfo { Name = "JsAwake", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_JsAwake, PropertySetter = TSF_Oolong_ScriptBehaviour_Wrap.S_JsAwake
#endif
                    }},
                    {"JsStart", new MemberRegisterInfo { Name = "JsStart", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_JsStart, PropertySetter = TSF_Oolong_ScriptBehaviour_Wrap.S_JsStart
#endif
                    }},
                    {"JsOnEnable", new MemberRegisterInfo { Name = "JsOnEnable", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_JsOnEnable, PropertySetter = TSF_Oolong_ScriptBehaviour_Wrap.S_JsOnEnable
#endif
                    }},
                    {"JsOnDisable", new MemberRegisterInfo { Name = "JsOnDisable", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_JsOnDisable, PropertySetter = TSF_Oolong_ScriptBehaviour_Wrap.S_JsOnDisable
#endif
                    }},
                    {"JsOnDestroy", new MemberRegisterInfo { Name = "JsOnDestroy", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_JsOnDestroy, PropertySetter = TSF_Oolong_ScriptBehaviour_Wrap.S_JsOnDestroy
#endif
                    }},
                    {"JsCall", new MemberRegisterInfo { Name = "JsCall", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_ScriptBehaviour_Wrap.G_JsCall, PropertySetter = TSF_Oolong_ScriptBehaviour_Wrap.S_JsCall
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_OolongEnvironment_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"Attach", new MemberRegisterInfo { Name = "Attach", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.M_Attach
#endif
                    }},
                    {"Detach", new MemberRegisterInfo { Name = "Detach", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.M_Detach
#endif
                    }},
                    {"FileExists", new MemberRegisterInfo { Name = "FileExists", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.M_FileExists
#endif
                    }},
                    {"ReadFile", new MemberRegisterInfo { Name = "ReadFile", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.M_ReadFile
#endif
                    }},
                    {"Resolve", new MemberRegisterInfo { Name = "Resolve", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.M_Resolve
#endif
                    }},
                    {"add_OnTick_static", new MemberRegisterInfo { Name = "add_OnTick", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.A_OnTick
#endif
                    }},
                    {"remove_OnTick_static", new MemberRegisterInfo { Name = "remove_OnTick", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.R_OnTick
#endif
                    }},
                    {"add_OnUpdate_static", new MemberRegisterInfo { Name = "add_OnUpdate", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.A_OnUpdate
#endif
                    }},
                    {"remove_OnUpdate_static", new MemberRegisterInfo { Name = "remove_OnUpdate", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.R_OnUpdate
#endif
                    }},
                    {"add_OnFixedUpdate_static", new MemberRegisterInfo { Name = "add_OnFixedUpdate", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.A_OnFixedUpdate
#endif
                    }},
                    {"remove_OnFixedUpdate_static", new MemberRegisterInfo { Name = "remove_OnFixedUpdate", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.R_OnFixedUpdate
#endif
                    }},
                    {"add_OnLateUpdate_static", new MemberRegisterInfo { Name = "add_OnLateUpdate", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.A_OnLateUpdate
#endif
                    }},
                    {"remove_OnLateUpdate_static", new MemberRegisterInfo { Name = "remove_OnLateUpdate", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.R_OnLateUpdate
#endif
                    }},
                    {"Initialize_static", new MemberRegisterInfo { Name = "Initialize", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.F_Initialize
#endif
                    }},
                    {"DisposeInstance_static", new MemberRegisterInfo { Name = "DisposeInstance", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_OolongEnvironment_Wrap.F_DisposeInstance
#endif
                    }},
                    {"JsEnv_static", new MemberRegisterInfo { Name = "JsEnv", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_OolongEnvironment_Wrap.G_JsEnv
#endif
                    }},
                    {"Instance_static", new MemberRegisterInfo { Name = "Instance", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_OolongEnvironment_Wrap.G_Instance
#endif
                    }},
                    {"OnInitialize_static", new MemberRegisterInfo { Name = "OnInitialize", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_OolongEnvironment_Wrap.G_OnInitialize, PropertySetter = TSF_Oolong_OolongEnvironment_Wrap.S_OnInitialize
#endif
                    }},
                    {"OnDispose_static", new MemberRegisterInfo { Name = "OnDispose", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_OolongEnvironment_Wrap.G_OnDispose, PropertySetter = TSF_Oolong_OolongEnvironment_Wrap.S_OnDispose
#endif
                    }},
                }
            };
        }

        public static void AddRegisterInfoGetterIntoJsEnv(JsEnv jsEnv)
        {
            
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.ScriptBehaviour), GetRegisterInfo_TSF_Oolong_ScriptBehaviour_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.OolongEnvironment), GetRegisterInfo_TSF_Oolong_OolongEnvironment_Wrap);
        }
    }
}