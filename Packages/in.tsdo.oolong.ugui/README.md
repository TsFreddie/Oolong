# Oolong Unity UI (Oolong UGUI)

A tsx workflow for creating UI. Powered by [MithrilJS](https://mithril.js.org/).

## What does Oolong UGUI do?

Oolong UGUI emulates a small subset of DOM to enable MithrilJS for UI authoring by creating GameObjects. A set of custom DOM elements based on Unity UI is also provided (e.g. `<panel>`, `<button>`, `<image>`, `<input>`, `<scrollview>`, etc.)

## Currently Missing Features

These are some of the critical features that is missing

- You can't set the font of `<text>`
- There is no `<dropdown>` element yet
- No direct animation support, but you can code animations via `SetTimeout` or `SetInterval` and update the DOM (which is just Unity Components).

## Why MithrilJS?

MithrilJS is very small and simple. It requires a very small set of DOM features to work, and you can make tsx work with it. Also MithrilJS works in plain JavaScript (so inherently, TypeScript as well), there is no custom format that need to be transpiled again.

There are also no CSS support since it is just a JavaScript front-end framework, which is actually a plus so I don't have to find a way to strip CSS from the framework or magically make CSS work in Unity UI.

The newer / experimental Unity UI Toolkit does have a style sheet format. Currently I have no plan on supporting UITK. But if I do in the future, I might try out something like Svelte to see if I can make it work with USS.