
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
        interface Action
        { 
        () : void; 
        Invoke?: () => void;
        }
        var Action: { new (func: () => void): Action; }
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
        class Single extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        class Enum extends System.ValueType implements System.IFormattable, System.IComparable, System.IConvertible
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
        class Array extends System.Object implements System.Collections.IStructuralComparable, System.Collections.IStructuralEquatable, System.ICloneable, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
        {
            protected [__keep_incompatibility]: never;
        }
    }
        class OolongUGUI extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static Initialize () : void
            public static Mount ($element: TSF.Oolong.UGUI.OolongElement, $component: Puerts.JSObject, $partial: boolean) : Puerts.JSObject
            public static Unmount ($element: Puerts.JSObject) : void
            public static TransformText ($text: string, $loader: TSF.Oolong.UGUI.OolongTextLoader) : string
            public static TransformAddress ($tag: string, $address: string) : string
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
        interface ICanvasRaycastFilter
        {
        }
        interface ISerializationCallbackReceiver
        {
        }
        /** Base class for all entities in Unity Scenes.
        */
        class GameObject extends UnityEngine.Object
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
    namespace TSF.Oolong.UGUI {
        class OolongElement extends UnityEngine.MonoBehaviour
        {
            protected [__keep_incompatibility]: never;
            public get TagName(): string;
            public set TagName(value: string);
            public get RootTransform(): UnityEngine.Transform;
            public get ParentElement(): TSF.Oolong.UGUI.OolongElement;
            public set ParentElement(value: TSF.Oolong.UGUI.OolongElement);
            public GetInstanceID () : number
            public AddChild ($e: TSF.Oolong.UGUI.OolongElement) : void
            public RemoveChild ($e: TSF.Oolong.UGUI.OolongElement) : void
            public SetElementAttribute ($key: string, $value: string) : void
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : void
            public RemoveListener ($key: string) : void
            public SetEventHandler ($handler: TSF.Oolong.UGUI.UIEventHandler) : void
            public OnCreate ($loader: TSF.Oolong.UGUI.IOolongLoader) : void
            public OnReset () : void
            public OnReuse () : void
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
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        interface IOolongLoader
        {
            AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            RemoveListener ($key: string) : boolean
            Release () : void
            Reuse () : void
            Reset () : void
            SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            ResetTransitions () : void
            SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        class OolongTextLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongTextLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : TMPro.TextMeshProUGUI
            public get TextAttr(): System.Collections.Generic.IReadOnlyDictionary$2<string, string>;
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
            public constructor ($gameObject: UnityEngine.GameObject)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        class DocumentUtils extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static OnDocumentPreUpdate : System.Action
            public static OnDocumentUpdate : System.Action
            public static OnDocumentLateUpdate : System.Action
            public static AttachElement ($parent: TSF.Oolong.UGUI.OolongElement, $node: TSF.Oolong.UGUI.OolongElement) : void
            public static DetachElement ($node: TSF.Oolong.UGUI.OolongElement) : void
            public static RemoveElement ($parent: TSF.Oolong.UGUI.OolongElement, $node: TSF.Oolong.UGUI.OolongElement) : void
            public static ResetElement ($node: TSF.Oolong.UGUI.OolongElement) : void
            public static InsertElement ($parent: TSF.Oolong.UGUI.OolongElement, $node: TSF.Oolong.UGUI.OolongElement, $index: number) : number
            public static CreateElement ($tagName: string) : TSF.Oolong.UGUI.OolongElement
            public static CacheElement ($tagName: string, $count: number) : void
            public static CreateChildRect ($parent: UnityEngine.Transform, $name: string) : UnityEngine.RectTransform
            public static ParseColor ($color: string) : UnityEngine.Color
            public static Dispose () : void
            public static UpdateLayout () : void
            public static LateUpdateLayout () : void
        }
        class UIEventHandler extends UnityEngine.MonoBehaviour implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.IEndDragHandler, UnityEngine.EventSystems.IDropHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.IPointerMoveHandler, UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.IPointerUpHandler
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public OnPointerEnter ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerExit ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerDown ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerUp ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerMove ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerClick ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnInitializePotentialDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnBeginDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnEndDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnDrop ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnScroll ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnUpdateSelected ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public OnSelect ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public OnDeselect ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public OnMove ($eventData: UnityEngine.EventSystems.AxisEventData) : void
            public OnSubmit ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public OnCancel ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public Reset () : void
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
            public constructor ($instance: UnityEngine.UI.Image, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
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
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        class OolongRectLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongRectLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.RectTransform
            public constructor ($gameObject: UnityEngine.GameObject)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        class OolongScrollbarLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongScrollbarLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.UI.Scrollbar
            public get Enabled(): boolean;
            public constructor ($obj: UnityEngine.GameObject, $tagName: string)
            public constructor ($obj: UnityEngine.GameObject, $direction: UnityEngine.UI.Scrollbar.Direction, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        class OolongSelectableLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongSelectableLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.UI.Selectable
            public get HasImage(): boolean;
            public get Loaded(): boolean;
            public get Enabled(): boolean;
            public set Enabled(value: boolean);
            public constructor ($instance: UnityEngine.UI.Selectable, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        class OolongSliderLoader extends TSF.Oolong.UGUI.OolongLoader$1<TSF.Oolong.UGUI.OolongSliderLoader> implements TSF.Oolong.UGUI.IOolongLoader
        {
            protected [__keep_incompatibility]: never;
            public Instance : UnityEngine.UI.Slider
            public get Enabled(): boolean;
            public constructor ($obj: UnityEngine.GameObject, $tagName: string)
            public constructor ($obj: UnityEngine.GameObject, $direction: UnityEngine.UI.Slider.Direction, $tagName: string)
            public AddListener ($key: string, $callback: TSF.Oolong.UGUI.IOolongLoader.JsCallback) : boolean
            public RemoveListener ($key: string) : boolean
            public Release () : void
            public Reuse () : void
            public Reset () : void
            public SetAttribute ($prefix: string, $key: string, $value: string) : boolean
            public ResetTransitions () : void
            public SetTransition ($key: string, $duration: number, $timingFunction: TSF.Oolong.UGUI.CubicBezier, $delay: number) : boolean
        }
        class MithrilComponent extends TSF.Oolong.UGUI.OolongElement
        {
            protected [__keep_incompatibility]: never;
            public AddressableScript : UnityEngine.AddressableAssets.AssetReferenceT$1<UnityEngine.TextAsset>
            public get HasScript(): boolean;
            public get PartialRedraw(): boolean;
            public constructor ()
        }
        class UnityWebRequestExtension extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static SetBody ($request: UnityEngine.Networking.UnityWebRequest, $body: ArrayBuffer) : void
            public static SendWithCallback ($request: UnityEngine.Networking.UnityWebRequest, $callback: TSF.Oolong.UGUI.UnityWebRequestExtension.JsWebCallback) : void
            public static GetArrayBuffer ($handler: UnityEngine.Networking.DownloadHandlerBuffer) : ArrayBuffer
        }
        class OolongMithril extends System.Object
        {
            protected [__keep_incompatibility]: never;
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
            public constructor ($applyCallback: System.Action$1<boolean>)
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
            public constructor ($applyCallback: System.Action$1<UnityEngine.Color>)
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
            public constructor ($applyCallback: System.Action$1<number>)
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
    namespace System.Runtime.Serialization {
        interface ISerializable
        {
        }
    }
    namespace UnityEngine.EventSystems {
        interface ISubmitHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IEventSystemHandler
        {
        }
        interface IPointerClickHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface ICancelHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IBeginDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IInitializePotentialDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IEndDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IDropHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IScrollHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerMoveHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IUpdateSelectedHandler extends UnityEngine.EventSystems.IEventSystemHandler
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
        interface IMoveHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerUpHandler extends UnityEngine.EventSystems.IEventSystemHandler
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
        class AxisEventData extends UnityEngine.EventSystems.BaseEventData
        {
            protected [__keep_incompatibility]: never;
        }
        class UIBehaviour extends UnityEngine.MonoBehaviour
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace TSF.Oolong.UGUI.IOolongLoader {
        interface JsCallback
        { 
        (eventData: UnityEngine.EventSystems.BaseEventData) : void; 
        Invoke?: (eventData: UnityEngine.EventSystems.BaseEventData) => void;
        }
        var JsCallback: { new (func: (eventData: UnityEngine.EventSystems.BaseEventData) => void): JsCallback; }
    }
    namespace UnityEngine.UI {
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
        class Scrollbar extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
        }
        class Slider extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
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
    namespace UnityEngine.UI.Scrollbar {
        enum Direction
        { LeftToRight = 0, RightToLeft = 1, BottomToTop = 2, TopToBottom = 3 }
    }
    namespace UnityEngine.UI.Slider {
        enum Direction
        { LeftToRight = 0, RightToLeft = 1, BottomToTop = 2, TopToBottom = 3 }
    }
    namespace TMPro {
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
        }
        /** Provides methods to communicate with web servers.
        */
        interface UnityWebRequest {
            SetBody ($body: ArrayBuffer) : void;
            SendWithCallback ($callback: TSF.Oolong.UGUI.UnityWebRequestExtension.JsWebCallback) : void;
        }
        /** Manage and process HTTP response body data received from a remote server.
        */
        class DownloadHandler extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        /** A general-purpose DownloadHandler implementation which stores received data in a native byte buffer.
        */
        class DownloadHandlerBuffer extends UnityEngine.Networking.DownloadHandler implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        /** A general-purpose DownloadHandler implementation which stores received data in a native byte buffer.
        */
        interface DownloadHandlerBuffer {
            GetArrayBuffer () : ArrayBuffer;
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
}
