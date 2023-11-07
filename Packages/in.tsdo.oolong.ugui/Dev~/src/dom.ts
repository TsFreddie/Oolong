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
    if (url.startsWith('/')) {
      this.request.url = HttpRequest.baseURL + url;
    } else {
      this.request.url = url;
    }
  }

  public send(body?: string | Uint8Array) {
    if (body != null) {
      if (typeof body != 'string') {
        CS.TSF.Oolong.UGUI.UnityWebRequestExtension.SetBody(this.request, body);
      } else {
        var data = new TextEncoder().encode(body);
        CS.TSF.Oolong.UGUI.UnityWebRequestExtension.SetBody(this.request, data);
      }
    }

    if (this.withCredentials) {
      // TODO: add authentication callback
    }
    CS.TSF.Oolong.UGUI.UnityWebRequestExtension.SendWithCallback(this.request, () => {
      if (this.onreadystatechange) {
        this.onreadystatechange({ target: this });
      }
    });
  }

  public get response() {
    if (this.responseType == 'json') {
      return JSON.parse(this.request.downloadHandler.text);
    } else if (this.responseType == 'arraybuffer') {
      return CS.TSF.Oolong.UGUI.UnityWebRequestExtension.GetArrayBuffer(
        this.request.downloadHandler
      );
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

interface HistoryEntry {
  state: string;
  title: string;
  url?: string;
}

export type UnityChild = UnityElement | UnityTextNode;
export type UnityChildren = UnityChild[];

const RenderText = (children: UnityChildren) => {
  const text = (children.filter(n => n instanceof UnityTextNode) as UnityTextNode[])
    .map(n => n.nodeText)
    .join('');
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
        return { nodes, elements };
      }
      if (child instanceof UnityElement) {
        elements++;
      }
    }
    return null;
  }

  private setText(text: string) {
    if (this.children.length > 0) {
      console.warn('Element is not empty when setText is called');
      return;
    }
    this.children.splice(0, this.children.length);

    if (text.length === 0) {
      return;
    }

    var textNode = new UnityTextNode(text);
    textNode.parent = this;
    this.children.push(textNode);
    this.setAttribute('#', text);
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
    this.setAttribute('#', RenderText(this.children));
  }

  public appendChild(child: UnityFragment | UnityElement | UnityTextNode): void {
    if (child.parent != null && !(child.parent instanceof UnityFragment)) {
      console.warn('Unexpected child.parent when appendChild');
    }

    if (child instanceof UnityFragment) {
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
      console.warn('Can not find child when removeChild');
      return;
    }

    // Remove node
    this.children.splice(index, 1);

    // Remove element
    if (child instanceof UnityElement) {
      this.removeChildInternal(child);
    }
    if (child instanceof UnityTextNode) {
      this.updateText();
    }
  }

  public insertBefore(child: UnityChild, ref: UnityChild) {
    if (child.parent != null) {
      console.warn('Unexpected child.parent when insertBefore');
    }

    const index = this.elementIndex(ref);
    if (index == null) {
      console.warn('Can not find the element when insertBefore');
      return;
    }

    child.parent = this;
    this.children.splice(index.nodes, 0, child);

    if (child instanceof UnityElement) {
      this.insertChildInternal(child, index.elements);
    }
    if (child instanceof UnityTextNode) {
      this.updateText();
    }
  }

  public toJSON(): any {
    return {
      type: this instanceof UnityFragment ? 'fragment' : 'element',
      node: LabelOf(this),
      parent: LabelOf(this.parent),
      children: this.children.map(child => child.toJSON()),
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
    this.tag = '';
  }

  public setAttribute() {}

  public removeAttribute() {}

  public attachChildInternal() {}

  public removeChildInternal() {}

  public insertChildInternal() {}
}

type UnityEvent = {
  type: string;
  target: UnityElement;
  eventData: CS.UnityEngine.EventSystems.BaseEventData;
};
type EventHandler = ((ev: UnityEvent) => void) | { handleEvent: (ev: UnityEvent) => void };

