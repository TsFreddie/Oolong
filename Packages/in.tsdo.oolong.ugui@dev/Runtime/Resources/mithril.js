var fr=Object.create;var je=Object.defineProperty;var ur=Object.getOwnPropertyDescriptor;var lr=Object.getOwnPropertyNames;var cr=Object.getPrototypeOf,sr=Object.prototype.hasOwnProperty;var I=(n,i)=>()=>(i||n((i={exports:{}}).exports,i),i.exports),nt=(n,i)=>{for(var f in i)je(n,f,{get:i[f],enumerable:!0})},or=(n,i,f,l)=>{if(i&&typeof i=="object"||typeof i=="function")for(let p of lr(i))!sr.call(n,p)&&p!==f&&je(n,p,{get:()=>i[p],enumerable:!(l=ur(i,p))||l.enumerable});return n};var ze=(n,i,f)=>(f=n!=null?fr(cr(n)):{},or(i||!n||!n.__esModule?je(f,"default",{value:n,enumerable:!0}):f,n));var Y=I((Kr,it)=>{"use strict";function $(n,i,f,l,p,o){return{tag:n,key:i,attrs:f,children:l,text:p,dom:o,domSize:void 0,state:void 0,events:void 0,instance:void 0}}$.normalize=function(n){return Array.isArray(n)?$("[",void 0,void 0,$.normalizeChildren(n),void 0,void 0):n==null||typeof n=="boolean"?null:typeof n=="object"?n:$("#",void 0,void 0,String(n),void 0,void 0)};$.normalizeChildren=function(n){var i=[];if(n.length){for(var f=n[0]!=null&&n[0].key!=null,l=1;l<n.length;l++)if((n[l]!=null&&n[l].key!=null)!==f)throw new TypeError(f&&(n[l]!=null||typeof n[l]=="boolean")?"In fragments, vnodes must either all have keys or none have keys. You may wish to consider using an explicit keyed empty fragment, m.fragment({key: ...}), instead of a hole.":"In fragments, vnodes must either all have keys or none have keys.");for(var l=0;l<n.length;l++)i[l]=$.normalize(n[l])}return i};it.exports=$});var Ie=I((Qr,at)=>{"use strict";var mr=Y();at.exports=function(){var n=arguments[this],i=this+1,f;if(n==null?n={}:(typeof n!="object"||n.tag!=null||Array.isArray(n))&&(n={},i=this),arguments.length===i+1)f=arguments[i],Array.isArray(f)||(f=[f]);else for(f=[];i<arguments.length;)f.push(arguments[i++]);return mr("",n.key,n,f)}});var ae=I((Jr,ft)=>{"use strict";ft.exports={}.hasOwnProperty});var Me=I((Br,ct)=>{"use strict";var hr=Y(),pr=Ie(),te=ae(),yr=/(?:(^|#|\.)([^#\.\[\]]+))|(\[(.+?)(?:\s*=\s*("|'|)((?:\\["'\]]|.)*?)\5)?\])/g,lt={};function ut(n){for(var i in n)if(te.call(n,i))return!1;return!0}function gr(n){for(var i,f="div",l=[],p={};i=yr.exec(n);){var o=i[1],c=i[2];if(o===""&&c!=="")f=c;else if(o==="#")p.id=c;else if(o===".")l.push(c);else if(i[3][0]==="["){var h=i[6];h&&(h=h.replace(/\\(["'])/g,"$1").replace(/\\\\/g,"\\")),i[4]==="class"?l.push(h):p[i[4]]=h===""?h:h||!0}}return l.length>0&&(p.className=l.join(" ")),lt[n]={tag:f,attrs:p}}function wr(n,i){var f=i.attrs,l=te.call(f,"class"),p=l?f.class:f.className;if(i.tag=n.tag,i.attrs={},!ut(n.attrs)&&!ut(f)){var o={};for(var c in f)te.call(f,c)&&(o[c]=f[c]);f=o}for(var c in n.attrs)te.call(n.attrs,c)&&c!=="className"&&!te.call(f,c)&&(f[c]=n.attrs[c]);(p!=null||n.attrs.className!=null)&&(f.className=p!=null?n.attrs.className!=null?String(n.attrs.className)+" "+String(p):p:n.attrs.className!=null?n.attrs.className:null),l&&(f.class=null);for(var c in f)if(te.call(f,c)&&c!=="key"){i.attrs=f;break}return i}function br(n){if(n==null||typeof n!="string"&&typeof n!="function"&&typeof n.view!="function")throw Error("The selector must be either a string or a component.");var i=pr.apply(1,arguments);return typeof n=="string"&&(i.children=hr.normalizeChildren(i.children),n!=="[")?wr(lt[n]||gr(n),i):(i.tag=n,i)}ct.exports=br});var ot=I((Gr,st)=>{"use strict";var xr=Y();st.exports=function(n){return n==null&&(n=""),xr("<",void 0,void 0,n,void 0,void 0)}});var ht=I((Xr,mt)=>{"use strict";var qr=Y(),Cr=Ie();mt.exports=function(){var n=Cr.apply(0,arguments);return n.tag="[",n.children=qr.normalizeChildren(n.children),n}});var yt=I((Yr,pt)=>{"use strict";var Le=Me();Le.trust=ot();Le.fragment=ht();pt.exports=Le});var _e=I((Zr,gt)=>{"use strict";var F=function(n){if(!(this instanceof F))throw new Error("Promise must be called with 'new'.");if(typeof n!="function")throw new TypeError("executor must be a function.");var i=this,f=[],l=[],p=s(f,!0),o=s(l,!1),c=i._instance={resolvers:f,rejectors:l},h=typeof setImmediate=="function"?setImmediate:setTimeout;function s(q,b){return function C(A){var N;try{if(b&&A!=null&&(typeof A=="object"||typeof A=="function")&&typeof(N=A.then)=="function"){if(A===i)throw new TypeError("Promise can't be resolved with itself.");y(N.bind(A))}else h(function(){!b&&q.length===0&&console.error("Possible unhandled promise rejection:",A);for(var x=0;x<q.length;x++)q[x](A);f.length=0,l.length=0,c.state=b,c.retry=function(){C(A)}})}catch(x){o(x)}}}function y(q){var b=0;function C(N){return function(x){b++>0||N(x)}}var A=C(o);try{q(C(p),A)}catch(N){A(N)}}y(n)};F.prototype.then=function(n,i){var f=this,l=f._instance;function p(s,y,q,b){y.push(function(C){if(typeof s!="function")q(C);else try{o(s(C))}catch(A){c&&c(A)}}),typeof l.retry=="function"&&b===l.state&&l.retry()}var o,c,h=new F(function(s,y){o=s,c=y});return p(n,l.resolvers,o,!0),p(i,l.rejectors,c,!1),h};F.prototype.catch=function(n){return this.then(null,n)};F.prototype.finally=function(n){return this.then(function(i){return F.resolve(n()).then(function(){return i})},function(i){return F.resolve(n()).then(function(){return F.reject(i)})})};F.resolve=function(n){return n instanceof F?n:new F(function(i){i(n)})};F.reject=function(n){return new F(function(i,f){f(n)})};F.all=function(n){return new F(function(i,f){var l=n.length,p=0,o=[];if(n.length===0)i([]);else for(var c=0;c<n.length;c++)(function(h){function s(y){p++,o[h]=y,p===l&&i(o)}n[h]!=null&&(typeof n[h]=="object"||typeof n[h]=="function")&&typeof n[h].then=="function"?n[h].then(s,f):s(n[h])})(c)})};F.race=function(n){return new F(function(i,f){for(var l=0;l<n.length;l++)n[l].then(i,f)})};gt.exports=F});var Ue=I((Wr,oe)=>{"use strict";var fe=_e();typeof window<"u"?(typeof window.Promise>"u"?window.Promise=fe:window.Promise.prototype.finally||(window.Promise.prototype.finally=fe.prototype.finally),oe.exports=window.Promise):typeof global<"u"?(typeof global.Promise>"u"?global.Promise=fe:global.Promise.prototype.finally||(global.Promise.prototype.finally=fe.prototype.finally),oe.exports=global.Promise):oe.exports=fe});var bt=I(($r,wt)=>{"use strict";var De=Y();wt.exports=function(n){var i=n&&n.document,f,l={svg:"http://www.w3.org/2000/svg",math:"http://www.w3.org/1998/Math/MathML"};function p(t){return t.attrs&&t.attrs.xmlns||l[t.tag]}function o(t,e){if(t.state!==e)throw new Error("'vnode.state' must not be modified.")}function c(t){var e=t.state;try{return this.apply(e,arguments)}finally{o(t,e)}}function h(){try{return i.activeElement}catch{return null}}function s(t,e,r,a,u,m,w){for(var T=r;T<a;T++){var g=e[T];g!=null&&y(t,g,u,w,m)}}function y(t,e,r,a,u){var m=e.tag;if(typeof m=="string")switch(e.state={},e.attrs!=null&&Ae(e.attrs,e,r),m){case"#":q(t,e,u);break;case"<":C(t,e,a,u);break;case"[":A(t,e,r,a,u);break;default:N(t,e,r,a,u)}else z(t,e,r,a,u)}function q(t,e,r){e.dom=i.createTextNode(e.children),X(t,e.dom,r)}var b={caption:"table",thead:"table",tbody:"table",tfoot:"table",tr:"tbody",th:"tr",td:"tr",colgroup:"table",col:"colgroup"};function C(t,e,r,a){var u=e.children.match(/^\s*?<(\w+)/im)||[],m=i.createElement(b[u[1]]||"div");r==="http://www.w3.org/2000/svg"?(m.innerHTML='<svg xmlns="http://www.w3.org/2000/svg">'+e.children+"</svg>",m=m.firstChild):m.innerHTML=e.children,e.dom=m.firstChild,e.domSize=m.childNodes.length,e.instance=[];for(var w=i.createDocumentFragment(),T;T=m.firstChild;)e.instance.push(T),w.appendChild(T);X(t,w,a)}function A(t,e,r,a,u){var m=i.createDocumentFragment();if(e.children!=null){var w=e.children;s(m,w,0,w.length,r,null,a)}e.dom=m.firstChild,e.domSize=m.childNodes.length,X(t,m,u)}function N(t,e,r,a,u){var m=e.tag,w=e.attrs,T=w&&w.is;a=p(e)||a;var g=a?T?i.createElementNS(a,m,{is:T}):i.createElementNS(a,m):T?i.createElement(m,{is:T}):i.createElement(m);if(e.dom=g,w!=null&&Wt(e,w,a),X(t,g,u),!Ze(e)&&e.children!=null){var R=e.children;s(g,R,0,R.length,r,null,a),e.tag==="select"&&w!=null&&kt(e,w)}}function x(t,e){var r;if(typeof t.tag.view=="function"){if(t.state=Object.create(t.tag),r=t.state.view,r.$$reentrantLock$$!=null)return;r.$$reentrantLock$$=!0}else{if(t.state=void 0,r=t.tag,r.$$reentrantLock$$!=null)return;r.$$reentrantLock$$=!0,t.state=t.tag.prototype!=null&&typeof t.tag.prototype.view=="function"?new t.tag(t):t.tag(t)}if(Ae(t.state,t,e),t.attrs!=null&&Ae(t.attrs,t,e),t.instance=De.normalize(c.call(t.state.view,t)),t.instance===t)throw Error("A view cannot return the vnode it received as argument");r.$$reentrantLock$$=null}function z(t,e,r,a,u){x(e,r),e.instance!=null?(y(t,e.instance,r,a,u),e.dom=e.instance.dom,e.domSize=e.dom!=null?e.instance.domSize:0):e.domSize=0}function v(t,e,r,a,u,m){if(!(e===r||e==null&&r==null))if(e==null||e.length===0)s(t,r,0,r.length,a,u,m);else if(r==null||r.length===0)re(t,e,0,e.length);else{var w=e[0]!=null&&e[0].key!=null,T=r[0]!=null&&r[0].key!=null,g=0,R=0;if(!w)for(;R<e.length&&e[R]==null;)R++;if(!T)for(;g<r.length&&r[g]==null;)g++;if(w!==T)re(t,e,R,e.length),s(t,r,g,r.length,a,u,m);else if(T){for(var Q=e.length-1,V=r.length-1,se,J,D,K,M,Oe;Q>=R&&V>=g&&(K=e[Q],M=r[V],K.key===M.key);)K!==M&&B(t,K,M,a,u,m),M.dom!=null&&(u=M.dom),Q--,V--;for(;Q>=R&&V>=g&&(J=e[R],D=r[g],J.key===D.key);)R++,g++,J!==D&&B(t,J,D,a,G(e,R,u),m);for(;Q>=R&&V>=g&&!(g===V||J.key!==M.key||K.key!==D.key);)Oe=G(e,R,u),k(t,K,Oe),K!==D&&B(t,K,D,a,Oe,m),++g<=--V&&k(t,J,u),J!==M&&B(t,J,M,a,u,m),M.dom!=null&&(u=M.dom),R++,Q--,K=e[Q],M=r[V],J=e[R],D=r[g];for(;Q>=R&&V>=g&&K.key===M.key;)K!==M&&B(t,K,M,a,u,m),M.dom!=null&&(u=M.dom),Q--,V--,K=e[Q],M=r[V];if(g>V)re(t,e,R,Q+1);else if(R>Q)s(t,r,g,V+1,a,u,m);else{var ar=u,rt=V-g+1,ie=new Array(rt),Te=0,_=0,Ne=2147483647,Pe=0,se,Re;for(_=0;_<rt;_++)ie[_]=-1;for(_=V;_>=g;_--){se==null&&(se=P(e,R,Q+1)),M=r[_];var ee=se[M.key];ee!=null&&(Ne=ee<Ne?ee:-1,ie[_-g]=ee,K=e[ee],e[ee]=null,K!==M&&B(t,K,M,a,u,m),M.dom!=null&&(u=M.dom),Pe++)}if(u=ar,Pe!==Q-R+1&&re(t,e,R,Q+1),Pe===0)s(t,r,g,V+1,a,u,m);else if(Ne===-1)for(Re=S(ie),Te=Re.length-1,_=V;_>=g;_--)D=r[_],ie[_-g]===-1?y(t,D,a,m,u):Re[Te]===_-g?Te--:k(t,D,u),D.dom!=null&&(u=r[_].dom);else for(_=V;_>=g;_--)D=r[_],ie[_-g]===-1&&y(t,D,a,m,u),D.dom!=null&&(u=r[_].dom)}}else{var Ee=e.length<r.length?e.length:r.length;for(g=g<R?g:R;g<Ee;g++)J=e[g],D=r[g],!(J===D||J==null&&D==null)&&(J==null?y(t,D,a,m,G(e,g+1,u)):D==null?le(t,J):B(t,J,D,a,G(e,g+1,u),m));e.length>Ee&&re(t,e,g,e.length),r.length>Ee&&s(t,r,g,r.length,a,u,m)}}}function B(t,e,r,a,u,m){var w=e.tag,T=r.tag;if(w===T){if(r.state=e.state,r.events=e.events,ir(r,e))return;if(typeof w=="string")switch(r.attrs!=null&&de(r.attrs,r,a),w){case"#":U(e,r);break;case"<":E(t,e,r,m,u);break;case"[":j(t,e,r,a,u,m);break;default:d(e,r,a,m)}else L(t,e,r,a,u,m)}else le(t,e),y(t,r,a,m,u)}function U(t,e){t.children.toString()!==e.children.toString()&&(t.dom.nodeValue=e.children),e.dom=t.dom}function E(t,e,r,a,u){e.children!==r.children?(We(t,e),C(t,r,a,u)):(r.dom=e.dom,r.domSize=e.domSize,r.instance=e.instance)}function j(t,e,r,a,u,m){v(t,e.children,r.children,a,u,m);var w=0,T=r.children;if(r.dom=null,T!=null){for(var g=0;g<T.length;g++){var R=T[g];R!=null&&R.dom!=null&&(r.dom==null&&(r.dom=R.dom),w+=R.domSize||1)}w!==1&&(r.domSize=w)}}function d(t,e,r,a){var u=e.dom=t.dom;a=p(e)||a,e.tag==="textarea"&&e.attrs==null&&(e.attrs={}),er(e,t.attrs,e.attrs,a),Ze(e)||v(u,t.children,e.children,r,null,a)}function L(t,e,r,a,u,m){if(r.instance=De.normalize(c.call(r.state.view,r)),r.instance===r)throw Error("A view cannot return the vnode it received as argument");de(r.state,r,a),r.attrs!=null&&de(r.attrs,r,a),r.instance!=null?(e.instance==null?y(t,r.instance,a,m,u):B(t,e.instance,r.instance,a,u,m),r.dom=r.instance.dom,r.domSize=r.instance.domSize):e.instance!=null?(le(t,e.instance),r.dom=void 0,r.domSize=0):(r.dom=e.dom,r.domSize=e.domSize)}function P(t,e,r){for(var a=Object.create(null);e<r;e++){var u=t[e];if(u!=null){var m=u.key;m!=null&&(a[m]=e)}}return a}var O=[];function S(t){for(var e=[0],r=0,a=0,u=0,m=O.length=t.length,u=0;u<m;u++)O[u]=t[u];for(var u=0;u<m;++u)if(t[u]!==-1){var w=e[e.length-1];if(t[w]<t[u]){O[u]=w,e.push(u);continue}for(r=0,a=e.length-1;r<a;){var T=(r>>>1)+(a>>>1)+(r&a&1);t[e[T]]<t[u]?r=T+1:a=T}t[u]<t[e[r]]&&(r>0&&(O[u]=e[r-1]),e[r]=u)}for(r=e.length,a=e[r-1];r-- >0;)e[r]=a,a=O[a];return O.length=0,e}function G(t,e,r){for(;e<t.length;e++)if(t[e]!=null&&t[e].dom!=null)return t[e].dom;return r}function k(t,e,r){var a=i.createDocumentFragment();W(t,a,e),X(t,a,r)}function W(t,e,r){for(;r.dom!=null&&r.dom.parentNode===t;){if(typeof r.tag!="string"){if(r=r.instance,r!=null)continue}else if(r.tag==="<")for(var a=0;a<r.instance.length;a++)e.appendChild(r.instance[a]);else if(r.tag!=="[")e.appendChild(r.dom);else if(r.children.length===1){if(r=r.children[0],r!=null)continue}else for(var a=0;a<r.children.length;a++){var u=r.children[a];u!=null&&W(t,e,u)}break}}function X(t,e,r){r!=null?t.insertBefore(e,r):t.appendChild(e)}function Ze(t){if(t.attrs==null||t.attrs.contenteditable==null&&t.attrs.contentEditable==null)return!1;var e=t.children;if(e!=null&&e.length===1&&e[0].tag==="<"){var r=e[0].children;t.dom.innerHTML!==r&&(t.dom.innerHTML=r)}else if(e!=null&&e.length!==0)throw new Error("Child node of a contenteditable must be trusted.");return!0}function re(t,e,r,a){for(var u=r;u<a;u++){var m=e[u];m!=null&&le(t,m)}}function le(t,e){var r=0,a=e.state,u,m;if(typeof e.tag!="string"&&typeof e.state.onbeforeremove=="function"){var w=c.call(e.state.onbeforeremove,e);w!=null&&typeof w.then=="function"&&(r=1,u=w)}if(e.attrs&&typeof e.attrs.onbeforeremove=="function"){var w=c.call(e.attrs.onbeforeremove,e);w!=null&&typeof w.then=="function"&&(r|=2,m=w)}if(o(e,a),!r)ce(e),be(t,e);else{if(u!=null){var T=function(){r&1&&(r&=2,r||g())};u.then(T,T)}if(m!=null){var T=function(){r&2&&(r&=1,r||g())};m.then(T,T)}}function g(){o(e,a),ce(e),be(t,e)}}function We(t,e){for(var r=0;r<e.instance.length;r++)t.removeChild(e.instance[r])}function be(t,e){for(;e.dom!=null&&e.dom.parentNode===t;){if(typeof e.tag!="string"){if(e=e.instance,e!=null)continue}else if(e.tag==="<")We(t,e);else{if(e.tag!=="["&&(t.removeChild(e.dom),!Array.isArray(e.children)))break;if(e.children.length===1){if(e=e.children[0],e!=null)continue}else for(var r=0;r<e.children.length;r++){var a=e.children[r];a!=null&&be(t,a)}}break}}function ce(t){if(typeof t.tag!="string"&&typeof t.state.onremove=="function"&&c.call(t.state.onremove,t),t.attrs&&typeof t.attrs.onremove=="function"&&c.call(t.attrs.onremove,t),typeof t.tag!="string")t.instance!=null&&ce(t.instance);else{var e=t.children;if(Array.isArray(e))for(var r=0;r<e.length;r++){var a=e[r];a!=null&&ce(a)}}}function Wt(t,e,r){t.tag==="input"&&e.type!=null&&t.dom.setAttribute("type",e.type);var a=e!=null&&t.tag==="input"&&e.type==="file";for(var u in e)xe(t,u,null,e[u],r,a)}function xe(t,e,r,a,u,m){if(!(e==="key"||e==="is"||a==null||$e(e)||r===a&&!tr(t,e)&&typeof a!="object"||e==="type"&&t.tag==="input")){if(e[0]==="o"&&e[1]==="n")return tt(t,e,a);if(e.slice(0,6)==="xlink:")t.dom.setAttributeNS("http://www.w3.org/1999/xlink",e.slice(6),a);else if(e==="style")et(t.dom,r,a);else if(ke(t,e,u)){if(e==="value"){if((t.tag==="input"||t.tag==="textarea")&&t.dom.value===""+a&&(m||t.dom===h())||t.tag==="select"&&r!==null&&t.dom.value===""+a||t.tag==="option"&&r!==null&&t.dom.value===""+a)return;if(m&&""+a!=""){console.error("`value` is read-only on file inputs!");return}}t.dom[e]=a}else typeof a=="boolean"?a?t.dom.setAttribute(e,""):t.dom.removeAttribute(e):t.dom.setAttribute(e==="className"?"class":e,a)}}function $t(t,e,r,a){if(!(e==="key"||e==="is"||r==null||$e(e)))if(e[0]==="o"&&e[1]==="n")tt(t,e,void 0);else if(e==="style")et(t.dom,r,null);else if(ke(t,e,a)&&e!=="className"&&e!=="title"&&!(e==="value"&&(t.tag==="option"||t.tag==="select"&&t.dom.selectedIndex===-1&&t.dom===h()))&&!(t.tag==="input"&&e==="type"))t.dom[e]=null;else{var u=e.indexOf(":");u!==-1&&(e=e.slice(u+1)),r!==!1&&t.dom.removeAttribute(e==="className"?"class":e)}}function kt(t,e){if("value"in e)if(e.value===null)t.dom.selectedIndex!==-1&&(t.dom.value=null);else{var r=""+e.value;(t.dom.value!==r||t.dom.selectedIndex===-1)&&(t.dom.value=r)}"selectedIndex"in e&&xe(t,"selectedIndex",null,e.selectedIndex,void 0)}function er(t,e,r,a){if(e&&e===r&&console.warn("Don't reuse attrs object, use new object for every redraw, this will throw in next major"),r!=null){t.tag==="input"&&r.type!=null&&t.dom.setAttribute("type",r.type);var u=t.tag==="input"&&r.type==="file";for(var m in r)xe(t,m,e&&e[m],r[m],a,u)}var w;if(e!=null)for(var m in e)(w=e[m])!=null&&(r==null||r[m]==null)&&$t(t,m,w,a)}function tr(t,e){return e==="value"||e==="checked"||e==="selectedIndex"||e==="selected"&&t.dom===h()||t.tag==="option"&&t.dom.parentNode===i.activeElement}function $e(t){return t==="oninit"||t==="oncreate"||t==="onupdate"||t==="onremove"||t==="onbeforeremove"||t==="onbeforeupdate"}function ke(t,e,r){return r===void 0&&(t.tag.indexOf("-")>-1||t.attrs!=null&&t.attrs.is||e!=="href"&&e!=="list"&&e!=="form"&&e!=="width"&&e!=="height")&&e in t.dom}var rr=/[A-Z]/g;function nr(t){return"-"+t.toLowerCase()}function qe(t){return t[0]==="-"&&t[1]==="-"?t:t==="cssFloat"?"float":t.replace(rr,nr)}function et(t,e,r){if(e!==r)if(r==null)t.style.cssText="";else if(typeof r!="object")t.style.cssText=r;else if(e==null||typeof e!="object"){t.style.cssText="";for(var a in r){var u=r[a];u!=null&&t.style.setProperty(qe(a),String(u))}}else{for(var a in r){var u=r[a];u!=null&&(u=String(u))!==String(e[a])&&t.style.setProperty(qe(a),u)}for(var a in e)e[a]!=null&&r[a]==null&&t.style.removeProperty(qe(a))}}function Ce(){this._=f}Ce.prototype=Object.create(null),Ce.prototype.handleEvent=function(t){var e=this["on"+t.type],r;typeof e=="function"?r=e.call(t.currentTarget,t):typeof e.handleEvent=="function"&&e.handleEvent(t),this._&&t.redraw!==!1&&(0,this._)(),r===!1&&(t.preventDefault(),t.stopPropagation())};function tt(t,e,r){if(t.events!=null){if(t.events._=f,t.events[e]===r)return;r!=null&&(typeof r=="function"||typeof r=="object")?(t.events[e]==null&&t.dom.addEventListener(e.slice(2),t.events,!1),t.events[e]=r):(t.events[e]!=null&&t.dom.removeEventListener(e.slice(2),t.events,!1),t.events[e]=void 0)}else r!=null&&(typeof r=="function"||typeof r=="object")&&(t.events=new Ce,t.dom.addEventListener(e.slice(2),t.events,!1),t.events[e]=r)}function Ae(t,e,r){typeof t.oninit=="function"&&c.call(t.oninit,e),typeof t.oncreate=="function"&&r.push(c.bind(t.oncreate,e))}function de(t,e,r){typeof t.onupdate=="function"&&r.push(c.bind(t.onupdate,e))}function ir(t,e){do{if(t.attrs!=null&&typeof t.attrs.onbeforeupdate=="function"){var r=c.call(t.attrs.onbeforeupdate,t,e);if(r!==void 0&&!r)break}if(typeof t.tag!="string"&&typeof t.state.onbeforeupdate=="function"){var r=c.call(t.state.onbeforeupdate,t,e);if(r!==void 0&&!r)break}return!1}while(!1);return t.dom=e.dom,t.domSize=e.domSize,t.instance=e.instance,t.attrs=e.attrs,t.children=e.children,t.text=e.text,!0}var ne;return function(t,e,r){if(!t)throw new TypeError("DOM element being rendered to does not exist.");if(ne!=null&&t.contains(ne))throw new TypeError("Node is currently being rendered to and thus is locked.");var a=f,u=ne,m=[],w=h(),T=t.namespaceURI;ne=t,f=typeof r=="function"?r:void 0;try{t.vnodes==null&&(t.textContent=""),e=De.normalizeChildren(Array.isArray(e)?e:[e]),v(t,t.vnodes,e,m,null,T==="http://www.w3.org/1999/xhtml"?void 0:T),t.vnodes=e,w!=null&&h()!==w&&typeof w.focus=="function"&&w.focus();for(var g=0;g<m.length;g++)m[g]()}finally{f=a,ne=u}}}});var ve=I((kr,xt)=>{"use strict";xt.exports=bt()(typeof window<"u"?window:null)});var At=I((en,Ct)=>{"use strict";var qt=Y();Ct.exports=function(n,i,f){var l=[],p=!1,o=-1;function c(){for(o=0;o<l.length;o+=2)try{n(l[o],qt(l[o+1]),h)}catch(y){f.error(y)}o=-1}function h(){p||(p=!0,i(function(){p=!1,c()}))}h.sync=c;function s(y,q){if(q!=null&&q.view==null&&typeof q!="function")throw new TypeError("m.mount expects a component, not a vnode.");var b=l.indexOf(y);b>=0&&(l.splice(b,2),b<=o&&(o-=2),n(y,[])),q!=null&&(l.push(y,q),n(y,qt(q),h))}return{mount:s,redraw:h}}});var me=I((tn,dt)=>{"use strict";var Ar=ve();dt.exports=At()(Ar,typeof requestAnimationFrame<"u"?requestAnimationFrame:null,typeof console<"u"?console:null)});var Ve=I((rn,Et)=>{"use strict";Et.exports=function(n){if(Object.prototype.toString.call(n)!=="[object Object]")return"";var i=[];for(var f in n)l(f,n[f]);return i.join("&");function l(p,o){if(Array.isArray(o))for(var c=0;c<o.length;c++)l(p+"["+c+"]",o[c]);else if(Object.prototype.toString.call(o)==="[object Object]")for(var c in o)l(p+"["+c+"]",o[c]);else i.push(encodeURIComponent(p)+(o!=null&&o!==""?"="+encodeURIComponent(o):""))}}});var Fe=I((nn,Ot)=>{"use strict";var dr=ae();Ot.exports=Object.assign||function(n,i){for(var f in i)dr.call(i,f)&&(n[f]=i[f])}});var he=I((an,Tt)=>{"use strict";var Er=Ve(),Or=Fe();Tt.exports=function(n,i){if(/:([^\/\.-]+)(\.{3})?:/.test(n))throw new SyntaxError("Template parameter names must be separated by either a '/', '-', or '.'.");if(i==null)return n;var f=n.indexOf("?"),l=n.indexOf("#"),p=l<0?n.length:l,o=f<0?p:f,c=n.slice(0,o),h={};Or(h,i);var s=c.replace(/:([^\/\.-]+)(\.{3})?/g,function(x,z,v){return delete h[z],i[z]==null?x:v?i[z]:encodeURIComponent(String(i[z]))}),y=s.indexOf("?"),q=s.indexOf("#"),b=q<0?s.length:q,C=y<0?b:y,A=s.slice(0,C);f>=0&&(A+=n.slice(f,p)),y>=0&&(A+=(f<0?"?":"&")+s.slice(y,b));var N=Er(h);return N&&(A+=(f<0&&y<0?"?":"&")+N),l>=0&&(A+=n.slice(l)),q>=0&&(A+=(l<0?"":"&")+s.slice(q)),A}});var Rt=I((fn,Pt)=>{"use strict";var Tr=he(),Nt=ae();Pt.exports=function(n,i,f){var l=0;function p(h){return new i(h)}p.prototype=i.prototype,p.__proto__=i;function o(h){return function(s,y){typeof s!="string"?(y=s,s=s.url):y==null&&(y={});var q=new i(function(N,x){h(Tr(s,y.params),y,function(z){if(typeof y.type=="function")if(Array.isArray(z))for(var v=0;v<z.length;v++)z[v]=new y.type(z[v]);else z=new y.type(z);N(z)},x)});if(y.background===!0)return q;var b=0;function C(){--b===0&&typeof f=="function"&&f()}return A(q);function A(N){var x=N.then;return N.constructor=p,N.then=function(){b++;var z=x.apply(N,arguments);return z.then(C,function(v){if(C(),b===0)throw v}),A(z)},N}}}function c(h,s){for(var y in h.headers)if(Nt.call(h.headers,y)&&y.toLowerCase()===s)return!0;return!1}return{request:o(function(h,s,y,q){var b=s.method!=null?s.method.toUpperCase():"GET",C=s.body,A=(s.serialize==null||s.serialize===JSON.serialize)&&!(C instanceof n.FormData||C instanceof n.URLSearchParams),N=s.responseType||(typeof s.extract=="function"?"":"json"),x=new n.XMLHttpRequest,z=!1,v=!1,B=x,U,E=x.abort;x.abort=function(){z=!0,E.call(this)},x.open(b,h,s.async!==!1,typeof s.user=="string"?s.user:void 0,typeof s.password=="string"?s.password:void 0),A&&C!=null&&!c(s,"content-type")&&x.setRequestHeader("Content-Type","application/json; charset=utf-8"),typeof s.deserialize!="function"&&!c(s,"accept")&&x.setRequestHeader("Accept","application/json, text/*"),s.withCredentials&&(x.withCredentials=s.withCredentials),s.timeout&&(x.timeout=s.timeout),x.responseType=N;for(var j in s.headers)Nt.call(s.headers,j)&&x.setRequestHeader(j,s.headers[j]);x.onreadystatechange=function(d){if(!z&&d.target.readyState===4)try{var L=d.target.status>=200&&d.target.status<300||d.target.status===304||/^file:\/\//i.test(h),P=d.target.response,O;if(N==="json"){if(!d.target.responseType&&typeof s.extract!="function")try{P=JSON.parse(d.target.responseText)}catch{P=null}}else(!N||N==="text")&&P==null&&(P=d.target.responseText);if(typeof s.extract=="function"?(P=s.extract(d.target,s),L=!0):typeof s.deserialize=="function"&&(P=s.deserialize(P)),L)y(P);else{var S=function(){try{O=d.target.responseText}catch{O=P}var G=new Error(O);G.code=d.target.status,G.response=P,q(G)};x.status===0?setTimeout(function(){v||S()}):S()}}catch(G){q(G)}},x.ontimeout=function(d){v=!0;var L=new Error("Request timed out");L.code=d.target.status,q(L)},typeof s.config=="function"&&(x=s.config(x,s,h)||x,x!==B&&(U=x.abort,x.abort=function(){z=!0,U.call(this)})),C==null?x.send():typeof s.serialize=="function"?x.send(s.serialize(C)):C instanceof n.FormData||C instanceof n.URLSearchParams?x.send(C):x.send(JSON.stringify(C))}),jsonp:o(function(h,s,y,q){var b=s.callbackName||"_mithril_"+Math.round(Math.random()*1e16)+"_"+l++,C=n.document.createElement("script");n[b]=function(A){delete n[b],C.parentNode.removeChild(C),y(A)},C.onerror=function(){delete n[b],C.parentNode.removeChild(C),q(new Error("JSONP request failed"))},C.src=h+(h.indexOf("?")<0?"?":"&")+encodeURIComponent(s.callbackKey||"callback")+"="+encodeURIComponent(b),n.document.documentElement.appendChild(C)})}}});var zt=I((un,jt)=>{"use strict";var Nr=Ue(),Pr=me();jt.exports=Rt()(typeof window<"u"?window:null,Nr,Pr.redraw)});var He=I((ln,Mt)=>{"use strict";function It(n){try{return decodeURIComponent(n)}catch{return n}}Mt.exports=function(n){if(n===""||n==null)return{};n.charAt(0)==="?"&&(n=n.slice(1));for(var i=n.split("&"),f={},l={},p=0;p<i.length;p++){var o=i[p].split("="),c=It(o[0]),h=o.length===2?It(o[1]):"";h==="true"?h=!0:h==="false"&&(h=!1);var s=c.split(/\]\[?|\[/),y=l;c.indexOf("[")>-1&&s.pop();for(var q=0;q<s.length;q++){var b=s[q],C=s[q+1],A=C==""||!isNaN(parseInt(C,10));if(b===""){var c=s.slice(0,q).join();f[c]==null&&(f[c]=Array.isArray(y)?y.length:0),b=f[c]++}else if(b==="__proto__")break;if(q===s.length-1)y[b]=h;else{var N=Object.getOwnPropertyDescriptor(y,b);N!=null&&(N=N.value),N==null&&(y[b]=N=A?[]:{}),y=N}}}return l}});var pe=I((cn,Lt)=>{"use strict";var Rr=He();Lt.exports=function(n){var i=n.indexOf("?"),f=n.indexOf("#"),l=f<0?n.length:f,p=i<0?l:i,o=n.slice(0,p).replace(/\/{2,}/g,"/");return o?(o[0]!=="/"&&(o="/"+o),o.length>1&&o[o.length-1]==="/"&&(o=o.slice(0,-1))):o="/",{path:o,params:i<0?{}:Rr(n.slice(i+1,l))}}});var Ut=I((sn,_t)=>{"use strict";var jr=pe();_t.exports=function(n){var i=jr(n),f=Object.keys(i.params),l=[],p=new RegExp("^"+i.path.replace(/:([^\/.-]+)(\.{3}|\.(?!\.)|-)?|[\\^$*+.()|\[\]{}]/g,function(o,c,h){return c==null?"\\"+o:(l.push({k:c,r:h==="..."}),h==="..."?"(.*)":h==="."?"([^/]+)\\.":"([^/]+)"+(h||""))})+"$");return function(o){for(var c=0;c<f.length;c++)if(i.params[f[c]]!==o.params[f[c]])return!1;if(!l.length)return p.test(o.path);var h=p.exec(o.path);if(h==null)return!1;for(var c=0;c<l.length;c++)o.params[l[c].k]=l[c].r?h[c+1]:decodeURIComponent(h[c+1]);return!0}}});var Se=I((on,Vt)=>{"use strict";var Dt=ae(),vt=new RegExp("^(?:key|oninit|oncreate|onbeforeupdate|onupdate|onbeforeremove|onremove)$");Vt.exports=function(n,i){var f={};if(i!=null)for(var l in n)Dt.call(n,l)&&!vt.test(l)&&i.indexOf(l)<0&&(f[l]=n[l]);else for(var l in n)Dt.call(n,l)&&!vt.test(l)&&(f[l]=n[l]);return f}});var Kt=I((mn,St)=>{"use strict";var zr=Y(),Ir=Me(),Mr=Ue(),Ft=he(),Ht=pe(),Lr=Ut(),_r=Fe(),Ur=Se(),Ke={};function Dr(n){try{return decodeURIComponent(n)}catch{return n}}St.exports=function(n,i){var f=n==null?null:typeof n.setImmediate=="function"?n.setImmediate:n.setTimeout,l=Mr.resolve(),p=!1,o=!1,c=0,h,s,y=Ke,q,b,C,A,N={onbeforeupdate:function(){return c=c?2:1,!(!c||Ke===y)},onremove:function(){n.removeEventListener("popstate",v,!1),n.removeEventListener("hashchange",z,!1)},view:function(){if(!(!c||Ke===y)){var E=[zr(q,b.key,b)];return y&&(E=y.render(E[0])),E}}},x=U.SKIP={};function z(){p=!1;var E=n.location.hash;U.prefix[0]!=="#"&&(E=n.location.search+E,U.prefix[0]!=="?"&&(E=n.location.pathname+E,E[0]!=="/"&&(E="/"+E)));var j=E.concat().replace(/(?:%[a-f89][a-f0-9])+/gim,Dr).slice(U.prefix.length),d=Ht(j);_r(d.params,n.history.state);function L(O){console.error(O),B(s,null,{replace:!0})}P(0);function P(O){for(;O<h.length;O++)if(h[O].check(d)){var S=h[O].component,G=h[O].route,k=S,W=A=function(X){if(W===A){if(X===x)return P(O+1);q=X!=null&&(typeof X.view=="function"||typeof X=="function")?X:"div",b=d.params,C=j,A=null,y=S.render?S:null,c===2?i.redraw():(c=2,i.redraw.sync())}};S.view||typeof S=="function"?(S={},W(k)):S.onmatch?l.then(function(){return S.onmatch(d.params,j,G)}).then(W,j===s?null:L):W("div");return}if(j===s)throw new Error("Could not resolve default route "+s+".");B(s,null,{replace:!0})}}function v(){p||(p=!0,f(z))}function B(E,j,d){if(E=Ft(E,j),o){v();var L=d?d.state:null,P=d?d.title:null;d&&d.replace?n.history.replaceState(L,P,U.prefix+E):n.history.pushState(L,P,U.prefix+E)}else n.location.href=U.prefix+E}function U(E,j,d){if(!E)throw new TypeError("DOM element being rendered to does not exist.");if(h=Object.keys(d).map(function(P){if(P[0]!=="/")throw new SyntaxError("Routes must start with a '/'.");if(/:([^\/\.-]+)(\.{3})?:/.test(P))throw new SyntaxError("Route parameter names must be separated with either '/', '.', or '-'.");return{route:P,component:d[P],check:Lr(P)}}),s=j,j!=null){var L=Ht(j);if(!h.some(function(P){return P.check(L)}))throw new ReferenceError("Default route doesn't match any known routes.")}typeof n.history.pushState=="function"?n.addEventListener("popstate",v,!1):U.prefix[0]==="#"&&n.addEventListener("hashchange",z,!1),o=!0,i.mount(E,N),z()}return U.set=function(E,j,d){A!=null&&(d=d||{},d.replace=!0),A=null,B(E,j,d)},U.get=function(){return C},U.prefix="#!",U.Link={view:function(E){var j=Ir(E.attrs.selector||"a",Ur(E.attrs,["options","params","selector","onclick"]),E.children),d,L,P;return(j.attrs.disabled=!!j.attrs.disabled)?(j.attrs.href=null,j.attrs["aria-disabled"]="true"):(d=E.attrs.options,L=E.attrs.onclick,P=Ft(j.attrs.href,E.attrs.params),j.attrs.href=U.prefix+P,j.attrs.onclick=function(O){var S;typeof L=="function"?S=L.call(O.currentTarget,O):L==null||typeof L!="object"||typeof L.handleEvent=="function"&&L.handleEvent(O),S!==!1&&!O.defaultPrevented&&(O.button===0||O.which===0||O.which===1)&&(!O.currentTarget.target||O.currentTarget.target==="_self")&&!O.ctrlKey&&!O.metaKey&&!O.shiftKey&&!O.altKey&&(O.preventDefault(),O.redraw=!1,U.set(P,null,d))}),j}},U.param=function(E){return b&&E!=null?b[E]:b},U}});var Jt=I((hn,Qt)=>{"use strict";var vr=me();Qt.exports=Kt()(typeof window<"u"?window:null,vr)});var ge=I((pn,Xt)=>{"use strict";var ye=yt(),Bt=zt(),Gt=me(),H=function(){return ye.apply(this,arguments)};H.m=ye;H.trust=ye.trust;H.fragment=ye.fragment;H.Fragment="[";H.mount=Gt.mount;H.route=Jt();H.render=ve();H.redraw=Gt.redraw;H.request=Bt.request;H.jsonp=Bt.jsonp;H.parseQueryString=He();H.buildQueryString=Ve();H.parsePathname=pe();H.buildPathname=he();H.vnode=Y();H.PromisePolyfill=_e();H.censor=Se();Xt.exports=H});var Zt=ze(ge(),1);var Je={};nt(Je,{MithrilComponent:()=>ue,MithrilMount:()=>Vr,MithrilRedraw:()=>Hr,MithrilUnmount:()=>Fr,PartialRedraw:()=>Qe});var Z=ze(ge(),1),we=new Map,Qe=n=>{let i=we.get(n);i&&i()},Vr=(n,i,f)=>{if(f){let c=function(){o||(o=!0,requestAnimationFrame(function(){o=!1,h()}))},h=function(){try{l.render(p,l.vnode(i),c)}catch(s){console.error(s)}},l=Z.default,p=new UnityElement(n,!0),o=!1;return l.render(p,l.vnode(i),c),we.set(p.mountId,c),p}else{let l=new UnityElement(n,!1);return Z.default.mount(l,i),l}},Fr=n=>{n.mountId?(we.delete(n.mountId),Z.default.render(n,[])):Z.default.mount(n,null)},Hr=(n=null)=>{if(n!=null){n.mountId?Qe(n.mountId):Z.default.redraw();return}Z.default.redraw();for(let i of we.values())i()},ue=class{constructor(i){}oncreate(i){this.__mountId=i.dom.mountId}redraw(){this.__mountId?Qe(this.__mountId):Z.default.redraw()}};var Xe={};nt(Xe,{Realtime:()=>Ge});var Be=ze(ge(),1);var Ge=class extends ue{register(f){var l=f.children;if(typeof l!="object")return;var p=l[0];if(typeof p!="function")return;let o=f.attrs?.interval||0;this.interval=setInterval(()=>{Be.default.render(this.dom,p())},o)}oncreate(f){this.dom=f.dom,this.register(f)}onupdate(f){this.onremove(),this.register(f)}view(f){return(0,Be.default)("div",f.attrs)}onremove(){this.interval!=null&&clearInterval(this.interval),this.interval=null}};var Yt={...Je,...Xe};for(Ye in Yt)globalThis[Ye]=Yt[Ye];var Ye;globalThis.m=Zt.default;
