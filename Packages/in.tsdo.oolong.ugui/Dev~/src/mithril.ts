import type * as dom from './dom.js';

declare class UnityElement extends dom.UnityElement {}

import m from 'mithril';

const partialRedrawMap = new Map<number, () => void>();

export const PartialRedraw = (mountId: number) => {
  const redraw = partialRedrawMap.get(mountId);
  if (redraw) {
    redraw();
  }
};

export const MithrilMount = (
  element: CS.TSF.Oolong.UGUI.IOolongElement,
  component: MithrilComponent,
  partial: boolean
) => {
  if (partial) {
    let mm: any = m; // for accessing untyped internal mithril API
    let el = new UnityElement(element, true);
    let pending = false;

    function redraw() {
      if (!pending) {
        pending = true;
        requestAnimationFrame(function () {
          pending = false;
          sync();
        });
      }
    }

    function sync() {
      try {
        mm.render(el, mm.vnode(component), redraw);
      } catch (e) {
        console.error(e);
      }
    }

    mm.render(el, mm.vnode(component), redraw);
    partialRedrawMap.set(el.mountId, redraw);
    return el;
  } else {
    let el = new UnityElement(element, false);
    return m.mount(el as any, component);
  }
};

export const MithrilUnmount = (element: UnityElement) => {
  if (element.mountId) {
    partialRedrawMap.delete(element.mountId);
    m.render(element as any, []);
  } else {
    m.mount(element as any, null);
  }
};

export abstract class MithrilComponent<A = {}> implements m.ClassComponent<A> {
  /** @internal */
  private __tsx_attrs: A & { key?: string | number };
  /** @internal */
  private __mountId: number;
  /** The oninit hook is called before a vnode is touched by the virtual DOM engine. */
  oninit?(vnode: m.Vnode<A, this>): any;
  /** The oncreate hook is called after a DOM element is created and attached to the document. */
  oncreate?(vnode: m.VnodeDOM<A, this>): any {
    this.__mountId = (vnode.dom as any).mountId;
  }
  /** The onbeforeremove hook is called before a DOM element is detached from the document. If a Promise is returned, Mithril only detaches the DOM element after the promise completes. */
  onbeforeremove?(vnode: m.VnodeDOM<A, this>): Promise<any> | void;
  /** The onremove hook is called before a DOM element is removed from the document. */
  onremove?(vnode: m.VnodeDOM<A, this>): any;
  /** The onbeforeupdate hook is called before a vnode is diffed in a update. */
  onbeforeupdate?(vnode: m.Vnode<A, this>, old: m.VnodeDOM<A, this>): boolean | void;
  /** The onupdate hook is called after a DOM element is updated, while attached to the document. */
  onupdate?(vnode: m.VnodeDOM<A, this>): any;
  /** Creates a view out of virtual elements. */
  abstract view(vnode: m.Vnode<A, this>): m.Children | null | void;
  redraw() {
    if (this.__mountId) {
      PartialRedraw(this.__mountId);
    } else {
      m.redraw();
    }
  }
}
