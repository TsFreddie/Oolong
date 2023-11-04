/// <reference types="csharp"/>

interface EventData<T = UnityElement> {
    target: T;
    type: string;
    redraw: boolean;
}

type EventHandler<T = UnityElement> = (ev: EventData<T>) => void;

interface UnityElement {
    element: IOolongElement;
}

interface UnityToggle {
    element: OolongToggle;
}

interface UnityScrollView {
    element: OolongScrollView;
}

interface UnityInput {
    element: OolongInput;
}

interface UnitySlider {
    element: OolongSlider;
}

interface IOolongElement {
    transform: CS.UnityEngine.Transform;
    gameObject: CS.UnityEngine.GameObject;
    RootTransform: CS.UnityEngine.Transform;
    TagName: string;
    GetComponent(type: CS.System.Type): CS.UnityEngine.Component;
    GetComponent(type: string): CS.UnityEngine.Component;
}

interface OolongSlider extends IOolongElement {
    Value: number;
}

interface OolongToggle extends IOolongElement {
    IsOn: boolean;
}

interface OolongScrollView extends IOolongElement {
    ScrollPosition: CS.UnityEngine.Vector2;
}

interface OolongInput extends IOolongElement {
    Value: string;
}

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

type AttributeNumber = number | `${number}`;

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
    amount?: AttributeNumber;
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
          fade?: AttributeNumber;
          disabled?: boolean;
          async?: boolean;
      }
    | ImageAttributes;

type ToggleAttributes = {
    active?: boolean;
    tab?: string;
    group?: string;
};

type PrefixAttributes<T, P extends string> = {
    [K in keyof T as K extends string ? `${P}${K}` : never]: T[K];
};

type ScrollbarAttributes = SelectableAttributes &
    PrefixAttributes<ImageAttributes, "bg-">;

type ScrollScrollView = {
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
    "ph-text"?: string;
    value?: string;
    padding?: AttributeNumber;
    "padding-left"?: AttributeNumber;
    "padding-top"?: AttributeNumber;
    "padding-right"?: AttributeNumber;
    "padding-bottom"?: AttributeNumber;
    "padding-x"?: AttributeNumber;
    "padding-y"?: AttributeNumber;
    "clip-border"?: AttributeNumber;
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

type ContainerAttributes = {
    alpha?: AttributeNumber;
    disabled?: boolean;
    passthrough?: boolean;
    scale?: AttributeNumber;
    delayed?: boolean;
    rotation?: AttributeNumber;
};

type ButtonCallbacks = {
    onclick?: EventHandler<UnityElement>;
    unfocus?: EventHandler<UnityElement>;
    onpointerdown?: EventHandler<UnityElement>;
    onpointerup?: EventHandler<UnityElement>;
};

type ToggleCallbacks = {
    onchange?: EventHandler<UnityToggle>;
    unfocus?: EventHandler<UnityToggle>;
};

type SliderCallbacks = {
    onchange?: EventHandler<UnitySlider>;
    unfocus?: EventHandler<UnitySlider>;
};

type ScrollViewCallbacks = {
    onchange?: EventHandler<UnityScrollView>;
};

type InputCallbacks = {
    oninput?: EventHandler<UnityInput>;
    onchange?: EventHandler<UnityInput>;
    onselect?: EventHandler<UnityInput>;
    ondeselect?: EventHandler<UnityInput>;
    unfocus?: EventHandler<UnityInput>;
};
