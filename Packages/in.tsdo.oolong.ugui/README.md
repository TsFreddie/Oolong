# Oolong Unity UI (Oolong UGUI)

A tsx workflow for creating UI. Powered by [MithrilJS](https://mithril.js.org/).

## What does Oolong UGUI do?

Oolong UGUI emulates a small subset of DOM to enable MithrilJS for UI authoring by creating GameObjects. A set of custom
DOM elements based on Unity UI is also provided.

## Currently Missing Features

These are some of the critical features that is missing

- You can't set the font of `<text>`
- There is no `<dropdown>` element yet

## Why MithrilJS?

MithrilJS is very small and simple. It requires a very small set of DOM features to work, and you can make tsx work with
it. Also MithrilJS works in plain JavaScript (so inherently, TypeScript as well), there is no custom format that need to
be transpiled again.

There are also no CSS support since it is just a JavaScript front-end framework, which is actually a plus so I don't
have to find a way to strip CSS from the framework or magically make CSS work in Unity UI.

The newer / experimental Unity UI Toolkit does have a style sheet format. Currently I have no plan on supporting UITK.
But if I do in the future, I might try out something like Svelte to see if I can make it work with USS.

## Getting Started

It is quite simple to create a component by creating a tsx file and inheriting `MithrilComponent`. Check
the [MithrilJS](https://mithril.js.org/)'s documentation for more detail on the lifecycle hooks.

Note that mithril uses **hyperscript** by default in the documentation. But apart from the syntax difference, tsx is
basically the same as hyperscript.

### Quick example

Here's a example of a Component that displays a button.

```tsx
export default class Page extends MithrilComponent {
    view() {
        return (
            <button
                src="#"
                color="#550000"
                align="stretch"
                onclick={() => {
                    console.log("clicked");
                }}
            >
                <text>{Math.random().toString()}</text>
            </button>
        );
    }
}
```

### Sprites

To load sprites, you need to mark your sprites as Addressable. Then you can load them by using address. Sprite assets
are loaded synchronously by default, so it is recommended to preload the common atlas before loading the UI.

If you just want to prototype the layout or simply use Unity's default white texture sprite. You can use `#` as the
address, so it will display as a white square.

You can also load image asynchronously by adding an `async` attribute to a `<image>` element. Async loading is only
supported on `<image>` elements.

### Elements

Currently the following elements are provided:

- `<panel>` - equivalent of a `RectTransform`, does not include an Image like Unity does. Also supports horizontal,
  vertical and grid layout if specified.
- `<image>` - equivalent of a `Image`.
- `<text>` - equivalent of a `TextMeshPro UGUI` text. The child of a text element should ideally be a string. You can
  have children elements under a `<text>` element, but it is not recommended.
- `<button>` - equivalent of a `Button`, does not include text. You should add the text using `<text>` element manually.
- `<toggle>` - equivalent of a `Toggle`, does not include text either.
- `<scrollrect>` - equivalent of a `ScrollRect`, includes multiple GameObjects that handles masking and scrollbars.
- `<input>` - equivalent of a `TextMeshPro InputField`.
- `<slider>` - equivalent of a `Slider`.
- `<container>` - a special kind of `<panel>` that also includes a `CanvasGroup` component for alpha and interaction
  control.

Check the built-in Mithril typings for detail about the attributes and events.

Also note that the Y coordinate is flipped.

### Partial Redraw

Given that MithrilJS is designed to serve a single page.
The [auto redraw system](https://mithril.js.org/autoredraw.html) of Mithril will update all components mounted
using `m.mount()` or `m.route()`. This might not be a problem if you only use Oolong UGUI to create a single Canvas
front-end experience. But if you use Oolong UGUI to create multiple Canvases, a partial redraw feature is provided to
reduce the amount of components to update if you have a lot of Canvases.

To enable Partial Redraw, you first need to make sure to call `super.oncreate(vnode)` if you are overriding
the `oncreate` life cycle hook:

```tsx
export default class PartialRedrawComponent extends MithrilComponent {
    oncreate(vnode: m.VnodeDOM<{}, this>) {
        // make sure this is called
        super.oncreate(vnode);

        // trigger a manual redraw after 5 seconds
        setTimeout(() => {
            this.redraw();
        }, 5000);
    }

    view() {
        return (<panel>
            <text>{Math.random().toString()}</text>
        </panel>);
    }
}
```

Then, you can simply enable Partial Redraw on the `MithrilComponent` in the Unity Editor. The auto redraw system will be
replaced with a partial redraw routine.

To manually redraw, instead of calling `m.redraw()`, call the `redraw()` method provided in `MithrilComponent` like the
example
above.

Note that if Partial Redraw is enabled, the root component will exists outside of Mithril's redraw system. This
means `m.redraw()` will not trigger redraws for components that has Partial Redraw enabled.

### Realtime

Since Mithril is designed for reactive UI, realtime update is generally discouraged. Calling `redraw` every frame would
be very expensive just to make the UI update every frame.

But if you ever find yourself needing a UI element to update in realtime, a `<Realtime>` component is provided, where
you can pass a render function to be called every frame.

```tsx
<Realtime>
    {() => (
        <text>
            {Math.random().toString()}
        </text>
    )}
</Realtime>
```

By using `<Realtime>` component, only the realtime part will be updated instead of the entire mounted component.
