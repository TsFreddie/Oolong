var E=Object.defineProperty;var C=(i,t)=>{for(var e in t)E(i,e,{get:t[e],enumerable:!0})};var y={};C(y,{HttpRequest:()=>h,MithrilTick:()=>A,UnimlementedURLSearchParams:()=>m,UnimplementedFormData:()=>b,UnityDocument:()=>c,UnityElement:()=>o,UnityFragment:()=>l,UnityHistory:()=>d,UnityLocation:()=>p,UnityNode:()=>u,UnityTextNode:()=>s,UnityWindow:()=>g,addEventListener:()=>F,document:()=>I,history:()=>w,location:()=>q,requestAnimationFrame:()=>T,window:()=>r});var h=class i{static{this.baseURL=null}constructor(){this.request=new CS.UnityEngine.Networking.UnityWebRequest}abort(){this.request.Abort()}setRequestHeader(t,e){this.request.SetRequestHeader(t,e)}open(t,e,n){this.request.method=t,e.startsWith("/")?this.request.url=i.baseURL+e:this.request.url=e}send(t){if(t!=null)if(typeof t!="string")CS.TSF.Oolong.UGUI.UnityWebRequestExtension.SetBody(this.request,t);else{var e=new TextEncoder().encode(t);CS.TSF.Oolong.UGUI.UnityWebRequestExtension.SetBody(this.request,e)}this.withCredentials,CS.TSF.Oolong.UGUI.UnityWebRequestExtension.SendWithCallback(this.request,()=>{this.onreadystatechange&&this.onreadystatechange({target:this})})}get response(){return this.responseType=="json"?JSON.parse(this.request.downloadHandler.text):this.responseType=="arraybuffer"?CS.TSF.Oolong.UGUI.UnityWebRequestExtension.GetArrayBuffer(this.request.downloadHandler):this.request.downloadHandler.text}get readyState(){return this.request.isDone?4:3}get status(){return this.request.responseCode}get statusText(){return this.request.error}set timeout(t){this.request.timeout=Math.ceil(t/1e3)}},f=i=>i.filter(e=>e instanceof s).map(e=>e.nodeText).join(""),v=i=>{if(i!=null)return i instanceof s?`[${i.nodeText}]`:i.id!=null?`<${i.tag} id=${i.id}/>`:`<${i.tag}/>`},u=class{constructor(){this.children=[]}get childNodes(){return this.children}elementIndex(t){let e=0;for(let n=0;n<this.children.length;n++){let a=this.children[n];if(a===t)return{nodes:n,elements:e};a instanceof o&&e++}return null}setText(t){if(this.children.length>0){console.warn("Element is not empty when setText is called");return}if(this.children.splice(0,this.children.length),t.length!==0){var e=new s(t);e.parent=this,this.children.push(e),this.setAttribute("#",t)}}get parentElement(){return this.parent}get parentNode(){return this.parent}get innerHTML(){return f(this.children)}set innerHTML(t){this.setText(t)}get textContent(){return f(this.children)}set textContent(t){this.setText(t)}get firstChild(){return this.children[0]}get lastChild(){return this.children[this.children.length-1]}updateText(){this.setAttribute("#",f(this.children))}appendChild(t){if(t.parent!=null&&!(t.parent instanceof l)&&console.warn("Unexpected child.parent when appendChild"),t instanceof l){for(let e=0;e<t.children.length;e++)this.appendChild(t.children[e]);t.children.splice(0,t.children.length);return}t.parent=this,this.children.push(t),t instanceof o&&this.attachChildInternal(t),t instanceof s&&this.updateText()}removeChild(t){t.parent=null;let e=this.children.indexOf(t);if(e<0){console.warn("Can not find child when removeChild");return}this.children.splice(e,1),t instanceof o&&this.removeChildInternal(t),t instanceof s&&this.updateText()}insertBefore(t,e){t.parent!=null&&console.warn("Unexpected child.parent when insertBefore");let n=this.elementIndex(e);if(n==null){console.warn("Can not find the element when insertBefore");return}t.parent=this,this.children.splice(n.nodes,0,t),t instanceof o&&this.insertChildInternal(t,n.elements),t instanceof s&&this.updateText()}toJSON(){return{type:this instanceof l?"fragment":"element",node:v(this),parent:v(this.parent),children:this.children.map(t=>t.toJSON())}}},l=class extends u{constructor(){super(),this.tag=""}setAttribute(){}removeAttribute(){}attachChildInternal(){}removeChildInternal(){}insertChildInternal(){}},S=(i,t,e,n)=>{typeof n=="function"?n({type:t,target:i,eventData:e}):typeof n=="object"&&n.handleEvent({type:t,target:i,eventData:e})},o=class extends u{constructor(e,n){super();this.attrs=new Proxy(this,{get(e,n){return e.getAttribute(n.toString())},set(e,n,a){return e.setAttribute(n.toString(),a)}});typeof e=="string"?this.element=CS.TSF.Oolong.UGUI.DocumentUtils.CreateElement(e):this.element=e,this.tag=this.element.TagName,this.events={},n&&(this.mountId=this.element.GetInstanceID())}contains(e){return!1}attachChildInternal(e){CS.TSF.Oolong.UGUI.DocumentUtils.AttachElement(this.element,e.element),e.mountId=this.mountId}removeChildInternal(e){CS.TSF.Oolong.UGUI.DocumentUtils.RemoveElement(this.element,e.element),e.mountId=void 0}insertChildInternal(e,n){CS.TSF.Oolong.UGUI.DocumentUtils.InsertElement(this.element,e.element,n),e.mountId=this.mountId}setAttribute(e,n){return e=="id"&&(this.id=n?.toString()),this.element.SetElementAttribute(e,n==null?null:n.toString())}getAttribute(e){return e=="id"?this.id:this.element.GetElementAttribute(e)}removeAttribute(e){e=="id"&&(this.id=void 0),this.element.SetElementAttribute(e,null)}addEventListener(e,n){this.events[e]=n,this.element.AddListener(e,a=>S(this,e,a,n))}removeEventListener(e,n){delete this.events[e],this.element.RemoveListener(e)}},s=class{constructor(t){this.nodeText=t}get parentElement(){return this.parent}get parentNode(){return this.parent}set nodeValue(t){this.nodeText=t,this.parent?.updateText?.()}toJSON(){return{type:"text",text:this.nodeText}}},c=class{createDocumentFragment(){return new l}createElement(t){return new o(t)}createTextNode(t){return new s(t)}},p=class{constructor(){this._hash="#";this._href="/"}get href(){return this._href}get hash(){return this._hash}set href(t){this._href=t}set hash(t){this._hash=t}},d=class{constructor(){this.historyStack=[]}pushState(t,e,n){n=n??r.location.href,this.historyStack.push({state:t,title:e,url:n}),r.location.hash=n,r.location.href=n}replaceState(t,e,n){n=n??r.location.href,this.historyStack.length>0?(this.historyStack[this.historyStack.length-1]={state:t,title:e,url:n},n&&(r.location.hash=n)):(this.historyStack.push({state:t,title:e,url:n}),n&&(r.location.hash=n)),r.location.hash=n,r.location.href=n}},b=class{},m=class{},g=class{constructor(){this.animationFrameQueue=[];this.animationFrameProcessor=[];this.location=new p;this.history=new d;this.document=new c;this.XMLHttpRequest=h;this.FormData=b;this.URLSearchParams=m;this.setTimeout=globalThis.setTimeout}requestAnimationFrame(t){typeof t=="function"&&this.animationFrameQueue.push(t)}addEventListener(t,e){}removeEventListener(t,e){}tick(){let t=this.animationFrameQueue;this.animationFrameQueue=this.animationFrameProcessor,this.animationFrameProcessor=t;for(let e of this.animationFrameProcessor)e();this.animationFrameProcessor.splice(0,this.animationFrameProcessor.length)}},r=new g,T=i=>r.requestAnimationFrame(i),I=r.document,q=r.location,w=r.history,F=(i,t)=>r.addEventListener(i,t),A=()=>{r.tick()};var x={...y};for(U in x)globalThis[U]=x[U];var U;
