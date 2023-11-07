using Puerts.TypeMapping;
using Puerts;

namespace PuertsStaticWrap
{
#if ENABLE_IL2CPP
    [UnityEngine.Scripting.Preserve]
#endif
    public static class RegisterOolongUGUI
    {
        
        public static RegisterInfo GetRegisterInfo_OolongUGUI_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"Initialize_static", new MemberRegisterInfo { Name = "Initialize", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = OolongUGUI_Wrap.F_Initialize
#endif
                    }},
                    {"Mount_static", new MemberRegisterInfo { Name = "Mount", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = OolongUGUI_Wrap.F_Mount
#endif
                    }},
                    {"Unmount_static", new MemberRegisterInfo { Name = "Unmount", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = OolongUGUI_Wrap.F_Unmount
#endif
                    }},
                    {"TransformText_static", new MemberRegisterInfo { Name = "TransformText", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = OolongUGUI_Wrap.F_TransformText
#endif
                    }},
                    {"TransformAddress_static", new MemberRegisterInfo { Name = "TransformAddress", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = OolongUGUI_Wrap.F_TransformAddress
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_DocumentUtils_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"AttachElement_static", new MemberRegisterInfo { Name = "AttachElement", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_AttachElement
#endif
                    }},
                    {"DetachElement_static", new MemberRegisterInfo { Name = "DetachElement", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_DetachElement
#endif
                    }},
                    {"RemoveElement_static", new MemberRegisterInfo { Name = "RemoveElement", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_RemoveElement
#endif
                    }},
                    {"ResetElement_static", new MemberRegisterInfo { Name = "ResetElement", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_ResetElement
#endif
                    }},
                    {"InsertElement_static", new MemberRegisterInfo { Name = "InsertElement", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_InsertElement
#endif
                    }},
                    {"CreateElement_static", new MemberRegisterInfo { Name = "CreateElement", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_CreateElement
#endif
                    }},
                    {"CacheElement_static", new MemberRegisterInfo { Name = "CacheElement", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_CacheElement
#endif
                    }},
                    {"CreateChildRect_static", new MemberRegisterInfo { Name = "CreateChildRect", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_CreateChildRect
#endif
                    }},
                    {"ParseColor_static", new MemberRegisterInfo { Name = "ParseColor", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_ParseColor
#endif
                    }},
                    {"Dispose_static", new MemberRegisterInfo { Name = "Dispose", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_Dispose
#endif
                    }},
                    {"UpdateLayout_static", new MemberRegisterInfo { Name = "UpdateLayout", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_UpdateLayout
#endif
                    }},
                    {"LateUpdateLayout_static", new MemberRegisterInfo { Name = "LateUpdateLayout", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_DocumentUtils_Wrap.F_LateUpdateLayout
#endif
                    }},
                    {"OnDocumentPreUpdate_static", new MemberRegisterInfo { Name = "OnDocumentPreUpdate", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_DocumentUtils_Wrap.G_OnDocumentPreUpdate, PropertySetter = TSF_Oolong_UGUI_DocumentUtils_Wrap.S_OnDocumentPreUpdate
#endif
                    }},
                    {"OnDocumentUpdate_static", new MemberRegisterInfo { Name = "OnDocumentUpdate", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_DocumentUtils_Wrap.G_OnDocumentUpdate, PropertySetter = TSF_Oolong_UGUI_DocumentUtils_Wrap.S_OnDocumentUpdate
#endif
                    }},
                    {"OnDocumentLateUpdate_static", new MemberRegisterInfo { Name = "OnDocumentLateUpdate", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_DocumentUtils_Wrap.G_OnDocumentLateUpdate, PropertySetter = TSF_Oolong_UGUI_DocumentUtils_Wrap.S_OnDocumentLateUpdate
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_UIEventHandler_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_UIEventHandler_Wrap.Constructor
#endif
                    }},
                    {"AddListener", new MemberRegisterInfo { Name = "AddListener", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_AddListener
#endif
                    }},
                    {"RemoveListener", new MemberRegisterInfo { Name = "RemoveListener", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_RemoveListener
#endif
                    }},
                    {"OnPointerEnter", new MemberRegisterInfo { Name = "OnPointerEnter", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnPointerEnter
#endif
                    }},
                    {"OnPointerExit", new MemberRegisterInfo { Name = "OnPointerExit", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnPointerExit
#endif
                    }},
                    {"OnPointerDown", new MemberRegisterInfo { Name = "OnPointerDown", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnPointerDown
#endif
                    }},
                    {"OnPointerUp", new MemberRegisterInfo { Name = "OnPointerUp", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnPointerUp
#endif
                    }},
                    {"OnPointerMove", new MemberRegisterInfo { Name = "OnPointerMove", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnPointerMove
#endif
                    }},
                    {"OnPointerClick", new MemberRegisterInfo { Name = "OnPointerClick", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnPointerClick
#endif
                    }},
                    {"OnInitializePotentialDrag", new MemberRegisterInfo { Name = "OnInitializePotentialDrag", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnInitializePotentialDrag
#endif
                    }},
                    {"OnBeginDrag", new MemberRegisterInfo { Name = "OnBeginDrag", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnBeginDrag
#endif
                    }},
                    {"OnDrag", new MemberRegisterInfo { Name = "OnDrag", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnDrag
#endif
                    }},
                    {"OnEndDrag", new MemberRegisterInfo { Name = "OnEndDrag", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnEndDrag
#endif
                    }},
                    {"OnDrop", new MemberRegisterInfo { Name = "OnDrop", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnDrop
#endif
                    }},
                    {"OnScroll", new MemberRegisterInfo { Name = "OnScroll", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnScroll
#endif
                    }},
                    {"OnUpdateSelected", new MemberRegisterInfo { Name = "OnUpdateSelected", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnUpdateSelected
#endif
                    }},
                    {"OnSelect", new MemberRegisterInfo { Name = "OnSelect", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnSelect
#endif
                    }},
                    {"OnDeselect", new MemberRegisterInfo { Name = "OnDeselect", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnDeselect
#endif
                    }},
                    {"OnMove", new MemberRegisterInfo { Name = "OnMove", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnMove
#endif
                    }},
                    {"OnSubmit", new MemberRegisterInfo { Name = "OnSubmit", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnSubmit
#endif
                    }},
                    {"OnCancel", new MemberRegisterInfo { Name = "OnCancel", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_OnCancel
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UIEventHandler_Wrap.M_Reset
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_IOolongLoader_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"AddListener", new MemberRegisterInfo { Name = "AddListener", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_AddListener
#endif
                    }},
                    {"RemoveListener", new MemberRegisterInfo { Name = "RemoveListener", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_RemoveListener
#endif
                    }},
                    {"Release", new MemberRegisterInfo { Name = "Release", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_Release
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_Reset
#endif
                    }},
                    {"SetAttribute", new MemberRegisterInfo { Name = "SetAttribute", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_SetAttribute
#endif
                    }},
                    {"ResetTransitions", new MemberRegisterInfo { Name = "ResetTransitions", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_ResetTransitions
#endif
                    }},
                    {"SetTransition", new MemberRegisterInfo { Name = "SetTransition", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_IOolongLoader_Wrap.M_SetTransition
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongImageLoader_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongImageLoader_Wrap.Constructor
#endif
                    }},
                    {"SetImage", new MemberRegisterInfo { Name = "SetImage", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongImageLoader_Wrap.M_SetImage
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongImageLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongImageLoader_Wrap.M_Reset
#endif
                    }},
                    {"Release", new MemberRegisterInfo { Name = "Release", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongImageLoader_Wrap.M_Release
#endif
                    }},
                    {"DefaultType", new MemberRegisterInfo { Name = "DefaultType", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongImageLoader_Wrap.G_DefaultType, PropertySetter = TSF_Oolong_UGUI_OolongImageLoader_Wrap.S_DefaultType
#endif
                    }},
                    {"HasImage", new MemberRegisterInfo { Name = "HasImage", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongImageLoader_Wrap.G_HasImage
#endif
                    }},
                    {"Loaded", new MemberRegisterInfo { Name = "Loaded", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongImageLoader_Wrap.G_Loaded
#endif
                    }},
                    {"Enabled", new MemberRegisterInfo { Name = "Enabled", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongImageLoader_Wrap.G_Enabled, PropertySetter = TSF_Oolong_UGUI_OolongImageLoader_Wrap.S_Enabled
#endif
                    }},
                    {"Instance", new MemberRegisterInfo { Name = "Instance", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongImageLoader_Wrap.G_Instance
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongLayoutLoader_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongLayoutLoader_Wrap.Constructor
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongLayoutLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongLayoutLoader_Wrap.M_Reset
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongRectLoader_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongRectLoader_Wrap.Constructor
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongRectLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongRectLoader_Wrap.M_Reset
#endif
                    }},
                    {"Instance", new MemberRegisterInfo { Name = "Instance", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongRectLoader_Wrap.G_Instance
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap.Constructor
#endif
                    }},
                    {"SetAttribute", new MemberRegisterInfo { Name = "SetAttribute", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap.M_SetAttribute
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap.M_Reset
#endif
                    }},
                    {"Release", new MemberRegisterInfo { Name = "Release", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap.M_Release
#endif
                    }},
                    {"Enabled", new MemberRegisterInfo { Name = "Enabled", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap.G_Enabled
#endif
                    }},
                    {"Instance", new MemberRegisterInfo { Name = "Instance", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap.G_Instance
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongSelectableLoader_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.Constructor
#endif
                    }},
                    {"SetAttribute", new MemberRegisterInfo { Name = "SetAttribute", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.M_SetAttribute
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.M_Reset
#endif
                    }},
                    {"Release", new MemberRegisterInfo { Name = "Release", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.M_Release
#endif
                    }},
                    {"HasImage", new MemberRegisterInfo { Name = "HasImage", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.G_HasImage
#endif
                    }},
                    {"Loaded", new MemberRegisterInfo { Name = "Loaded", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.G_Loaded
#endif
                    }},
                    {"Enabled", new MemberRegisterInfo { Name = "Enabled", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.G_Enabled, PropertySetter = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.S_Enabled
#endif
                    }},
                    {"Instance", new MemberRegisterInfo { Name = "Instance", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongSelectableLoader_Wrap.G_Instance
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongSliderLoader_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongSliderLoader_Wrap.Constructor
#endif
                    }},
                    {"SetAttribute", new MemberRegisterInfo { Name = "SetAttribute", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSliderLoader_Wrap.M_SetAttribute
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSliderLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSliderLoader_Wrap.M_Reset
#endif
                    }},
                    {"Release", new MemberRegisterInfo { Name = "Release", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongSliderLoader_Wrap.M_Release
#endif
                    }},
                    {"Enabled", new MemberRegisterInfo { Name = "Enabled", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongSliderLoader_Wrap.G_Enabled
#endif
                    }},
                    {"Instance", new MemberRegisterInfo { Name = "Instance", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongSliderLoader_Wrap.G_Instance
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongTextLoader_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongTextLoader_Wrap.Constructor
#endif
                    }},
                    {"SetAttribute", new MemberRegisterInfo { Name = "SetAttribute", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongTextLoader_Wrap.M_SetAttribute
#endif
                    }},
                    {"Reuse", new MemberRegisterInfo { Name = "Reuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongTextLoader_Wrap.M_Reuse
#endif
                    }},
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongTextLoader_Wrap.M_Reset
#endif
                    }},
                    {"Release", new MemberRegisterInfo { Name = "Release", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongTextLoader_Wrap.M_Release
#endif
                    }},
                    {"TextAttr", new MemberRegisterInfo { Name = "TextAttr", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.G_TextAttr
#endif
                    }},
                    {"DefaultAlign", new MemberRegisterInfo { Name = "DefaultAlign", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.G_DefaultAlign, PropertySetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.S_DefaultAlign
#endif
                    }},
                    {"DefaultOverflow", new MemberRegisterInfo { Name = "DefaultOverflow", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.G_DefaultOverflow, PropertySetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.S_DefaultOverflow
#endif
                    }},
                    {"DefaultWrap", new MemberRegisterInfo { Name = "DefaultWrap", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.G_DefaultWrap, PropertySetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.S_DefaultWrap
#endif
                    }},
                    {"DefaultColor", new MemberRegisterInfo { Name = "DefaultColor", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.G_DefaultColor, PropertySetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.S_DefaultColor
#endif
                    }},
                    {"DefaultStyle", new MemberRegisterInfo { Name = "DefaultStyle", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.G_DefaultStyle, PropertySetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.S_DefaultStyle
#endif
                    }},
                    {"Instance", new MemberRegisterInfo { Name = "Instance", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongTextLoader_Wrap.G_Instance
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_MithrilComponent_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_MithrilComponent_Wrap.Constructor
#endif
                    }},
                    {"HasScript", new MemberRegisterInfo { Name = "HasScript", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_MithrilComponent_Wrap.G_HasScript
#endif
                    }},
                    {"PartialRedraw", new MemberRegisterInfo { Name = "PartialRedraw", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_MithrilComponent_Wrap.G_PartialRedraw
#endif
                    }},
                    {"AddressableScript", new MemberRegisterInfo { Name = "AddressableScript", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_MithrilComponent_Wrap.G_AddressableScript, PropertySetter = TSF_Oolong_UGUI_MithrilComponent_Wrap.S_AddressableScript
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_UnityWebRequestExtension_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"SetBody_static", new MemberRegisterInfo { Name = "SetBody", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UnityWebRequestExtension_Wrap.F_SetBody
#endif
                    }},
                    {"SendWithCallback_static", new MemberRegisterInfo { Name = "SendWithCallback", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UnityWebRequestExtension_Wrap.F_SendWithCallback
#endif
                    }},
                    {"GetArrayBuffer_static", new MemberRegisterInfo { Name = "GetArrayBuffer", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_UnityWebRequestExtension_Wrap.F_GetArrayBuffer
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongElement_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_OolongElement_Wrap.Constructor
#endif
                    }},
                    {"GetInstanceID", new MemberRegisterInfo { Name = "GetInstanceID", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_GetInstanceID
#endif
                    }},
                    {"AddChild", new MemberRegisterInfo { Name = "AddChild", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_AddChild
#endif
                    }},
                    {"RemoveChild", new MemberRegisterInfo { Name = "RemoveChild", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_RemoveChild
#endif
                    }},
                    {"SetElementAttribute", new MemberRegisterInfo { Name = "SetElementAttribute", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_SetElementAttribute
#endif
                    }},
                    {"AddListener", new MemberRegisterInfo { Name = "AddListener", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_AddListener
#endif
                    }},
                    {"RemoveListener", new MemberRegisterInfo { Name = "RemoveListener", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_RemoveListener
#endif
                    }},
                    {"SetEventHandler", new MemberRegisterInfo { Name = "SetEventHandler", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_SetEventHandler
#endif
                    }},
                    {"OnCreate", new MemberRegisterInfo { Name = "OnCreate", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_OnCreate
#endif
                    }},
                    {"OnReset", new MemberRegisterInfo { Name = "OnReset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_OnReset
#endif
                    }},
                    {"OnReuse", new MemberRegisterInfo { Name = "OnReuse", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_OolongElement_Wrap.M_OnReuse
#endif
                    }},
                    {"TagName", new MemberRegisterInfo { Name = "TagName", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongElement_Wrap.G_TagName, PropertySetter = TSF_Oolong_UGUI_OolongElement_Wrap.S_TagName
#endif
                    }},
                    {"RootTransform", new MemberRegisterInfo { Name = "RootTransform", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongElement_Wrap.G_RootTransform
#endif
                    }},
                    {"ParentElement", new MemberRegisterInfo { Name = "ParentElement", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_OolongElement_Wrap.G_ParentElement, PropertySetter = TSF_Oolong_UGUI_OolongElement_Wrap.S_ParentElement
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_OolongMithril_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_BooleanTransitionProperty_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_BooleanTransitionProperty_Wrap.Constructor
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_ColorTransitionProperty_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_ColorTransitionProperty_Wrap.Constructor
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_CubicBezier_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_CubicBezier_Wrap.Constructor
#endif
                    }},
                    {"Evaluate", new MemberRegisterInfo { Name = "Evaluate", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_CubicBezier_Wrap.M_Evaluate
#endif
                    }},
                    {"Ease_static", new MemberRegisterInfo { Name = "Ease", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_CubicBezier_Wrap.G_Ease, PropertySetter = TSF_Oolong_UGUI_CubicBezier_Wrap.S_Ease
#endif
                    }},
                    {"Linear_static", new MemberRegisterInfo { Name = "Linear", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_CubicBezier_Wrap.G_Linear, PropertySetter = TSF_Oolong_UGUI_CubicBezier_Wrap.S_Linear
#endif
                    }},
                    {"EaseIn_static", new MemberRegisterInfo { Name = "EaseIn", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_CubicBezier_Wrap.G_EaseIn, PropertySetter = TSF_Oolong_UGUI_CubicBezier_Wrap.S_EaseIn
#endif
                    }},
                    {"EaseOut_static", new MemberRegisterInfo { Name = "EaseOut", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_CubicBezier_Wrap.G_EaseOut, PropertySetter = TSF_Oolong_UGUI_CubicBezier_Wrap.S_EaseOut
#endif
                    }},
                    {"EaseInOut_static", new MemberRegisterInfo { Name = "EaseInOut", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_CubicBezier_Wrap.G_EaseInOut, PropertySetter = TSF_Oolong_UGUI_CubicBezier_Wrap.S_EaseInOut
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_FloatTransitionProperty_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_FloatTransitionProperty_Wrap.Constructor
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_ITransitionProperty_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"Reset", new MemberRegisterInfo { Name = "Reset", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_ITransitionProperty_Wrap.M_Reset
#endif
                    }},
                    {"TimingFunction", new MemberRegisterInfo { Name = "TimingFunction", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_ITransitionProperty_Wrap.G_TimingFunction, PropertySetter = TSF_Oolong_UGUI_ITransitionProperty_Wrap.S_TimingFunction
#endif
                    }},
                    {"Delay", new MemberRegisterInfo { Name = "Delay", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_ITransitionProperty_Wrap.G_Delay, PropertySetter = TSF_Oolong_UGUI_ITransitionProperty_Wrap.S_Delay
#endif
                    }},
                    {"Duration", new MemberRegisterInfo { Name = "Duration", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_ITransitionProperty_Wrap.G_Duration, PropertySetter = TSF_Oolong_UGUI_ITransitionProperty_Wrap.S_Duration
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_TransitionUtils_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"ParseHumanTime_static", new MemberRegisterInfo { Name = "ParseHumanTime", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_TransitionUtils_Wrap.F_ParseHumanTime
#endif
                    }},
                    {"ParseTimingFunction_static", new MemberRegisterInfo { Name = "ParseTimingFunction", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_TransitionUtils_Wrap.F_ParseTimingFunction
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_FlipGraphic_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_FlipGraphic_Wrap.Constructor
#endif
                    }},
                    {"ModifyMesh", new MemberRegisterInfo { Name = "ModifyMesh", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_FlipGraphic_Wrap.M_ModifyMesh
#endif
                    }},
                    {"FlipX", new MemberRegisterInfo { Name = "FlipX", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_FlipGraphic_Wrap.G_FlipX, PropertySetter = TSF_Oolong_UGUI_FlipGraphic_Wrap.S_FlipX
#endif
                    }},
                    {"FlipY", new MemberRegisterInfo { Name = "FlipY", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = TSF_Oolong_UGUI_FlipGraphic_Wrap.G_FlipY, PropertySetter = TSF_Oolong_UGUI_FlipGraphic_Wrap.S_FlipY
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_TSF_Oolong_UGUI_NonDrawingGraphic_Wrap() 
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
                    , Constructor = TSF_Oolong_UGUI_NonDrawingGraphic_Wrap.Constructor
#endif
                    }},
                    {"SetMaterialDirty", new MemberRegisterInfo { Name = "SetMaterialDirty", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_NonDrawingGraphic_Wrap.M_SetMaterialDirty
#endif
                    }},
                    {"SetVerticesDirty", new MemberRegisterInfo { Name = "SetVerticesDirty", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = TSF_Oolong_UGUI_NonDrawingGraphic_Wrap.M_SetVerticesDirty
#endif
                    }},
                }
            };
        }

