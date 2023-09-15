export class HttpRequest {
    public static baseURL: string = null;
    public onreadystatechange: (ev: { target: HttpRequest }) => void;
    private request: CS.UnityEngine.Networking.UnityWebRequest;
    public responseType: string;
    public withCredentials: boolean;

    public constructor() {
        this.request = new CS.UnityEngine.Networking.UnityWebRequest();
    }

    public abort() {
        this.request.Abort();
    }

    public setRequestHeader(key: string, value: string) {
        this.request.SetRequestHeader(key, value);
    }

    public open(method: string, url: string, async: boolean) {
        this.request.method = method;
        if (url.startsWith("/")) {
            this.request.url = HttpRequest.baseURL + url;
        } else {
            this.request.url = url;
        }
    }

    public send(body?: string | Uint8Array) {
        if (body != null) {
            if (typeof body != "string") {
                this.request.uploadHandler =
                    new CS.UnityEngine.Networking.UploadHandlerRaw(
                        ToCSharpByteArray(body)
                    );
            } else {
                CS.TSF.Oolong.UI.UnityWebRequestExtension.SetBody(
                    this.request,
                    body
                );
            }
        }

        if (this.withCredentials) {
            CS.TSF.Oolong.UI.OolongWebConfig.Authenticate(this.request);
        }
        CS.TSF.Oolong.UI.UnityWebRequestExtension.SendWithCallback(
            this.request,
            () => {
                if (this.onreadystatechange) {
                    this.onreadystatechange({target: this});
                }
            }
        );
    }

    public get response() {
        if (this.responseType == "json") {
            return JSON.parse(this.request.downloadHandler.text);
        } else if (this.responseType == "arraybuffer") {
            return FromCSharpByteArray(this.request.downloadHandler.data);
        } else {
            return this.request.downloadHandler.text;
        }
    }

    public get readyState() {
        return this.request.isDone ? 4 : 3;
    }

    public get status() {
        return this.request.responseCode;
    }

    public get statusText() {
        return this.request.error;
    }

    public set timeout(value: number) {
        this.request.timeout = Math.ceil(value / 1000);
    }
}

export const ToCSharpByteArray = <T = number>(
    data: Uint8Array
): CS.System.Array$1<T> => {
    const byteArray = CS.System.Array.CreateInstance(
        puerts.$typeof(CS.System.Byte),
        data.length
    );
    for (let i = 0; i < data.length; i++) {
        byteArray.set_Item(i, data[i]);
    }
    return byteArray;
};

export const FromCSharpByteArray = (data: CS.System.Array$1<number>) => {
    if (data == null) return null;
    const length = data.Length;
    if (length == 0) return null;
    const byteArray = new Uint8Array(length);
    for (let i = 0; i < length; i++) {
        byteArray[i] = data.get_Item(i);
    }
    return byteArray;
};

interface HistoryEntry {
    state: string;
    title: string;
    url?: string;
}

export type UnityChild = UnityElement | UnityTextNode;
export type UnityChildren = UnityChild[];

// TODO: 克隆一份TMP，直接修改TMP，避免Transform。并且可以考虑在Window中添加清洗用户输入的方法
const TransformText = (text: string) => {
    return text
        .replace(/</g, "\u003C\u200B")
        .replace(/>/g, "\u003E\u200B")
        .replace(/\[/g, "<")
        .replace(/\]/g, ">")
        .replace(/&lb;/g, "\u005B")
        .replace(/&rb;/g, "\u005D");
};

const RenderText = (children: UnityChildren) => {
    const text = (
        children.filter((n) => n instanceof UnityTextNode) as UnityTextNode[]
    )
        .map((n) => n.nodeText)
        .join("");
    return text;
};

const LabelOf = (node: UnityNode | UnityTextNode) => {
    if (node == null) return undefined;
    if (node instanceof UnityTextNode) {
        return `[${node.nodeText}]`;
    }
    if (node.id != null) return `<${node.tag} id=${node.id}/>`;
    return `<${node.tag}/>`;
};

export abstract class UnityNode {
    public id: string;
    public tag: string;
    public parent: UnityNode;
    public children: UnityChildren = [];

    public get childNodes() {
        return this.children;
    }

    private elementIndex(element: UnityChild) {
        let elements = 0;
        for (let nodes = 0; nodes < this.children.length; nodes++) {
            const child = this.children[nodes];
            if (child === element) {
                return {nodes, elements};
            }
            if (child instanceof UnityElement) {
                elements++;
            }
        }
        return null;
    }

