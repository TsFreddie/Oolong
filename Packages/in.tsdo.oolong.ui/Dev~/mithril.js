import * as mithril from "./src/mithril";
import * as realtime from "./src/realtime";

const global = {
    ...mithril,
    ...realtime,
};

for (var k in global) {
    globalThis[k] = global[k];
}