const runEvent = (
  target: UnityElement,
  event: string,
  eventData: CS.UnityEngine.EventSystems.BaseEventData,
  cb: EventHandler
) => {
  if (typeof cb === 'function') {
    cb({ type: event, target, eventData });
  } else if (typeof cb === 'object') {
    cb.handleEvent({ type: event, target, eventData });
  }
};

export class UnityElement<
  T extends CS.TSF.Oolong.UGUI.OolongElement = CS.TSF.Oolong.UGUI.OolongElement
> extends UnityNode {
  public element: T;
  public mountId: number;
  private events: { [key: string]: EventHandler };

  constructor(element: CS.TSF.Oolong.UGUI.OolongElement, mount?: boolean);
  constructor(tagName: string, mount?: boolean);
  constructor(tagNameOrElement: string | CS.TSF.Oolong.UGUI.OolongElement, mount?: boolean) {
    super();
    if (typeof tagNameOrElement == 'string') {
      this.element = CS.TSF.Oolong.UGUI.DocumentUtils.CreateElement(tagNameOrElement) as T;
    } else {
      this.element = tagNameOrElement as T;
    }
    this.tag = this.element.TagName;
    this.events = {};
    if (mount) {
      this.mountId = this.element.GetInstanceID();
    }
  }

  public contains(node: UnityElement) {
    // Skip mithril's lock check
    return false;
  }

  public attachChildInternal(child: UnityElement) {
    CS.TSF.Oolong.UGUI.DocumentUtils.AttachElement(this.element, child.element);
    child.mountId = this.mountId;
  }

  public removeChildInternal(child: UnityElement) {
    CS.TSF.Oolong.UGUI.DocumentUtils.RemoveElement(this.element, child.element);
    child.mountId = undefined;
  }

  public insertChildInternal(child: UnityElement, pos: number) {
    CS.TSF.Oolong.UGUI.DocumentUtils.InsertElement(this.element, child.element, pos);
    child.mountId = this.mountId;
  }

  public setAttribute(name: string, value: any) {
    if (name == 'id') this.id = value.toString();
    this.element.SetElementAttribute(name, value.toString());
  }

  public removeAttribute(name: string) {
    if (name == 'id') this.id = undefined;
    this.element.SetElementAttribute(name, null);
  }

  public addEventListener(event: string, callback: EventHandler) {
    this.events[event] = callback;
    this.element.AddListener(event, eventData => runEvent(this, event, eventData, callback));
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
      type: 'text',
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
  private _hash: string = '#';
  private _href: string = '/';

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
    this.historyStack.push({ state, title, url });
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
      this.historyStack.push({ state, title, url });
      if (url) window.location.hash = url;
    }
    window.location.hash = url;
    window.location.href = url;
  }
}

// Stubs, just to make mithril happy
export class UnimplementedFormData {}

export class UnimlementedURLSearchParams {}

export class UnityWindow {
  private animationFrameQueue: (() => void)[] = [];
  private animationFrameProcessor: (() => void)[] = [];

  public location: UnityLocation = new UnityLocation();
  public history: UnityHistory = new UnityHistory();
  public document: UnityDocument = new UnityDocument();

  public XMLHttpRequest = HttpRequest;
  public FormData = UnimplementedFormData;
  public URLSearchParams = UnimlementedURLSearchParams;

  public setTimeout = globalThis.setTimeout;

  public requestAnimationFrame(cb: () => void) {
    if (typeof cb !== 'function') return;
    this.animationFrameQueue.push(cb);
  }

  // TODO: handle popstate
  public addEventListener(event: string, cb: (e: any) => void) {}

  public removeEventListener(event: string, cb: (e: any) => void) {}

  public tick() {
    const tmp = this.animationFrameQueue;
    this.animationFrameQueue = this.animationFrameProcessor;
    this.animationFrameProcessor = tmp;
    for (const cb of this.animationFrameProcessor) {
      cb();
    }
    this.animationFrameProcessor.splice(0, this.animationFrameProcessor.length);
  }
}

export const window = new UnityWindow();
export const requestAnimationFrame = (cb: () => void) => window.requestAnimationFrame(cb);

export const document = window.document;
export const location = window.location;
export const history = window.history;
export const addEventListener = (event: string, cb: (e: any) => void) =>
  window.addEventListener(event, cb);
export const MithrilTick = () => {
  window.tick();
};