    private setText(text: string) {
        if (this.children.length > 0) {
            console.warn("设置文本时，元素中已经有元素了");
            return;
        }
        this.children.splice(0, this.children.length);

        if (text.length === 0) {
            return;
        }

        var textNode = new UnityTextNode(text);
        textNode.parent = this;
        this.children.push(textNode);
        this.setAttribute("#", TransformText(text));
    }

    public get parentElement() {
        return this.parent;
    }

    public get parentNode() {
        return this.parent;
    }

    public get innerHTML() {
        return RenderText(this.children);
    }

    public set innerHTML(text: string) {
        this.setText(text);
    }

    public get textContent() {
        return RenderText(this.children);
    }

    public set textContent(text: string) {
        this.setText(text);
    }

    public get firstChild() {
        return this.children[0];
    }

    public get lastChild() {
        return this.children[this.children.length - 1];
    }

    public updateText() {
        this.setAttribute("#", RenderText(this.children));
    }

    public appendChild(
        child: UnityFragment | UnityElement | UnityTextNode
    ): void {
        if (child.parent != null && !(child.parent instanceof UnityFragment)) {
            console.warn("Element中出现了未处理的状况");
        }

        if (child instanceof UnityFragment) {
            // 将 Fragment 的子元素添加到当前元素中
            for (let i = 0; i < child.children.length; i++) {
                this.appendChild(child.children[i]);
            }
            child.children.splice(0, child.children.length);
            return;
        }

        child.parent = this;
        this.children.push(child);

        if (child instanceof UnityElement) {
            this.attachChildInternal(child);
        }
        if (child instanceof UnityTextNode) {
            this.updateText();
        }
    }

    public removeChild(child: UnityChild): void {
        child.parent = null;

        const index = this.children.indexOf(child);
        if (index < 0) {
            console.warn("找不到正在移除的元素。可能是vnode不同步");
            return;
        }

        // 移除节点
        this.children.splice(index, 1);

        // 如果是元素则移除元素
        if (child instanceof UnityElement) {
            this.removeChildInternal(child);
        }
        if (child instanceof UnityTextNode) {
            this.updateText();
        }
    }

    public insertBefore(child: UnityChild, ref: UnityChild) {
        if (child.parent != null) {
            console.warn("Element中出现了未处理的状况");
        }

        const index = this.elementIndex(ref);
        if (index == null) {
            console.warn("找不到插入目标元素。可能是vnode不同步");
            return;
        }

        child.parent = this;
        this.children.splice(index.nodes, 0, child);

        // 如果是元素则插入元素
        if (child instanceof UnityElement) {
            this.insertChildInternal(child, index.elements);
        }
        if (child instanceof UnityTextNode) {
            this.updateText();
        }
    }

    public toJSON(): any {
        return {
            type: this instanceof UnityFragment ? "fragment" : "element",
            node: LabelOf(this),
            parent: LabelOf(this.parent),
            children: this.children.map((child) => child.toJSON()),
        };
    }

    public abstract setAttribute(name: string, value: string): void;

    public abstract removeAttribute(name: string): void;

    public abstract attachChildInternal(child: UnityElement): void;

    public abstract removeChildInternal(child: UnityElement): void;

    public abstract insertChildInternal(child: UnityElement, pos: number): void;
}

export class UnityFragment extends UnityNode {
    constructor() {
        super();
        this.tag = "";
    }

    public setAttribute() {
    }

    public removeAttribute() {
    }

    public attachChildInternal() {
    }

    public removeChildInternal() {
    }

    public insertChildInternal() {
    }
}

type Event = { type: string; target: UnityElement };
type EventHandler =
    | ((ev: Event) => void)
    | { handleEvent: (ev: Event) => void };

const runEvent = (target: UnityElement, event: string, cb: EventHandler) => {
    if (typeof cb === "function") {
        cb({target, type: event});
    } else if (typeof cb === "object") {
        cb.handleEvent({target, type: event});
    }
};

export class UnityElement extends UnityNode {
    public element: CS.TSF.Oolong.UI.IOolongElement;
    private events: { [key: string]: EventHandler };

    constructor(element: CS.TSF.Oolong.UI.IOolongElement);
    constructor(tagName: string);
    constructor(tagNameOrElement: string | CS.TSF.Oolong.UI.IOolongElement) {
        super();
        if (typeof tagNameOrElement == "string") {
            this.element =
                CS.TSF.Oolong.UI.DocumentUtils.CreateElement(tagNameOrElement);
        } else {
            this.element = tagNameOrElement;
        }
        this.tag = this.element.TagName;
        this.events = {};
    }

    public contains(node: UnityElement) {
        // Skip mithril's lock check
        return false;
    }

