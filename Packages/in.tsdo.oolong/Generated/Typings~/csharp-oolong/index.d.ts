
    declare namespace CS {
    //keep type incompatibility / 此属性保持类型不兼容
    const __keep_incompatibility: unique symbol;
    interface $Ref<T> {
        value: T
    }
    namespace System {
        interface Array$1<T> extends System.Array {
            get_Item(index: number):T;
            set_Item(index: number, value: T):void;
        }
    }
    interface $Task<T> {}
    namespace System {
        class Object
        {
            protected [__keep_incompatibility]: never;
        }
        class Delegate extends System.Object implements System.Runtime.Serialization.ISerializable, System.ICloneable
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICloneable
        {
        }
        interface MulticastDelegate
        { 
        (...args:any[]) : any; 
        Invoke?: (...args:any[]) => any;
        }
        var MulticastDelegate: { new (func: (...args:any[]) => any): MulticastDelegate; }
        interface Action
        { 
        () : void; 
        Invoke?: () => void;
        }
        var Action: { new (func: () => void): Action; }
        class ValueType extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class Void extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class String extends System.Object implements System.ICloneable, System.IComparable, System.IComparable$1<string>, System.IConvertible, System.Collections.Generic.IEnumerable$1<number>, System.Collections.IEnumerable, System.IEquatable$1<string>
        {
            protected [__keep_incompatibility]: never;
        }
        interface IComparable
        {
        }
        interface IComparable$1<T>
        {
        }
        interface IConvertible
        {
        }
        class Char extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        interface IEquatable$1<T>
        {
        }
        interface Action$1<T>
        { 
        (obj: T) : void; 
        Invoke?: (obj: T) => void;
        }
        class Boolean extends System.ValueType implements System.IComparable, System.IComparable$1<boolean>, System.IConvertible, System.IEquatable$1<boolean>
        {
            protected [__keep_incompatibility]: never;
        }
        class Int32 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        interface IFormattable
        {
        }
        interface ISpanFormattable
        {
        }
        interface IDisposable
        {
        }
        class Array extends System.Object implements System.Collections.IStructuralComparable, System.Collections.IStructuralEquatable, System.ICloneable, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine {
        /** Base class for all objects Unity can reference.
        */
        class Object extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** Base class for everything attached to a GameObject.
        */
        class Component extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** Behaviours are Components that can be enabled or disabled.
        */
        class Behaviour extends UnityEngine.Component
        {
            protected [__keep_incompatibility]: never;
        }
        /** MonoBehaviour is a base class that many Unity scripts derive from.
        */
        class MonoBehaviour extends UnityEngine.Behaviour
        {
            protected [__keep_incompatibility]: never;
        }
        /** Represents a raw text or binary file asset.
        */
        class TextAsset extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace TSF.Oolong {
        class ScriptBehaviour extends UnityEngine.MonoBehaviour
        {
            protected [__keep_incompatibility]: never;
            public AddressableScript : UnityEngine.AddressableAssets.AssetReferenceT$1<UnityEngine.TextAsset>
            public JsAwake : System.Action
            public JsStart : System.Action
            public JsOnEnable : System.Action
            public JsOnDisable : System.Action
            public JsOnDestroy : System.Action
            public JsCall : System.Action$1<string>
            public get HasScript(): boolean;
            public get EditorAsset(): UnityEngine.TextAsset;
            public SetHooks ($awake: System.Action, $start: System.Action, $onEnable: System.Action, $onDisable: System.Action, $onDestroy: System.Action) : void
            public Call ($func: string) : void
            public ClearHooks () : void
            public KeepAsset () : void
            public GetScriptInstanceID () : number
            public GetGameObjectInstanceID () : number
            public constructor ()
        }
        class OolongEnvironment extends System.Object implements Puerts.ILoader, Puerts.IResolvableLoader
        {
            protected [__keep_incompatibility]: never;
            public static OnInitialize : System.Action
            public static OnDispose : System.Action
            public static get JsEnv(): Puerts.JsEnv;
            public static get Instance(): TSF.Oolong.OolongEnvironment;
            public static add_OnTick ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static remove_OnTick ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static add_OnUpdate ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static remove_OnUpdate ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static add_OnFixedUpdate ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static remove_OnFixedUpdate ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static add_OnLateUpdate ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static remove_OnLateUpdate ($value: TSF.Oolong.OolongEnvironment.JsUpdate) : void
            public static Initialize () : void
            public static DisposeInstance () : void
            public Attach ($behaviour: TSF.Oolong.ScriptBehaviour, $scriptClass: Puerts.JSObject, $jsonData: string) : void
            public Detach ($behaviour: TSF.Oolong.ScriptBehaviour) : void
            public FileExists ($filePath: string) : boolean
            public ReadFile ($filePath: string, $debugPath: $Ref<string>) : string
            public Resolve ($specifier: string, $referrer: string) : string
        }
    }
    namespace UnityEngine.AddressableAssets {
        class AssetReference extends System.Object implements UnityEngine.AddressableAssets.IKeyEvaluator
        {
            protected [__keep_incompatibility]: never;
        }
        interface IKeyEvaluator
        {
        }
        class AssetReferenceT$1<TObject> extends UnityEngine.AddressableAssets.AssetReference implements UnityEngine.AddressableAssets.IKeyEvaluator
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Runtime.Serialization {
        interface ISerializable
        {
        }
    }
    namespace System.Collections.Generic {
        interface IEnumerable$1<T> extends System.Collections.IEnumerable
        {
        }
    }
    namespace System.Collections {
        interface IEnumerable
        {
        }
        interface IStructuralComparable
        {
        }
        interface IStructuralEquatable
        {
        }
        interface ICollection extends System.Collections.IEnumerable
        {
        }
        interface IList extends System.Collections.ICollection, System.Collections.IEnumerable
        {
        }
    }
    namespace Puerts {
        interface ILoader
        {
        }
        interface IResolvableLoader
        {
        }
        class JsEnv extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        type JSObject = any;
    }
    namespace TSF.Oolong.OolongEnvironment {
        interface JsUpdate
        { 
        () : void; 
        Invoke?: () => void;
        }
        var JsUpdate: { new (func: () => void): JsUpdate; }
    }
}
