import m from 'mithril';
import { MithrilComponent } from './mithril.js';

interface RealtimeAttr {
  interval?: number;
}

export abstract class Realtime extends MithrilComponent<RealtimeAttr> {
  private interval: number;
  private dom: any;

  register(vnode: m.VnodeDOM<RealtimeAttr, this>) {
    var children = vnode.children as any;
    if (typeof children != 'object') return;
    var render = children[0];
    if (typeof render != 'function') return;

    const interval = vnode.attrs?.interval || 0;

    this.interval = setInterval(() => {
      m.render(this.dom, render());
    }, interval);
  }

  oncreate(vnode: m.VnodeDOM<{}, this>) {
    this.dom = vnode.dom;
    this.register(vnode);
  }

  onupdate(vnode: m.VnodeDOM<{}, this>) {
    this.onremove();
    this.register(vnode);
  }

  view(vnode: m.Vnode<{}, this>): void | m.Children {
    return m('div', vnode.attrs);
  }

  onremove() {
    if (this.interval != null) clearInterval(this.interval);
    this.interval = null;
  }
}
