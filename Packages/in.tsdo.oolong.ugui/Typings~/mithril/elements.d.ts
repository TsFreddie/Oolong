/// <reference types="../oolong-ugui"/>
/// <reference types="../../Generated/Typings~/csharp-oolong-ugui"/>

// TODO: I need to double check this typing at some point
// Or I can write a generator for this typing I guess

interface EventData<T extends object = any> {
    type: string;
    target: UnityElement<T>;
    eventData: CS.UnityEngine.EventSystems.BaseEventData;
    redraw: boolean;
}

type OolongEventHandler<T extends object = any> = (ev: EventData<T>) => void;

type RectAlignHorizontal = "top" | "middle" | "bottom";
type RectAlignVertical = "left" | "center" | "right";
type RectAlign =
    | "stretch"
    | RectAlignHorizontal
    | RectAlignVertical
    | `${RectAlignHorizontal} ${RectAlignVertical}`
    | `${RectAlignVertical} stretch`
    | `${RectAlignHorizontal} stretch`;

type CornerAlign = "top left" | "top right" | "bottom left" | "bottom right";

type ChildAlign =
    | "top left"
    | "top center"
    | "top right"
    | "middle left"
    | "middle center"
    | "middle right"
    | "bottom left"
    | "bottom center"
    | "bottom right";

type Direction = "horizontal" | "vertical";

type ImageType =
    | "slice"
    | "border"
    | "tile"
    | "bar"
    | "bar-right"
    | "bar-left"
    | "bar-down"
    | "bar-up"
    | "pie"
    | "pie-bl"
    | "pie-tl"
    | "pie-tr"
    | "pie-br"
    | "fan-bottom"
    | "fan"
    | "fan-left"
    | "fan-top"
    | "fan-right"
    | "ring"
    | "ring-bottom"
    | "ring-left"
    | "ring-top"
    | "ring-right"
    | "simple";

type TextAlignHorizontal =
    | "left"
    | "center"
    | "right"
    | "justify"
    | "flush"
    | "geo";

type TextAlignVertical =
    | "top"
    | "middle"
    | "bottom"
    | "baseline"
    | "midline"
    | "capline";

type TextAlign =
    | TextAlignHorizontal
    | TextAlignVertical
    | `${TextAlignVertical} ${TextAlignHorizontal}`;

type TextOverflow =
    | "overflow"
    | "ellipsis"
    | "masking"
    | "truncate"
    | "page"
    | "none";

type StringNumber = `${number}`;
type AttributeNumber = number | StringNumber;

// Loaders

type RectAttributes = {
    align?: RectAlign;
    width?: AttributeNumber;
    height?: AttributeNumber;
    margin?: AttributeNumber;
    "margin-left"?: AttributeNumber;
    "margin-top"?: AttributeNumber;
    "margin-right"?: AttributeNumber;
    "margin-bottom"?: AttributeNumber;
    "margin-x"?: AttributeNumber;
    "margin-y"?: AttributeNumber;
    x?: AttributeNumber;
    y?: AttributeNumber;
    z?: AttributeNumber;
    rotation?: AttributeNumber;
    anchor?: `${number} ${number}`;
    "min-width"?: AttributeNumber;
    "min-height"?: AttributeNumber;
    "flex-width"?: AttributeNumber;
    "flex-height"?: AttributeNumber;
    "ignore-layout"?: boolean;
    priority?: AttributeNumber;
};

type LayoutAttributes = {
    layout?: Direction | "grid" | "none";
    "fit-content"?: "x" | "y" | "xy" | boolean;
    reverse?: boolean;
    spacing?: AttributeNumber;
    "spacing-x"?: AttributeNumber;
    "spacing-y"?: AttributeNumber;
    "cell-width"?: AttributeNumber;
    "cell-height"?: AttributeNumber;
    padding?: AttributeNumber;
    "padding-left"?: AttributeNumber;
    "padding-top"?: AttributeNumber;
    "padding-right"?: AttributeNumber;
    "padding-bottom"?: AttributeNumber;
    "padding-x"?: AttributeNumber;
    "padding-y"?: AttributeNumber;
    "child-align"?: ChildAlign;
    "start-corner"?: CornerAlign;
    "start-axis"?: Direction;
    columns?: AttributeNumber;
    rows?: AttributeNumber;
};

