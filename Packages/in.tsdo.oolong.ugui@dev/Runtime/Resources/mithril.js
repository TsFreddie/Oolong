var fr=Object.create;var je=Object.defineProperty;var ur=Object.getOwnPropertyDescriptor;var lr=Object.getOwnPropertyNames;var cr=Object.getPrototypeOf,sr=Object.prototype.hasOwnProperty;var z=(n,i)=>()=>(i||n((i={exports:{}}).exports,i),i.exports),nt=(n,i)=>{for(var u in i)je(n,u,{get:i[u],enumerable:!0})},or=(n,i,u,l)=>{if(i&&typeof i=="object"||typeof i=="function")for(let p of lr(i))!sr.call(n,p)&&p!==u&&je(n,p,{get:()=>i[p],enumerable:!(l=ur(i,p))||l.enumerable});return n};var ze=(n,i,u)=>(u=n!=null?fr(cr(n)):{},or(i||!n||!n.__esModule?je(u,"default",{value:n,enumerable:!0}):u,n));var Y=z((Kr,it)=>{"use strict";function $(n,i,u,l,p,m){return{tag:n,key:i,attrs:u,children:l,text:p,dom:m,domSize:void 0,state:void 0,events:void 0,instance:void 0}}$.normalize=function(n){return Array.isArray(n)?$("[",void 0,void 0,$.normalizeChildren(n),void 0,void 0):n==null||typeof n=="boolean"?null:typeof n=="object"?n:$("#",void 0,void 0,String(n),void 0,void 0)};$.normalizeChildren=function(n){var i=[];if(n.length){for(var u=n[0]!=null&&n[0].key!=null,l=1;l<n.length;l++)if((n[l]!=null&&n[l].key!=null)!==u)throw new TypeError(u&&(n[l]!=null||typeof n[l]=="boolean")?"In fragments, vnodes must either all have keys or none have keys. You may wish to consider using an explicit keyed empty fragment, m.fragment({key: ...}), instead of a hole.":"In fragments, vnodes must either all have keys or none have keys.");for(var l=0;l<n.length;l++)i[l]=$.normalize(n[l])}return i};it.exports=$});var Ie=z((Qr,at)=>{"use strict";var mr=Y();at.exports=function(){var n=arguments[this],i=this+1,u;if(n==null?n={}:(typeof n!="object"||n.tag!=null||Array.isArray(n))&&(n={},i=this),arguments.length===i+1)u=arguments[i],Array.isArray(u)||(u=[u]);else for(u=[];i<arguments.length;)u.push(arguments[i++]);return mr("",n.key,n,u)}});var ae=z((Jr,ft)=>{"use strict";ft.exports={}.hasOwnProperty});var Me=z((Br,ct)=>{"use strict";var hr=Y(),pr=Ie(),te=ae(),yr=/(?:(^|#|\.)([^#\.\[\]]+))|(\[(.+?)(?:\s*=\s*("|'|)((?:\\["'\]]|.)*?)\5)?\])/g,lt={};function ut(n){for(var i in n)if(te.call(n,i))return!1;return!0}function gr(n){for(var i,u="div",l=[],p={};i=yr.exec(n);){var m=i[1],c=i[2];if(m===""&&c!=="")u=c;else if(m==="#")p.id=c;else if(m===".")l.push(c);else if(i[3][0]==="["){var h=i[6];h&&(h=h.replace(/\\(["'])/g,"$1").replace(/\\\\/g,"\\")),i[4]==="class"?l.push(h):p[i[4]]=h===""?h:h||!0}}return l.length>0&&(p.className=l.join(" ")),lt[n]={tag:u,attrs:p}}function wr(n,i){var u=i.attrs,l=te.call(u,"class"),p=l?u.class:u.className;if(i.tag=n.tag,i.attrs={},!ut(n.attrs)&&!ut(u)){var m={};for(var c in u)te.call(u,c)&&(m[c]=u[c]);u=m}for(var c in n.attrs)te.call(n.attrs,c)&&c!=="className"&&!te.call(u,c)&&(u[c]=n.attrs[c]);(p!=null||n.attrs.className!=null)&&(u.className=p!=null?n.attrs.className!=null?String(n.attrs.className)+" "+String(p):p:n.attrs.className!=null?n.attrs.className:null),l&&(u.class=null);for(var c in u)if(te.call(u,c)&&c!=="key"){i.attrs=u;break}return i}function br(n){if(n==null||typeof n!="string"&&typeof n!="function"&&typeof n.view!="function")throw Error("The selector must be either a string or a component.");var i=pr.apply(1,arguments);return typeof n=="string"&&(i.children=hr.normalizeChildren(i.children),n!=="[")?wr(lt[n]||gr(n),i):(i.tag=n,i)}ct.exports=br});var ot=z((Gr,st)=>{"use strict";var xr=Y();st.exports=function(n){return n==null&&(n=""),xr("<",void 0,void 0,n,void 0,void 0)}});var ht=z((Xr,mt)=>{"use strict";var qr=Y(),dr=Ie();mt.exports=function(){var n=dr.apply(0,arguments);return n.tag="[",n.children=qr.normalizeChildren(n.children),n}});var yt=z((Yr,pt)=>{"use strict";var Le=Me();Le.trust=ot();Le.fragment=ht();pt.exports=Le});var Ue=z((Zr,gt)=>{"use strict";var F=function(n){if(!(this instanceof F))throw new Error("Promise must be called with 'new'.");if(typeof n!="function")throw new TypeError("executor must be a function.");var i=this,u=[],l=[],p=s(u,!0),m=s(l,!1),c=i._instance={resolvers:u,rejectors:l},h=typeof setImmediate=="function"?setImmediate:setTimeout;function s(q,b){return function d(A){var N;try{if(b&&A!=null&&(typeof A=="object"||typeof A=="function")&&typeof(N=A.then)=="function"){if(A===i)throw new TypeError("Promise can't be resolved with itself.");y(N.bind(A))}else h(function(){!b&&q.length===0&&console.error("Possible unhandled promise rejection:",A);for(var x=0;x<q.length;x++)q[x](A);u.length=0,l.length=0,c.state=b,c.retry=function(){d(A)}})}catch(x){m(x)}}}function y(q){var b=0;function d(N){return function(x){b++>0||N(x)}}var A=d(m);try{q(d(p),A)}catch(N){A(N)}}y(n)};F.prototype.then=function(n,i){var u=this,l=u._instance;function p(s,y,q,b){y.push(function(d){if(typeof s!="function")q(d);else try{m(s(d))}catch(A){c&&c(A)}}),typeof l.retry=="function"&&b===l.state&&l.retry()}var m,c,h=new F(function(s,y){m=s,c=y});return p(n,l.resolvers,m,!0),p(i,l.rejectors,c,!1),h};F.prototype.catch=function(n){return this.then(null,n)};F.prototype.finally=function(n){return this.then(function(i){return F.resolve(n()).then(function(){return i})},function(i){return F.resolve(n()).then(function(){return F.reject(i)})})};F.resolve=function(n){return n instanceof F?n:new F(function(i){i(n)})};F.reject=function(n){return new F(function(i,u){u(n)})};F.all=function(n){return new F(function(i,u){var l=n.length,p=0,m=[];if(n.length===0)i([]);else for(var c=0;c<n.length;c++)(function(h){function s(y){p++,m[h]=y,p===l&&i(m)}n[h]!=null&&(typeof n[h]=="object"||typeof n[h]=="function")&&typeof n[h].then=="function"?n[h].then(s,u):s(n[h])})(c)})};F.race=function(n){return new F(function(i,u){for(var l=0;l<n.length;l++)n[l].then(i,u)})};gt.exports=F});var De=z((Wr,me)=>{"use strict";var fe=Ue();typeof window<"u"?(typeof window.Promise>"u"?window.Promise=fe:window.Promise.prototype.finally||(window.Promise.prototype.finally=fe.prototype.finally),me.exports=window.Promise):typeof global<"u"?(typeof global.Promise>"u"?global.Promise=fe:global.Promise.prototype.finally||(global.Promise.prototype.finally=fe.prototype.finally),me.exports=global.Promise):me.exports=fe});var bt=z(($r,wt)=>{"use strict";var ve=Y();wt.exports=function(n){var i=n&&n.document,u,l={svg:"http://www.w3.org/2000/svg",math:"http://www.w3.org/1998/Math/MathML"};function p(t){return t.attrs&&t.attrs.xmlns||l[t.tag]}function m(t,e){if(t.state!==e)throw new Error("'vnode.state' must not be modified.")}function c(t){var e=t.state;try{return this.apply(e,arguments)}finally{m(t,e)}}function h(){try{return i.activeElement}catch{return null}}function s(t,e,r,a,f,o,w){for(var T=r;T<a;T++){var g=e[T];g!=null&&y(t,g,f,w,o)}}function y(t,e,r,a,f){var o=e.tag;if(typeof o=="string")switch(e.state={},e.attrs!=null&&Ce(e.attrs,e,r),o){case"#":q(t,e,f);break;case"<":d(t,e,a,f);break;case"[":A(t,e,r,a,f);break;default:N(t,e,r,a,f)}else j(t,e,r,a,f)}function q(t,e,r){e.dom=i.createTextNode(e.children),X(t,e.dom,r)}var b={caption:"table",thead:"table",tbody:"table",tfoot:"table",tr:"tbody",th:"tr",td:"tr",colgroup:"table",col:"colgroup"};function d(t,e,r,a){var f=e.children.match(/^\s*?<(\w+)/im)||[],o=i.createElement(b[f[1]]||"div");r==="http://www.w3.org/2000/svg"?(o.innerHTML='<svg xmlns="http://www.w3.org/2000/svg">'+e.children+"</svg>",o=o.firstChild):o.innerHTML=e.children,e.dom=o.firstChild,e.domSize=o.childNodes.length,e.instance=[];for(var w=i.createDocumentFragment(),T;T=o.firstChild;)e.instance.push(T),w.appendChild(T);X(t,w,a)}function A(t,e,r,a,f){var o=i.createDocumentFragment();if(e.children!=null){var w=e.children;s(o,w,0,w.length,r,null,a)}e.dom=o.firstChild,e.domSize=o.childNodes.length,X(t,o,f)}function N(t,e,r,a,f){var o=e.tag,w=e.attrs,T=w&&w.is;a=p(e)||a;var g=a?T?i.createElementNS(a,o,{is:T}):i.createElementNS(a,o):T?i.createElement(o,{is:T}):i.createElement(o);if(e.dom=g,w!=null&&Wt(e,w,a),X(t,g,f),!Ze(e)&&e.children!=null){var R=e.children;s(g,R,0,R.length,r,null,a),e.tag==="select"&&w!=null&&kt(e,w)}}function x(t,e){var r;if(typeof t.tag.view=="function"){if(t.state=Object.create(t.tag),r=t.state.view,r.$$reentrantLock$$!=null)return;r.$$reentrantLock$$=!0}else{if(t.state=void 0,r=t.tag,r.$$reentrantLock$$!=null)return;r.$$reentrantLock$$=!0,t.state=t.tag.prototype!=null&&typeof t.tag.prototype.view=="function"?new t.tag(t):t.tag(t)}if(Ce(t.state,t,e),t.attrs!=null&&Ce(t.attrs,t,e),t.instance=ve.normalize(c.call(t.state.view,t)),t.instance===t)throw Error("A view cannot return the vnode it received as argument");r.$$reentrantLock$$=null}function j(t,e,r,a,f){x(e,r),e.instance!=null?(y(t,e.instance,r,a,f),e.dom=e.instance.dom,e.domSize=e.dom!=null?e.instance.domSize:0):e.domSize=0}function v(t,e,r,a,f,o){if(!(e===r||e==null&&r==null))if(e==null||e.length===0)s(t,r,0,r.length,a,f,o);else if(r==null||r.length===0)re(t,e,0,e.length);else{var w=e[0]!=null&&e[0].key!=null,T=r[0]!=null&&r[0].key!=null,g=0,R=0;if(!w)for(;R<e.length&&e[R]==null;)R++;if(!T)for(;g<r.length&&r[g]==null;)g++;if(w!==T)re(t,e,R,e.length),s(t,r,g,r.length,a,f,o);else if(T){for(var Q=e.length-1,V=r.length-1,oe,J,D,K,I,Te;Q>=R&&V>=g&&(K=e[Q],I=r[V],K.key===I.key);)K!==I&&B(t,K,I,a,f,o),I.dom!=null&&(f=I.dom),Q--,V--;for(;Q>=R&&V>=g&&(J=e[R],D=r[g],J.key===D.key);)R++,g++,J!==D&&B(t,J,D,a,G(e,R,f),o);for(;Q>=R&&V>=g&&!(g===V||J.key!==I.key||K.key!==D.key);)Te=G(e,R,f),k(t,K,Te),K!==D&&B(t,K,D,a,Te,o),++g<=--V&&k(t,J,f),J!==I&&B(t,J,I,a,f,o),I.dom!=null&&(f=I.dom),R++,Q--,K=e[Q],I=r[V],J=e[R],D=r[g];for(;Q>=R&&V>=g&&K.key===I.key;)K!==I&&B(t,K,I,a,f,o),I.dom!=null&&(f=I.dom),Q--,V--,K=e[Q],I=r[V];if(g>V)re(t,e,R,Q+1);else if(R>Q)s(t,r,g,V+1,a,f,o);else{var ar=f,rt=V-g+1,ie=new Array(rt),Ne=0,L=0,Oe=2147483647,Re=0,oe,_e;for(L=0;L<rt;L++)ie[L]=-1;for(L=V;L>=g;L--){oe==null&&(oe=O(e,R,Q+1)),I=r[L];var ee=oe[I.key];ee!=null&&(Oe=ee<Oe?ee:-1,ie[L-g]=ee,K=e[ee],e[ee]=null,K!==I&&B(t,K,I,a,f,o),I.dom!=null&&(f=I.dom),Re++)}if(f=ar,Re!==Q-R+1&&re(t,e,R,Q+1),Re===0)s(t,r,g,V+1,a,f,o);else if(Oe===-1)for(_e=S(ie),Ne=_e.length-1,L=V;L>=g;L--)D=r[L],ie[L-g]===-1?y(t,D,a,o,f):_e[Ne]===L-g?Ne--:k(t,D,f),D.dom!=null&&(f=r[L].dom);else for(L=V;L>=g;L--)D=r[L],ie[L-g]===-1&&y(t,D,a,o,f),D.dom!=null&&(f=r[L].dom)}}else{var Pe=e.length<r.length?e.length:r.length;for(g=g<R?g:R;g<Pe;g++)J=e[g],D=r[g],!(J===D||J==null&&D==null)&&(J==null?y(t,D,a,o,G(e,g+1,f)):D==null?ce(t,J):B(t,J,D,a,G(e,g+1,f),o));e.length>Pe&&re(t,e,g,e.length),r.length>Pe&&s(t,r,g,r.length,a,f,o)}}}function B(t,e,r,a,f,o){var w=e.tag,T=r.tag;if(w===T){if(r.state=e.state,r.events=e.events,ir(r,e))return;if(typeof w=="string")switch(r.attrs!=null&&Ee(r.attrs,r,a),w){case"#":U(e,r);break;case"<":E(t,e,r,o,f);break;case"[":_(t,e,r,a,f,o);break;default:C(e,r,a,o)}else M(t,e,r,a,f,o)}else ce(t,e),y(t,r,a,o,f)}function U(t,e){t.children.toString()!==e.children.toString()&&(t.dom.nodeValue=e.children),e.dom=t.dom}function E(t,e,r,a,f){e.children!==r.children?(We(t,e),d(t,r,a,f)):(r.dom=e.dom,r.domSize=e.domSize,r.instance=e.instance)}function _(t,e,r,a,f,o){v(t,e.children,r.children,a,f,o);var w=0,T=r.children;if(r.dom=null,T!=null){for(var g=0;g<T.length;g++){var R=T[g];R!=null&&R.dom!=null&&(r.dom==null&&(r.dom=R.dom),w+=R.domSize||1)}w!==1&&(r.domSize=w)}}function C(t,e,r,a){var f=e.dom=t.dom;a=p(e)||a,e.tag==="textarea"&&e.attrs==null&&(e.attrs={}),er(e,t.attrs,e.attrs,a),Ze(e)||v(f,t.children,e.children,r,null,a)}function M(t,e,r,a,f,o){if(r.instance=ve.normalize(c.call(r.state.view,r)),r.instance===r)throw Error("A view cannot return the vnode it received as argument");Ee(r.state,r,a),r.attrs!=null&&Ee(r.attrs,r,a),r.instance!=null?(e.instance==null?y(t,r.instance,a,o,f):B(t,e.instance,r.instance,a,f,o),r.dom=r.instance.dom,r.domSize=r.instance.domSize):e.instance!=null?(ce(t,e.instance),r.dom=void 0,r.domSize=0):(r.dom=e.dom,r.domSize=e.domSize)}function O(t,e,r){for(var a=Object.create(null);e<r;e++){var f=t[e];if(f!=null){var o=f.key;o!=null&&(a[o]=e)}}return a}var P=[];function S(t){for(var e=[0],r=0,a=0,f=0,o=P.length=t.length,f=0;f<o;f++)P[f]=t[f];for(var f=0;f<o;++f)if(t[f]!==-1){var w=e[e.length-1];if(t[w]<t[f]){P[f]=w,e.push(f);continue}for(r=0,a=e.length-1;r<a;){var T=(r>>>1)+(a>>>1)+(r&a&1);t[e[T]]<t[f]?r=T+1:a=T}t[f]<t[e[r]]&&(r>0&&(P[f]=e[r-1]),e[r]=f)}for(r=e.length,a=e[r-1];r-- >0;)e[r]=a,a=P[a];return P.length=0,e}function G(t,e,r){for(;e<t.length;e++)if(t[e]!=null&&t[e].dom!=null)return t[e].dom;return r}function k(t,e,r){var a=i.createDocumentFragment();W(t,a,e),X(t,a,r)}function W(t,e,r){for(;r.dom!=null&&r.dom.parentNode===t;){if(typeof r.tag!="string"){if(r=r.instance,r!=null)continue}else if(r.tag==="<")for(var a=0;a<r.instance.length;a++)e.appendChild(r.instance[a]);else if(r.tag!=="[")e.appendChild(r.dom);else if(r.children.length===1){if(r=r.children[0],r!=null)continue}else for(var a=0;a<r.children.length;a++){var f=r.children[a];f!=null&&W(t,e,f)}break}}function X(t,e,r){r!=null?t.insertBefore(e,r):t.appendChild(e)}function Ze(t){if(t.attrs==null||t.attrs.contenteditable==null&&t.attrs.contentEditable==null)return!1;var e=t.children;if(e!=null&&e.length===1&&e[0].tag==="<"){var r=e[0].children;t.dom.innerHTML!==r&&(t.dom.innerHTML=r)}else if(e!=null&&e.length!==0)throw new Error("Child node of a contenteditable must be trusted.");return!0}function re(t,e,r,a){for(var f=r;f<a;f++){var o=e[f];o!=null&&ce(t,o)}}function ce(t,e){var r=0,a=e.state,f,o;if(typeof e.tag!="string"&&typeof e.state.onbeforeremove=="function"){var w=c.call(e.state.onbeforeremove,e);w!=null&&typeof w.then=="function"&&(r=1,f=w)}if(e.attrs&&typeof e.attrs.onbeforeremove=="function"){var w=c.call(e.attrs.onbeforeremove,e);w!=null&&typeof w.then=="function"&&(r|=2,o=w)}if(m(e,a),!r)se(e),xe(t,e);else{if(f!=null){var T=function(){r&1&&(r&=2,r||g())};f.then(T,T)}if(o!=null){var T=function(){r&2&&(r&=1,r||g())};o.then(T,T)}}function g(){m(e,a),se(e),xe(t,e)}}function We(t,e){for(var r=0;r<e.instance.length;r++)t.removeChild(e.instance[r])}function xe(t,e){for(;e.dom!=null&&e.dom.parentNode===t;){if(typeof e.tag!="string"){if(e=e.instance,e!=null)continue}else if(e.tag==="<")We(t,e);else{if(e.tag!=="["&&(t.removeChild(e.dom),!Array.isArray(e.children)))break;if(e.children.length===1){if(e=e.children[0],e!=null)continue}else for(var r=0;r<e.children.length;r++){var a=e.children[r];a!=null&&xe(t,a)}}break}}function se(t){if(typeof t.tag!="string"&&typeof t.state.onremove=="function"&&c.call(t.state.onremove,t),t.attrs&&typeof t.attrs.onremove=="function"&&c.call(t.attrs.onremove,t),typeof t.tag!="string")t.instance!=null&&se(t.instance);else{var e=t.children;if(Array.isArray(e))for(var r=0;r<e.length;r++){var a=e[r];a!=null&&se(a)}}}function Wt(t,e,r){t.tag==="input"&&e.type!=null&&t.dom.setAttribute("type",e.type);var a=e!=null&&t.tag==="input"&&e.type==="file";for(var f in e)qe(t,f,null,e[f],r,a)}function qe(t,e,r,a,f,o){if(!(e==="key"||e==="is"||a==null||$e(e)||r===a&&!tr(t,e)&&typeof a!="object"||e==="type"&&t.tag==="input")){if(e[0]==="o"&&e[1]==="n")return tt(t,e,a);if(e.slice(0,6)==="xlink:")t.dom.setAttributeNS("http://www.w3.org/1999/xlink",e.slice(6),a);else if(e==="style")et(t.dom,r,a);else if(ke(t,e,f)){if(e==="value"){if((t.tag==="input"||t.tag==="textarea")&&t.dom.value===""+a&&(o||t.dom===h())||t.tag==="select"&&r!==null&&t.dom.value===""+a||t.tag==="option"&&r!==null&&t.dom.value===""+a)return;if(o&&""+a!=""){console.error("`value` is read-only on file inputs!");return}}t.dom[e]=a}else typeof a=="boolean"?a?t.dom.setAttribute(e,""):t.dom.removeAttribute(e):t.dom.setAttribute(e==="className"?"class":e,a)}}function $t(t,e,r,a){if(!(e==="key"||e==="is"||r==null||$e(e)))if(e[0]==="o"&&e[1]==="n")tt(t,e,void 0);else if(e==="style")et(t.dom,r,null);else if(ke(t,e,a)&&e!=="className"&&e!=="title"&&!(e==="value"&&(t.tag==="option"||t.tag==="select"&&t.dom.selectedIndex===-1&&t.dom===h()))&&!(t.tag==="input"&&e==="type"))t.dom[e]=null;else{var f=e.indexOf(":");f!==-1&&(e=e.slice(f+1)),r!==!1&&t.dom.removeAttribute(e==="className"?"class":e)}}function kt(t,e){if("value"in e)if(e.value===null)t.dom.selectedIndex!==-1&&(t.dom.value=null);else{var r=""+e.value;(t.dom.value!==r||t.dom.selectedIndex===-1)&&(t.dom.value=r)}"selectedIndex"in e&&qe(t,"selectedIndex",null,e.selectedIndex,void 0)}function er(t,e,r,a){if(e&&e===r&&console.warn("Don't reuse attrs object, use new object for every redraw, this will throw in next major"),r!=null){t.tag==="input"&&r.type!=null&&t.dom.setAttribute("type",r.type);var f=t.tag==="input"&&r.type==="file";for(var o in r)qe(t,o,e&&e[o],r[o],a,f)}var w;if(e!=null)for(var o in e)(w=e[o])!=null&&(r==null||r[o]==null)&&$t(t,o,w,a)}function tr(t,e){return e==="value"||e==="checked"||e==="selectedIndex"||e==="selected"&&t.dom===h()||t.tag==="option"&&t.dom.parentNode===i.activeElement}function $e(t){return t==="oninit"||t==="oncreate"||t==="onupdate"||t==="onremove"||t==="onbeforeremove"||t==="onbeforeupdate"}function ke(t,e,r){return r===void 0&&(t.tag.indexOf("-")>-1||t.attrs!=null&&t.attrs.is||e!=="href"&&e!=="list"&&e!=="form"&&e!=="width"&&e!=="height")&&e in t.dom}var rr=/[A-Z]/g;function nr(t){return"-"+t.toLowerCase()}function de(t){return t[0]==="-"&&t[1]==="-"?t:t==="cssFloat"?"float":t.replace(rr,nr)}function et(t,e,r){if(e!==r)if(r==null)t.style.cssText="";else if(typeof r!="object")t.style.cssText=r;else if(e==null||typeof e!="object"){t.style.cssText="";for(var a in r){var f=r[a];f!=null&&t.style.setProperty(de(a),String(f))}}else{for(var a in r){var f=r[a];f!=null&&(f=String(f))!==String(e[a])&&t.style.setProperty(de(a),f)}for(var a in e)e[a]!=null&&r[a]==null&&t.style.removeProperty(de(a))}}function Ae(){this._=u}Ae.prototype=Object.create(null),Ae.prototype.handleEvent=function(t){var e=this["on"+t.type],r;typeof e=="function"?r=e.call(t.currentTarget,t):typeof e.handleEvent=="function"&&e.handleEvent(t),this._&&t.redraw!==!1&&(0,this._)(),r===!1&&(t.preventDefault(),t.stopPropagation())};function tt(t,e,r){if(t.events!=null){if(t.events._=u,t.events[e]===r)return;r!=null&&(typeof r=="function"||typeof r=="object")?(t.events[e]==null&&t.dom.addEventListener(e.slice(2),t.events,!1),t.events[e]=r):(t.events[e]!=null&&t.dom.removeEventListener(e.slice(2),t.events,!1),t.events[e]=void 0)}else r!=null&&(typeof r=="function"||typeof r=="object")&&(t.events=new Ae,t.dom.addEventListener(e.slice(2),t.events,!1),t.events[e]=r)}function Ce(t,e,r){typeof t.oninit=="function"&&c.call(t.oninit,e),typeof t.oncreate=="function"&&r.push(c.bind(t.oncreate,e))}function Ee(t,e,r){typeof t.onupdate=="function"&&r.push(c.bind(t.onupdate,e))}function ir(t,e){do{if(t.attrs!=null&&typeof t.attrs.onbeforeupdate=="function"){var r=c.call(t.attrs.onbeforeupdate,t,e);if(r!==void 0&&!r)break}if(typeof t.tag!="string"&&typeof t.state.onbeforeupdate=="function"){var r=c.call(t.state.onbeforeupdate,t,e);if(r!==void 0&&!r)break}return!1}while(!1);return t.dom=e.dom,t.domSize=e.domSize,t.instance=e.instance,t.attrs=e.attrs,t.children=e.children,t.text=e.text,!0}var ne;return function(t,e,r){if(!t)throw new TypeError("DOM element being rendered to does not exist.");if(ne!=null&&t.contains(ne))throw new TypeError("Node is currently being rendered to and thus is locked.");var a=u,f=ne,o=[],w=h(),T=t.namespaceURI;ne=t,u=typeof r=="function"?r:void 0;try{t.vnodes==null&&(t.textContent=""),e=ve.normalizeChildren(Array.isArray(e)?e:[e]),v(t,t.vnodes,e,o,null,T==="http://www.w3.org/1999/xhtml"?void 0:T),t.vnodes=e,w!=null&&h()!==w&&typeof w.focus=="function"&&w.focus();for(var g=0;g<o.length;g++)o[g]()}finally{u=a,ne=f}}}});var Ve=z((kr,xt)=>{"use strict";xt.exports=bt()(typeof window<"u"?window:null)});var At=z((en,dt)=>{"use strict";var qt=Y();dt.exports=function(n,i,u){var l=[],p=!1,m=-1;function c(){for(m=0;m<l.length;m+=2)try{n(l[m],qt(l[m+1]),h)}catch(y){u.error(y)}m=-1}function h(){p||(p=!0,i(function(){p=!1,c()}))}h.sync=c;function s(y,q){if(q!=null&&q.view==null&&typeof q!="function")throw new TypeError("m.mount expects a component, not a vnode.");var b=l.indexOf(y);b>=0&&(l.splice(b,2),b<=m&&(m-=2),n(y,[])),q!=null&&(l.push(y,q),n(y,qt(q),h))}return{mount:s,redraw:h}}});var he=z((tn,Ct)=>{"use strict";var Ar=Ve();Ct.exports=At()(Ar,typeof requestAnimationFrame<"u"?requestAnimationFrame:null,typeof console<"u"?console:null)});var Fe=z((rn,Et)=>{"use strict";Et.exports=function(n){if(Object.prototype.toString.call(n)!=="[object Object]")return"";var i=[];for(var u in n)l(u,n[u]);return i.join("&");function l(p,m){if(Array.isArray(m))for(var c=0;c<m.length;c++)l(p+"["+c+"]",m[c]);else if(Object.prototype.toString.call(m)==="[object Object]")for(var c in m)l(p+"["+c+"]",m[c]);else i.push(encodeURIComponent(p)+(m!=null&&m!==""?"="+encodeURIComponent(m):""))}}});var He=z((nn,Pt)=>{"use strict";var Cr=ae();Pt.exports=Object.assign||function(n,i){for(var u in i)Cr.call(i,u)&&(n[u]=i[u])}});var pe=z((an,Tt)=>{"use strict";var Er=Fe(),Pr=He();Tt.exports=function(n,i){if(/:([^\/\.-]+)(\.{3})?:/.test(n))throw new SyntaxError("Template parameter names must be separated by either a '/', '-', or '.'.");if(i==null)return n;var u=n.indexOf("?"),l=n.indexOf("#"),p=l<0?n.length:l,m=u<0?p:u,c=n.slice(0,m),h={};Pr(h,i);var s=c.replace(/:([^\/\.-]+)(\.{3})?/g,function(x,j,v){return delete h[j],i[j]==null?x:v?i[j]:encodeURIComponent(String(i[j]))}),y=s.indexOf("?"),q=s.indexOf("#"),b=q<0?s.length:q,d=y<0?b:y,A=s.slice(0,d);u>=0&&(A+=n.slice(u,p)),y>=0&&(A+=(u<0?"?":"&")+s.slice(y,b));var N=Er(h);return N&&(A+=(u<0&&y<0?"?":"&")+N),l>=0&&(A+=n.slice(l)),q>=0&&(A+=(l<0?"":"&")+s.slice(q)),A}});var Rt=z((fn,Ot)=>{"use strict";var Tr=pe(),Nt=ae();Ot.exports=function(n,i,u){var l=0;function p(h){return new i(h)}p.prototype=i.prototype,p.__proto__=i;function m(h){return function(s,y){typeof s!="string"?(y=s,s=s.url):y==null&&(y={});var q=new i(function(N,x){h(Tr(s,y.params),y,function(j){if(typeof y.type=="function")if(Array.isArray(j))for(var v=0;v<j.length;v++)j[v]=new y.type(j[v]);else j=new y.type(j);N(j)},x)});if(y.background===!0)return q;var b=0;function d(){--b===0&&typeof u=="function"&&u()}return A(q);function A(N){var x=N.then;return N.constructor=p,N.then=function(){b++;var j=x.apply(N,arguments);return j.then(d,function(v){if(d(),b===0)throw v}),A(j)},N}}}function c(h,s){for(var y in h.headers)if(Nt.call(h.headers,y)&&y.toLowerCase()===s)return!0;return!1}return{request:m(function(h,s,y,q){var b=s.method!=null?s.method.toUpperCase():"GET",d=s.body,A=(s.serialize==null||s.serialize===JSON.serialize)&&!(d instanceof n.FormData||d instanceof n.URLSearchParams),N=s.responseType||(typeof s.extract=="function"?"":"json"),x=new n.XMLHttpRequest,j=!1,v=!1,B=x,U,E=x.abort;x.abort=function(){j=!0,E.call(this)},x.open(b,h,s.async!==!1,typeof s.user=="string"?s.user:void 0,typeof s.password=="string"?s.password:void 0),A&&d!=null&&!c(s,"content-type")&&x.setRequestHeader("Content-Type","application/json; charset=utf-8"),typeof s.deserialize!="function"&&!c(s,"accept")&&x.setRequestHeader("Accept","application/json, text/*"),s.withCredentials&&(x.withCredentials=s.withCredentials),s.timeout&&(x.timeout=s.timeout),x.responseType=N;for(var _ in s.headers)Nt.call(s.headers,_)&&x.setRequestHeader(_,s.headers[_]);x.onreadystatechange=function(C){if(!j&&C.target.readyState===4)try{var M=C.target.status>=200&&C.target.status<300||C.target.status===304||/^file:\/\//i.test(h),O=C.target.response,P;if(N==="json"){if(!C.target.responseType&&typeof s.extract!="function")try{O=JSON.parse(C.target.responseText)}catch{O=null}}else(!N||N==="text")&&O==null&&(O=C.target.responseText);if(typeof s.extract=="function"?(O=s.extract(C.target,s),M=!0):typeof s.deserialize=="function"&&(O=s.deserialize(O)),M)y(O);else{var S=function(){try{P=C.target.responseText}catch{P=O}var G=new Error(P);G.code=C.target.status,G.response=O,q(G)};x.status===0?setTimeout(function(){v||S()}):S()}}catch(G){q(G)}},x.ontimeout=function(C){v=!0;var M=new Error("Request timed out");M.code=C.target.status,q(M)},typeof s.config=="function"&&(x=s.config(x,s,h)||x,x!==B&&(U=x.abort,x.abort=function(){j=!0,U.call(this)})),d==null?x.send():typeof s.serialize=="function"?x.send(s.serialize(d)):d instanceof n.FormData||d instanceof n.URLSearchParams?x.send(d):x.send(JSON.stringify(d))}),jsonp:m(function(h,s,y,q){var b=s.callbackName||"_mithril_"+Math.round(Math.random()*1e16)+"_"+l++,d=n.document.createElement("script");n[b]=function(A){delete n[b],d.parentNode.removeChild(d),y(A)},d.onerror=function(){delete n[b],d.parentNode.removeChild(d),q(new Error("JSONP request failed"))},d.src=h+(h.indexOf("?")<0?"?":"&")+encodeURIComponent(s.callbackKey||"callback")+"="+encodeURIComponent(b),n.document.documentElement.appendChild(d)})}}});var jt=z((un,_t)=>{"use strict";var Nr=De(),Or=he();_t.exports=Rt()(typeof window<"u"?window:null,Nr,Or.redraw)});var Se=z((ln,It)=>{"use strict";function zt(n){try{return decodeURIComponent(n)}catch{return n}}It.exports=function(n){if(n===""||n==null)return{};n.charAt(0)==="?"&&(n=n.slice(1));for(var i=n.split("&"),u={},l={},p=0;p<i.length;p++){var m=i[p].split("="),c=zt(m[0]),h=m.length===2?zt(m[1]):"";h==="true"?h=!0:h==="false"&&(h=!1);var s=c.split(/\]\[?|\[/),y=l;c.indexOf("[")>-1&&s.pop();for(var q=0;q<s.length;q++){var b=s[q],d=s[q+1],A=d==""||!isNaN(parseInt(d,10));if(b===""){var c=s.slice(0,q).join();u[c]==null&&(u[c]=Array.isArray(y)?y.length:0),b=u[c]++}else if(b==="__proto__")break;if(q===s.length-1)y[b]=h;else{var N=Object.getOwnPropertyDescriptor(y,b);N!=null&&(N=N.value),N==null&&(y[b]=N=A?[]:{}),y=N}}}return l}});var ye=z((cn,Mt)=>{"use strict";var Rr=Se();Mt.exports=function(n){var i=n.indexOf("?"),u=n.indexOf("#"),l=u<0?n.length:u,p=i<0?l:i,m=n.slice(0,p).replace(/\/{2,}/g,"/");return m?(m[0]!=="/"&&(m="/"+m),m.length>1&&m[m.length-1]==="/"&&(m=m.slice(0,-1))):m="/",{path:m,params:i<0?{}:Rr(n.slice(i+1,l))}}});var Ut=z((sn,Lt)=>{"use strict";var _r=ye();Lt.exports=function(n){var i=_r(n),u=Object.keys(i.params),l=[],p=new RegExp("^"+i.path.replace(/:([^\/.-]+)(\.{3}|\.(?!\.)|-)?|[\\^$*+.()|\[\]{}]/g,function(m,c,h){return c==null?"\\"+m:(l.push({k:c,r:h==="..."}),h==="..."?"(.*)":h==="."?"([^/]+)\\.":"([^/]+)"+(h||""))})+"$");return function(m){for(var c=0;c<u.length;c++)if(i.params[u[c]]!==m.params[u[c]])return!1;if(!l.length)return p.test(m.path);var h=p.exec(m.path);if(h==null)return!1;for(var c=0;c<l.length;c++)m.params[l[c].k]=l[c].r?h[c+1]:decodeURIComponent(h[c+1]);return!0}}});var Ke=z((on,Vt)=>{"use strict";var Dt=ae(),vt=new RegExp("^(?:key|oninit|oncreate|onbeforeupdate|onupdate|onbeforeremove|onremove)$");Vt.exports=function(n,i){var u={};if(i!=null)for(var l in n)Dt.call(n,l)&&!vt.test(l)&&i.indexOf(l)<0&&(u[l]=n[l]);else for(var l in n)Dt.call(n,l)&&!vt.test(l)&&(u[l]=n[l]);return u}});var Kt=z((mn,St)=>{"use strict";var jr=Y(),zr=Me(),Ir=De(),Ft=pe(),Ht=ye(),Mr=Ut(),Lr=He(),Ur=Ke(),Qe={};function Dr(n){try{return decodeURIComponent(n)}catch{return n}}St.exports=function(n,i){var u=n==null?null:typeof n.setImmediate=="function"?n.setImmediate:n.setTimeout,l=Ir.resolve(),p=!1,m=!1,c=0,h,s,y=Qe,q,b,d,A,N={onbeforeupdate:function(){return c=c?2:1,!(!c||Qe===y)},onremove:function(){n.removeEventListener("popstate",v,!1),n.removeEventListener("hashchange",j,!1)},view:function(){if(!(!c||Qe===y)){var E=[jr(q,b.key,b)];return y&&(E=y.render(E[0])),E}}},x=U.SKIP={};function j(){p=!1;var E=n.location.hash;U.prefix[0]!=="#"&&(E=n.location.search+E,U.prefix[0]!=="?"&&(E=n.location.pathname+E,E[0]!=="/"&&(E="/"+E)));var _=E.concat().replace(/(?:%[a-f89][a-f0-9])+/gim,Dr).slice(U.prefix.length),C=Ht(_);Lr(C.params,n.history.state);function M(P){console.error(P),B(s,null,{replace:!0})}O(0);function O(P){for(;P<h.length;P++)if(h[P].check(C)){var S=h[P].component,G=h[P].route,k=S,W=A=function(X){if(W===A){if(X===x)return O(P+1);q=X!=null&&(typeof X.view=="function"||typeof X=="function")?X:"div",b=C.params,d=_,A=null,y=S.render?S:null,c===2?i.redraw():(c=2,i.redraw.sync())}};S.view||typeof S=="function"?(S={},W(k)):S.onmatch?l.then(function(){return S.onmatch(C.params,_,G)}).then(W,_===s?null:M):W("div");return}if(_===s)throw new Error("Could not resolve default route "+s+".");B(s,null,{replace:!0})}}function v(){p||(p=!0,u(j))}function B(E,_,C){if(E=Ft(E,_),m){v();var M=C?C.state:null,O=C?C.title:null;C&&C.replace?n.history.replaceState(M,O,U.prefix+E):n.history.pushState(M,O,U.prefix+E)}else n.location.href=U.prefix+E}function U(E,_,C){if(!E)throw new TypeError("DOM element being rendered to does not exist.");if(h=Object.keys(C).map(function(O){if(O[0]!=="/")throw new SyntaxError("Routes must start with a '/'.");if(/:([^\/\.-]+)(\.{3})?:/.test(O))throw new SyntaxError("Route parameter names must be separated with either '/', '.', or '-'.");return{route:O,component:C[O],check:Mr(O)}}),s=_,_!=null){var M=Ht(_);if(!h.some(function(O){return O.check(M)}))throw new ReferenceError("Default route doesn't match any known routes.")}typeof n.history.pushState=="function"?n.addEventListener("popstate",v,!1):U.prefix[0]==="#"&&n.addEventListener("hashchange",j,!1),m=!0,i.mount(E,N),j()}return U.set=function(E,_,C){A!=null&&(C=C||{},C.replace=!0),A=null,B(E,_,C)},U.get=function(){return d},U.prefix="#!",U.Link={view:function(E){var _=zr(E.attrs.selector||"a",Ur(E.attrs,["options","params","selector","onclick"]),E.children),C,M,O;return(_.attrs.disabled=!!_.attrs.disabled)?(_.attrs.href=null,_.attrs["aria-disabled"]="true"):(C=E.attrs.options,M=E.attrs.onclick,O=Ft(_.attrs.href,E.attrs.params),_.attrs.href=U.prefix+O,_.attrs.onclick=function(P){var S;typeof M=="function"?S=M.call(P.currentTarget,P):M==null||typeof M!="object"||typeof M.handleEvent=="function"&&M.handleEvent(P),S!==!1&&!P.defaultPrevented&&(P.button===0||P.which===0||P.which===1)&&(!P.currentTarget.target||P.currentTarget.target==="_self")&&!P.ctrlKey&&!P.metaKey&&!P.shiftKey&&!P.altKey&&(P.preventDefault(),P.redraw=!1,U.set(O,null,C))}),_}},U.param=function(E){return b&&E!=null?b[E]:b},U}});var Jt=z((hn,Qt)=>{"use strict";var vr=he();Qt.exports=Kt()(typeof window<"u"?window:null,vr)});var we=z((pn,Xt)=>{"use strict";var ge=yt(),Bt=jt(),Gt=he(),H=function(){return ge.apply(this,arguments)};H.m=ge;H.trust=ge.trust;H.fragment=ge.fragment;H.Fragment="[";H.mount=Gt.mount;H.route=Jt();H.render=Ve();H.redraw=Gt.redraw;H.request=Bt.request;H.jsonp=Bt.jsonp;H.parseQueryString=Se();H.buildQueryString=Fe();H.parsePathname=ye();H.buildPathname=pe();H.vnode=Y();H.PromisePolyfill=Ue();H.censor=Ke();Xt.exports=H});var Zt=ze(we(),1);var Be={};nt(Be,{MithrilComponent:()=>ue,MithrilMount:()=>Vr,MithrilRedraw:()=>Hr,MithrilUnmount:()=>Fr,PartialRedraw:()=>Je});var Z=ze(we(),1),be=new Map,Je=n=>{let i=be.get(n);i&&i.redraw()},Vr=(n,i,u)=>{if(u){let h=function(){m||(m=!0,requestAnimationFrame(function(){m=!1,s()}))},s=function(){try{l.render(p,l.vnode(i,void 0,c),h)}catch(y){console.error(y)}},l=Z.default,p=new UnityElement(n,!0),m=!1,c={redraw:h,element:p};return l.render(p,l.vnode(i,void 0,c),h),be.set(p.mountId,c),p}else{let l=new UnityElement(n,!1);return Z.default.mount(l,i),l}},Fr=n=>{n.mountId?(be.delete(n.mountId),Z.default.render(n,[])):Z.default.mount(n,null)},Hr=(n=null)=>{if(n!=null){n.mountId?Je(n.mountId):Z.default.redraw();return}Z.default.redraw();for(let i of be.values())i.redraw()},ue=class{constructor(i){}oncreate(i){this.__mountId=i.dom.mountId}redraw(){this.__mountId?Je(this.__mountId):Z.default.redraw()}};var Xe={};nt(Xe,{Realtime:()=>Ge});var le=ze(we(),1);var Ge=class extends ue{_render(u){var l=u.children;if(typeof l=="object"){var p=l[0];if(typeof p=="function")return p()}}oncreate(u){this._dom=u.dom;let l=u.attrs?.interval||0;this._interval=setInterval(()=>{le.default.render(this._dom,this._render(u))},l),le.default.render(this._dom,this._render(u))}view(u){return(0,le.default)("panel",u.attrs)}onremove(){le.default.render(this._dom,null),this._interval!=null&&clearInterval(this._interval),this._interval=null}};var Yt={...Be,...Xe};for(Ye in Yt)globalThis[Ye]=Yt[Ye];var Ye;globalThis.m=Zt.default;