    public attachChildInternal(child: UnityElement) {
        CS.TSF.Oolong.UI.DocumentUtils.AttachElement(
            this.element,
            child.element
        );
    }

    public removeChildInternal(child: UnityElement) {
        CS.TSF.Oolong.UI.DocumentUtils.RemoveElement(
            this.element,
            child.element
        );
    }

    public insertChildInternal(child: UnityElement, pos: number) {
        CS.TSF.Oolong.UI.DocumentUtils.InsertElement(
            this.element,
            child.element,
            pos
        );
    }

    public setAttribute(name: string, value: any) {
        if (name == "id") this.id = value;
        this.element.SetElementAttribute(name, value.toString());
    }

    public removeAttribute(name: string) {
        if (name == "id") this.id = undefined;
        this.element.SetElementAttribute(name, null);
    }

    public addEventListener(event: string, callback: EventHandler) {
        this.events[event] = callback;
        this.element.AddListener(event, () => runEvent(this, event, callback));
    }

    public removeEventListener(event: string, callback: EventHandler) {
        delete this.events[event];
        this.element.RemoveListener(event);
    }
}

export class UnityTextNode {
    public nodeText: string;
    public parent: UnityNode;

    constructor(text: string) {
        this.nodeText = text;
    }

    public get parentElement() {
        return this.parent;
    }

    public get parentNode() {
        return this.parent;
    }

    public set nodeValue(text: string) {
        this.nodeText = text;
        this.parent?.updateText?.();
    }

    public toJSON() {
        return {
            type: "text",
            text: this.nodeText,
        };
    }
}

export class UnityDocument {
    public createDocumentFragment(): UnityFragment {
        return new UnityFragment();
    }

    public createElement(tagName: string): UnityElement {
        return new UnityElement(tagName);
    }

    public createTextNode(text: string) {
        return new UnityTextNode(text);
    }
}

export class UnityLocation {
    private _hash: string = "#";
    private _href: string = "/";

    public get href() {
        return this._href;
    }

    public get hash() {
        return this._hash;
    }

    public set href(value: string) {
        this._href = value;
    }

    public set hash(value: string) {
        this._hash = value;
    }
}

export class UnityHistory {
    private historyStack: HistoryEntry[] = [];

    public pushState(state: string, title: string, url?: string) {
        url = url ?? window.location.href;
        this.historyStack.push({state, title, url});
        window.location.hash = url;
        window.location.href = url;
    }

    public replaceState(state: string, title: string, url?: string) {
        url = url ?? window.location.href;
        if (this.historyStack.length > 0) {
            this.historyStack[this.historyStack.length - 1] = {
                state,
                title,
                url,
            };
            if (url) window.location.hash = url;
        } else {
            this.historyStack.push({state, title, url});
            if (url) window.location.hash = url;
        }
        window.location.hash = url;
        window.location.href = url;
    }
}

// Stub 类，避免 Mithril 报错
export class UnimplementedFormData {
}

export class UnimlementedURLSearchParams {
}

export class UnityWindow {
    // Mithril 渲染时使用
    private animationFrameQueue: (() => void)[] = [];
    private animationFrameProcessor: (() => void)[] = [];

    public location: UnityLocation = new UnityLocation();
    public history: UnityHistory = new UnityHistory();
    public document: UnityDocument = new UnityDocument();

    public requestAnimationFrame(cb: () => void) {
        if (typeof cb !== "function") return;
        this.animationFrameQueue.push(cb);
    }

    // TODO: handle popstate
    public addEventListener(event: string, cb: (e: any) => void) {
    }

    public removeEventListener(event: string, cb: (e: any) => void) {
    }

    public tick() {
        const tmp = this.animationFrameQueue;
        this.animationFrameQueue = this.animationFrameProcessor;
        this.animationFrameProcessor = tmp;
        for (const cb of this.animationFrameProcessor) {
            cb();
        }
        this.animationFrameProcessor.splice(
            0,
            this.animationFrameProcessor.length
        );
    }

    public XMLHttpRequest = HttpRequest;
    public FormData = UnimplementedFormData;
    public URLSearchParams = UnimlementedURLSearchParams;

    public setTimeout = globalThis.setTimeout;
}

globalThis.UnityElement = UnityElement;
globalThis.window = new UnityWindow();
globalThis.requestAnimationFrame = (cb: () => void) =>
    globalThis.window.requestAnimationFrame(cb);
globalThis.document = globalThis.window.document;
globalThis.location = globalThis.window.location;
globalThis.history = globalThis.window.history;
globalThis.addEventListener = (event: string, cb: (e: any) => void) =>
    globalThis.window.addEventListener(event, cb);
globalThis.MithrilTick = () => {
    globalThis.window.tick();
};
