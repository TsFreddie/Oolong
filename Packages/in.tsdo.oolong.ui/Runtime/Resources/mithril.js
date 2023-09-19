var ar=Object.create;var Me=Object.defineProperty;var fr=Object.getOwnPropertyDescriptor;var ur=Object.getOwnPropertyNames;var lr=Object.getPrototypeOf,cr=Object.prototype.hasOwnProperty;var d=(n,a)=>()=>(a||n((a={exports:{}}).exports,a),a.exports),rt=(n,a)=>{for(var u in a)Me(n,u,{get:a[u],enumerable:!0})},sr=(n,a,u,l)=>{if(a&&typeof a=="object"||typeof a=="function")for(let y of ur(a))!cr.call(n,y)&&y!==u&&Me(n,y,{get:()=>a[y],enumerable:!(l=fr(a,y))||l.enumerable});return n};var Re=(n,a,u)=>(u=n!=null?ar(lr(n)):{},sr(a||!n||!n.__esModule?Me(u,"default",{value:n,enumerable:!0}):u,n));var Y=d((Hr,nt)=>{"use strict";function W(n,a,u,l,y,m){return{tag:n,key:a,attrs:u,children:l,text:y,dom:m,domSize:void 0,state:void 0,events:void 0,instance:void 0}}W.normalize=function(n){return Array.isArray(n)?W("[",void 0,void 0,W.normalizeChildren(n),void 0,void 0):n==null||typeof n=="boolean"?null:typeof n=="object"?n:W("#",void 0,void 0,String(n),void 0,void 0)};W.normalizeChildren=function(n){var a=[];if(n.length){for(var u=n[0]!=null&&n[0].key!=null,l=1;l<n.length;l++)if((n[l]!=null&&n[l].key!=null)!==u)throw new TypeError(u&&(n[l]!=null||typeof n[l]=="boolean")?"In fragments, vnodes must either all have keys or none have keys. You may wish to consider using an explicit keyed empty fragment, m.fragment({key: ...}), instead of a hole.":"In fragments, vnodes must either all have keys or none have keys.");for(var l=0;l<n.length;l++)a[l]=W.normalize(n[l])}return a};nt.exports=W});var de=d((Sr,it)=>{"use strict";var or=Y();it.exports=function(){var n=arguments[this],a=this+1,u;if(n==null?n={}:(typeof n!="object"||n.tag!=null||Array.isArray(n))&&(n={},a=this),arguments.length===a+1)u=arguments[a],Array.isArray(u)||(u=[u]);else for(u=[];a<arguments.length;)u.push(arguments[a++]);return or("",n.key,n,u)}});var ie=d((Kr,at)=>{"use strict";at.exports={}.hasOwnProperty});var Le=d((Qr,lt)=>{"use strict";var mr=Y(),hr=de(),ee=ie(),pr=/(?:(^|#|\.)([^#\.\[\]]+))|(\[(.+?)(?:\s*=\s*("|'|)((?:\\["'\]]|.)*?)\5)?\])/g,ut={};function ft(n){for(var a in n)if(ee.call(n,a))return!1;return!0}function yr(n){for(var a,u="div",l=[],y={};a=pr.exec(n);){var m=a[1],c=a[2];if(m===""&&c!=="")u=c;else if(m==="#")y.id=c;else if(m===".")l.push(c);else if(a[3][0]==="["){var h=a[6];h&&(h=h.replace(/\\(["'])/g,"$1").replace(/\\\\/g,"\\")),a[4]==="class"?l.push(h):y[a[4]]=h===""?h:h||!0}}return l.length>0&&(y.className=l.join(" ")),ut[n]={tag:u,attrs:y}}function gr(n,a){var u=a.attrs,l=ee.call(u,"class"),y=l?u.class:u.className;if(a.tag=n.tag,a.attrs={},!ft(n.attrs)&&!ft(u)){var m={};for(var c in u)ee.call(u,c)&&(m[c]=u[c]);u=m}for(var c in n.attrs)ee.call(n.attrs,c)&&c!=="className"&&!ee.call(u,c)&&(u[c]=n.attrs[c]);(y!=null||n.attrs.className!=null)&&(u.className=y!=null?n.attrs.className!=null?String(n.attrs.className)+" "+String(y):y:n.attrs.className!=null?n.attrs.className:null),l&&(u.class=null);for(var c in u)if(ee.call(u,c)&&c!=="key"){a.attrs=u;break}return a}function wr(n){if(n==null||typeof n!="string"&&typeof n!="function"&&typeof n.view!="function")throw Error("The selector must be either a string or a component.");var a=hr.apply(1,arguments);return typeof n=="string"&&(a.children=mr.normalizeChildren(a.children),n!=="[")?gr(ut[n]||yr(n),a):(a.tag=n,a)}lt.exports=wr});var st=d((Jr,ct)=>{"use strict";var br=Y();ct.exports=function(n){return n==null&&(n=""),br("<",void 0,void 0,n,void 0,void 0)}});var mt=d((Br,ot)=>{"use strict";var xr=Y(),qr=de();ot.exports=function(){var n=qr.apply(0,arguments);return n.tag="[",n.children=xr.normalizeChildren(n.children),n}});var pt=d((Gr,ht)=>{"use strict";var Ie=Le();Ie.trust=st();Ie.fragment=mt();ht.exports=Ie});var De=d((Xr,yt)=>{"use strict";var F=function(n){if(!(this instanceof F))throw new Error("Promise must be called with 'new'.");if(typeof n!="function")throw new TypeError("executor must be a function.");var a=this,u=[],l=[],y=s(u,!0),m=s(l,!1),c=a._instance={resolvers:u,rejectors:l},h=typeof setImmediate=="function"?setImmediate:setTimeout;function s(q,b){return function C(A){var T;try{if(b&&A!=null&&(typeof A=="object"||typeof A=="function")&&typeof(T=A.then)=="function"){if(A===a)throw new TypeError("Promise can't be resolved with itself.");p(T.bind(A))}else h(function(){!b&&q.length===0&&console.error("Possible unhandled promise rejection:",A);for(var x=0;x<q.length;x++)q[x](A);u.length=0,l.length=0,c.state=b,c.retry=function(){C(A)}})}catch(x){m(x)}}}function p(q){var b=0;function C(T){return function(x){b++>0||T(x)}}var A=C(m);try{q(C(y),A)}catch(T){A(T)}}p(n)};F.prototype.then=function(n,a){var u=this,l=u._instance;function y(s,p,q,b){p.push(function(C){if(typeof s!="function")q(C);else try{m(s(C))}catch(A){c&&c(A)}}),typeof l.retry=="function"&&b===l.state&&l.retry()}var m,c,h=new F(function(s,p){m=s,c=p});return y(n,l.resolvers,m,!0),y(a,l.rejectors,c,!1),h};F.prototype.catch=function(n){return this.then(null,n)};F.prototype.finally=function(n){return this.then(function(a){return F.resolve(n()).then(function(){return a})},function(a){return F.resolve(n()).then(function(){return F.reject(a)})})};F.resolve=function(n){return n instanceof F?n:new F(function(a){a(n)})};F.reject=function(n){return new F(function(a,u){u(n)})};F.all=function(n){return new F(function(a,u){var l=n.length,y=0,m=[];if(n.length===0)a([]);else for(var c=0;c<n.length;c++)(function(h){function s(p){y++,m[h]=p,y===l&&a(m)}n[h]!=null&&(typeof n[h]=="object"||typeof n[h]=="function")&&typeof n[h].then=="function"?n[h].then(s,u):s(n[h])})(c)})};F.race=function(n){return new F(function(a,u){for(var l=0;l<n.length;l++)n[l].then(a,u)})};yt.exports=F});var Ue=d((Yr,se)=>{"use strict";var ae=De();typeof window<"u"?(typeof window.Promise>"u"?window.Promise=ae:window.Promise.prototype.finally||(window.Promise.prototype.finally=ae.prototype.finally),se.exports=window.Promise):typeof global<"u"?(typeof global.Promise>"u"?global.Promise=ae:global.Promise.prototype.finally||(global.Promise.prototype.finally=ae.prototype.finally),se.exports=global.Promise):se.exports=ae});var wt=d((Zr,gt)=>{"use strict";var ve=Y();gt.exports=function(n){var a=n&&n.document,u,l={svg:"http://www.w3.org/2000/svg",math:"http://www.w3.org/1998/Math/MathML"};function y(t){return t.attrs&&t.attrs.xmlns||l[t.tag]}function m(t,e){if(t.state!==e)throw new Error("'vnode.state' must not be modified.")}function c(t){var e=t.state;try{return this.apply(e,arguments)}finally{m(t,e)}}function h(){try{return a.activeElement}catch{return null}}function s(t,e,r,i,f,o,w){for(var P=r;P<i;P++){var g=e[P];g!=null&&p(t,g,f,w,o)}}function p(t,e,r,i,f){var o=e.tag;if(typeof o=="string")switch(e.state={},e.attrs!=null&&Ae(e.attrs,e,r),o){case"#":q(t,e,f);break;case"<":C(t,e,i,f);break;case"[":A(t,e,r,i,f);break;default:T(t,e,r,i,f)}else R(t,e,r,i,f)}function q(t,e,r){e.dom=a.createTextNode(e.children),X(t,e.dom,r)}var b={caption:"table",thead:"table",tbody:"table",tfoot:"table",tr:"tbody",th:"tr",td:"tr",colgroup:"table",col:"colgroup"};function C(t,e,r,i){var f=e.children.match(/^\s*?<(\w+)/im)||[],o=a.createElement(b[f[1]]||"div");r==="http://www.w3.org/2000/svg"?(o.innerHTML='<svg xmlns="http://www.w3.org/2000/svg">'+e.children+"</svg>",o=o.firstChild):o.innerHTML=e.children,e.dom=o.firstChild,e.domSize=o.childNodes.length,e.instance=[];for(var w=a.createDocumentFragment(),P;P=o.firstChild;)e.instance.push(P),w.appendChild(P);X(t,w,i)}function A(t,e,r,i,f){var o=a.createDocumentFragment();if(e.children!=null){var w=e.children;s(o,w,0,w.length,r,null,i)}e.dom=o.firstChild,e.domSize=o.childNodes.length,X(t,o,f)}function T(t,e,r,i,f){var o=e.tag,w=e.attrs,P=w&&w.is;i=y(e)||i;var g=i?P?a.createElementNS(i,o,{is:P}):a.createElementNS(i,o):P?a.createElement(o,{is:P}):a.createElement(o);if(e.dom=g,w!=null&&Zt(e,w,i),X(t,g,f),!Ye(e)&&e.children!=null){var z=e.children;s(g,z,0,z.length,r,null,i),e.tag==="select"&&w!=null&&$t(e,w)}}function x(t,e){var r;if(typeof t.tag.view=="function"){if(t.state=Object.create(t.tag),r=t.state.view,r.$$reentrantLock$$!=null)return;r.$$reentrantLock$$=!0}else{if(t.state=void 0,r=t.tag,r.$$reentrantLock$$!=null)return;r.$$reentrantLock$$=!0,t.state=t.tag.prototype!=null&&typeof t.tag.prototype.view=="function"?new t.tag(t):t.tag(t)}if(Ae(t.state,t,e),t.attrs!=null&&Ae(t.attrs,t,e),t.instance=ve.normalize(c.call(t.state.view,t)),t.instance===t)throw Error("A view cannot return the vnode it received as argument");r.$$reentrantLock$$=null}function R(t,e,r,i,f){x(e,r),e.instance!=null?(p(t,e.instance,r,i,f),e.dom=e.instance.dom,e.domSize=e.dom!=null?e.instance.domSize:0):e.domSize=0}function _(t,e,r,i,f,o){if(!(e===r||e==null&&r==null))if(e==null||e.length===0)s(t,r,0,r.length,i,f,o);else if(r==null||r.length===0)te(t,e,0,e.length);else{var w=e[0]!=null&&e[0].key!=null,P=r[0]!=null&&r[0].key!=null,g=0,z=0;if(!w)for(;z<e.length&&e[z]==null;)z++;if(!P)for(;g<r.length&&r[g]==null;)g++;if(w!==P)te(t,e,z,e.length),s(t,r,g,r.length,i,f,o);else if(P){for(var Q=e.length-1,V=r.length-1,ce,J,v,K,L,Oe;Q>=z&&V>=g&&(K=e[Q],L=r[V],K.key===L.key);)K!==L&&B(t,K,L,i,f,o),L.dom!=null&&(f=L.dom),Q--,V--;for(;Q>=z&&V>=g&&(J=e[z],v=r[g],J.key===v.key);)z++,g++,J!==v&&B(t,J,v,i,G(e,z,f),o);for(;Q>=z&&V>=g&&!(g===V||J.key!==L.key||K.key!==v.key);)Oe=G(e,z,f),$(t,K,Oe),K!==v&&B(t,K,v,i,Oe,o),++g<=--V&&$(t,J,f),J!==L&&B(t,J,L,i,f,o),L.dom!=null&&(f=L.dom),z++,Q--,K=e[Q],L=r[V],J=e[z],v=r[g];for(;Q>=z&&V>=g&&K.key===L.key;)K!==L&&B(t,K,L,i,f,o),L.dom!=null&&(f=L.dom),Q--,V--,K=e[Q],L=r[V];if(g>V)te(t,e,z,Q+1);else if(z>Q)s(t,r,g,V+1,i,f,o);else{var ir=f,tt=V-g+1,ne=new Array(tt),Pe=0,D=0,Te=2147483647,je=0,ce,ze;for(D=0;D<tt;D++)ne[D]=-1;for(D=V;D>=g;D--){ce==null&&(ce=j(e,z,Q+1)),L=r[D];var k=ce[L.key];k!=null&&(Te=k<Te?k:-1,ne[D-g]=k,K=e[k],e[k]=null,K!==L&&B(t,K,L,i,f,o),L.dom!=null&&(f=L.dom),je++)}if(f=ir,je!==Q-z+1&&te(t,e,z,Q+1),je===0)s(t,r,g,V+1,i,f,o);else if(Te===-1)for(ze=S(ne),Pe=ze.length-1,D=V;D>=g;D--)v=r[D],ne[D-g]===-1?p(t,v,i,o,f):ze[Pe]===D-g?Pe--:$(t,v,f),v.dom!=null&&(f=r[D].dom);else for(D=V;D>=g;D--)v=r[D],ne[D-g]===-1&&p(t,v,i,o,f),v.dom!=null&&(f=r[D].dom)}}else{var Ne=e.length<r.length?e.length:r.length;for(g=g<z?g:z;g<Ne;g++)J=e[g],v=r[g],!(J===v||J==null&&v==null)&&(J==null?p(t,v,i,o,G(e,g+1,f)):v==null?ue(t,J):B(t,J,v,i,G(e,g+1,f),o));e.length>Ne&&te(t,e,g,e.length),r.length>Ne&&s(t,r,g,r.length,i,f,o)}}}function B(t,e,r,i,f,o){var w=e.tag,P=r.tag;if(w===P){if(r.state=e.state,r.events=e.events,nr(r,e))return;if(typeof w=="string")switch(r.attrs!=null&&Ee(r.attrs,r,i),w){case"#":U(e,r);break;case"<":N(t,e,r,o,f);break;case"[":M(t,e,r,i,f,o);break;default:E(e,r,i,o)}else I(t,e,r,i,f,o)}else ue(t,e),p(t,r,i,o,f)}function U(t,e){t.children.toString()!==e.children.toString()&&(t.dom.nodeValue=e.children),e.dom=t.dom}function N(t,e,r,i,f){e.children!==r.children?(Ze(t,e),C(t,r,i,f)):(r.dom=e.dom,r.domSize=e.domSize,r.instance=e.instance)}function M(t,e,r,i,f,o){_(t,e.children,r.children,i,f,o);var w=0,P=r.children;if(r.dom=null,P!=null){for(var g=0;g<P.length;g++){var z=P[g];z!=null&&z.dom!=null&&(r.dom==null&&(r.dom=z.dom),w+=z.domSize||1)}w!==1&&(r.domSize=w)}}function E(t,e,r,i){var f=e.dom=t.dom;i=y(e)||i,e.tag==="textarea"&&e.attrs==null&&(e.attrs={}),kt(e,t.attrs,e.attrs,i),Ye(e)||_(f,t.children,e.children,r,null,i)}function I(t,e,r,i,f,o){if(r.instance=ve.normalize(c.call(r.state.view,r)),r.instance===r)throw Error("A view cannot return the vnode it received as argument");Ee(r.state,r,i),r.attrs!=null&&Ee(r.attrs,r,i),r.instance!=null?(e.instance==null?p(t,r.instance,i,o,f):B(t,e.instance,r.instance,i,f,o),r.dom=r.instance.dom,r.domSize=r.instance.domSize):e.instance!=null?(ue(t,e.instance),r.dom=void 0,r.domSize=0):(r.dom=e.dom,r.domSize=e.domSize)}function j(t,e,r){for(var i=Object.create(null);e<r;e++){var f=t[e];if(f!=null){var o=f.key;o!=null&&(i[o]=e)}}return i}var O=[];function S(t){for(var e=[0],r=0,i=0,f=0,o=O.length=t.length,f=0;f<o;f++)O[f]=t[f];for(var f=0;f<o;++f)if(t[f]!==-1){var w=e[e.length-1];if(t[w]<t[f]){O[f]=w,e.push(f);continue}for(r=0,i=e.length-1;r<i;){var P=(r>>>1)+(i>>>1)+(r&i&1);t[e[P]]<t[f]?r=P+1:i=P}t[f]<t[e[r]]&&(r>0&&(O[f]=e[r-1]),e[r]=f)}for(r=e.length,i=e[r-1];r-- >0;)e[r]=i,i=O[i];return O.length=0,e}function G(t,e,r){for(;e<t.length;e++)if(t[e]!=null&&t[e].dom!=null)return t[e].dom;return r}function $(t,e,r){var i=a.createDocumentFragment();Z(t,i,e),X(t,i,r)}function Z(t,e,r){for(;r.dom!=null&&r.dom.parentNode===t;){if(typeof r.tag!="string"){if(r=r.instance,r!=null)continue}else if(r.tag==="<")for(var i=0;i<r.instance.length;i++)e.appendChild(r.instance[i]);else if(r.tag!=="[")e.appendChild(r.dom);else if(r.children.length===1){if(r=r.children[0],r!=null)continue}else for(var i=0;i<r.children.length;i++){var f=r.children[i];f!=null&&Z(t,e,f)}break}}function X(t,e,r){r!=null?t.insertBefore(e,r):t.appendChild(e)}function Ye(t){if(t.attrs==null||t.attrs.contenteditable==null&&t.attrs.contentEditable==null)return!1;var e=t.children;if(e!=null&&e.length===1&&e[0].tag==="<"){var r=e[0].children;t.dom.innerHTML!==r&&(t.dom.innerHTML=r)}else if(e!=null&&e.length!==0)throw new Error("Child node of a contenteditable must be trusted.");return!0}function te(t,e,r,i){for(var f=r;f<i;f++){var o=e[f];o!=null&&ue(t,o)}}function ue(t,e){var r=0,i=e.state,f,o;if(typeof e.tag!="string"&&typeof e.state.onbeforeremove=="function"){var w=c.call(e.state.onbeforeremove,e);w!=null&&typeof w.then=="function"&&(r=1,f=w)}if(e.attrs&&typeof e.attrs.onbeforeremove=="function"){var w=c.call(e.attrs.onbeforeremove,e);w!=null&&typeof w.then=="function"&&(r|=2,o=w)}if(m(e,i),!r)le(e),be(t,e);else{if(f!=null){var P=function(){r&1&&(r&=2,r||g())};f.then(P,P)}if(o!=null){var P=function(){r&2&&(r&=1,r||g())};o.then(P,P)}}function g(){m(e,i),le(e),be(t,e)}}function Ze(t,e){for(var r=0;r<e.instance.length;r++)t.removeChild(e.instance[r])}function be(t,e){for(;e.dom!=null&&e.dom.parentNode===t;){if(typeof e.tag!="string"){if(e=e.instance,e!=null)continue}else if(e.tag==="<")Ze(t,e);else{if(e.tag!=="["&&(t.removeChild(e.dom),!Array.isArray(e.children)))break;if(e.children.length===1){if(e=e.children[0],e!=null)continue}else for(var r=0;r<e.children.length;r++){var i=e.children[r];i!=null&&be(t,i)}}break}}function le(t){if(typeof t.tag!="string"&&typeof t.state.onremove=="function"&&c.call(t.state.onremove,t),t.attrs&&typeof t.attrs.onremove=="function"&&c.call(t.attrs.onremove,t),typeof t.tag!="string")t.instance!=null&&le(t.instance);else{var e=t.children;if(Array.isArray(e))for(var r=0;r<e.length;r++){var i=e[r];i!=null&&le(i)}}}function Zt(t,e,r){t.tag==="input"&&e.type!=null&&t.dom.setAttribute("type",e.type);var i=e!=null&&t.tag==="input"&&e.type==="file";for(var f in e)xe(t,f,null,e[f],r,i)}function xe(t,e,r,i,f,o){if(!(e==="key"||e==="is"||i==null||We(e)||r===i&&!er(t,e)&&typeof i!="object"||e==="type"&&t.tag==="input")){if(e[0]==="o"&&e[1]==="n")return et(t,e,i);if(e.slice(0,6)==="xlink:")t.dom.setAttributeNS("http://www.w3.org/1999/xlink",e.slice(6),i);else if(e==="style")ke(t.dom,r,i);else if($e(t,e,f)){if(e==="value"){if((t.tag==="input"||t.tag==="textarea")&&t.dom.value===""+i&&(o||t.dom===h())||t.tag==="select"&&r!==null&&t.dom.value===""+i||t.tag==="option"&&r!==null&&t.dom.value===""+i)return;if(o&&""+i!=""){console.error("`value` is read-only on file inputs!");return}}t.dom[e]=i}else typeof i=="boolean"?i?t.dom.setAttribute(e,""):t.dom.removeAttribute(e):t.dom.setAttribute(e==="className"?"class":e,i)}}function Wt(t,e,r,i){if(!(e==="key"||e==="is"||r==null||We(e)))if(e[0]==="o"&&e[1]==="n")et(t,e,void 0);else if(e==="style")ke(t.dom,r,null);else if($e(t,e,i)&&e!=="className"&&e!=="title"&&!(e==="value"&&(t.tag==="option"||t.tag==="select"&&t.dom.selectedIndex===-1&&t.dom===h()))&&!(t.tag==="input"&&e==="type"))t.dom[e]=null;else{var f=e.indexOf(":");f!==-1&&(e=e.slice(f+1)),r!==!1&&t.dom.removeAttribute(e==="className"?"class":e)}}function $t(t,e){if("value"in e)if(e.value===null)t.dom.selectedIndex!==-1&&(t.dom.value=null);else{var r=""+e.value;(t.dom.value!==r||t.dom.selectedIndex===-1)&&(t.dom.value=r)}"selectedIndex"in e&&xe(t,"selectedIndex",null,e.selectedIndex,void 0)}function kt(t,e,r,i){if(e&&e===r&&console.warn("Don't reuse attrs object, use new object for every redraw, this will throw in next major"),r!=null){t.tag==="input"&&r.type!=null&&t.dom.setAttribute("type",r.type);var f=t.tag==="input"&&r.type==="file";for(var o in r)xe(t,o,e&&e[o],r[o],i,f)}var w;if(e!=null)for(var o in e)(w=e[o])!=null&&(r==null||r[o]==null)&&Wt(t,o,w,i)}function er(t,e){return e==="value"||e==="checked"||e==="selectedIndex"||e==="selected"&&t.dom===h()||t.tag==="option"&&t.dom.parentNode===a.activeElement}function We(t){return t==="oninit"||t==="oncreate"||t==="onupdate"||t==="onremove"||t==="onbeforeremove"||t==="onbeforeupdate"}function $e(t,e,r){return r===void 0&&(t.tag.indexOf("-")>-1||t.attrs!=null&&t.attrs.is||e!=="href"&&e!=="list"&&e!=="form"&&e!=="width"&&e!=="height")&&e in t.dom}var tr=/[A-Z]/g;function rr(t){return"-"+t.toLowerCase()}function qe(t){return t[0]==="-"&&t[1]==="-"?t:t==="cssFloat"?"float":t.replace(tr,rr)}function ke(t,e,r){if(e!==r)if(r==null)t.style.cssText="";else if(typeof r!="object")t.style.cssText=r;else if(e==null||typeof e!="object"){t.style.cssText="";for(var i in r){var f=r[i];f!=null&&t.style.setProperty(qe(i),String(f))}}else{for(var i in r){var f=r[i];f!=null&&(f=String(f))!==String(e[i])&&t.style.setProperty(qe(i),f)}for(var i in e)e[i]!=null&&r[i]==null&&t.style.removeProperty(qe(i))}}function Ce(){this._=u}Ce.prototype=Object.create(null),Ce.prototype.handleEvent=function(t){var e=this["on"+t.type],r;typeof e=="function"?r=e.call(t.currentTarget,t):typeof e.handleEvent=="function"&&e.handleEvent(t),this._&&t.redraw!==!1&&(0,this._)(),r===!1&&(t.preventDefault(),t.stopPropagation())};function et(t,e,r){if(t.events!=null){if(t.events._=u,t.events[e]===r)return;r!=null&&(typeof r=="function"||typeof r=="object")?(t.events[e]==null&&t.dom.addEventListener(e.slice(2),t.events,!1),t.events[e]=r):(t.events[e]!=null&&t.dom.removeEventListener(e.slice(2),t.events,!1),t.events[e]=void 0)}else r!=null&&(typeof r=="function"||typeof r=="object")&&(t.events=new Ce,t.dom.addEventListener(e.slice(2),t.events,!1),t.events[e]=r)}function Ae(t,e,r){typeof t.oninit=="function"&&c.call(t.oninit,e),typeof t.oncreate=="function"&&r.push(c.bind(t.oncreate,e))}function Ee(t,e,r){typeof t.onupdate=="function"&&r.push(c.bind(t.onupdate,e))}function nr(t,e){do{if(t.attrs!=null&&typeof t.attrs.onbeforeupdate=="function"){var r=c.call(t.attrs.onbeforeupdate,t,e);if(r!==void 0&&!r)break}if(typeof t.tag!="string"&&typeof t.state.onbeforeupdate=="function"){var r=c.call(t.state.onbeforeupdate,t,e);if(r!==void 0&&!r)break}return!1}while(!1);return t.dom=e.dom,t.domSize=e.domSize,t.instance=e.instance,t.attrs=e.attrs,t.children=e.children,t.text=e.text,!0}var re;return function(t,e,r){if(!t)throw new TypeError("DOM element being rendered to does not exist.");if(re!=null&&t.contains(re))throw new TypeError("Node is currently being rendered to and thus is locked.");var i=u,f=re,o=[],w=h(),P=t.namespaceURI;re=t,u=typeof r=="function"?r:void 0;try{t.vnodes==null&&(t.textContent=""),e=ve.normalizeChildren(Array.isArray(e)?e:[e]),_(t,t.vnodes,e,o,null,P==="http://www.w3.org/1999/xhtml"?void 0:P),t.vnodes=e,w!=null&&h()!==w&&typeof w.focus=="function"&&w.focus();for(var g=0;g<o.length;g++)o[g]()}finally{u=i,re=f}}}});var _e=d((Wr,bt)=>{"use strict";bt.exports=wt()(typeof window<"u"?window:null)});var Ct=d(($r,qt)=>{"use strict";var xt=Y();qt.exports=function(n,a,u){var l=[],y=!1,m=-1;function c(){for(m=0;m<l.length;m+=2)try{n(l[m],xt(l[m+1]),h)}catch(p){u.error(p)}m=-1}function h(){y||(y=!0,a(function(){y=!1,c()}))}h.sync=c;function s(p,q){if(q!=null&&q.view==null&&typeof q!="function")throw new TypeError("m.mount expects a component, not a vnode.");var b=l.indexOf(p);b>=0&&(l.splice(b,2),b<=m&&(m-=2),n(p,[])),q!=null&&(l.push(p,q),n(p,xt(q),h))}return{mount:s,redraw:h}}});var oe=d((kr,At)=>{"use strict";var Cr=_e();At.exports=Ct()(Cr,typeof requestAnimationFrame<"u"?requestAnimationFrame:null,typeof console<"u"?console:null)});var Ve=d((en,Et)=>{"use strict";Et.exports=function(n){if(Object.prototype.toString.call(n)!=="[object Object]")return"";var a=[];for(var u in n)l(u,n[u]);return a.join("&");function l(y,m){if(Array.isArray(m))for(var c=0;c<m.length;c++)l(y+"["+c+"]",m[c]);else if(Object.prototype.toString.call(m)==="[object Object]")for(var c in m)l(y+"["+c+"]",m[c]);else a.push(encodeURIComponent(y)+(m!=null&&m!==""?"="+encodeURIComponent(m):""))}}});var Fe=d((tn,Nt)=>{"use strict";var Ar=ie();Nt.exports=Object.assign||function(n,a){for(var u in a)Ar.call(a,u)&&(n[u]=a[u])}});var me=d((rn,Ot)=>{"use strict";var Er=Ve(),Nr=Fe();Ot.exports=function(n,a){if(/:([^\/\.-]+)(\.{3})?:/.test(n))throw new SyntaxError("Template parameter names must be separated by either a '/', '-', or '.'.");if(a==null)return n;var u=n.indexOf("?"),l=n.indexOf("#"),y=l<0?n.length:l,m=u<0?y:u,c=n.slice(0,m),h={};Nr(h,a);var s=c.replace(/:([^\/\.-]+)(\.{3})?/g,function(x,R,_){return delete h[R],a[R]==null?x:_?a[R]:encodeURIComponent(String(a[R]))}),p=s.indexOf("?"),q=s.indexOf("#"),b=q<0?s.length:q,C=p<0?b:p,A=s.slice(0,C);u>=0&&(A+=n.slice(u,y)),p>=0&&(A+=(u<0?"?":"&")+s.slice(p,b));var T=Er(h);return T&&(A+=(u<0&&p<0?"?":"&")+T),l>=0&&(A+=n.slice(l)),q>=0&&(A+=(l<0?"":"&")+s.slice(q)),A}});var jt=d((nn,Tt)=>{"use strict";var Or=me(),Pt=ie();Tt.exports=function(n,a,u){var l=0;function y(h){return new a(h)}y.prototype=a.prototype,y.__proto__=a;function m(h){return function(s,p){typeof s!="string"?(p=s,s=s.url):p==null&&(p={});var q=new a(function(T,x){h(Or(s,p.params),p,function(R){if(typeof p.type=="function")if(Array.isArray(R))for(var _=0;_<R.length;_++)R[_]=new p.type(R[_]);else R=new p.type(R);T(R)},x)});if(p.background===!0)return q;var b=0;function C(){--b===0&&typeof u=="function"&&u()}return A(q);function A(T){var x=T.then;return T.constructor=y,T.then=function(){b++;var R=x.apply(T,arguments);return R.then(C,function(_){if(C(),b===0)throw _}),A(R)},T}}}function c(h,s){for(var p in h.headers)if(Pt.call(h.headers,p)&&p.toLowerCase()===s)return!0;return!1}return{request:m(function(h,s,p,q){var b=s.method!=null?s.method.toUpperCase():"GET",C=s.body,A=(s.serialize==null||s.serialize===JSON.serialize)&&!(C instanceof n.FormData||C instanceof n.URLSearchParams),T=s.responseType||(typeof s.extract=="function"?"":"json"),x=new n.XMLHttpRequest,R=!1,_=!1,B=x,U,N=x.abort;x.abort=function(){R=!0,N.call(this)},x.open(b,h,s.async!==!1,typeof s.user=="string"?s.user:void 0,typeof s.password=="string"?s.password:void 0),A&&C!=null&&!c(s,"content-type")&&x.setRequestHeader("Content-Type","application/json; charset=utf-8"),typeof s.deserialize!="function"&&!c(s,"accept")&&x.setRequestHeader("Accept","application/json, text/*"),s.withCredentials&&(x.withCredentials=s.withCredentials),s.timeout&&(x.timeout=s.timeout),x.responseType=T;for(var M in s.headers)Pt.call(s.headers,M)&&x.setRequestHeader(M,s.headers[M]);x.onreadystatechange=function(E){if(!R&&E.target.readyState===4)try{var I=E.target.status>=200&&E.target.status<300||E.target.status===304||/^file:\/\//i.test(h),j=E.target.response,O;if(T==="json"){if(!E.target.responseType&&typeof s.extract!="function")try{j=JSON.parse(E.target.responseText)}catch{j=null}}else(!T||T==="text")&&j==null&&(j=E.target.responseText);if(typeof s.extract=="function"?(j=s.extract(E.target,s),I=!0):typeof s.deserialize=="function"&&(j=s.deserialize(j)),I)p(j);else{var S=function(){try{O=E.target.responseText}catch{O=j}var G=new Error(O);G.code=E.target.status,G.response=j,q(G)};x.status===0?setTimeout(function(){_||S()}):S()}}catch(G){q(G)}},x.ontimeout=function(E){_=!0;var I=new Error("Request timed out");I.code=E.target.status,q(I)},typeof s.config=="function"&&(x=s.config(x,s,h)||x,x!==B&&(U=x.abort,x.abort=function(){R=!0,U.call(this)})),C==null?x.send():typeof s.serialize=="function"?x.send(s.serialize(C)):C instanceof n.FormData||C instanceof n.URLSearchParams?x.send(C):x.send(JSON.stringify(C))}),jsonp:m(function(h,s,p,q){var b=s.callbackName||"_mithril_"+Math.round(Math.random()*1e16)+"_"+l++,C=n.document.createElement("script");n[b]=function(A){delete n[b],C.parentNode.removeChild(C),p(A)},C.onerror=function(){delete n[b],C.parentNode.removeChild(C),q(new Error("JSONP request failed"))},C.src=h+(h.indexOf("?")<0?"?":"&")+encodeURIComponent(s.callbackKey||"callback")+"="+encodeURIComponent(b),n.document.documentElement.appendChild(C)})}}});var Mt=d((an,zt)=>{"use strict";var Pr=Ue(),Tr=oe();zt.exports=jt()(typeof window<"u"?window:null,Pr,Tr.redraw)});var He=d((fn,dt)=>{"use strict";function Rt(n){try{return decodeURIComponent(n)}catch{return n}}dt.exports=function(n){if(n===""||n==null)return{};n.charAt(0)==="?"&&(n=n.slice(1));for(var a=n.split("&"),u={},l={},y=0;y<a.length;y++){var m=a[y].split("="),c=Rt(m[0]),h=m.length===2?Rt(m[1]):"";h==="true"?h=!0:h==="false"&&(h=!1);var s=c.split(/\]\[?|\[/),p=l;c.indexOf("[")>-1&&s.pop();for(var q=0;q<s.length;q++){var b=s[q],C=s[q+1],A=C==""||!isNaN(parseInt(C,10));if(b===""){var c=s.slice(0,q).join();u[c]==null&&(u[c]=Array.isArray(p)?p.length:0),b=u[c]++}else if(b==="__proto__")break;if(q===s.length-1)p[b]=h;else{var T=Object.getOwnPropertyDescriptor(p,b);T!=null&&(T=T.value),T==null&&(p[b]=T=A?[]:{}),p=T}}}return l}});var he=d((un,Lt)=>{"use strict";var jr=He();Lt.exports=function(n){var a=n.indexOf("?"),u=n.indexOf("#"),l=u<0?n.length:u,y=a<0?l:a,m=n.slice(0,y).replace(/\/{2,}/g,"/");return m?(m[0]!=="/"&&(m="/"+m),m.length>1&&m[m.length-1]==="/"&&(m=m.slice(0,-1))):m="/",{path:m,params:a<0?{}:jr(n.slice(a+1,l))}}});var Dt=d((ln,It)=>{"use strict";var zr=he();It.exports=function(n){var a=zr(n),u=Object.keys(a.params),l=[],y=new RegExp("^"+a.path.replace(/:([^\/.-]+)(\.{3}|\.(?!\.)|-)?|[\\^$*+.()|\[\]{}]/g,function(m,c,h){return c==null?"\\"+m:(l.push({k:c,r:h==="..."}),h==="..."?"(.*)":h==="."?"([^/]+)\\.":"([^/]+)"+(h||""))})+"$");return function(m){for(var c=0;c<u.length;c++)if(a.params[u[c]]!==m.params[u[c]])return!1;if(!l.length)return y.test(m.path);var h=y.exec(m.path);if(h==null)return!1;for(var c=0;c<l.length;c++)m.params[l[c].k]=l[c].r?h[c+1]:decodeURIComponent(h[c+1]);return!0}}});var Se=d((cn,_t)=>{"use strict";var Ut=ie(),vt=new RegExp("^(?:key|oninit|oncreate|onbeforeupdate|onupdate|onbeforeremove|onremove)$");_t.exports=function(n,a){var u={};if(a!=null)for(var l in n)Ut.call(n,l)&&!vt.test(l)&&a.indexOf(l)<0&&(u[l]=n[l]);else for(var l in n)Ut.call(n,l)&&!vt.test(l)&&(u[l]=n[l]);return u}});var St=d((sn,Ht)=>{"use strict";var Mr=Y(),Rr=Le(),dr=Ue(),Vt=me(),Ft=he(),Lr=Dt(),Ir=Fe(),Dr=Se(),Ke={};function Ur(n){try{return decodeURIComponent(n)}catch{return n}}Ht.exports=function(n,a){var u=n==null?null:typeof n.setImmediate=="function"?n.setImmediate:n.setTimeout,l=dr.resolve(),y=!1,m=!1,c=0,h,s,p=Ke,q,b,C,A,T={onbeforeupdate:function(){return c=c?2:1,!(!c||Ke===p)},onremove:function(){n.removeEventListener("popstate",_,!1),n.removeEventListener("hashchange",R,!1)},view:function(){if(!(!c||Ke===p)){var N=[Mr(q,b.key,b)];return p&&(N=p.render(N[0])),N}}},x=U.SKIP={};function R(){y=!1;var N=n.location.hash;U.prefix[0]!=="#"&&(N=n.location.search+N,U.prefix[0]!=="?"&&(N=n.location.pathname+N,N[0]!=="/"&&(N="/"+N)));var M=N.concat().replace(/(?:%[a-f89][a-f0-9])+/gim,Ur).slice(U.prefix.length),E=Ft(M);Ir(E.params,n.history.state);function I(O){console.error(O),B(s,null,{replace:!0})}j(0);function j(O){for(;O<h.length;O++)if(h[O].check(E)){var S=h[O].component,G=h[O].route,$=S,Z=A=function(X){if(Z===A){if(X===x)return j(O+1);q=X!=null&&(typeof X.view=="function"||typeof X=="function")?X:"div",b=E.params,C=M,A=null,p=S.render?S:null,c===2?a.redraw():(c=2,a.redraw.sync())}};S.view||typeof S=="function"?(S={},Z($)):S.onmatch?l.then(function(){return S.onmatch(E.params,M,G)}).then(Z,M===s?null:I):Z("div");return}if(M===s)throw new Error("Could not resolve default route "+s+".");B(s,null,{replace:!0})}}function _(){y||(y=!0,u(R))}function B(N,M,E){if(N=Vt(N,M),m){_();var I=E?E.state:null,j=E?E.title:null;E&&E.replace?n.history.replaceState(I,j,U.prefix+N):n.history.pushState(I,j,U.prefix+N)}else n.location.href=U.prefix+N}function U(N,M,E){if(!N)throw new TypeError("DOM element being rendered to does not exist.");if(h=Object.keys(E).map(function(j){if(j[0]!=="/")throw new SyntaxError("Routes must start with a '/'.");if(/:([^\/\.-]+)(\.{3})?:/.test(j))throw new SyntaxError("Route parameter names must be separated with either '/', '.', or '-'.");return{route:j,component:E[j],check:Lr(j)}}),s=M,M!=null){var I=Ft(M);if(!h.some(function(j){return j.check(I)}))throw new ReferenceError("Default route doesn't match any known routes.")}typeof n.history.pushState=="function"?n.addEventListener("popstate",_,!1):U.prefix[0]==="#"&&n.addEventListener("hashchange",R,!1),m=!0,a.mount(N,T),R()}return U.set=function(N,M,E){A!=null&&(E=E||{},E.replace=!0),A=null,B(N,M,E)},U.get=function(){return C},U.prefix="#!",U.Link={view:function(N){var M=Rr(N.attrs.selector||"a",Dr(N.attrs,["options","params","selector","onclick"]),N.children),E,I,j;return(M.attrs.disabled=!!M.attrs.disabled)?(M.attrs.href=null,M.attrs["aria-disabled"]="true"):(E=N.attrs.options,I=N.attrs.onclick,j=Vt(M.attrs.href,N.attrs.params),M.attrs.href=U.prefix+j,M.attrs.onclick=function(O){var S;typeof I=="function"?S=I.call(O.currentTarget,O):I==null||typeof I!="object"||typeof I.handleEvent=="function"&&I.handleEvent(O),S!==!1&&!O.defaultPrevented&&(O.button===0||O.which===0||O.which===1)&&(!O.currentTarget.target||O.currentTarget.target==="_self")&&!O.ctrlKey&&!O.metaKey&&!O.shiftKey&&!O.altKey&&(O.preventDefault(),O.redraw=!1,U.set(j,null,E))}),M}},U.param=function(N){return b&&N!=null?b[N]:b},U}});var Qt=d((on,Kt)=>{"use strict";var vr=oe();Kt.exports=St()(typeof window<"u"?window:null,vr)});var ye=d((mn,Gt)=>{"use strict";var pe=pt(),Jt=Mt(),Bt=oe(),H=function(){return pe.apply(this,arguments)};H.m=pe;H.trust=pe.trust;H.fragment=pe.fragment;H.Fragment="[";H.mount=Bt.mount;H.route=Qt();H.render=_e();H.redraw=Bt.redraw;H.request=Jt.request;H.jsonp=Jt.jsonp;H.parseQueryString=He();H.buildQueryString=Ve();H.parsePathname=he();H.buildPathname=me();H.vnode=Y();H.PromisePolyfill=De();H.censor=Se();Gt.exports=H});var Yt=Re(ye(),1);var Je={};rt(Je,{MithrilComponent:()=>fe,MithrilMount:()=>_r,MithrilUnmount:()=>Vr});var Qe=Re(ye(),1),fe=class{},_r=(n,a)=>{var u=new UnityElement(n);return Qe.default.mount(u,a),u},Vr=n=>{Qe.default.mount(n,null)};var Ge={};rt(Ge,{Realtime:()=>we,RealtimeText:()=>Be});var ge=Re(ye(),1);var we=class extends fe{oncreate(u){var l=u.dom,y=this;this.interval=setInterval(()=>{ge.default.render(l,y.onvalueupdate())},0)}view(u){return(0,ge.default)("panel")}onbeforeremove(u){clearInterval(this.interval)}},Be=class extends we{onvalueupdate(){return(0,ge.default)("text",Math.random().toString())}};var Xt={...Je,...Ge};for(Xe in Xt)globalThis[Xe]=Xt[Xe];var Xe;globalThis.m=Yt.default;
