/// <reference types="mithril"/>
/// <reference types="csharp"/>
export {};
declare global {
    declare class UnityElement extends dom.UnityElement {
    }
    export declare const PartialRedraw: (mountId: number) => void;
    export declare const MithrilMount: (element: CS.TSF.Oolong.UGUI.IOolongElement, component: MithrilComponent, partial: boolean) => any;
    export declare const MithrilUnmount: (element: UnityElement) => void;
    export declare abstract class MithrilComponent<A = {}> implements m.ClassComponent<A> {
        private __tsx_attrs;
        private __mountId;
        oninit?(vnode: m.Vnode<A, this>): any;
        oncreate?(vnode: m.VnodeDOM<A, this>): any;
        onbeforeremove?(vnode: m.VnodeDOM<A, this>): Promise<any> | void;
        onremove?(vnode: m.VnodeDOM<A, this>): any;
        onbeforeupdate?(vnode: m.Vnode<A, this>, old: m.VnodeDOM<A, this>): boolean | void;
        onupdate?(vnode: m.VnodeDOM<A, this>): any;
        abstract view(vnode: m.Vnode<A, this>): m.Children | null | void;
        redraw(): void;
    }
    export declare abstract class Realtime extends MithrilComponent {
        private interval;
        private dom;
        register(vnode: m.VnodeDOM<{}, this>): void;
        oncreate(vnode: m.VnodeDOM<{}, this>): void;
        onupdate(vnode: m.VnodeDOM<{}, this>): void;
        view(vnode: m.Vnode<{}, this>): void | m.Children;
        onbeforeremove(): void;
    }
}
