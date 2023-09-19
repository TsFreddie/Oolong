import type * as dom from './dom.js';

declare class UnityElement extends dom.UnityElement {}

import m from 'mithril';

export abstract class MithrilComponent<A = {}> implements m.ClassComponent<A> {
  /** @internal */
  private __tsx_attrs: A & { key?: string | number };
  /** The oninit hook is called before a vnode is touched by the virtual DOM engine. */
  oninit?(vnode: m.Vnode<A, this>): any;
  /** The oncreate hook is called after a DOM element is created and attached to the document. */
  oncreate?(vnode: m.VnodeDOM<A, this>): any;
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
}

export const MithrilMount = (
  element: CS.TSF.Oolong.UI.IOolongElement,
  component: MithrilComponent
) => {
  var el = new UnityElement(element);
  m.mount(el as any, component);
  return el;
};

export const MithrilUnmount = (element: UnityElement) => {
  m.mount(element as any, null);
};
