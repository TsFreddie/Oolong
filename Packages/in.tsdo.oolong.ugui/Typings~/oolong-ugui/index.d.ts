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
    export declare const ToCSharpByteArray: <T = number>(data: Uint8Array) => CS.System.Array$1<T>;
    export declare const FromCSharpByteArray: (data: CS.System.Array$1<number>) => Uint8Array;
    export type UnityChild = UnityElement | UnityTextNode;
    export type UnityChildren = UnityChild[];
    export declare abstract class UnityNode {
        id: string;
        tag: string;
        parent: UnityNode;
        children: UnityChildren;
        get childNodes(): UnityChildren;
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
        appendChild(child: UnityFragment | UnityElement | UnityTextNode): void;
        removeChild(child: UnityChild): void;
        insertBefore(child: UnityChild, ref: UnityChild): void;
        toJSON(): any;
        abstract setAttribute(name: string, value: string): void;
        abstract removeAttribute(name: string): void;
        abstract attachChildInternal(child: UnityElement): void;
        abstract removeChildInternal(child: UnityElement): void;
        abstract insertChildInternal(child: UnityElement, pos: number): void;
    }
    export declare class UnityFragment extends UnityNode {
        constructor();
        setAttribute(): void;
        removeAttribute(): void;
        attachChildInternal(): void;
        removeChildInternal(): void;
        insertChildInternal(): void;
    }
    type Event = {
        type: string;
        target: UnityElement;
    };
    type EventHandler = ((ev: Event) => void) | {
        handleEvent: (ev: Event) => void;
    };
    export declare class UnityElement<T extends CS.TSF.Oolong.UGUI.IOolongElement = CS.TSF.Oolong.UGUI.IOolongElement> extends UnityNode {
        element: T;
        private events;
        constructor(element: CS.TSF.Oolong.UGUI.IOolongElement);
        constructor(tagName: string);
        contains(node: UnityElement): boolean;
        attachChildInternal(child: UnityElement): void;
        removeChildInternal(child: UnityElement): void;
        insertChildInternal(child: UnityElement, pos: number): void;
        setAttribute(name: string, value: any): void;
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
    export declare const requestAnimationFrame: (cb: () => void) => void;
    export declare const document: UnityDocument;
    export declare const location: UnityLocation;
    export declare const history: UnityHistory;
    export declare const addEventListener: (event: string, cb: (e: any) => void) => void;
    export declare const MithrilTick: () => void;
    declare class UnityElement extends dom.UnityElement {
    }
    export declare abstract class MithrilComponent<A = {}> implements m.ClassComponent<A> {
        private __tsx_attrs;
        oninit?(vnode: m.Vnode<A, this>): any;
        oncreate?(vnode: m.VnodeDOM<A, this>): any;
        onbeforeremove?(vnode: m.VnodeDOM<A, this>): Promise<any> | void;
        onremove?(vnode: m.VnodeDOM<A, this>): any;
        onbeforeupdate?(vnode: m.Vnode<A, this>, old: m.VnodeDOM<A, this>): boolean | void;
        onupdate?(vnode: m.VnodeDOM<A, this>): any;
        abstract view(vnode: m.Vnode<A, this>): m.Children | null | void;
    }
    export declare const MithrilMount: (element: CS.TSF.Oolong.UGUI.IOolongElement, component: MithrilComponent) => UnityElement;
    export declare const MithrilUnmount: (element: UnityElement) => void;
    export declare abstract class Realtime extends MithrilComponent {
        private interval;
        oncreate(vnode: m.VnodeDOM<{}, this>): void;
        abstract onvalueupdate(): m.Children;
        view(vnode: m.Vnode<{}, this>): void | m.Children;
        onbeforeremove(vnode: m.VnodeDOM<{}, this>): void | Promise<any>;
    }
}
