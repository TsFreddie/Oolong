/// <reference types="mithril"/>
/// <reference types="csharp"/>
export {};
declare global {
    export declare class HttpRequest {
        static baseURL: string;
        onreadystatechange: (ev: {
            target: HttpRequest;
        }) => void;
        private request;
        responseType: string;
        withCredentials: boolean;
        constructor();
        abort(): void;
        setRequestHeader(key: string, value: string): void;
        open(method: string, url: string, async: boolean): void;
        send(body?: string | Uint8Array): void;
        get response(): any;
        get readyState(): 4 | 3;
        get status(): bigint;
        get statusText(): string;
        set timeout(value: number);
    }
    export type UnityChild = UnityElement | UnityTextNode;
    export type UnityChildren = UnityChild[];
    export declare abstract class UnityNode {
        tag: string;
        parent: UnityNode;
        children: UnityChildren;
        private _id;
        private childrenMap;
        get id(): string;
        set id(value: string);
        get childNodes(): UnityChildren;
        findChildById(id: string): UnityElement;
        findChildrenById(id: string): readonly UnityElement[];
        private elementIndex;
        private setText;
        get parentElement(): UnityNode;
        get parentNode(): UnityNode;
        get innerHTML(): string;
        set innerHTML(text: string);
        get textContent(): string;
        set textContent(text: string);
        get firstChild(): UnityChild;
        get lastChild(): UnityChild;
        updateText(): void;
        private addChildId;
        private removeChildId;
        appendChild(child: UnityFragment | UnityElement | UnityTextNode): void;
        removeChild(child: UnityChild): void;
        insertBefore(child: UnityChild, ref: UnityChild): void;
        toJSON(): any;
        abstract setAttribute(name: string, value: string): void;
        abstract removeAttribute(name: string): void;
    }
    export declare class UnityFragment extends UnityNode {
        constructor();
        setAttribute(): void;
        removeAttribute(): void;
    }
    type UnityEvent = {
        type: string;
        target: UnityElement;
        eventData: CS.UnityEngine.EventSystems.BaseEventData;
    };
    type EventHandler = ((ev: UnityEvent) => void) | {
        handleEvent: (ev: UnityEvent) => void;
    };
    export declare class UnityElement<T extends object = any> extends UnityNode {
        mono: CS.TSF.Oolong.UGUI.OolongElement;
        mountId: number;
        attrs: T;
        private events;
        private _version;
        constructor(mono: CS.TSF.Oolong.UGUI.OolongElement, mount?: boolean);
        constructor(tagName: string, mount?: boolean);
        contains(node: UnityElement): boolean;
        setAttribute(name: string, value: any): boolean;
        getAttribute(name: string): string;
        removeAttribute(name: string): void;
        addEventListener(event: string, callback: EventHandler): void;
        removeEventListener(event: string, callback: EventHandler): void;
    }
    export declare class UnityTextNode {
        nodeText: string;
        parent: UnityNode;
        constructor(text: string);
        get parentElement(): UnityNode;
        get parentNode(): UnityNode;
        set nodeValue(text: string);
        toJSON(): {
            type: string;
            text: string;
        };
    }
    export declare class UnityDocument {
        private emptyList;
        getElementById(id: string): UnityElement<any>;
        getElementsById(id: string): readonly UnityElement[];
        createDocumentFragment(): UnityFragment;
        createElement(tagName: string): UnityElement;
        createTextNode(text: string): UnityTextNode;
    }
    export declare class UnityLocation {
        private _hash;
        private _href;
        get href(): string;
        get hash(): string;
        set href(value: string);
        set hash(value: string);
    }
    export declare class UnityHistory {
        private historyStack;
        pushState(state: string, title: string, url?: string): void;
        replaceState(state: string, title: string, url?: string): void;
    }
    export declare class UnimplementedFormData {
    }
    export declare class UnimlementedURLSearchParams {
    }
    export declare class UnityWindow {
        private animationFrameQueue;
        private animationFrameProcessor;
        location: UnityLocation;
        history: UnityHistory;
        document: UnityDocument;
        XMLHttpRequest: typeof HttpRequest;
        FormData: typeof UnimplementedFormData;
        URLSearchParams: typeof UnimlementedURLSearchParams;
        setTimeout: typeof setTimeout;
        requestAnimationFrame(cb: () => void): void;
        addEventListener(event: string, cb: (e: any) => void): void;
        removeEventListener(event: string, cb: (e: any) => void): void;
        tick(): void;
    }
    export declare const window: UnityWindow;
    export declare const unityWindow: UnityWindow;
    export declare const requestAnimationFrame: (cb: () => void) => void;
    export declare const document: UnityDocument;
    export declare const unityDocument: UnityDocument;
    export declare const location: UnityLocation;
    export declare const unityLocation: UnityLocation;
    export declare const history: UnityHistory;
    export declare const unityHistory: UnityHistory;
    export declare const addEventListener: (event: string, cb: (e: any) => void) => void;
    export declare const MithrilTick: () => void;
    declare class UnityElement<T extends object = any> extends dom.UnityElement<T> {
    }
    export interface PartialRedrawAttrs {
        redraw: () => void;
        element: UnityElement;
    }
    export declare const CustomRedraw: (mountId: number) => void;
    export declare const MithrilMount: (mono: CS.TSF.Oolong.UGUI.OolongElement, component: MithrilComponent, partial: boolean) => UnityElement<any>;
    export declare const MithrilUnmount: (element: UnityElement) => void;
    export declare const MithrilRedraw: (element?: UnityElement) => void;
    export declare abstract class MithrilComponent<A = {}> implements m.ClassComponent<A> {
        constructor(attrs: A);
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
    type RealtimeAttrs = {
        interval?: number;
    } & PanelElementAttributes;
    export declare abstract class Realtime extends MithrilComponent<RealtimeAttrs> {
        oncreate(vnode: m.VnodeDOM<RealtimeAttrs, this>): void;
        view(vnode: m.Vnode<RealtimeAttrs, this>): void | m.Children;
        onremove(): void;
    }
}