type ImageAttributes = {
    src?: string;
    color?: string;
    type?: ImageType;
    fit?: boolean;
    clockwise?: boolean;
    "fill-amount"?: AttributeNumber;
    passthrough?: boolean;
    extend?: AttributeNumber;
    "extend-left"?: AttributeNumber;
    "extend-top"?: AttributeNumber;
    "extend-right"?: AttributeNumber;
    "extend-bottom"?: AttributeNumber;
    "extend-x"?: AttributeNumber;
    "extend-y"?: AttributeNumber;
    mask?: boolean | "show" | "mask";
    "flip-x"?: boolean;
    "flip-y"?: boolean;
    async?: boolean;
};

type TextAttributes = {
    text?: string;
    "text-align"?: TextAlign;
    size?: AttributeNumber;
    "min-size"?: AttributeNumber;
    color?: string;
    overflow?: TextOverflow;
    wrap?: "enabled" | "disabled" | boolean;
    passthrough?: boolean;
    extend?: AttributeNumber;
    "extend-left"?: AttributeNumber;
    "extend-top"?: AttributeNumber;
    "extend-right"?: AttributeNumber;
    "extend-bottom"?: AttributeNumber;
    "extend-x"?: AttributeNumber;
    "extend-y"?: AttributeNumber;
    styles?: string;
    outline?: string;
    "outline-thickness"?: AttributeNumber;
    "letter-spacing"?: AttributeNumber;
    "word-spacing"?: AttributeNumber;
    "line-spacing"?: AttributeNumber;
    "paragraph-spacing"?: AttributeNumber;
    font?: string;
};

type SelectableAttributes =
    | {
          color?: string;
          normal?: string;
          highlight?: string;
          press?: string;
          select?: string;
          disable?: string;
          "fade-duration"?: AttributeNumber;
          disabled?: boolean;
          async?: boolean;
      }
    | ImageAttributes;

type ToggleAttributes = {
    value?: "on" | "off";
    tab?: string;
    group?: string;
};

type PrefixAttributes<T, P extends string> = {
    [K in keyof T as K extends string ? `${P}${K}` : never]: T[K];
};

type ScrollbarAttributes = SelectableAttributes &
    PrefixAttributes<ImageAttributes, "bg-">;

type ScrollRectAttributes = {
    "sx-width"?: AttributeNumber;
    "sx-height"?: AttributeNumber;
    "sx-occupy-width"?: AttributeNumber;
    "sy-occupy-width"?: AttributeNumber;
    "sx-offset"?: AttributeNumber;
    "sy-offset"?: AttributeNumber;
    "sx-visibility"?: "always" | "reserve" | "auto";
    "sy-visibility"?: "always" | "reserve" | "auto";
    elasticity?: AttributeNumber;
    inertia?: AttributeNumber;
    sensitivity?: AttributeNumber;
    direction?: Direction | "both" | "none";
};

type InputAttributes = {
    value?: string;
    padding?: AttributeNumber;
    "padding-left"?: AttributeNumber;
    "padding-top"?: AttributeNumber;
    "padding-right"?: AttributeNumber;
    "padding-bottom"?: AttributeNumber;
    "padding-x"?: AttributeNumber;
    "padding-y"?: AttributeNumber;
    "caret-width"?: AttributeNumber;
    "caret-blink-rate"?: AttributeNumber;
    "caret-color"?: string;
    "selection-color"?: string;
    font?: string;
};

type SliderAttributes = {
    direction?: "rl" | "bt" | "tb" | "lr";
    inset?: AttributeNumber;
    "handle-width"?: AttributeNumber;
    "handle-height"?: AttributeNumber;
    thickness?: AttributeNumber;
    value?: string;
    min?: AttributeNumber;
    max?: AttributeNumber;
    int?: boolean;
    "handle-offset-x"?: AttributeNumber;
    "handle-offset-y"?: AttributeNumber;
};

