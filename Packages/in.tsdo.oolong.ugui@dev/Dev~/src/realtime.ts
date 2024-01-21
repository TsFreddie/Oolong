import m from 'mithril';
import { MithrilComponent } from './mithril.js';

type RealtimeAttrs = {
  interval?: number;
} & PanelElementAttributes;

export abstract class Realtime extends MithrilComponent<RealtimeAttrs> {
  /** @internal */
  private _interval: number;
  /** @internal */
  private _dom: any;

  /** @internal */
  private _render(vnode: m.Vnode<RealtimeAttrs, this>) {
    var children = vnode.children as any;
    if (typeof children != 'object') return;
    var render = children[0];
    if (typeof render != 'function') return;
    return render();
  }

  oncreate(vnode: m.VnodeDOM<RealtimeAttrs, this>) {
    super.oncreate(vnode);
    this._dom = vnode.dom;
    const interval = vnode.attrs?.interval || 0;

    const redraw = () => {
      this.redraw();
    };

    this._interval = setInterval(() => {
      (m as any).render(this._dom, this._render(vnode), redraw);
    }, interval);

    (m as any).render(this._dom, this._render(vnode), redraw);
  }

  view(vnode: m.Vnode<RealtimeAttrs, this>): void | m.Children {
    return m('panel', vnode.attrs);
  }

  onremove() {
    m.render(this._dom, null);
    if (this._interval != null) clearInterval(this._interval);
    this._interval = null;
  }
}
