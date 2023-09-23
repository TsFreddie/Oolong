using Puerts.TypeMapping;
using Puerts;

namespace PuertsStaticWrap
{
#if ENABLE_IL2CPP
    [UnityEngine.Scripting.Preserve]
#endif
    public static class PuerRegisterInfo_Gen
    {
        
        public static RegisterInfo GetRegisterInfo_UnityEngine_GameObject_Wrap() 
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
                    , Constructor = UnityEngine_GameObject_Wrap.Constructor
#endif
                    }},
                    {"GetComponent", new MemberRegisterInfo { Name = "GetComponent", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_GetComponent
#endif
                    }},
                    {"GetComponentInChildren", new MemberRegisterInfo { Name = "GetComponentInChildren", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_GetComponentInChildren
#endif
                    }},
                    {"GetComponentInParent", new MemberRegisterInfo { Name = "GetComponentInParent", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_GetComponentInParent
#endif
                    }},
                    {"GetComponents", new MemberRegisterInfo { Name = "GetComponents", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_GetComponents
#endif
                    }},
                    {"GetComponentsInChildren", new MemberRegisterInfo { Name = "GetComponentsInChildren", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_GetComponentsInChildren
#endif
                    }},
                    {"GetComponentsInParent", new MemberRegisterInfo { Name = "GetComponentsInParent", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_GetComponentsInParent
#endif
                    }},
                    {"TryGetComponent", new MemberRegisterInfo { Name = "TryGetComponent", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_TryGetComponent
#endif
                    }},
                    {"SendMessageUpwards", new MemberRegisterInfo { Name = "SendMessageUpwards", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_SendMessageUpwards
#endif
                    }},
                    {"SendMessage", new MemberRegisterInfo { Name = "SendMessage", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_SendMessage
#endif
                    }},
                    {"BroadcastMessage", new MemberRegisterInfo { Name = "BroadcastMessage", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_BroadcastMessage
#endif
                    }},
                    {"AddComponent", new MemberRegisterInfo { Name = "AddComponent", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_AddComponent
#endif
                    }},
                    {"SetActive", new MemberRegisterInfo { Name = "SetActive", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_SetActive
#endif
                    }},
                    {"CompareTag", new MemberRegisterInfo { Name = "CompareTag", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.M_CompareTag
#endif
                    }},
                    {"transform", new MemberRegisterInfo { Name = "transform", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_transform
#endif
                    }},
                    {"layer", new MemberRegisterInfo { Name = "layer", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_layer, PropertySetter = UnityEngine_GameObject_Wrap.S_layer
#endif
                    }},
                    {"activeSelf", new MemberRegisterInfo { Name = "activeSelf", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_activeSelf
#endif
                    }},
                    {"activeInHierarchy", new MemberRegisterInfo { Name = "activeInHierarchy", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_activeInHierarchy
#endif
                    }},
                    {"isStatic", new MemberRegisterInfo { Name = "isStatic", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_isStatic, PropertySetter = UnityEngine_GameObject_Wrap.S_isStatic
#endif
                    }},
                    {"tag", new MemberRegisterInfo { Name = "tag", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_tag, PropertySetter = UnityEngine_GameObject_Wrap.S_tag
#endif
                    }},
                    {"scene", new MemberRegisterInfo { Name = "scene", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_scene
#endif
                    }},
                    {"sceneCullingMask", new MemberRegisterInfo { Name = "sceneCullingMask", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_sceneCullingMask
#endif
                    }},
                    {"gameObject", new MemberRegisterInfo { Name = "gameObject", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_GameObject_Wrap.G_gameObject
#endif
                    }},
                    {"CreatePrimitive_static", new MemberRegisterInfo { Name = "CreatePrimitive", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.F_CreatePrimitive
#endif
                    }},
                    {"FindWithTag_static", new MemberRegisterInfo { Name = "FindWithTag", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.F_FindWithTag
#endif
                    }},
                    {"FindGameObjectWithTag_static", new MemberRegisterInfo { Name = "FindGameObjectWithTag", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.F_FindGameObjectWithTag
#endif
                    }},
                    {"FindGameObjectsWithTag_static", new MemberRegisterInfo { Name = "FindGameObjectsWithTag", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.F_FindGameObjectsWithTag
#endif
                    }},
                    {"Find_static", new MemberRegisterInfo { Name = "Find", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_GameObject_Wrap.F_Find
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_UnityEngine_Transform_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"SetParent", new MemberRegisterInfo { Name = "SetParent", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_SetParent
#endif
                    }},
                    {"SetPositionAndRotation", new MemberRegisterInfo { Name = "SetPositionAndRotation", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_SetPositionAndRotation
#endif
                    }},
                    {"SetLocalPositionAndRotation", new MemberRegisterInfo { Name = "SetLocalPositionAndRotation", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_SetLocalPositionAndRotation
#endif
                    }},
                    {"GetPositionAndRotation", new MemberRegisterInfo { Name = "GetPositionAndRotation", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_GetPositionAndRotation
#endif
                    }},
                    {"GetLocalPositionAndRotation", new MemberRegisterInfo { Name = "GetLocalPositionAndRotation", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_GetLocalPositionAndRotation
#endif
                    }},
                    {"Translate", new MemberRegisterInfo { Name = "Translate", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_Translate
#endif
                    }},
                    {"Rotate", new MemberRegisterInfo { Name = "Rotate", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_Rotate
#endif
                    }},
                    {"RotateAround", new MemberRegisterInfo { Name = "RotateAround", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_RotateAround
#endif
                    }},
                    {"LookAt", new MemberRegisterInfo { Name = "LookAt", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_LookAt
#endif
                    }},
                    {"TransformDirection", new MemberRegisterInfo { Name = "TransformDirection", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_TransformDirection
#endif
                    }},
                    {"InverseTransformDirection", new MemberRegisterInfo { Name = "InverseTransformDirection", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_InverseTransformDirection
#endif
                    }},
                    {"TransformVector", new MemberRegisterInfo { Name = "TransformVector", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_TransformVector
#endif
                    }},
                    {"InverseTransformVector", new MemberRegisterInfo { Name = "InverseTransformVector", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_InverseTransformVector
#endif
                    }},
                    {"TransformPoint", new MemberRegisterInfo { Name = "TransformPoint", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_TransformPoint
#endif
                    }},
                    {"InverseTransformPoint", new MemberRegisterInfo { Name = "InverseTransformPoint", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_InverseTransformPoint
#endif
                    }},
                    {"DetachChildren", new MemberRegisterInfo { Name = "DetachChildren", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_DetachChildren
#endif
                    }},
                    {"SetAsFirstSibling", new MemberRegisterInfo { Name = "SetAsFirstSibling", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_SetAsFirstSibling
#endif
                    }},
                    {"SetAsLastSibling", new MemberRegisterInfo { Name = "SetAsLastSibling", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_SetAsLastSibling
#endif
                    }},
                    {"SetSiblingIndex", new MemberRegisterInfo { Name = "SetSiblingIndex", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_SetSiblingIndex
#endif
                    }},
                    {"GetSiblingIndex", new MemberRegisterInfo { Name = "GetSiblingIndex", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_GetSiblingIndex
#endif
                    }},
                    {"Find", new MemberRegisterInfo { Name = "Find", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_Find
#endif
                    }},
                    {"IsChildOf", new MemberRegisterInfo { Name = "IsChildOf", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_IsChildOf
#endif
                    }},
                    {"GetEnumerator", new MemberRegisterInfo { Name = "GetEnumerator", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_GetEnumerator
#endif
                    }},
                    {"GetChild", new MemberRegisterInfo { Name = "GetChild", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Transform_Wrap.M_GetChild
#endif
                    }},
                    {"position", new MemberRegisterInfo { Name = "position", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_position, PropertySetter = UnityEngine_Transform_Wrap.S_position
#endif
                    }},
                    {"localPosition", new MemberRegisterInfo { Name = "localPosition", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_localPosition, PropertySetter = UnityEngine_Transform_Wrap.S_localPosition
#endif
                    }},
                    {"eulerAngles", new MemberRegisterInfo { Name = "eulerAngles", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_eulerAngles, PropertySetter = UnityEngine_Transform_Wrap.S_eulerAngles
#endif
                    }},
                    {"localEulerAngles", new MemberRegisterInfo { Name = "localEulerAngles", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_localEulerAngles, PropertySetter = UnityEngine_Transform_Wrap.S_localEulerAngles
#endif
                    }},
                    {"right", new MemberRegisterInfo { Name = "right", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_right, PropertySetter = UnityEngine_Transform_Wrap.S_right
#endif
                    }},
                    {"up", new MemberRegisterInfo { Name = "up", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_up, PropertySetter = UnityEngine_Transform_Wrap.S_up
#endif
                    }},
                    {"forward", new MemberRegisterInfo { Name = "forward", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_forward, PropertySetter = UnityEngine_Transform_Wrap.S_forward
#endif
                    }},
                    {"rotation", new MemberRegisterInfo { Name = "rotation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_rotation, PropertySetter = UnityEngine_Transform_Wrap.S_rotation
#endif
                    }},
                    {"localRotation", new MemberRegisterInfo { Name = "localRotation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_localRotation, PropertySetter = UnityEngine_Transform_Wrap.S_localRotation
#endif
                    }},
                    {"localScale", new MemberRegisterInfo { Name = "localScale", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_localScale, PropertySetter = UnityEngine_Transform_Wrap.S_localScale
#endif
                    }},
                    {"parent", new MemberRegisterInfo { Name = "parent", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_parent, PropertySetter = UnityEngine_Transform_Wrap.S_parent
#endif
                    }},
                    {"worldToLocalMatrix", new MemberRegisterInfo { Name = "worldToLocalMatrix", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_worldToLocalMatrix
#endif
                    }},
                    {"localToWorldMatrix", new MemberRegisterInfo { Name = "localToWorldMatrix", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_localToWorldMatrix
#endif
                    }},
                    {"root", new MemberRegisterInfo { Name = "root", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_root
#endif
                    }},
                    {"childCount", new MemberRegisterInfo { Name = "childCount", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_childCount
#endif
                    }},
                    {"lossyScale", new MemberRegisterInfo { Name = "lossyScale", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_lossyScale
#endif
                    }},
                    {"hasChanged", new MemberRegisterInfo { Name = "hasChanged", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_hasChanged, PropertySetter = UnityEngine_Transform_Wrap.S_hasChanged
#endif
                    }},
                    {"hierarchyCapacity", new MemberRegisterInfo { Name = "hierarchyCapacity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_hierarchyCapacity, PropertySetter = UnityEngine_Transform_Wrap.S_hierarchyCapacity
#endif
                    }},
                    {"hierarchyCount", new MemberRegisterInfo { Name = "hierarchyCount", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Transform_Wrap.G_hierarchyCount
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_UnityEngine_Rigidbody_Wrap() 
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
                    , Constructor = UnityEngine_Rigidbody_Wrap.Constructor
#endif
                    }},
                    {"SetDensity", new MemberRegisterInfo { Name = "SetDensity", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_SetDensity
#endif
                    }},
                    {"MovePosition", new MemberRegisterInfo { Name = "MovePosition", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_MovePosition
#endif
                    }},
                    {"MoveRotation", new MemberRegisterInfo { Name = "MoveRotation", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_MoveRotation
#endif
                    }},
                    {"Move", new MemberRegisterInfo { Name = "Move", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_Move
#endif
                    }},
                    {"Sleep", new MemberRegisterInfo { Name = "Sleep", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_Sleep
#endif
                    }},
                    {"IsSleeping", new MemberRegisterInfo { Name = "IsSleeping", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_IsSleeping
#endif
                    }},
                    {"WakeUp", new MemberRegisterInfo { Name = "WakeUp", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_WakeUp
#endif
                    }},
                    {"ResetCenterOfMass", new MemberRegisterInfo { Name = "ResetCenterOfMass", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_ResetCenterOfMass
#endif
                    }},
                    {"ResetInertiaTensor", new MemberRegisterInfo { Name = "ResetInertiaTensor", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_ResetInertiaTensor
#endif
                    }},
                    {"GetRelativePointVelocity", new MemberRegisterInfo { Name = "GetRelativePointVelocity", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_GetRelativePointVelocity
#endif
                    }},
                    {"GetPointVelocity", new MemberRegisterInfo { Name = "GetPointVelocity", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_GetPointVelocity
#endif
                    }},
                    {"GetAccumulatedForce", new MemberRegisterInfo { Name = "GetAccumulatedForce", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_GetAccumulatedForce
#endif
                    }},
                    {"GetAccumulatedTorque", new MemberRegisterInfo { Name = "GetAccumulatedTorque", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_GetAccumulatedTorque
#endif
                    }},
                    {"AddForce", new MemberRegisterInfo { Name = "AddForce", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_AddForce
#endif
                    }},
                    {"AddRelativeForce", new MemberRegisterInfo { Name = "AddRelativeForce", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_AddRelativeForce
#endif
                    }},
                    {"AddTorque", new MemberRegisterInfo { Name = "AddTorque", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_AddTorque
#endif
                    }},
                    {"AddRelativeTorque", new MemberRegisterInfo { Name = "AddRelativeTorque", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_AddRelativeTorque
#endif
                    }},
                    {"AddForceAtPosition", new MemberRegisterInfo { Name = "AddForceAtPosition", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_AddForceAtPosition
#endif
                    }},
                    {"AddExplosionForce", new MemberRegisterInfo { Name = "AddExplosionForce", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_AddExplosionForce
#endif
                    }},
                    {"ClosestPointOnBounds", new MemberRegisterInfo { Name = "ClosestPointOnBounds", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_ClosestPointOnBounds
#endif
                    }},
                    {"SweepTest", new MemberRegisterInfo { Name = "SweepTest", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_SweepTest
#endif
                    }},
                    {"SweepTestAll", new MemberRegisterInfo { Name = "SweepTestAll", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody_Wrap.M_SweepTestAll
#endif
                    }},
                    {"velocity", new MemberRegisterInfo { Name = "velocity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_velocity, PropertySetter = UnityEngine_Rigidbody_Wrap.S_velocity
#endif
                    }},
                    {"angularVelocity", new MemberRegisterInfo { Name = "angularVelocity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_angularVelocity, PropertySetter = UnityEngine_Rigidbody_Wrap.S_angularVelocity
#endif
                    }},
                    {"drag", new MemberRegisterInfo { Name = "drag", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_drag, PropertySetter = UnityEngine_Rigidbody_Wrap.S_drag
#endif
                    }},
                    {"angularDrag", new MemberRegisterInfo { Name = "angularDrag", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_angularDrag, PropertySetter = UnityEngine_Rigidbody_Wrap.S_angularDrag
#endif
                    }},
                    {"mass", new MemberRegisterInfo { Name = "mass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_mass, PropertySetter = UnityEngine_Rigidbody_Wrap.S_mass
#endif
                    }},
                    {"useGravity", new MemberRegisterInfo { Name = "useGravity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_useGravity, PropertySetter = UnityEngine_Rigidbody_Wrap.S_useGravity
#endif
                    }},
                    {"maxDepenetrationVelocity", new MemberRegisterInfo { Name = "maxDepenetrationVelocity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_maxDepenetrationVelocity, PropertySetter = UnityEngine_Rigidbody_Wrap.S_maxDepenetrationVelocity
#endif
                    }},
                    {"isKinematic", new MemberRegisterInfo { Name = "isKinematic", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_isKinematic, PropertySetter = UnityEngine_Rigidbody_Wrap.S_isKinematic
#endif
                    }},
                    {"freezeRotation", new MemberRegisterInfo { Name = "freezeRotation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_freezeRotation, PropertySetter = UnityEngine_Rigidbody_Wrap.S_freezeRotation
#endif
                    }},
                    {"constraints", new MemberRegisterInfo { Name = "constraints", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_constraints, PropertySetter = UnityEngine_Rigidbody_Wrap.S_constraints
#endif
                    }},
                    {"collisionDetectionMode", new MemberRegisterInfo { Name = "collisionDetectionMode", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_collisionDetectionMode, PropertySetter = UnityEngine_Rigidbody_Wrap.S_collisionDetectionMode
#endif
                    }},
                    {"automaticCenterOfMass", new MemberRegisterInfo { Name = "automaticCenterOfMass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_automaticCenterOfMass, PropertySetter = UnityEngine_Rigidbody_Wrap.S_automaticCenterOfMass
#endif
                    }},
                    {"centerOfMass", new MemberRegisterInfo { Name = "centerOfMass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_centerOfMass, PropertySetter = UnityEngine_Rigidbody_Wrap.S_centerOfMass
#endif
                    }},
                    {"worldCenterOfMass", new MemberRegisterInfo { Name = "worldCenterOfMass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_worldCenterOfMass
#endif
                    }},
                    {"automaticInertiaTensor", new MemberRegisterInfo { Name = "automaticInertiaTensor", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_automaticInertiaTensor, PropertySetter = UnityEngine_Rigidbody_Wrap.S_automaticInertiaTensor
#endif
                    }},
                    {"inertiaTensorRotation", new MemberRegisterInfo { Name = "inertiaTensorRotation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_inertiaTensorRotation, PropertySetter = UnityEngine_Rigidbody_Wrap.S_inertiaTensorRotation
#endif
                    }},
                    {"inertiaTensor", new MemberRegisterInfo { Name = "inertiaTensor", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_inertiaTensor, PropertySetter = UnityEngine_Rigidbody_Wrap.S_inertiaTensor
#endif
                    }},
                    {"detectCollisions", new MemberRegisterInfo { Name = "detectCollisions", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_detectCollisions, PropertySetter = UnityEngine_Rigidbody_Wrap.S_detectCollisions
#endif
                    }},
                    {"position", new MemberRegisterInfo { Name = "position", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_position, PropertySetter = UnityEngine_Rigidbody_Wrap.S_position
#endif
                    }},
                    {"rotation", new MemberRegisterInfo { Name = "rotation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_rotation, PropertySetter = UnityEngine_Rigidbody_Wrap.S_rotation
#endif
                    }},
                    {"interpolation", new MemberRegisterInfo { Name = "interpolation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_interpolation, PropertySetter = UnityEngine_Rigidbody_Wrap.S_interpolation
#endif
                    }},
                    {"solverIterations", new MemberRegisterInfo { Name = "solverIterations", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_solverIterations, PropertySetter = UnityEngine_Rigidbody_Wrap.S_solverIterations
#endif
                    }},
                    {"sleepThreshold", new MemberRegisterInfo { Name = "sleepThreshold", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_sleepThreshold, PropertySetter = UnityEngine_Rigidbody_Wrap.S_sleepThreshold
#endif
                    }},
                    {"maxAngularVelocity", new MemberRegisterInfo { Name = "maxAngularVelocity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_maxAngularVelocity, PropertySetter = UnityEngine_Rigidbody_Wrap.S_maxAngularVelocity
#endif
                    }},
                    {"maxLinearVelocity", new MemberRegisterInfo { Name = "maxLinearVelocity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_maxLinearVelocity, PropertySetter = UnityEngine_Rigidbody_Wrap.S_maxLinearVelocity
#endif
                    }},
                    {"solverVelocityIterations", new MemberRegisterInfo { Name = "solverVelocityIterations", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_solverVelocityIterations, PropertySetter = UnityEngine_Rigidbody_Wrap.S_solverVelocityIterations
#endif
                    }},
                    {"excludeLayers", new MemberRegisterInfo { Name = "excludeLayers", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_excludeLayers, PropertySetter = UnityEngine_Rigidbody_Wrap.S_excludeLayers
#endif
                    }},
                    {"includeLayers", new MemberRegisterInfo { Name = "includeLayers", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody_Wrap.G_includeLayers, PropertySetter = UnityEngine_Rigidbody_Wrap.S_includeLayers
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_UnityEngine_Rigidbody2D_Wrap() 
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
                    , Constructor = UnityEngine_Rigidbody2D_Wrap.Constructor
#endif
                    }},
                    {"SetRotation", new MemberRegisterInfo { Name = "SetRotation", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_SetRotation
#endif
                    }},
                    {"MovePosition", new MemberRegisterInfo { Name = "MovePosition", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_MovePosition
#endif
                    }},
                    {"MoveRotation", new MemberRegisterInfo { Name = "MoveRotation", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_MoveRotation
#endif
                    }},
                    {"IsSleeping", new MemberRegisterInfo { Name = "IsSleeping", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_IsSleeping
#endif
                    }},
                    {"IsAwake", new MemberRegisterInfo { Name = "IsAwake", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_IsAwake
#endif
                    }},
                    {"Sleep", new MemberRegisterInfo { Name = "Sleep", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_Sleep
#endif
                    }},
                    {"WakeUp", new MemberRegisterInfo { Name = "WakeUp", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_WakeUp
#endif
                    }},
                    {"IsTouching", new MemberRegisterInfo { Name = "IsTouching", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_IsTouching
#endif
                    }},
                    {"IsTouchingLayers", new MemberRegisterInfo { Name = "IsTouchingLayers", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_IsTouchingLayers
#endif
                    }},
                    {"OverlapPoint", new MemberRegisterInfo { Name = "OverlapPoint", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_OverlapPoint
#endif
                    }},
                    {"Distance", new MemberRegisterInfo { Name = "Distance", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_Distance
#endif
                    }},
                    {"ClosestPoint", new MemberRegisterInfo { Name = "ClosestPoint", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_ClosestPoint
#endif
                    }},
                    {"AddForce", new MemberRegisterInfo { Name = "AddForce", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_AddForce
#endif
                    }},
                    {"AddRelativeForce", new MemberRegisterInfo { Name = "AddRelativeForce", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_AddRelativeForce
#endif
                    }},
                    {"AddForceAtPosition", new MemberRegisterInfo { Name = "AddForceAtPosition", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_AddForceAtPosition
#endif
                    }},
                    {"AddTorque", new MemberRegisterInfo { Name = "AddTorque", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_AddTorque
#endif
                    }},
                    {"GetPoint", new MemberRegisterInfo { Name = "GetPoint", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetPoint
#endif
                    }},
                    {"GetRelativePoint", new MemberRegisterInfo { Name = "GetRelativePoint", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetRelativePoint
#endif
                    }},
                    {"GetVector", new MemberRegisterInfo { Name = "GetVector", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetVector
#endif
                    }},
                    {"GetRelativeVector", new MemberRegisterInfo { Name = "GetRelativeVector", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetRelativeVector
#endif
                    }},
                    {"GetPointVelocity", new MemberRegisterInfo { Name = "GetPointVelocity", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetPointVelocity
#endif
                    }},
                    {"GetRelativePointVelocity", new MemberRegisterInfo { Name = "GetRelativePointVelocity", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetRelativePointVelocity
#endif
                    }},
                    {"OverlapCollider", new MemberRegisterInfo { Name = "OverlapCollider", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_OverlapCollider
#endif
                    }},
                    {"GetContacts", new MemberRegisterInfo { Name = "GetContacts", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetContacts
#endif
                    }},
                    {"GetAttachedColliders", new MemberRegisterInfo { Name = "GetAttachedColliders", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetAttachedColliders
#endif
                    }},
                    {"Cast", new MemberRegisterInfo { Name = "Cast", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_Cast
#endif
                    }},
                    {"GetShapes", new MemberRegisterInfo { Name = "GetShapes", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Rigidbody2D_Wrap.M_GetShapes
#endif
                    }},
                    {"position", new MemberRegisterInfo { Name = "position", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_position, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_position
#endif
                    }},
                    {"rotation", new MemberRegisterInfo { Name = "rotation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_rotation, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_rotation
#endif
                    }},
                    {"velocity", new MemberRegisterInfo { Name = "velocity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_velocity, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_velocity
#endif
                    }},
                    {"angularVelocity", new MemberRegisterInfo { Name = "angularVelocity", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_angularVelocity, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_angularVelocity
#endif
                    }},
                    {"useAutoMass", new MemberRegisterInfo { Name = "useAutoMass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_useAutoMass, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_useAutoMass
#endif
                    }},
                    {"mass", new MemberRegisterInfo { Name = "mass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_mass, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_mass
#endif
                    }},
                    {"sharedMaterial", new MemberRegisterInfo { Name = "sharedMaterial", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_sharedMaterial, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_sharedMaterial
#endif
                    }},
                    {"centerOfMass", new MemberRegisterInfo { Name = "centerOfMass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_centerOfMass, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_centerOfMass
#endif
                    }},
                    {"worldCenterOfMass", new MemberRegisterInfo { Name = "worldCenterOfMass", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_worldCenterOfMass
#endif
                    }},
                    {"inertia", new MemberRegisterInfo { Name = "inertia", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_inertia, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_inertia
#endif
                    }},
                    {"drag", new MemberRegisterInfo { Name = "drag", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_drag, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_drag
#endif
                    }},
                    {"angularDrag", new MemberRegisterInfo { Name = "angularDrag", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_angularDrag, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_angularDrag
#endif
                    }},
                    {"gravityScale", new MemberRegisterInfo { Name = "gravityScale", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_gravityScale, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_gravityScale
#endif
                    }},
                    {"bodyType", new MemberRegisterInfo { Name = "bodyType", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_bodyType, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_bodyType
#endif
                    }},
                    {"useFullKinematicContacts", new MemberRegisterInfo { Name = "useFullKinematicContacts", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_useFullKinematicContacts, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_useFullKinematicContacts
#endif
                    }},
                    {"isKinematic", new MemberRegisterInfo { Name = "isKinematic", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_isKinematic, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_isKinematic
#endif
                    }},
                    {"freezeRotation", new MemberRegisterInfo { Name = "freezeRotation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_freezeRotation, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_freezeRotation
#endif
                    }},
                    {"constraints", new MemberRegisterInfo { Name = "constraints", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_constraints, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_constraints
#endif
                    }},
                    {"simulated", new MemberRegisterInfo { Name = "simulated", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_simulated, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_simulated
#endif
                    }},
                    {"interpolation", new MemberRegisterInfo { Name = "interpolation", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_interpolation, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_interpolation
#endif
                    }},
                    {"sleepMode", new MemberRegisterInfo { Name = "sleepMode", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_sleepMode, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_sleepMode
#endif
                    }},
                    {"collisionDetectionMode", new MemberRegisterInfo { Name = "collisionDetectionMode", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_collisionDetectionMode, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_collisionDetectionMode
#endif
                    }},
                    {"attachedColliderCount", new MemberRegisterInfo { Name = "attachedColliderCount", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_attachedColliderCount
#endif
                    }},
                    {"totalForce", new MemberRegisterInfo { Name = "totalForce", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_totalForce, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_totalForce
#endif
                    }},
                    {"totalTorque", new MemberRegisterInfo { Name = "totalTorque", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_totalTorque, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_totalTorque
#endif
                    }},
                    {"excludeLayers", new MemberRegisterInfo { Name = "excludeLayers", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_excludeLayers, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_excludeLayers
#endif
                    }},
                    {"includeLayers", new MemberRegisterInfo { Name = "includeLayers", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Rigidbody2D_Wrap.G_includeLayers, PropertySetter = UnityEngine_Rigidbody2D_Wrap.S_includeLayers
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_UnityEngine_Vector3_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = true,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {".ctor", new MemberRegisterInfo { Name = ".ctor", IsStatic = false, MemberType = MemberType.Constructor, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Constructor = UnityEngine_Vector3_Wrap.Constructor
#endif
                    }},
                    {"Set", new MemberRegisterInfo { Name = "Set", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.M_Set
#endif
                    }},
                    {"Scale", new MemberRegisterInfo { Name = "Scale", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.M_Scale
#endif
                    }},
                    {"GetHashCode", new MemberRegisterInfo { Name = "GetHashCode", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.M_GetHashCode
#endif
                    }},
                    {"Equals", new MemberRegisterInfo { Name = "Equals", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.M_Equals
#endif
                    }},
                    {"Normalize", new MemberRegisterInfo { Name = "Normalize", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.M_Normalize
#endif
                    }},
                    {"op_Addition_static", new MemberRegisterInfo { Name = "op_Addition", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.O_op_Addition
#endif
                    }},
                    {"op_Subtraction_static", new MemberRegisterInfo { Name = "op_Subtraction", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.O_op_Subtraction
#endif
                    }},
                    {"op_UnaryNegation_static", new MemberRegisterInfo { Name = "op_UnaryNegation", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.O_op_UnaryNegation
#endif
                    }},
                    {"op_Multiply_static", new MemberRegisterInfo { Name = "op_Multiply", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.O_op_Multiply
#endif
                    }},
                    {"op_Division_static", new MemberRegisterInfo { Name = "op_Division", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.O_op_Division
#endif
                    }},
                    {"op_Equality_static", new MemberRegisterInfo { Name = "op_Equality", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.O_op_Equality
#endif
                    }},
                    {"op_Inequality_static", new MemberRegisterInfo { Name = "op_Inequality", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.O_op_Inequality
#endif
                    }},
                    {"ToString", new MemberRegisterInfo { Name = "ToString", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.M_ToString
#endif
                    }},
                    {"get_Item", new MemberRegisterInfo { Name = "get_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.GetItem
#endif
                    }},
                    {"set_Item", new MemberRegisterInfo { Name = "set_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.SetItem
#endif
                    }},
                    {"normalized", new MemberRegisterInfo { Name = "normalized", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_normalized
#endif
                    }},
                    {"magnitude", new MemberRegisterInfo { Name = "magnitude", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_magnitude
#endif
                    }},
                    {"sqrMagnitude", new MemberRegisterInfo { Name = "sqrMagnitude", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_sqrMagnitude
#endif
                    }},
                    {"x", new MemberRegisterInfo { Name = "x", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_x, PropertySetter = UnityEngine_Vector3_Wrap.S_x
#endif
                    }},
                    {"y", new MemberRegisterInfo { Name = "y", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_y, PropertySetter = UnityEngine_Vector3_Wrap.S_y
#endif
                    }},
                    {"z", new MemberRegisterInfo { Name = "z", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_z, PropertySetter = UnityEngine_Vector3_Wrap.S_z
#endif
                    }},
                    {"Slerp_static", new MemberRegisterInfo { Name = "Slerp", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Slerp
#endif
                    }},
                    {"SlerpUnclamped_static", new MemberRegisterInfo { Name = "SlerpUnclamped", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_SlerpUnclamped
#endif
                    }},
                    {"OrthoNormalize_static", new MemberRegisterInfo { Name = "OrthoNormalize", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_OrthoNormalize
#endif
                    }},
                    {"RotateTowards_static", new MemberRegisterInfo { Name = "RotateTowards", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_RotateTowards
#endif
                    }},
                    {"Lerp_static", new MemberRegisterInfo { Name = "Lerp", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Lerp
#endif
                    }},
                    {"LerpUnclamped_static", new MemberRegisterInfo { Name = "LerpUnclamped", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_LerpUnclamped
#endif
                    }},
                    {"MoveTowards_static", new MemberRegisterInfo { Name = "MoveTowards", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_MoveTowards
#endif
                    }},
                    {"SmoothDamp_static", new MemberRegisterInfo { Name = "SmoothDamp", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_SmoothDamp
#endif
                    }},
                    {"Scale_static", new MemberRegisterInfo { Name = "Scale", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Scale
#endif
                    }},
                    {"Cross_static", new MemberRegisterInfo { Name = "Cross", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Cross
#endif
                    }},
                    {"Reflect_static", new MemberRegisterInfo { Name = "Reflect", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Reflect
#endif
                    }},
                    {"Normalize_static", new MemberRegisterInfo { Name = "Normalize", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Normalize
#endif
                    }},
                    {"Dot_static", new MemberRegisterInfo { Name = "Dot", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Dot
#endif
                    }},
                    {"Project_static", new MemberRegisterInfo { Name = "Project", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Project
#endif
                    }},
                    {"ProjectOnPlane_static", new MemberRegisterInfo { Name = "ProjectOnPlane", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_ProjectOnPlane
#endif
                    }},
                    {"Angle_static", new MemberRegisterInfo { Name = "Angle", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Angle
#endif
                    }},
                    {"SignedAngle_static", new MemberRegisterInfo { Name = "SignedAngle", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_SignedAngle
#endif
                    }},
                    {"Distance_static", new MemberRegisterInfo { Name = "Distance", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Distance
#endif
                    }},
                    {"ClampMagnitude_static", new MemberRegisterInfo { Name = "ClampMagnitude", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_ClampMagnitude
#endif
                    }},
                    {"Magnitude_static", new MemberRegisterInfo { Name = "Magnitude", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Magnitude
#endif
                    }},
                    {"SqrMagnitude_static", new MemberRegisterInfo { Name = "SqrMagnitude", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_SqrMagnitude
#endif
                    }},
                    {"Min_static", new MemberRegisterInfo { Name = "Min", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Min
#endif
                    }},
                    {"Max_static", new MemberRegisterInfo { Name = "Max", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector3_Wrap.F_Max
#endif
                    }},
                    {"zero_static", new MemberRegisterInfo { Name = "zero", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_zero
#endif
                    }},
                    {"one_static", new MemberRegisterInfo { Name = "one", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_one
#endif
                    }},
                    {"forward_static", new MemberRegisterInfo { Name = "forward", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_forward
#endif
                    }},
                    {"back_static", new MemberRegisterInfo { Name = "back", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_back
#endif
                    }},
                    {"up_static", new MemberRegisterInfo { Name = "up", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_up
#endif
                    }},
                    {"down_static", new MemberRegisterInfo { Name = "down", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_down
#endif
                    }},
                    {"left_static", new MemberRegisterInfo { Name = "left", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_left
#endif
                    }},
                    {"right_static", new MemberRegisterInfo { Name = "right", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_right
#endif
                    }},
                    {"positiveInfinity_static", new MemberRegisterInfo { Name = "positiveInfinity", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_positiveInfinity
#endif
                    }},
                    {"negativeInfinity_static", new MemberRegisterInfo { Name = "negativeInfinity", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_negativeInfinity
#endif
                    }},
                    {"kEpsilon_static", new MemberRegisterInfo { Name = "kEpsilon", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_kEpsilon
#endif
                    }},
                    {"kEpsilonNormalSqrt_static", new MemberRegisterInfo { Name = "kEpsilonNormalSqrt", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector3_Wrap.G_kEpsilonNormalSqrt
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_UnityEngine_Vector2_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = true,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {".ctor", new MemberRegisterInfo { Name = ".ctor", IsStatic = false, MemberType = MemberType.Constructor, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Constructor = UnityEngine_Vector2_Wrap.Constructor
#endif
                    }},
                    {"Set", new MemberRegisterInfo { Name = "Set", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.M_Set
#endif
                    }},
                    {"Scale", new MemberRegisterInfo { Name = "Scale", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.M_Scale
#endif
                    }},
                    {"Normalize", new MemberRegisterInfo { Name = "Normalize", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.M_Normalize
#endif
                    }},
                    {"ToString", new MemberRegisterInfo { Name = "ToString", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.M_ToString
#endif
                    }},
                    {"GetHashCode", new MemberRegisterInfo { Name = "GetHashCode", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.M_GetHashCode
#endif
                    }},
                    {"Equals", new MemberRegisterInfo { Name = "Equals", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.M_Equals
#endif
                    }},
                    {"SqrMagnitude", new MemberRegisterInfo { Name = "SqrMagnitude", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.M_SqrMagnitude
#endif
                    }},
                    {"op_Addition_static", new MemberRegisterInfo { Name = "op_Addition", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.O_op_Addition
#endif
                    }},
                    {"op_Subtraction_static", new MemberRegisterInfo { Name = "op_Subtraction", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.O_op_Subtraction
#endif
                    }},
                    {"op_Multiply_static", new MemberRegisterInfo { Name = "op_Multiply", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.O_op_Multiply
#endif
                    }},
                    {"op_Division_static", new MemberRegisterInfo { Name = "op_Division", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.O_op_Division
#endif
                    }},
                    {"op_UnaryNegation_static", new MemberRegisterInfo { Name = "op_UnaryNegation", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.O_op_UnaryNegation
#endif
                    }},
                    {"op_Equality_static", new MemberRegisterInfo { Name = "op_Equality", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.O_op_Equality
#endif
                    }},
                    {"op_Inequality_static", new MemberRegisterInfo { Name = "op_Inequality", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.O_op_Inequality
#endif
                    }},
                    {"get_Item", new MemberRegisterInfo { Name = "get_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.GetItem
#endif
                    }},
                    {"set_Item", new MemberRegisterInfo { Name = "set_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.SetItem
#endif
                    }},
                    {"normalized", new MemberRegisterInfo { Name = "normalized", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_normalized
#endif
                    }},
                    {"magnitude", new MemberRegisterInfo { Name = "magnitude", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_magnitude
#endif
                    }},
                    {"sqrMagnitude", new MemberRegisterInfo { Name = "sqrMagnitude", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_sqrMagnitude
#endif
                    }},
                    {"x", new MemberRegisterInfo { Name = "x", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_x, PropertySetter = UnityEngine_Vector2_Wrap.S_x
#endif
                    }},
                    {"y", new MemberRegisterInfo { Name = "y", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_y, PropertySetter = UnityEngine_Vector2_Wrap.S_y
#endif
                    }},
                    {"Lerp_static", new MemberRegisterInfo { Name = "Lerp", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Lerp
#endif
                    }},
                    {"LerpUnclamped_static", new MemberRegisterInfo { Name = "LerpUnclamped", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_LerpUnclamped
#endif
                    }},
                    {"MoveTowards_static", new MemberRegisterInfo { Name = "MoveTowards", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_MoveTowards
#endif
                    }},
                    {"Scale_static", new MemberRegisterInfo { Name = "Scale", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Scale
#endif
                    }},
                    {"Reflect_static", new MemberRegisterInfo { Name = "Reflect", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Reflect
#endif
                    }},
                    {"Perpendicular_static", new MemberRegisterInfo { Name = "Perpendicular", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Perpendicular
#endif
                    }},
                    {"Dot_static", new MemberRegisterInfo { Name = "Dot", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Dot
#endif
                    }},
                    {"Angle_static", new MemberRegisterInfo { Name = "Angle", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Angle
#endif
                    }},
                    {"SignedAngle_static", new MemberRegisterInfo { Name = "SignedAngle", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_SignedAngle
#endif
                    }},
                    {"Distance_static", new MemberRegisterInfo { Name = "Distance", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Distance
#endif
                    }},
                    {"ClampMagnitude_static", new MemberRegisterInfo { Name = "ClampMagnitude", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_ClampMagnitude
#endif
                    }},
                    {"SqrMagnitude_static", new MemberRegisterInfo { Name = "SqrMagnitude", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_SqrMagnitude
#endif
                    }},
                    {"Min_static", new MemberRegisterInfo { Name = "Min", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Min
#endif
                    }},
                    {"Max_static", new MemberRegisterInfo { Name = "Max", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_Max
#endif
                    }},
                    {"SmoothDamp_static", new MemberRegisterInfo { Name = "SmoothDamp", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = UnityEngine_Vector2_Wrap.F_SmoothDamp
#endif
                    }},
                    {"zero_static", new MemberRegisterInfo { Name = "zero", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_zero
#endif
                    }},
                    {"one_static", new MemberRegisterInfo { Name = "one", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_one
#endif
                    }},
                    {"up_static", new MemberRegisterInfo { Name = "up", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_up
#endif
                    }},
                    {"down_static", new MemberRegisterInfo { Name = "down", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_down
#endif
                    }},
                    {"left_static", new MemberRegisterInfo { Name = "left", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_left
#endif
                    }},
                    {"right_static", new MemberRegisterInfo { Name = "right", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_right
#endif
                    }},
                    {"positiveInfinity_static", new MemberRegisterInfo { Name = "positiveInfinity", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_positiveInfinity
#endif
                    }},
                    {"negativeInfinity_static", new MemberRegisterInfo { Name = "negativeInfinity", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_negativeInfinity
#endif
                    }},
                    {"kEpsilon_static", new MemberRegisterInfo { Name = "kEpsilon", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_kEpsilon
#endif
                    }},
                    {"kEpsilonNormalSqrt_static", new MemberRegisterInfo { Name = "kEpsilonNormalSqrt", IsStatic = true, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = UnityEngine_Vector2_Wrap.G_kEpsilonNormalSqrt
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_Puerts_ILoader_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"FileExists", new MemberRegisterInfo { Name = "FileExists", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = Puerts_ILoader_Wrap.M_FileExists
#endif
                    }},
                    {"ReadFile", new MemberRegisterInfo { Name = "ReadFile", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = Puerts_ILoader_Wrap.M_ReadFile
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_System_Array_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"CopyTo", new MemberRegisterInfo { Name = "CopyTo", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_CopyTo
#endif
                    }},
                    {"Clone", new MemberRegisterInfo { Name = "Clone", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_Clone
#endif
                    }},
                    {"GetLongLength", new MemberRegisterInfo { Name = "GetLongLength", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_GetLongLength
#endif
                    }},
                    {"GetValue", new MemberRegisterInfo { Name = "GetValue", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_GetValue
#endif
                    }},
                    {"SetValue", new MemberRegisterInfo { Name = "SetValue", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_SetValue
#endif
                    }},
                    {"GetEnumerator", new MemberRegisterInfo { Name = "GetEnumerator", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_GetEnumerator
#endif
                    }},
                    {"GetLength", new MemberRegisterInfo { Name = "GetLength", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_GetLength
#endif
                    }},
                    {"GetLowerBound", new MemberRegisterInfo { Name = "GetLowerBound", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_GetLowerBound
#endif
                    }},
                    {"GetUpperBound", new MemberRegisterInfo { Name = "GetUpperBound", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_GetUpperBound
#endif
                    }},
                    {"Initialize", new MemberRegisterInfo { Name = "Initialize", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.M_Initialize
#endif
                    }},
                    {"LongLength", new MemberRegisterInfo { Name = "LongLength", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Array_Wrap.G_LongLength
#endif
                    }},
                    {"IsFixedSize", new MemberRegisterInfo { Name = "IsFixedSize", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Array_Wrap.G_IsFixedSize
#endif
                    }},
                    {"IsReadOnly", new MemberRegisterInfo { Name = "IsReadOnly", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Array_Wrap.G_IsReadOnly
#endif
                    }},
                    {"IsSynchronized", new MemberRegisterInfo { Name = "IsSynchronized", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Array_Wrap.G_IsSynchronized
#endif
                    }},
                    {"SyncRoot", new MemberRegisterInfo { Name = "SyncRoot", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Array_Wrap.G_SyncRoot
#endif
                    }},
                    {"Length", new MemberRegisterInfo { Name = "Length", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Array_Wrap.G_Length
#endif
                    }},
                    {"Rank", new MemberRegisterInfo { Name = "Rank", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Array_Wrap.G_Rank
#endif
                    }},
                    {"CreateInstance_static", new MemberRegisterInfo { Name = "CreateInstance", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_CreateInstance
#endif
                    }},
                    {"BinarySearch_static", new MemberRegisterInfo { Name = "BinarySearch", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_BinarySearch
#endif
                    }},
                    {"Copy_static", new MemberRegisterInfo { Name = "Copy", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_Copy
#endif
                    }},
                    {"IndexOf_static", new MemberRegisterInfo { Name = "IndexOf", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_IndexOf
#endif
                    }},
                    {"LastIndexOf_static", new MemberRegisterInfo { Name = "LastIndexOf", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_LastIndexOf
#endif
                    }},
                    {"Reverse_static", new MemberRegisterInfo { Name = "Reverse", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_Reverse
#endif
                    }},
                    {"Sort_static", new MemberRegisterInfo { Name = "Sort", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_Sort
#endif
                    }},
                    {"Clear_static", new MemberRegisterInfo { Name = "Clear", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_Clear
#endif
                    }},
                    {"ConstrainedCopy_static", new MemberRegisterInfo { Name = "ConstrainedCopy", IsStatic = true, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Array_Wrap.F_ConstrainedCopy
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_System_Collections_IList_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"Add", new MemberRegisterInfo { Name = "Add", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.M_Add
#endif
                    }},
                    {"Contains", new MemberRegisterInfo { Name = "Contains", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.M_Contains
#endif
                    }},
                    {"Clear", new MemberRegisterInfo { Name = "Clear", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.M_Clear
#endif
                    }},
                    {"IndexOf", new MemberRegisterInfo { Name = "IndexOf", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.M_IndexOf
#endif
                    }},
                    {"Insert", new MemberRegisterInfo { Name = "Insert", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.M_Insert
#endif
                    }},
                    {"Remove", new MemberRegisterInfo { Name = "Remove", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.M_Remove
#endif
                    }},
                    {"RemoveAt", new MemberRegisterInfo { Name = "RemoveAt", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.M_RemoveAt
#endif
                    }},
                    {"get_Item", new MemberRegisterInfo { Name = "get_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.GetItem
#endif
                    }},
                    {"set_Item", new MemberRegisterInfo { Name = "set_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IList_Wrap.SetItem
#endif
                    }},
                    {"IsReadOnly", new MemberRegisterInfo { Name = "IsReadOnly", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_IList_Wrap.G_IsReadOnly
#endif
                    }},
                    {"IsFixedSize", new MemberRegisterInfo { Name = "IsFixedSize", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_IList_Wrap.G_IsFixedSize
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_System_Collections_ICollection_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"CopyTo", new MemberRegisterInfo { Name = "CopyTo", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_ICollection_Wrap.M_CopyTo
#endif
                    }},
                    {"Count", new MemberRegisterInfo { Name = "Count", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_ICollection_Wrap.G_Count
#endif
                    }},
                    {"SyncRoot", new MemberRegisterInfo { Name = "SyncRoot", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_ICollection_Wrap.G_SyncRoot
#endif
                    }},
                    {"IsSynchronized", new MemberRegisterInfo { Name = "IsSynchronized", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_ICollection_Wrap.G_IsSynchronized
#endif
                    }},
                }
            };
        }
        public static RegisterInfo GetRegisterInfo_System_Collections_IDictionary_Wrap() 
        {
            return new RegisterInfo 
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    
                    {"Contains", new MemberRegisterInfo { Name = "Contains", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IDictionary_Wrap.M_Contains
#endif
                    }},
                    {"Add", new MemberRegisterInfo { Name = "Add", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IDictionary_Wrap.M_Add
#endif
                    }},
                    {"Clear", new MemberRegisterInfo { Name = "Clear", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IDictionary_Wrap.M_Clear
#endif
                    }},
                    {"GetEnumerator", new MemberRegisterInfo { Name = "GetEnumerator", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IDictionary_Wrap.M_GetEnumerator
#endif
                    }},
                    {"Remove", new MemberRegisterInfo { Name = "Remove", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IDictionary_Wrap.M_Remove
#endif
                    }},
                    {"get_Item", new MemberRegisterInfo { Name = "get_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IDictionary_Wrap.GetItem
#endif
                    }},
                    {"set_Item", new MemberRegisterInfo { Name = "set_Item", IsStatic = false, MemberType = MemberType.Method, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , Method = System_Collections_IDictionary_Wrap.SetItem
#endif
                    }},
                    {"Keys", new MemberRegisterInfo { Name = "Keys", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_IDictionary_Wrap.G_Keys
#endif
                    }},
                    {"Values", new MemberRegisterInfo { Name = "Values", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_IDictionary_Wrap.G_Values
#endif
                    }},
                    {"IsReadOnly", new MemberRegisterInfo { Name = "IsReadOnly", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_IDictionary_Wrap.G_IsReadOnly
#endif
                    }},
                    {"IsFixedSize", new MemberRegisterInfo { Name = "IsFixedSize", IsStatic = false, MemberType = MemberType.Property, UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                    , PropertyGetter = System_Collections_IDictionary_Wrap.G_IsFixedSize
#endif
                    }},
                }
            };
        }

        public static void AddRegisterInfoGetterIntoJsEnv(JsEnv jsEnv)
        {
            
                jsEnv.AddRegisterInfoGetter(typeof(UnityEngine.GameObject), GetRegisterInfo_UnityEngine_GameObject_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(UnityEngine.Transform), GetRegisterInfo_UnityEngine_Transform_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(UnityEngine.Rigidbody), GetRegisterInfo_UnityEngine_Rigidbody_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(UnityEngine.Rigidbody2D), GetRegisterInfo_UnityEngine_Rigidbody2D_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(UnityEngine.Vector3), GetRegisterInfo_UnityEngine_Vector3_Wrap);
#if !EXPERIMENTAL_IL2CPP_PUERTS
                UnityEngine_Vector3_Wrap.InitBlittableCopy(jsEnv);                    
#endif
                jsEnv.AddRegisterInfoGetter(typeof(UnityEngine.Vector2), GetRegisterInfo_UnityEngine_Vector2_Wrap);
#if !EXPERIMENTAL_IL2CPP_PUERTS
                UnityEngine_Vector2_Wrap.InitBlittableCopy(jsEnv);                    
#endif
                jsEnv.AddRegisterInfoGetter(typeof(Puerts.ILoader), GetRegisterInfo_Puerts_ILoader_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(System.Array), GetRegisterInfo_System_Array_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(System.Collections.IList), GetRegisterInfo_System_Collections_IList_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(System.Collections.ICollection), GetRegisterInfo_System_Collections_ICollection_Wrap);
                jsEnv.AddRegisterInfoGetter(typeof(System.Collections.IDictionary), GetRegisterInfo_System_Collections_IDictionary_Wrap);
        }
    }
}