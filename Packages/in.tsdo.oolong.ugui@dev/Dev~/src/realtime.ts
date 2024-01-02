import m from 'mithril';
import { MithrilComponent } from './mithril.js';

export abstract class Realtime extends MithrilComponent {
  private interval: number;
  private dom: any;

  register(vnode: m.VnodeDOM<{}, this>) {
    var children = vnode.children as any;
    if (typeof children != 'object') return;
    var render = children[0];
    if (typeof render != 'function') return;

    this.interval = setInterval(() => {
      m.render(this.dom, render());
    }, 0);
  }

  oncreate(vnode: m.VnodeDOM<{}, this>) {
    this.dom = vnode.dom;
    this.register(vnode);
  }

  onupdate(vnode: m.VnodeDOM<{}, this>) {
    this.onbeforeremove();
    this.register(vnode);
  }

  view(vnode: m.Vnode<{}, this>): void | m.Children {
    return m('div', vnode.attrs);
  }

  onbeforeremove() {
    if (this.interval != null) clearInterval(this.interval);
    this.interval = null;
  }
}
