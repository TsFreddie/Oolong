import mithril from "mithril";
import { MithrilComponent } from "./mithril.js";

export abstract class Realtime extends MithrilComponent {
    private interval: number;
    oncreate(vnode: mithril.VnodeDOM<{}, this>) {
        var dom = vnode.dom;
        var self = this;
        this.interval = setInterval(() => {
            mithril.render(dom, self.onvalueupdate());
        }, 0);
    }

    abstract onvalueupdate(): mithril.Children;

    view(vnode: mithril.Vnode<{}, this>): void | mithril.Children {
        return mithril("panel");
    }

    onbeforeremove(vnode: mithril.VnodeDOM<{}, this>): void | Promise<any> {
        clearInterval(this.interval);
    }
}

export class RealtimeText extends Realtime {
    override onvalueupdate(): mithril.Children {
        return mithril("text", Math.random().toString());
    }
}