type CanvasGroupAttributes = {
    alpha?: AttributeNumber;
    disabled?: boolean;
    passthrough?: boolean;
    scale?: AttributeNumber;
    "scale-x"?: AttributeNumber;
    "scale-y"?: AttributeNumber;
    delayed?: boolean;
};

// Values

type ScrollRectValueAttributes = {
    scrollX?: StringNumber;
    scrollY?: StringNumber;
};

// Transitions

type TransitionAttributes = {
    "transition-property"?: string;
    "transition-duration"?: string;
    "transition-timing-function"?: string;
    "transition-delay"?: string;
};

// Elements

type PanelElementAttributes = RectAttributes & LayoutAttributes;
type ImageElementAttributes = RectAttributes & ImageAttributes;
type TextElementAttributes = RectAttributes & TextAttributes;
type ButtonElementAttributes = RectAttributes & SelectableAttributes;
type ToggleElementAttributes = RectAttributes &
    ToggleAttributes &
    SelectableAttributes &
    PrefixAttributes<ImageAttributes, "cm-"> &
    PrefixAttributes<RectAttributes, "cm-">;
type ScrollRectElementAttributes = RectAttributes &
    ScrollRectAttributes &
    PrefixAttributes<ScrollbarAttributes, "sx-"> &
    PrefixAttributes<ScrollbarAttributes, "sy-"> &
    PrefixAttributes<RectAttributes, "content-"> &
    LayoutAttributes;
type InputElementAttributes = RectAttributes &
    InputAttributes &
    SelectableAttributes &
    PrefixAttributes<TextAttributes, "text-"> &
    PrefixAttributes<TextAttributes, "ph-">;
type SliderElementAttributes = RectAttributes &
    InputAttributes &
    SliderAttributes &
    SelectableAttributes &
    PrefixAttributes<ImageAttributes, "bg-"> &
    PrefixAttributes<ImageAttributes, "fill-">;
type CanvasGroupElementAttributes = RectAttributes & CanvasGroupAttributes;

// Events

type ElementCallbacks<T extends object = any> = {
    onpointerenter?: OolongEventHandler<T>;
    onpointerexit?: OolongEventHandler<T>;
    onpointerdown?: OolongEventHandler<T>;
    onpointerup?: OolongEventHandler<T>;
    onpointermove?: OolongEventHandler<T>;
    onpointerclick?: OolongEventHandler<T>;
    oninitializepotentialdrag?: OolongEventHandler<T>;
    onbegindrag?: OolongEventHandler<T>;
    ondrag?: OolongEventHandler<T>;
    onenddrag?: OolongEventHandler<T>;
    ondrop?: OolongEventHandler<T>;
    onscroll?: OolongEventHandler<T>;
    onupdateselected?: OolongEventHandler<T>;
    onselect?: OolongEventHandler<T>;
    ondeselect?: OolongEventHandler<T>;
    onmove?: OolongEventHandler<T>;
    onsubmit?: OolongEventHandler<T>;
    oncancel?: OolongEventHandler<T>;
};

type ButtonCallbacks = {
    onclick?: OolongEventHandler<ButtonElementAttributes>;
};

type ToggleCallbacks = {
    onvaluechanged?: OolongEventHandler<ToggleElementAttributes>;
};

type SliderCallbacks = {
    onvaluechanged?: OolongEventHandler<SliderElementAttributes>;
};

type ScrollRectCallbacks = {
    onvaluechanged?: OolongEventHandler<
        ScrollRectElementAttributes & ScrollRectValueAttributes
    >;
};

type InputCallbacks = {
    onvaluechanged?: OolongEventHandler<InputElementAttributes>;
    onendedit?: OolongEventHandler<InputElementAttributes>;
    oninputselect?: OolongEventHandler<InputElementAttributes>;
    oninputdeselect?: OolongEventHandler<InputElementAttributes>;
};