        public static void AddRegisterInfoGetterIntoJsEnv(JsEnv jsEnv)
        {
            
                jsEnv.AddRegisterInfoGetter(typeof(OolongUGUI), GetRegisterInfo_OolongUGUI_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.DocumentUtils), GetRegisterInfo_TSF_Oolong_UGUI_DocumentUtils_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.UIEventHandler), GetRegisterInfo_TSF_Oolong_UGUI_UIEventHandler_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.IOolongLoader), GetRegisterInfo_TSF_Oolong_UGUI_IOolongLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongImageLoader), GetRegisterInfo_TSF_Oolong_UGUI_OolongImageLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongLayoutLoader), GetRegisterInfo_TSF_Oolong_UGUI_OolongLayoutLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongRectLoader), GetRegisterInfo_TSF_Oolong_UGUI_OolongRectLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongScrollbarLoader), GetRegisterInfo_TSF_Oolong_UGUI_OolongScrollbarLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongSelectableLoader), GetRegisterInfo_TSF_Oolong_UGUI_OolongSelectableLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongSliderLoader), GetRegisterInfo_TSF_Oolong_UGUI_OolongSliderLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongTextLoader), GetRegisterInfo_TSF_Oolong_UGUI_OolongTextLoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.MithrilComponent), GetRegisterInfo_TSF_Oolong_UGUI_MithrilComponent_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.UnityWebRequestExtension), GetRegisterInfo_TSF_Oolong_UGUI_UnityWebRequestExtension_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongElement), GetRegisterInfo_TSF_Oolong_UGUI_OolongElement_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.OolongMithril), GetRegisterInfo_TSF_Oolong_UGUI_OolongMithril_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.BooleanTransitionProperty), GetRegisterInfo_TSF_Oolong_UGUI_BooleanTransitionProperty_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.ColorTransitionProperty), GetRegisterInfo_TSF_Oolong_UGUI_ColorTransitionProperty_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.CubicBezier), GetRegisterInfo_TSF_Oolong_UGUI_CubicBezier_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.FloatTransitionProperty), GetRegisterInfo_TSF_Oolong_UGUI_FloatTransitionProperty_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.ITransitionProperty), GetRegisterInfo_TSF_Oolong_UGUI_ITransitionProperty_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.TransitionUtils), GetRegisterInfo_TSF_Oolong_UGUI_TransitionUtils_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.FlipGraphic), GetRegisterInfo_TSF_Oolong_UGUI_FlipGraphic_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(TSF.Oolong.UGUI.NonDrawingGraphic), GetRegisterInfo_TSF_Oolong_UGUI_NonDrawingGraphic_Wrap);
        }
    }
}