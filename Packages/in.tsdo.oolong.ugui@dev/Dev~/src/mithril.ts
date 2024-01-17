import type * as dom from './dom.js';

declare class UnityElement<T extends object = any> extends dom.UnityElement<T> {}

import m from 'mithril';

export interface PartialRedrawAttrs {
  redraw: () => void;
  element: UnityElement;
}

const mountMap = new Map<number, PartialRedrawAttrs>();

export const PartialRedraw = (mountId: number) => {
  const mount = mountMap.get(mountId);
  if (mount) {
    mount.redraw();
  }
};

export const MithrilMount = (
  mono: CS.TSF.Oolong.UGUI.OolongElement,
  component: MithrilComponent,
  partial: boolean
) => {
  if (partial) {
    const mm: any = m; // for accessing untyped internal mithril API
    const el = new UnityElement(mono, true);
    let pending = false;
    const mount: PartialRedrawAttrs = {
      redraw,
      element: el,
    };

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
        mm.render(el, mm.vnode(component, undefined, mount), redraw);
      } catch (e) {
        console.error(e);
      }
    }

    mm.render(el, mm.vnode(component, undefined, mount), redraw);
    mountMap.set(el.mountId, mount);
    return el;
  } else {
    let el = new UnityElement(mono, false);
    m.mount(el as any, component);
    return el;
  }
};

export const MithrilUnmount = (element: UnityElement) => {
  if (element.mountId) {
    mountMap.delete(element.mountId);
    m.render(element as any, []);
  } else {
    m.mount(element as any, null);
  }
};

export const MithrilRedraw = (element: UnityElement = null) => {
  // Try partial redraw if element is provided
  if (element != null) {
    if (element.mountId) {
      PartialRedraw(element.mountId);
    } else {
      m.redraw();
    }
    return;
  }

  // Global redraw
  m.redraw();

  // Also redraw all partial redraws
  for (const mount of mountMap.values()) {
    mount.redraw();
  }
};

export abstract class MithrilComponent<A = {}> implements m.ClassComponent<A> {
  constructor(attrs: A) {}

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
