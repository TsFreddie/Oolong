import * as dom from "./src/dom.js";

const global = {
    ...dom,
};

for (var k in global) {
    globalThis[k] = global[k];
}
