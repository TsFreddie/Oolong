
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
        class ValueType extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class Void extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class Boolean extends System.ValueType implements System.IComparable, System.IComparable$1<boolean>, System.IConvertible, System.IEquatable$1<boolean>
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
        interface IEquatable$1<T>
        {
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
        class String extends System.Object implements System.ICloneable, System.IComparable, System.IComparable$1<string>, System.IConvertible, System.Collections.Generic.IEnumerable$1<number>, System.Collections.IEnumerable, System.IEquatable$1<string>
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICloneable
        {
        }
        class Char extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        class Delegate extends System.Object implements System.Runtime.Serialization.ISerializable, System.ICloneable
        {
            protected [__keep_incompatibility]: never;
        }
        interface MulticastDelegate
        { 
        (...args:any[]) : any; 
        Invoke?: (...args:any[]) => any;
        }
        var MulticastDelegate: { new (func: (...args:any[]) => any): MulticastDelegate; }
        class Enum extends System.ValueType implements System.IFormattable, System.IComparable, System.IConvertible
        {
            protected [__keep_incompatibility]: never;
        }
        interface Action
        { 
        () : void; 
        Invoke?: () => void;
        }
        var Action: { new (func: () => void): Action; }
        class Type extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._Type, System.Reflection.ICustomAttributeProvider, System.Reflection.IReflect
        {
            protected [__keep_incompatibility]: never;
        }
        class Single extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        interface IDisposable
        {
        }
        interface Action$1<T>
        { 
        (obj: T) : void; 
        Invoke?: (obj: T) => void;
        }
        class Byte extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        class Array extends System.Object implements System.Collections.IStructuralComparable, System.Collections.IStructuralEquatable, System.ICloneable, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
        {
            protected [__keep_incompatibility]: never;
        }
        class Uri extends System.Object implements System.Runtime.Serialization.ISerializable
        {
            protected [__keep_incompatibility]: never;
        }
        class Int64 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>
        {
            protected [__keep_incompatibility]: never;
        }
        class UInt64 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>
        {
            protected [__keep_incompatibility]: never;
        }
        class UInt32 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
    }
        class OolongUGUI extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static get TextTransformer(): ITextTransformer;
            public static set TextTransformer(value: ITextTransformer);
            public static get AddressTransformer(): IAddressTransformer;
            public static set AddressTransformer(value: IAddressTransformer);
            public static Initialize () : void
            public static Mount ($element: TSF.Oolong.UGUI.OolongElement, $component: Puerts.JSObject, $partial: boolean) : Puerts.JSObject
            public static Unmount ($element: Puerts.JSObject) : void
            public static Redraw ($element?: Puerts.JSObject) : void
            public static Redraw ($mountId?: number) : void
            public static TransformText ($text: string, $loader: TSF.Oolong.UGUI.OolongTextLoader) : string
            public static TransformAddress ($tag: string, $address: string) : string
        }
        interface ITextTransformer
        {
        }
        interface IAddressTransformer
        {
        }
        namespace Puerts {
        type JSObject = any;
        class ArrayBuffer extends System.Object
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
        /** Position, rotation and scale of an object.
        */
        class Transform extends UnityEngine.Component implements System.Collections.IEnumerable
        {
            protected [__keep_incompatibility]: never;
        }
        /** Base class for all entities in Unity Scenes.
        */
        class GameObject extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICanvasRaycastFilter
        {
        }
        interface ISerializationCallbackReceiver
        {
        }
        /** Position, size, anchor and pivot information for a rectangle.
        */
        class RectTransform extends UnityEngine.Transform implements System.Collections.IEnumerable
        {
            protected [__keep_incompatibility]: never;
        }
        /** Representation of RGBA colors.
        */
        class Color extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Color>
        {
            protected [__keep_incompatibility]: never;
        }
        /** A Canvas placable element that can be used to modify children Alpha, Raycasting, Enabled state.
        */
        class CanvasGroup extends UnityEngine.Behaviour implements UnityEngine.ICanvasRaycastFilter
        {
            protected [__keep_incompatibility]: never;
        }
        /** Represents a raw text or binary file asset.
        */
        class TextAsset extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** The material class.
        */
        class Material extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** Base class for all yield instructions.
        */
        class YieldInstruction extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** Asynchronous operation coroutine.
        */
        class AsyncOperation extends UnityEngine.YieldInstruction
        {
            protected [__keep_incompatibility]: never;
        }
        /** Type of the imported(native) data.
        */
        enum AudioType
        { UNKNOWN = 0, ACC = 1, AIFF = 2, IT = 10, MOD = 12, MPEG = 13, OGGVORBIS = 14, S3M = 17, WAV = 20, XM = 21, XMA = 22, VAG = 23, AUDIOQUEUE = 24 }
        /** Represents  a 128-bit hash value.
        */
        class Hash128 extends System.ValueType implements System.IComparable, System.IComparable$1<UnityEngine.Hash128>, System.IEquatable$1<UnityEngine.Hash128>
        {
            protected [__keep_incompatibility]: never;
        }
        /** Data structure for downloading AssetBundles to a customized cache path. See Also:UnityWebRequestAssetBundle.GetAssetBundle for more information.
        */
        class CachedAssetBundle extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        /** Helper class to generate form data to post to web servers using the UnityWebRequest or WWW classes.
        */
        class WWWForm extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace TSF.Oolong.UGUI {
        class OolongElement extends UnityEngine.MonoBehaviour
        {
            protected [__keep_incompatibility]: never;
            public Attrs : System.Collections.Generic.Dictionary$2<string, string>
            public get TagName(): string;
            public set TagName(value: string);
            public get RootTransform(): UnityEngine.Transform;
            public set RootTransform(value: UnityEngine.Transform);
            public get ParentElement(): TSF.Oolong.UGUI.OolongElement;
            public set ParentElement(value: TSF.Oolong.UGUI.OolongElement);
            public get MountId(): number;
            public set MountId(value: number);
            public get Version(): number;
            public GetInstanceID () : number
            public AddChild ($e: TSF.Oolong.UGUI.OolongElement) : void
            public RemoveChild ($e: TSF.Oolong.UGUI.OolongElement) : void
            public ResetChildren () : void
            public SetElementAttribute ($key: string, $value: string) : boolean
            public GetElementAttribute ($key: string) : string
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener ($key: string) : void
            public OnCreate ($loader: TSF.Oolong.UGUI.IOolongLoader) : void
            public OnReset () : void
            public OnReuse () : void
            public Redraw () : void
            public constructor ()
        }
        class OolongLoader$1<T> extends System.Object implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        interface IOolongLoader
        {
            AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            RemoveListener ($key: string) : boolean
            Release () : void
            Reuse () : void
            Reset () : void
            SetAttribute ($key: string, $value: string) : boolean
            TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            ResetTransitions () : void
            SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongTextLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongTextLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TMPro.TextMeshProUGUI
            public Element : TSF.Oolong.UGUI.OolongElement
            public get DefaultAlign(): TMPro.TextAlignmentOptions;
            public set DefaultAlign(value: TMPro.TextAlignmentOptions);
            public get DefaultOverflow(): TMPro.TextOverflowModes;
            public set DefaultOverflow(value: TMPro.TextOverflowModes);
            public get DefaultWrap(): boolean;
            public set DefaultWrap(value: boolean);
            public get DefaultColor(): UnityEngine.Color;
            public set DefaultColor(value: UnityEngine.Color);
            public get DefaultStyle(): TMPro.FontStyles;
            public set DefaultStyle(value: TMPro.FontStyles);
            public constructor ($gameObject: UnityEngine.GameObject, $element: TSF.Oolong.UGUI.OolongElement)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        interface IOolongSelectable
        {
            enabled : boolean
            transform : UnityEngine.Transform
            gameObject : UnityEngine.GameObject
            colors : UnityEngine.UI.ColorBlock
            spriteState : UnityEngine.UI.SpriteState
            transition : UnityEngine.UI.Selectable.Transition
            targetGraphic : UnityEngine.UI.Graphic
            interactable : boolean
            image : UnityEngine.UI.Image
            add_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            remove_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            IsInteractable () : boolean
        }
        interface CanvasGroupChanged
        { 
        () : void; 
        Invoke?: () => void;
        }
        var CanvasGroupChanged: { new (func: () => void): CanvasGroupChanged; }
        class OolongButton extends UnityEngine.UI.Button implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, TSF.Oolong.UGUI.IOolongSelectable, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public get enabled(): boolean;
            public set enabled(value: boolean);
            public get transform(): UnityEngine.Transform;
            public get gameObject(): UnityEngine.GameObject;
            public get colors(): UnityEngine.UI.ColorBlock;
            public set colors(value: UnityEngine.UI.ColorBlock);
            public get spriteState(): UnityEngine.UI.SpriteState;
            public set spriteState(value: UnityEngine.UI.SpriteState);
            public get transition(): UnityEngine.UI.Selectable.Transition;
            public set transition(value: UnityEngine.UI.Selectable.Transition);
            public get targetGraphic(): UnityEngine.UI.Graphic;
            public set targetGraphic(value: UnityEngine.UI.Graphic);
            public get interactable(): boolean;
            public set interactable(value: boolean);
            public get image(): UnityEngine.UI.Image;
            public set image(value: UnityEngine.UI.Image);
            public add_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public remove_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public constructor ()
            public IsInteractable () : boolean
        }
        class OolongInput extends TMPro.TMP_InputField implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.IEndDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, TSF.Oolong.UGUI.IOolongSelectable, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler, UnityEngine.UI.ILayoutElement
        {
            protected [__keep_incompatibility]: never;
            public get enabled(): boolean;
            public set enabled(value: boolean);
            public get transform(): UnityEngine.Transform;
            public get gameObject(): UnityEngine.GameObject;
            public get colors(): UnityEngine.UI.ColorBlock;
            public set colors(value: UnityEngine.UI.ColorBlock);
            public get spriteState(): UnityEngine.UI.SpriteState;
            public set spriteState(value: UnityEngine.UI.SpriteState);
            public get transition(): UnityEngine.UI.Selectable.Transition;
            public set transition(value: UnityEngine.UI.Selectable.Transition);
            public get targetGraphic(): UnityEngine.UI.Graphic;
            public set targetGraphic(value: UnityEngine.UI.Graphic);
            public get interactable(): boolean;
            public set interactable(value: boolean);
            public get image(): UnityEngine.UI.Image;
            public set image(value: UnityEngine.UI.Image);
            public add_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public remove_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public constructor ()
            public IsInteractable () : boolean
        }
        class OolongScrollbar extends UnityEngine.UI.Scrollbar implements UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, TSF.Oolong.UGUI.IOolongSelectable, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public get enabled(): boolean;
            public set enabled(value: boolean);
            public get transform(): UnityEngine.Transform;
            public get gameObject(): UnityEngine.GameObject;
            public get colors(): UnityEngine.UI.ColorBlock;
            public set colors(value: UnityEngine.UI.ColorBlock);
            public get spriteState(): UnityEngine.UI.SpriteState;
            public set spriteState(value: UnityEngine.UI.SpriteState);
            public get transition(): UnityEngine.UI.Selectable.Transition;
            public set transition(value: UnityEngine.UI.Selectable.Transition);
            public get targetGraphic(): UnityEngine.UI.Graphic;
            public set targetGraphic(value: UnityEngine.UI.Graphic);
            public get interactable(): boolean;
            public set interactable(value: boolean);
            public get image(): UnityEngine.UI.Image;
            public set image(value: UnityEngine.UI.Image);
            public add_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public remove_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public constructor ()
            public IsInteractable () : boolean
        }
        class OolongSelectable extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, TSF.Oolong.UGUI.IOolongSelectable, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public get enabled(): boolean;
            public set enabled(value: boolean);
            public get transform(): UnityEngine.Transform;
            public get gameObject(): UnityEngine.GameObject;
            public get colors(): UnityEngine.UI.ColorBlock;
            public set colors(value: UnityEngine.UI.ColorBlock);
            public get spriteState(): UnityEngine.UI.SpriteState;
            public set spriteState(value: UnityEngine.UI.SpriteState);
            public get transition(): UnityEngine.UI.Selectable.Transition;
            public set transition(value: UnityEngine.UI.Selectable.Transition);
            public get targetGraphic(): UnityEngine.UI.Graphic;
            public set targetGraphic(value: UnityEngine.UI.Graphic);
            public get interactable(): boolean;
            public set interactable(value: boolean);
            public get image(): UnityEngine.UI.Image;
            public set image(value: UnityEngine.UI.Image);
            public add_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public remove_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public constructor ()
            public IsInteractable () : boolean
        }
        class OolongSlider extends UnityEngine.UI.Slider implements UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, TSF.Oolong.UGUI.IOolongSelectable, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public get enabled(): boolean;
            public set enabled(value: boolean);
            public get transform(): UnityEngine.Transform;
            public get gameObject(): UnityEngine.GameObject;
            public get colors(): UnityEngine.UI.ColorBlock;
            public set colors(value: UnityEngine.UI.ColorBlock);
            public get spriteState(): UnityEngine.UI.SpriteState;
            public set spriteState(value: UnityEngine.UI.SpriteState);
            public get transition(): UnityEngine.UI.Selectable.Transition;
            public set transition(value: UnityEngine.UI.Selectable.Transition);
            public get targetGraphic(): UnityEngine.UI.Graphic;
            public set targetGraphic(value: UnityEngine.UI.Graphic);
            public get interactable(): boolean;
            public set interactable(value: boolean);
            public get image(): UnityEngine.UI.Image;
            public set image(value: UnityEngine.UI.Image);
            public add_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public remove_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public constructor ()
            public IsInteractable () : boolean
        }
        class OolongToggle extends UnityEngine.UI.Toggle implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, TSF.Oolong.UGUI.IOolongSelectable, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public get enabled(): boolean;
            public set enabled(value: boolean);
            public get transform(): UnityEngine.Transform;
            public get gameObject(): UnityEngine.GameObject;
            public get colors(): UnityEngine.UI.ColorBlock;
            public set colors(value: UnityEngine.UI.ColorBlock);
            public get spriteState(): UnityEngine.UI.SpriteState;
            public set spriteState(value: UnityEngine.UI.SpriteState);
            public get transition(): UnityEngine.UI.Selectable.Transition;
            public set transition(value: UnityEngine.UI.Selectable.Transition);
            public get targetGraphic(): UnityEngine.UI.Graphic;
            public set targetGraphic(value: UnityEngine.UI.Graphic);
            public get interactable(): boolean;
            public set interactable(value: boolean);
            public get image(): UnityEngine.UI.Image;
            public set image(value: UnityEngine.UI.Image);
            public add_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public remove_OnCanvasGroupChange ($value: TSF.Oolong.UGUI.CanvasGroupChanged) : void
            public constructor ()
            public IsInteractable () : boolean
        }
        class DocumentUtils extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static OnTransitionUpdate : System.Action
            public static OnTransitionValueUpdate : System.Action
            public static OnDocumentUpdate : System.Action
            public static OnDocumentLateUpdate : System.Action
            public static get PoolInitialized(): boolean;
            public static Initialize () : void
            public static AttachElement ($parent: TSF.Oolong.UGUI.OolongElement, $node: TSF.Oolong.UGUI.OolongElement) : void
            public static RemoveElement ($parent: TSF.Oolong.UGUI.OolongElement, $node: TSF.Oolong.UGUI.OolongElement) : void
            public static ResetElement ($node: TSF.Oolong.UGUI.OolongElement) : void
            public static InsertElement ($parent: TSF.Oolong.UGUI.OolongElement, $node: TSF.Oolong.UGUI.OolongElement, $index: number) : number
            public static CreateElement ($tagName: string) : TSF.Oolong.UGUI.OolongElement
            public static CacheElement ($tagName: string, $count: number) : void
            public static CreateChildRect ($parent: UnityEngine.Transform, $name: string) : UnityEngine.RectTransform
            public static ParseColor ($color: string) : UnityEngine.Color
            public static TryParseColor ($color: string, $value: $Ref<UnityEngine.Color>) : boolean
            public static Dispose () : void
            public static UpdateLayout () : void
            public static LateUpdateLayout () : void
        }
        interface IUIEventHandler
        {
            AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            RemoveListener () : void
        }
        class UIEventHandler extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static GetHandlerType ($key: string) : System.Type
            public static AddListenerToGameObject ($gameObject: UnityEngine.GameObject, $key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public static RemoveListenerFromGameObject ($gameObject: UnityEngine.GameObject, $key: string) : boolean
            public static ResetListeners ($gameObject: UnityEngine.GameObject) : void
        }
        class OnPointerEnterHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnPointerEnter ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnPointerExitHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerExitHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnPointerExit ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnPointerDownHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerDownHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnPointerDown ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnPointerUpHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerUpHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnPointerUp ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnPointerMoveHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnPointerMove ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnPointerClickHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.IPointerClickHandler, TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnPointerClick ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnInitializePotentialDragHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.IInitializePotentialDragHandler, TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnInitializePotentialDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnBeginDragHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.IBeginDragHandler, TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnBeginDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnDragHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.IDragHandler, TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnEndDragHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.IEndDragHandler, TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnEndDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnDropHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IDropHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnDrop ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnScrollHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IScrollHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnScroll ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public constructor ()
        }
        class OnUpdateSelectedHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IUpdateSelectedHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnUpdateSelected ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public constructor ()
        }
        class OnSelectHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.ISelectHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnSelect ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public constructor ()
        }
        class OnDeselectHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IDeselectHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnDeselect ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public constructor ()
        }
        class OnMoveHandler extends UnityEngine.MonoBehaviour implements TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnMove ($eventData: UnityEngine.EventSystems.AxisEventData) : void
            public constructor ()
        }
        class OnSubmitHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.ISubmitHandler, TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnSubmit ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public constructor ()
        }
        class OnCancelHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.ICancelHandler, TSF.Oolong.UGUI.IUIEventHandler, UnityEngine.EventSystems.IEventSystemHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener () : void
            public OnCancel ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public constructor ()
        }
        class CubicBezier extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
            public static Ease : TSF.Oolong.UGUI.CubicBezier
            public static Linear : TSF.Oolong.UGUI.CubicBezier
            public static EaseIn : TSF.Oolong.UGUI.CubicBezier
            public static EaseOut : TSF.Oolong.UGUI.CubicBezier
            public static EaseInOut : TSF.Oolong.UGUI.CubicBezier
            public Evaluate ($x: number) : number
            public constructor ($p1X: number, $p1Y: number, $p2X: number, $p2Y: number)
        }
        class OolongButtonLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongButtonLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TSF.Oolong.UGUI.OolongButton
            public constructor ($gameObject: UnityEngine.GameObject)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongCanvasGroupLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongCanvasGroupLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.CanvasGroup
            public constructor ($gameObject: UnityEngine.GameObject)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongChainLoader extends System.Object implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
            public Do ($action: System.Action) : TSF.Oolong.UGUI.OolongChainLoader
            public CreateChildRect ($transform: UnityEngine.Transform, $name: string, $childRect: $Ref<UnityEngine.RectTransform>) : TSF.Oolong.UGUI.OolongChainLoader
            public SetRoot ($e: TSF.Oolong.UGUI.OolongElement, $transform: UnityEngine.Transform) : TSF.Oolong.UGUI.OolongChainLoader
            public constructor ()
        }
        class OolongImageLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongImageLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.UI.Image
            public get DefaultType(): string;
            public set DefaultType(value: string);
            public get HasImage(): boolean;
            public get Loaded(): boolean;
            public get Enabled(): boolean;
            public set Enabled(value: boolean);
            public SetImage ($address: string) : void
            public constructor ($gameObject: UnityEngine.GameObject, $tagName: string)
            public constructor ($instance: UnityEngine.UI.Image, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongInputLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongInputLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TSF.Oolong.UGUI.OolongInput
            public Content : UnityEngine.RectTransform
            public TextArea : UnityEngine.RectTransform
            public constructor ($gameObject: UnityEngine.GameObject, $textArea: UnityEngine.RectTransform, $placeHolder: UnityEngine.UI.Graphic, $text: TMPro.TMP_Text)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongLayoutLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongLayoutLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public constructor ($obj: UnityEngine.GameObject)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongRectLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongRectLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.RectTransform
            public constructor ($transform: UnityEngine.Transform)
            public constructor ($rect: UnityEngine.RectTransform)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongRectMaskLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongRectMaskLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.UI.RectMask2D
            public constructor ($gameObject: UnityEngine.GameObject, $withNullGraphic?: boolean)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongScrollbarLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongScrollbarLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TSF.Oolong.UGUI.OolongScrollbar
            public get Enabled(): boolean;
            public constructor ($obj: UnityEngine.GameObject, $tagName: string)
            public constructor ($obj: UnityEngine.GameObject, $direction: UnityEngine.UI.Scrollbar.Direction, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongScrollRectLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongScrollRectLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.UI.ScrollRect
            public Viewport : UnityEngine.RectTransform
            public Content : UnityEngine.RectTransform
            public constructor ($obj: UnityEngine.GameObject, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongSelectableLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongSelectableLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TSF.Oolong.UGUI.IOolongSelectable
            public get HasImage(): boolean;
            public get Loaded(): boolean;
            public get Enabled(): boolean;
            public set Enabled(value: boolean);
            public constructor ($instance: TSF.Oolong.UGUI.IOolongSelectable, $tagName: string, $createImageTarget?: boolean)
            public constructor ($gameObject: UnityEngine.GameObject, $tagName: string, $createImageTarget?: boolean)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongSliderLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongSliderLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TSF.Oolong.UGUI.OolongSlider
            public get Enabled(): boolean;
            public constructor ($obj: UnityEngine.GameObject, $tagName: string)
            public constructor ($obj: UnityEngine.GameObject, $direction: UnityEngine.UI.Slider.Direction, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class OolongToggleLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongToggleLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TSF.Oolong.UGUI.OolongToggle
            public constructor ($gameObject: UnityEngine.GameObject, $checkmark?: UnityEngine.UI.Graphic)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($key: string, $value: string) : boolean
            public TryGetAttribute ($key: string, $value: $Ref<string>) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : void
        }
        class MithrilComponent extends TSF.Oolong.UGUI.OolongElement
        {
            protected [__keep_incompatibility]: never;
            public AddressableScript : UnityEngine.AddressableAssets.AssetReferenceT$1<UnityEngine.TextAsset>
            public get HasScript(): boolean;
            public get PartialRedraw(): boolean;
            public Redraw () : void
            public constructor ()
        }
        class UnityWebRequestExtension extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static Create () : UnityEngine.Networking.UnityWebRequest
            public static SetArrayBufferBody ($request: UnityEngine.Networking.UnityWebRequest, $body: ArrayBuffer) : void
            public static SetStringBody ($request: UnityEngine.Networking.UnityWebRequest, $body: string) : void
            public static SendWithCallback ($request: UnityEngine.Networking.UnityWebRequest, $callback: TSF.Oolong.UGUI.UnityWebRequestExtension.JsWebCallback) : void
            public static GetArrayBuffer ($handler: UnityEngine.Networking.DownloadHandler) : ArrayBuffer
        }
        class OolongTextMeshPro extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static GetFont ($fontName: string, $materialName: string, $font: $Ref<UnityEngine.TextCore.Text.FontAsset>, $material: $Ref<UnityEngine.Material>) : void
        }
        class TransitionProperty$1<T> extends System.Object implements TSF.Oolong.UGUI.ITransitionProperty
        {
            protected [__keep_incompatibility]: never;
            public get TimingFunction(): TSF.Oolong.UGUI.CubicBezier;
            public set TimingFunction(value: TSF.Oolong.UGUI.CubicBezier);
            public get Delay(): number;
            public set Delay(value: number);
            public get Duration(): number;
            public set Duration(value: number);
            public Reset () : void
        }
        interface ITransitionProperty
        {
            TimingFunction : TSF.Oolong.UGUI.CubicBezier
            Delay : number
            Duration : number
            Reset () : void
        }
        class BooleanTransitionProperty extends TSF.Oolong.UGUI.TransitionProperty$1<boolean> implements TSF.Oolong.UGUI.ITransitionProperty
        {
            protected [__keep_incompatibility]: never;
            public get TimingFunction(): TSF.Oolong.UGUI.CubicBezier;
            public set TimingFunction(value: TSF.Oolong.UGUI.CubicBezier);
            public get Delay(): number;
            public set Delay(value: number);
            public get Duration(): number;
            public set Duration(value: number);
            public constructor ($applyCallback?: System.Action$1<boolean>, $defaultValue?: boolean)
            public Reset () : void
        }
        class ColorTransitionProperty extends TSF.Oolong.UGUI.TransitionProperty$1<UnityEngine.Color> implements TSF.Oolong.UGUI.ITransitionProperty
        {
            protected [__keep_incompatibility]: never;
            public get TimingFunction(): TSF.Oolong.UGUI.CubicBezier;
            public set TimingFunction(value: TSF.Oolong.UGUI.CubicBezier);
            public get Delay(): number;
            public set Delay(value: number);
            public get Duration(): number;
            public set Duration(value: number);
            public constructor ($applyCallback?: System.Action$1<UnityEngine.Color>, $defaultValue?: UnityEngine.Color)
            public Reset () : void
        }
        class FloatTransitionProperty extends TSF.Oolong.UGUI.TransitionProperty$1<number> implements TSF.Oolong.UGUI.ITransitionProperty
        {
            protected [__keep_incompatibility]: never;
            public get TimingFunction(): TSF.Oolong.UGUI.CubicBezier;
            public set TimingFunction(value: TSF.Oolong.UGUI.CubicBezier);
            public get Delay(): number;
            public set Delay(value: number);
            public get Duration(): number;
            public set Duration(value: number);
            public constructor ($applyCallback?: System.Action$1<number>, $defaultValue?: number)
            public Reset () : void
        }
        class TransitionUtils extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static ParseHumanTime ($humanTime: string) : number
            public static ParseTimingFunction ($value: string) : TSF.Oolong.UGUI.CubicBezier
        }
        class FlipGraphic extends UnityEngine.UI.BaseMeshEffect implements UnityEngine.UI.IMeshModifier
        {
            protected [__keep_incompatibility]: never;
            public get FlipX(): boolean;
            public set FlipX(value: boolean);
            public get FlipY(): boolean;
            public set FlipY(value: boolean);
            public constructor ()
        }
        class NonDrawingGraphic extends UnityEngine.UI.Graphic implements UnityEngine.UI.ICanvasElement
        {
            protected [__keep_incompatibility]: never;
            public constructor ()
        }
    }
    namespace System.Collections.Generic {
        interface IEnumerable$1<T> extends System.Collections.IEnumerable
        {
        }
        class Dictionary$2<TKey, TValue> extends System.Object implements System.Runtime.Serialization.IDeserializationCallback, System.Collections.Generic.IReadOnlyDictionary$2<TKey, TValue>, System.Collections.Generic.IDictionary$2<TKey, TValue>, System.Runtime.Serialization.ISerializable, System.Collections.ICollection, System.Collections.IDictionary, System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.Generic.ICollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        }
        interface IReadOnlyDictionary$2<TKey, TValue> extends System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        {
        }
        class KeyValuePair$2<TKey, TValue> extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        interface IReadOnlyCollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
        {
        }
        interface IDictionary$2<TKey, TValue> extends System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.IEnumerable, System.Collections.Generic.ICollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        {
        }
        interface ICollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
        {
        }
        class List$1<T> extends System.Object implements System.Collections.Generic.IReadOnlyList$1<T>, System.Collections.ICollection, System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IList$1<T>, System.Collections.Generic.IReadOnlyCollection$1<T>, System.Collections.IList, System.Collections.Generic.ICollection$1<T>
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<T>
        }
        interface IReadOnlyList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<T>
        {
        }
        interface IList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.ICollection$1<T>
        {
        }
    }
    namespace System.Collections {
        interface IEnumerable
        {
        }
        interface ICollection extends System.Collections.IEnumerable
        {
        }
        interface IDictionary extends System.Collections.ICollection, System.Collections.IEnumerable
        {
        }
        interface IStructuralComparable
        {
        }
        interface IStructuralEquatable
        {
        }
        interface IList extends System.Collections.ICollection, System.Collections.IEnumerable
        {
        }
    }
    namespace System.Runtime.Serialization {
        interface ISerializable
        {
        }
        interface IDeserializationCallback
        {
        }
    }
    namespace UnityEngine.UI {
        class ColorBlock extends System.ValueType implements System.IEquatable$1<UnityEngine.UI.ColorBlock>
        {
            protected [__keep_incompatibility]: never;
        }
        class SpriteState extends System.ValueType implements System.IEquatable$1<UnityEngine.UI.SpriteState>
        {
            protected [__keep_incompatibility]: never;
        }
        class Graphic extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.UI.ICanvasElement
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICanvasElement
        {
        }
        class MaskableGraphic extends UnityEngine.UI.Graphic implements UnityEngine.UI.IClippable, UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement
        {
            protected [__keep_incompatibility]: never;
        }
        interface IClippable
        {
        }
        interface IMaterialModifier
        {
        }
        interface IMaskable
        {
        }
        class Image extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IClippable, UnityEngine.UI.IMaterialModifier, UnityEngine.ICanvasRaycastFilter, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.ISerializationCallbackReceiver, UnityEngine.UI.ILayoutElement
        {
            protected [__keep_incompatibility]: never;
        }
        interface ILayoutElement
        {
        }
        class Selectable extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
        }
        class Button extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
        }
        class Scrollbar extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
        }
        class Slider extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
        }
        class Toggle extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
        }
        class RectMask2D extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.ICanvasRaycastFilter, UnityEngine.UI.IClipper
        {
            protected [__keep_incompatibility]: never;
        }
        interface IClipper
        {
        }
        class ScrollRect extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.UI.ILayoutController, UnityEngine.UI.ILayoutGroup, UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.IEndDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IScrollHandler, UnityEngine.UI.ILayoutElement
        {
            protected [__keep_incompatibility]: never;
        }
        interface ILayoutController
        {
        }
        interface ILayoutGroup extends UnityEngine.UI.ILayoutController
        {
        }
        class BaseMeshEffect extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.UI.IMeshModifier
        {
            protected [__keep_incompatibility]: never;
        }
        interface IMeshModifier
        {
        }
        class VertexHelper extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine.UI.Selectable {
        enum Transition
        { None = 0, ColorTint = 1, SpriteSwap = 2, Animation = 3 }
    }
    namespace UnityEngine.EventSystems {
        class UIBehaviour extends UnityEngine.MonoBehaviour
        {
            protected [__keep_incompatibility]: never;
        }
        interface IEventSystemHandler
        {
        }
        interface IPointerEnterHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface ISelectHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerExitHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IDeselectHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerDownHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerUpHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IMoveHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface ISubmitHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerClickHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IBeginDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IEndDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IScrollHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IUpdateSelectedHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IInitializePotentialDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        class AbstractEventData extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class BaseEventData extends UnityEngine.EventSystems.AbstractEventData
        {
            protected [__keep_incompatibility]: never;
        }
        class PointerEventData extends UnityEngine.EventSystems.BaseEventData
        {
            protected [__keep_incompatibility]: never;
        }
        interface IPointerMoveHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IDropHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        class AxisEventData extends UnityEngine.EventSystems.BaseEventData
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICancelHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
    }
    namespace TMPro {
        class TMP_InputField extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.IEndDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler, UnityEngine.UI.ILayoutElement
        {
            protected [__keep_incompatibility]: never;
        }
        class TMP_Text extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IClippable, UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement
        {
            protected [__keep_incompatibility]: never;
        }
        class TextMeshProUGUI extends TMPro.TMP_Text implements UnityEngine.UI.IClippable, UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.UI.ILayoutElement
        {
            protected [__keep_incompatibility]: never;
        }
        enum TextAlignmentOptions
        { TopLeft = 257, Top = 258, TopRight = 260, TopJustified = 264, TopFlush = 272, TopGeoAligned = 288, Left = 513, Center = 514, Right = 516, Justified = 520, Flush = 528, CenterGeoAligned = 544, BottomLeft = 1025, Bottom = 1026, BottomRight = 1028, BottomJustified = 1032, BottomFlush = 1040, BottomGeoAligned = 1056, BaselineLeft = 2049, Baseline = 2050, BaselineRight = 2052, BaselineJustified = 2056, BaselineFlush = 2064, BaselineGeoAligned = 2080, MidlineLeft = 4097, Midline = 4098, MidlineRight = 4100, MidlineJustified = 4104, MidlineFlush = 4112, MidlineGeoAligned = 4128, CaplineLeft = 8193, Capline = 8194, CaplineRight = 8196, CaplineJustified = 8200, CaplineFlush = 8208, CaplineGeoAligned = 8224, Converted = 65535 }
        enum TextOverflowModes
        { Overflow = 0, Ellipsis = 1, Masking = 2, Truncate = 3, ScrollRect = 4, Page = 5, Linked = 6 }
        enum FontStyles
        { Normal = 0, Bold = 1, Italic = 2, Underline = 4, LowerCase = 8, UpperCase = 16, SmallCaps = 32, Strikethrough = 64, Superscript = 128, Subscript = 256, Highlight = 512 }
    }
    namespace TSF.Oolong.UGUI.IOolongLoader {
        interface JsCallback
        { 
        (eventData: UnityEngine.EventSystems.BaseEventData) : void; 
        Invoke?: (eventData: UnityEngine.EventSystems.BaseEventData) => void;
        }
        var JsCallback: { new (func: (eventData: UnityEngine.EventSystems.BaseEventData) => void): JsCallback; }
    }
    namespace System.Reflection {
        class MemberInfo extends System.Object implements System.Runtime.InteropServices._MemberInfo, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICustomAttributeProvider
        {
        }
        interface IReflect
        {
        }
    }
    namespace System.Runtime.InteropServices {
        interface _MemberInfo
        {
        }
        interface _Type
        {
        }
    }
    namespace UnityEngine.UI.Scrollbar {
        enum Direction
        { LeftToRight = 0, RightToLeft = 1, BottomToTop = 2, TopToBottom = 3 }
    }
    namespace UnityEngine.UI.Slider {
        enum Direction
        { LeftToRight = 0, RightToLeft = 1, BottomToTop = 2, TopToBottom = 3 }
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
    namespace UnityEngine.Networking {
        /** Provides methods to communicate with web servers.
        */
        class UnityWebRequest extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
            /** The string "GET", commonly used as the verb for an HTTP GET request.
            */
            public static kHttpVerbGET : string
            /** The string "HEAD", commonly used as the verb for an HTTP HEAD request.
            */
            public static kHttpVerbHEAD : string
            /** The string "POST", commonly used as the verb for an HTTP POST request.
            */
            public static kHttpVerbPOST : string
            /** The string "PUT", commonly used as the verb for an HTTP PUT request.
            */
            public static kHttpVerbPUT : string
            /** The string "CREATE", commonly used as the verb for an HTTP CREATE request.
            */
            public static kHttpVerbCREATE : string
            /** The string "DELETE", commonly used as the verb for an HTTP DELETE request.
            */
            public static kHttpVerbDELETE : string
            /** If true, any CertificateHandler attached to this UnityWebRequest will have CertificateHandler.Dispose called automatically when UnityWebRequest.Dispose is called.
            */
            public get disposeCertificateHandlerOnDispose(): boolean;
            public set disposeCertificateHandlerOnDispose(value: boolean);
            /** If true, any DownloadHandler attached to this UnityWebRequest will have DownloadHandler.Dispose called automatically when UnityWebRequest.Dispose is called.
            */
            public get disposeDownloadHandlerOnDispose(): boolean;
            public set disposeDownloadHandlerOnDispose(value: boolean);
            /** If true, any UploadHandler attached to this UnityWebRequest will have UploadHandler.Dispose called automatically when UnityWebRequest.Dispose is called.
            */
            public get disposeUploadHandlerOnDispose(): boolean;
            public set disposeUploadHandlerOnDispose(value: boolean);
            /** Defines the HTTP verb used by this UnityWebRequest, such as GET or POST.
            */
            public get method(): string;
            public set method(value: string);
            /** A human-readable string describing any system errors encountered by this UnityWebRequest object while handling HTTP requests or responses. (Read Only)
            */
            public get error(): string;
            /** Determines whether this UnityWebRequest will include Expect: 100-Continue in its outgoing request headers. (Default: true).
            */
            public get useHttpContinue(): boolean;
            public set useHttpContinue(value: boolean);
            /** Defines the target URL for the UnityWebRequest to communicate with.
            */
            public get url(): string;
            public set url(value: string);
            /** Defines the target URI for the UnityWebRequest to communicate with.
            */
            public get uri(): System.Uri;
            public set uri(value: System.Uri);
            /** The numeric HTTP response code returned by the server, such as 200, 404 or 500. (Read Only)
            */
            public get responseCode(): bigint;
            /** Returns a floating-point value between 0.0 and 1.0, indicating the progress of uploading body data to the server.
            */
            public get uploadProgress(): number;
            /** Returns true while a UnityWebRequest’s configuration properties can be altered. (Read Only)
            */
            public get isModifiable(): boolean;
            /** Returns true after the UnityWebRequest has finished communicating with the remote server. (Read Only)
            */
            public get isDone(): boolean;
            /** The result of this UnityWebRequest.
            */
            public get result(): UnityEngine.Networking.UnityWebRequest.Result;
            /** Returns a floating-point value between 0.0 and 1.0, indicating the progress of downloading body data from the server. (Read Only)
            */
            public get downloadProgress(): number;
            /** Returns the number of bytes of body data the system has uploaded to the remote server. (Read Only)
            */
            public get uploadedBytes(): bigint;
            /** Returns the number of bytes of body data the system has downloaded from the remote server. (Read Only)
            */
            public get downloadedBytes(): bigint;
            /** Indicates the number of redirects which this UnityWebRequest will follow before halting with a “Redirect Limit Exceeded” system error.
            */
            public get redirectLimit(): number;
            public set redirectLimit(value: number);
            /** Holds a reference to the UploadHandler object which manages body data to be uploaded to the remote server.
            */
            public get uploadHandler(): UnityEngine.Networking.UploadHandler;
            public set uploadHandler(value: UnityEngine.Networking.UploadHandler);
            /** Holds a reference to a DownloadHandler object, which manages body data received from the remote server by this UnityWebRequest.
            */
            public get downloadHandler(): UnityEngine.Networking.DownloadHandler;
            public set downloadHandler(value: UnityEngine.Networking.DownloadHandler);
            /** Holds a reference to a CertificateHandler object, which manages certificate validation for this UnityWebRequest.
            */
            public get certificateHandler(): UnityEngine.Networking.CertificateHandler;
            public set certificateHandler(value: UnityEngine.Networking.CertificateHandler);
            /** Sets UnityWebRequest to attempt to abort after the number of seconds in timeout have passed.
            */
            public get timeout(): number;
            public set timeout(value: number);
            /** Clears stored cookies from the cache.
            * @param $domain An optional URL to define which cookies are removed. Only cookies that apply to this URL will be removed from the cache.
            */
            public static ClearCookieCache () : void
            public static ClearCookieCache ($uri: System.Uri) : void
            /** Signals that this UnityWebRequest is no longer being used, and should clean up any resources it is using.
            */
            public Dispose () : void
            /** Begin communicating with the remote server.
            */
            public SendWebRequest () : UnityEngine.Networking.UnityWebRequestAsyncOperation
            /** If in progress, halts the UnityWebRequest as soon as possible.
            */
            public Abort () : void
            /** Retrieves the value of a custom request header.
            * @param $name Name of the custom request header. Case-insensitive.
            * @returns The value of the custom request header. If no custom header with a matching name has been set, returns an empty string. 
            */
            public GetRequestHeader ($name: string) : string
            /** Set a HTTP request header to a custom value.
            * @param $name The key of the header to be set. Case-sensitive.
            * @param $value The header's intended value.
            */
            public SetRequestHeader ($name: string, $value: string) : void
            /** Retrieves the value of a response header from the latest HTTP response received.
            * @param $name The name of the HTTP header to retrieve. Case-insensitive.
            * @returns The value of the HTTP header from the latest HTTP response. If no header with a matching name has been received, or no responses have been received, returns null. 
            */
            public GetResponseHeader ($name: string) : string
            /** Retrieves a dictionary containing all the response headers received by this UnityWebRequest in the latest HTTP response.
            * @returns A dictionary containing all the response headers received in the latest HTTP response. If no responses have been received, returns null. 
            */
            public GetResponseHeaders () : System.Collections.Generic.Dictionary$2<string, string>
            /** Create a UnityWebRequest for HTTP GET.
            * @param $uri The URI of the resource to retrieve via HTTP GET.
            * @returns An object that retrieves data from the uri. 
            */
            public static Get ($uri: string) : UnityEngine.Networking.UnityWebRequest
            /** Create a UnityWebRequest for HTTP GET.
            * @param $uri The URI of the resource to retrieve via HTTP GET.
            * @returns An object that retrieves data from the uri. 
            */
            public static Get ($uri: System.Uri) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured for HTTP DELETE.
            * @param $uri The URI to which a DELETE request should be sent.
            * @returns A UnityWebRequest configured to send an HTTP DELETE request. 
            */
            public static Delete ($uri: string) : UnityEngine.Networking.UnityWebRequest
            public static Delete ($uri: System.Uri) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send a HTTP HEAD request.
            * @param $uri The URI to which to send a HTTP HEAD request.
            * @returns A UnityWebRequest configured to transmit a HTTP HEAD request. 
            */
            public static Head ($uri: string) : UnityEngine.Networking.UnityWebRequest
            public static Head ($uri: System.Uri) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to upload raw data to a remote server via HTTP PUT.
            * @param $uri The URI to which the data will be sent.
            * @param $bodyData The data to transmit to the remote server.
            If a string, the string will be converted to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
            * @returns A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT. 
            */
            public static Put ($uri: string, $bodyData: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            public static Put ($uri: System.Uri, $bodyData: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to upload raw data to a remote server via HTTP PUT.
            * @param $uri The URI to which the data will be sent.
            * @param $bodyData The data to transmit to the remote server.
            If a string, the string will be converted to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
            * @returns A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT. 
            */
            public static Put ($uri: string, $bodyData: string) : UnityEngine.Networking.UnityWebRequest
            public static Put ($uri: System.Uri, $bodyData: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $form An HTML form to send.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static PostWwwForm ($uri: string, $form: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $form An HTML form to send.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static PostWwwForm ($uri: System.Uri, $form: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which the string will be transmitted.
            * @param $postData Form body data. Will be converted to UTF-8 string.
            * @param $contentType Value for the Content-Type header, for example application/json.
            * @returns A UnityWebRequest configured to send string to uri via POST. 
            */
            public static Post ($uri: string, $postData: string, $contentType: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which the string will be transmitted.
            * @param $postData Form body data. Will be converted to UTF-8 string.
            * @param $contentType Value for the Content-Type header, for example application/json.
            * @returns A UnityWebRequest configured to send string to uri via POST. 
            */
            public static Post ($uri: System.Uri, $postData: string, $contentType: string) : UnityEngine.Networking.UnityWebRequest
            /** Create a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $formData Form fields or files encapsulated in a WWWForm object, for formatting and transmission to the remote server.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static Post ($uri: string, $formData: UnityEngine.WWWForm) : UnityEngine.Networking.UnityWebRequest
            /** Create a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $formData Form fields or files encapsulated in a WWWForm object, for formatting and transmission to the remote server.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static Post ($uri: System.Uri, $formData: UnityEngine.WWWForm) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: string, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: System.Uri, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: string, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>, $boundary: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: System.Uri, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>, $boundary: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: string, $formFields: System.Collections.Generic.Dictionary$2<string, string>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: System.Uri, $formFields: System.Collections.Generic.Dictionary$2<string, string>) : UnityEngine.Networking.UnityWebRequest
            /** Escapes characters in a string to ensure they are URL-friendly.
            * @param $s A string with characters to be escaped.
            * @param $e The text encoding to use.
            */
            public static EscapeURL ($s: string) : string
            /** Escapes characters in a string to ensure they are URL-friendly.
            * @param $s A string with characters to be escaped.
            * @param $e The text encoding to use.
            */
            public static EscapeURL ($s: string, $e: System.Text.Encoding) : string
            /** Converts URL-friendly escape sequences back to normal text.
            * @param $s A string containing escaped characters.
            * @param $e The text encoding to use.
            */
            public static UnEscapeURL ($s: string) : string
            /** Converts URL-friendly escape sequences back to normal text.
            * @param $s A string containing escaped characters.
            * @param $e The text encoding to use.
            */
            public static UnEscapeURL ($s: string, $e: System.Text.Encoding) : string
            public static SerializeFormSections ($multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>, $boundary: System.Array$1<number>) : System.Array$1<number>
            /** Generate a random 40-byte array for use as a multipart form boundary.
            * @returns 40 random bytes, guaranteed to contain only printable ASCII values. 
            */
            public static GenerateBoundary () : System.Array$1<number>
            public static SerializeSimpleForm ($formFields: System.Collections.Generic.Dictionary$2<string, string>) : System.Array$1<number>
            public constructor ()
            public constructor ($url: string)
            public constructor ($uri: System.Uri)
            public constructor ($url: string, $method: string)
            public constructor ($uri: System.Uri, $method: string)
            public constructor ($url: string, $method: string, $downloadHandler: UnityEngine.Networking.DownloadHandler, $uploadHandler: UnityEngine.Networking.UploadHandler)
            public constructor ($uri: System.Uri, $method: string, $downloadHandler: UnityEngine.Networking.DownloadHandler, $uploadHandler: UnityEngine.Networking.UploadHandler)
        }
        /** Provides methods to communicate with web servers.
        */
        interface UnityWebRequest {
            SetArrayBufferBody ($body: ArrayBuffer) : void;
            SetStringBody ($body: string) : void;
            SendWithCallback ($callback: TSF.Oolong.UGUI.UnityWebRequestExtension.JsWebCallback) : void;
        }
        /** Manage and process HTTP response body data received from a remote server.
        */
        class DownloadHandler extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
            /** Returns true if this DownloadHandler has been informed by its parent UnityWebRequest that all data has been received, and this DownloadHandler has completed any necessary post-download processing. (Read Only)
            */
            public get isDone(): boolean;
            /** Error message describing a failure that occurred inside the download handler.
            */
            public get error(): string;
            /** Provides direct access to downloaded data.
            */
            public get nativeData(): Unity.Collections.NativeArray$1.ReadOnly<number>;
            /** Returns the raw bytes downloaded from the remote server, or null. (Read Only)
            */
            public get data(): System.Array$1<number>;
            /** Convenience property. Returns the bytes from data interpreted as a UTF8 string. (Read Only)
            */
            public get text(): string;
            /** Signals that this DownloadHandler is no longer being used, and should clean up any resources it is using.
            */
            public Dispose () : void
        }
        /** Manage and process HTTP response body data received from a remote server.
        */
        interface DownloadHandler {
            GetArrayBuffer () : ArrayBuffer;
        }
        /** Asynchronous operation object returned from UnityWebRequest.SendWebRequest().
        You can yield until it continues, register an event handler with AsyncOperation.completed, or manually check whether it's done (AsyncOperation.isDone) or progress (AsyncOperation.progress).
        */
        class UnityWebRequestAsyncOperation extends UnityEngine.AsyncOperation
        {
            protected [__keep_incompatibility]: never;
        }
        /** Helper object for UnityWebRequests. Manages the buffering and transmission of body data during HTTP requests.
        */
        class UploadHandler extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        /** Responsible for rejecting or accepting certificates received on https requests.
        */
        class CertificateHandler extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        interface IMultipartFormSection
        {
        }
    }
    namespace TSF.Oolong.UGUI.UnityWebRequestExtension {
        interface JsWebCallback
        { 
        () : void; 
        Invoke?: () => void;
        }
        var JsWebCallback: { new (func: () => void): JsWebCallback; }
    }
    namespace UnityEngine.TextCore.Text {
        class FontAsset extends UnityEngine.TextCore.Text.TextAsset
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace TSF.Oolong.UGUI.OolongChainLoader {
        class Node extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
            public Prefix : string
            public Loader : TSF.Oolong.UGUI.IOolongLoader
        }
    }
    namespace Unity.Collections.NativeArray$1 {
        class ReadOnly<T> extends System.ValueType implements System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<T>
        }
    }
    namespace UnityEngine.Networking.UnityWebRequest {
        enum Result
        { InProgress = 0, Success = 1, ConnectionError = 2, ProtocolError = 3, DataProcessingError = 4 }
    }
    namespace System.Text {
        class Encoding extends System.Object implements System.ICloneable
        {
            protected [__keep_incompatibility]: never;
        }
    }
}
