var P = (i, u) => () => (u || i((u = { exports: {} }).exports, u), u.exports);
var G = P((Cr, Ve) => {
    "use strict";
    function Y(i, u, s, c, b, o) {
        return {
            tag: i,
            key: u,
            attrs: s,
            children: c,
            text: b,
            dom: o,
            domSize: void 0,
            state: void 0,
            events: void 0,
            instance: void 0,
        };
    }
    Y.normalize = function (i) {
        return Array.isArray(i)
            ? Y("[", void 0, void 0, Y.normalizeChildren(i), void 0, void 0)
            : i == null || typeof i == "boolean"
            ? null
            : typeof i == "object"
            ? i
            : Y("#", void 0, void 0, String(i), void 0, void 0);
    };
    Y.normalizeChildren = function (i) {
        var u = [];
        if (i.length) {
            for (
                var s = i[0] != null && i[0].key != null, c = 1;
                c < i.length;
                c++
            )
                if ((i[c] != null && i[c].key != null) !== s)
                    throw new TypeError(
                        s && (i[c] != null || typeof i[c] == "boolean")
                            ? "In fragments, vnodes must either all have keys or none have keys. You may wish to consider using an explicit keyed empty fragment, m.fragment({key: ...}), instead of a hole."
                            : "In fragments, vnodes must either all have keys or none have keys."
                    );
            for (var c = 0; c < i.length; c++) u[c] = Y.normalize(i[c]);
        }
        return u;
    };
    Ve.exports = Y;
});
var Ee = P((Er, $e) => {
    "use strict";
    var Bt = G();
    $e.exports = function () {
        var i = arguments[this],
            u = this + 1,
            s;
        if (
            (i == null
                ? (i = {})
                : (typeof i != "object" || i.tag != null || Array.isArray(i)) &&
                  ((i = {}), (u = this)),
            arguments.length === u + 1)
        )
            (s = arguments[u]), Array.isArray(s) || (s = [s]);
        else for (s = []; u < arguments.length; ) s.push(arguments[u++]);
        return Bt("", i.key, i, s);
    };
});
var ie = P((Or, Je) => {
    "use strict";
    Je.exports = {}.hasOwnProperty;
});
var Oe = P((zr, Ge) => {
    "use strict";
    var Gt = G(),
        Wt = Ee(),
        d = ie(),
        Xt =
            /(?:(^|#|\.)([^#\.\[\]]+))|(\[(.+?)(?:\s*=\s*("|'|)((?:\\["'\]]|.)*?)\5)?\])/g,
        Be = {};
    function Yt(i) {
        for (var u in i) if (d.call(i, u)) return !1;
        return !0;
    }
    function Zt(i) {
        for (var u, s = "div", c = [], b = {}; (u = Xt.exec(i)); ) {
            var o = u[1],
                a = u[2];
            if (o === "" && a !== "") s = a;
            else if (o === "#") b.id = a;
            else if (o === ".") c.push(a);
            else if (u[3][0] === "[") {
                var m = u[6];
                m && (m = m.replace(/\\(["'])/g, "$1").replace(/\\\\/g, "\\")),
                    u[4] === "class"
                        ? c.push(m)
                        : (b[u[4]] = m === "" ? m : m || !0);
            }
        }
        return (
            c.length > 0 && (b.className = c.join(" ")),
            (Be[i] = { tag: s, attrs: b })
        );
    }
    function vt(i, u) {
        var s = u.attrs,
            c = d.call(s, "class"),
            b = c ? s.class : s.className;
        if (((u.tag = i.tag), (u.attrs = {}), !Yt(i.attrs))) {
            var o = {};
            for (var a in s) d.call(s, a) && (o[a] = s[a]);
            s = o;
        }
        for (var a in i.attrs)
            d.call(i.attrs, a) &&
                a !== "className" &&
                !d.call(s, a) &&
                (s[a] = i.attrs[a]);
        (b != null || i.attrs.className != null) &&
            (s.className =
                b != null
                    ? i.attrs.className != null
                        ? String(i.attrs.className) + " " + String(b)
                        : b
                    : i.attrs.className != null
                    ? i.attrs.className
                    : null),
            c && (s.class = null);
        for (var a in s)
            if (d.call(s, a) && a !== "key") {
                u.attrs = s;
                break;
            }
        return u;
    }
    function dt(i) {
        if (
            i == null ||
            (typeof i != "string" &&
                typeof i != "function" &&
                typeof i.view != "function")
        )
            throw Error("The selector must be either a string or a component.");
        var u = Wt.apply(1, arguments);
        return typeof i == "string" &&
            ((u.children = Gt.normalizeChildren(u.children)), i !== "[")
            ? vt(Be[i] || Zt(i), u)
            : ((u.tag = i), u);
    }
    Ge.exports = dt;
});
var Xe = P((Nr, We) => {
    "use strict";
    var kt = G();
    We.exports = function (i) {
        return (
            i == null && (i = ""), kt("<", void 0, void 0, i, void 0, void 0)
        );
    };
});
var Ze = P((Tr, Ye) => {
    "use strict";
    var er = G(),
        tr = Ee();
    Ye.exports = function () {
        var i = tr.apply(0, arguments);
        return (
            (i.tag = "["), (i.children = er.normalizeChildren(i.children)), i
        );
    };
});
var de = P((Rr, ve) => {
    "use strict";
    var ze = Oe();
    ze.trust = Xe();
    ze.fragment = Ze();
    ve.exports = ze;
});
var Ne = P((Pr, et) => {
    "use strict";
    var ke = new WeakMap();
    function* rr({ dom: i, domSize: u }, { generation: s } = {}) {
        if (i != null)
            do {
                let { nextSibling: c } = i;
                ke.get(i) === s && (yield i, u--), (i = c);
            } while (u);
    }
    et.exports = { delayedRemoval: ke, domFor: rr };
});
var nt = P((Lr, it) => {
    "use strict";
    var Te = G(),
        rt = Ne(),
        tt = rt.delayedRemoval,
        Re = rt.domFor;
    it.exports = function (i) {
        var u = i && i.document,
            s = {
                svg: "http://www.w3.org/2000/svg",
                math: "http://www.w3.org/1998/Math/MathML",
            },
            c,
            b;
        function o(t) {
            return (t.attrs && t.attrs.xmlns) || s[t.tag];
        }
        function a(t, e) {
            if (t.state !== e)
                throw new Error("'vnode.state' must not be modified.");
        }
        function m(t) {
            var e = t.state;
            try {
                return this.apply(e, arguments);
            } finally {
                a(t, e);
            }
        }
        function A() {
            try {
                return u.activeElement;
            } catch (t) {
                return null;
            }
        }
        function x(t, e, r, n, f, l, g) {
            for (var C = r; C < n; C++) {
                var h = e[C];
                h != null && w(t, h, f, g, l);
            }
        }
        function w(t, e, r, n, f) {
            var l = e.tag;
            if (typeof l == "string")
                switch (
                    ((e.state = {}), e.attrs != null && ye(e.attrs, e, r), l)
                ) {
                    case "#":
                        E(t, e, f);
                        break;
                    case "<":
                        y(t, e, n, f);
                        break;
                    case "[":
                        I(t, e, r, n, f);
                        break;
                    default:
                        W(t, e, r, n, f);
                }
            else J(t, e, r, n, f);
        }
        function E(t, e, r) {
            (e.dom = u.createTextNode(e.children)), $(t, e.dom, r);
        }
        var _ = {
            caption: "table",
            thead: "table",
            tbody: "table",
            tfoot: "table",
            tr: "tbody",
            th: "tr",
            td: "tr",
            colgroup: "table",
            col: "colgroup",
        };
        function y(t, e, r, n) {
            var f = e.children.match(/^\s*?<(\w+)/im) || [],
                l = u.createElement(_[f[1]] || "div");
            r === "http://www.w3.org/2000/svg"
                ? ((l.innerHTML =
                      '<svg xmlns="http://www.w3.org/2000/svg">' +
                      e.children +
                      "</svg>"),
                  (l = l.firstChild))
                : (l.innerHTML = e.children),
                (e.dom = l.firstChild),
                (e.domSize = l.childNodes.length);
            for (var g = u.createDocumentFragment(), C; (C = l.firstChild); )
                g.appendChild(C);
            $(t, g, n);
        }
        function I(t, e, r, n, f) {
            var l = u.createDocumentFragment();
            if (e.children != null) {
                var g = e.children;
                x(l, g, 0, g.length, r, null, n);
            }
            (e.dom = l.firstChild),
                (e.domSize = l.childNodes.length),
                $(t, l, f);
        }
        function W(t, e, r, n, f) {
            var l = e.tag,
                g = e.attrs,
                C = g && g.is;
            n = o(e) || n;
            var h = n
                ? C
                    ? u.createElementNS(n, l, { is: C })
                    : u.createElementNS(n, l)
                : C
                ? u.createElement(l, { is: C })
                : u.createElement(l);
            if (
                ((e.dom = h),
                g != null && Ut(e, g, n),
                $(t, h, f),
                !Ue(e) && e.children != null)
            ) {
                var T = e.children;
                x(h, T, 0, T.length, r, null, n),
                    e.tag === "select" && g != null && _t(e, g);
            }
        }
        function V(t, e) {
            var r;
            if (typeof t.tag.view == "function") {
                if (
                    ((t.state = Object.create(t.tag)),
                    (r = t.state.view),
                    r.$$reentrantLock$$ != null)
                )
                    return;
                r.$$reentrantLock$$ = !0;
            } else {
                if (
                    ((t.state = void 0),
                    (r = t.tag),
                    r.$$reentrantLock$$ != null)
                )
                    return;
                (r.$$reentrantLock$$ = !0),
                    (t.state =
                        t.tag.prototype != null &&
                        typeof t.tag.prototype.view == "function"
                            ? new t.tag(t)
                            : t.tag(t));
            }
            if (
                (ye(t.state, t, e),
                t.attrs != null && ye(t.attrs, t, e),
                (t.instance = Te.normalize(m.call(t.state.view, t))),
                t.instance === t)
            )
                throw Error(
                    "A view cannot return the vnode it received as argument"
                );
            r.$$reentrantLock$$ = null;
        }
        function J(t, e, r, n, f) {
            V(e, r),
                e.instance != null
                    ? (w(t, e.instance, r, n, f),
                      (e.dom = e.instance.dom),
                      (e.domSize = e.dom != null ? e.instance.domSize : 0))
                    : (e.domSize = 0);
        }
        function B(t, e, r, n, f, l) {
            if (!(e === r || (e == null && r == null)))
                if (e == null || e.length === 0) x(t, r, 0, r.length, n, f, l);
                else if (r == null || r.length === 0) k(t, e, 0, e.length);
                else {
                    var g = e[0] != null && e[0].key != null,
                        C = r[0] != null && r[0].key != null,
                        h = 0,
                        T = 0;
                    if (!g) for (; T < e.length && e[T] == null; ) T++;
                    if (!C) for (; h < r.length && r[h] == null; ) h++;
                    if (g !== C)
                        k(t, e, T, e.length), x(t, r, h, r.length, n, f, l);
                    else if (C) {
                        for (
                            var K = e.length - 1,
                                U = r.length - 1,
                                ue,
                                Q,
                                D,
                                S,
                                j,
                                be;
                            K >= T &&
                            U >= h &&
                            ((S = e[K]), (j = r[U]), S.key === j.key);

                        )
                            S !== j && z(t, S, j, n, f, l),
                                j.dom != null && (f = j.dom),
                                K--,
                                U--;
                        for (
                            ;
                            K >= T &&
                            U >= h &&
                            ((Q = e[T]), (D = r[h]), Q.key === D.key);

                        )
                            T++, h++, Q !== D && z(t, Q, D, n, Z(e, T, f), l);
                        for (
                            ;
                            K >= T &&
                            U >= h &&
                            !(h === U || Q.key !== j.key || S.key !== D.key);

                        )
                            (be = Z(e, T, f)),
                                X(t, S, be),
                                S !== D && z(t, S, D, n, be, l),
                                ++h <= --U && X(t, Q, f),
                                Q !== j && z(t, Q, j, n, f, l),
                                j.dom != null && (f = j.dom),
                                T++,
                                K--,
                                (S = e[K]),
                                (j = r[U]),
                                (Q = e[T]),
                                (D = r[h]);
                        for (; K >= T && U >= h && S.key === j.key; )
                            S !== j && z(t, S, j, n, f, l),
                                j.dom != null && (f = j.dom),
                                K--,
                                U--,
                                (S = e[K]),
                                (j = r[U]);
                        if (h > U) k(t, e, T, K + 1);
                        else if (T > K) x(t, r, h, U + 1, n, f, l);
                        else {
                            var Jt = f,
                                Qe = U - h + 1,
                                re = new Array(Qe),
                                qe = 0,
                                M = 0,
                                xe = 2147483647,
                                Ae = 0,
                                ue,
                                Ce;
                            for (M = 0; M < Qe; M++) re[M] = -1;
                            for (M = U; M >= h; M--) {
                                ue == null && (ue = N(e, T, K + 1)), (j = r[M]);
                                var v = ue[j.key];
                                v != null &&
                                    ((xe = v < xe ? v : -1),
                                    (re[M - h] = v),
                                    (S = e[v]),
                                    (e[v] = null),
                                    S !== j && z(t, S, j, n, f, l),
                                    j.dom != null && (f = j.dom),
                                    Ae++);
                            }
                            if (
                                ((f = Jt),
                                Ae !== K - T + 1 && k(t, e, T, K + 1),
                                Ae === 0)
                            )
                                x(t, r, h, U + 1, n, f, l);
                            else if (xe === -1)
                                for (
                                    Ce = ne(re), qe = Ce.length - 1, M = U;
                                    M >= h;
                                    M--
                                )
                                    (D = r[M]),
                                        re[M - h] === -1
                                            ? w(t, D, n, l, f)
                                            : Ce[qe] === M - h
                                            ? qe--
                                            : X(t, D, f),
                                        D.dom != null && (f = r[M].dom);
                            else
                                for (M = U; M >= h; M--)
                                    (D = r[M]),
                                        re[M - h] === -1 && w(t, D, n, l, f),
                                        D.dom != null && (f = r[M].dom);
                        }
                    } else {
                        var we = e.length < r.length ? e.length : r.length;
                        for (h = h < T ? h : T; h < we; h++)
                            (Q = e[h]),
                                (D = r[h]),
                                !(Q === D || (Q == null && D == null)) &&
                                    (Q == null
                                        ? w(t, D, n, l, Z(e, h + 1, f))
                                        : D == null
                                        ? ae(t, Q)
                                        : z(t, Q, D, n, Z(e, h + 1, f), l));
                        e.length > we && k(t, e, h, e.length),
                            r.length > we && x(t, r, h, r.length, n, f, l);
                    }
                }
        }
        function z(t, e, r, n, f, l) {
            var g = e.tag,
                C = r.tag;
            if (g === C) {
                if (((r.state = e.state), (r.events = e.events), $t(r, e)))
                    return;
                if (typeof g == "string")
                    switch ((r.attrs != null && ge(r.attrs, r, n), g)) {
                        case "#":
                            p(e, r);
                            break;
                        case "<":
                            O(t, e, r, l, f);
                            break;
                        case "[":
                            q(t, e, r, n, f, l);
                            break;
                        default:
                            F(e, r, n, l);
                    }
                else L(t, e, r, n, f, l);
            } else ae(t, e), w(t, r, n, l, f);
        }
        function p(t, e) {
            t.children.toString() !== e.children.toString() &&
                (t.dom.nodeValue = e.children),
                (e.dom = t.dom);
        }
        function O(t, e, r, n, f) {
            e.children !== r.children
                ? (fe(t, e, void 0), y(t, r, n, f))
                : ((r.dom = e.dom), (r.domSize = e.domSize));
        }
        function q(t, e, r, n, f, l) {
            B(t, e.children, r.children, n, f, l);
            var g = 0,
                C = r.children;
            if (((r.dom = null), C != null)) {
                for (var h = 0; h < C.length; h++) {
                    var T = C[h];
                    T != null &&
                        T.dom != null &&
                        (r.dom == null && (r.dom = T.dom),
                        (g += T.domSize || 1));
                }
                g !== 1 && (r.domSize = g);
            }
        }
        function F(t, e, r, n) {
            var f = (e.dom = t.dom);
            (n = o(e) || n),
                e.tag === "textarea" && e.attrs == null && (e.attrs = {}),
                St(e, t.attrs, e.attrs, n),
                Ue(e) || B(f, t.children, e.children, r, null, n);
        }
        function L(t, e, r, n, f, l) {
            if (
                ((r.instance = Te.normalize(m.call(r.state.view, r))),
                r.instance === r)
            )
                throw Error(
                    "A view cannot return the vnode it received as argument"
                );
            ge(r.state, r, n),
                r.attrs != null && ge(r.attrs, r, n),
                r.instance != null
                    ? (e.instance == null
                          ? w(t, r.instance, n, l, f)
                          : z(t, e.instance, r.instance, n, f, l),
                      (r.dom = r.instance.dom),
                      (r.domSize = r.instance.domSize))
                    : e.instance != null
                    ? (ae(t, e.instance), (r.dom = void 0), (r.domSize = 0))
                    : ((r.dom = e.dom), (r.domSize = e.domSize));
        }
        function N(t, e, r) {
            for (var n = Object.create(null); e < r; e++) {
                var f = t[e];
                if (f != null) {
                    var l = f.key;
                    l != null && (n[l] = e);
                }
            }
            return n;
        }
        var R = [];
        function ne(t) {
            for (
                var e = [0],
                    r = 0,
                    n = 0,
                    f = 0,
                    l = (R.length = t.length),
                    f = 0;
                f < l;
                f++
            )
                R[f] = t[f];
            for (var f = 0; f < l; ++f)
                if (t[f] !== -1) {
                    var g = e[e.length - 1];
                    if (t[g] < t[f]) {
                        (R[f] = g), e.push(f);
                        continue;
                    }
                    for (r = 0, n = e.length - 1; r < n; ) {
                        var C = (r >>> 1) + (n >>> 1) + (r & n & 1);
                        t[e[C]] < t[f] ? (r = C + 1) : (n = C);
                    }
                    t[f] < t[e[r]] && (r > 0 && (R[f] = e[r - 1]), (e[r] = f));
                }
            for (r = e.length, n = e[r - 1]; r-- > 0; ) (e[r] = n), (n = R[n]);
            return (R.length = 0), e;
        }
        function Z(t, e, r) {
            for (; e < t.length; e++)
                if (t[e] != null && t[e].dom != null) return t[e].dom;
            return r;
        }
        function X(t, e, r) {
            if (e.dom != null) {
                var n;
                if (e.domSize == null) n = e.dom;
                else {
                    n = u.createDocumentFragment();
                    for (var f of Re(e)) n.appendChild(f);
                }
                $(t, n, r);
            }
        }
        function $(t, e, r) {
            r != null ? t.insertBefore(e, r) : t.appendChild(e);
        }
        function Ue(t) {
            if (
                t.attrs == null ||
                (t.attrs.contenteditable == null &&
                    t.attrs.contentEditable == null)
            )
                return !1;
            var e = t.children;
            if (e != null && e.length === 1 && e[0].tag === "<") {
                var r = e[0].children;
                t.dom.innerHTML !== r && (t.dom.innerHTML = r);
            } else if (e != null && e.length !== 0)
                throw new Error(
                    "Child node of a contenteditable must be trusted."
                );
            return !0;
        }
        function k(t, e, r, n) {
            for (var f = r; f < n; f++) {
                var l = e[f];
                l != null && ae(t, l);
            }
        }
        function ae(t, e) {
            var r = 0,
                n = e.state,
                f,
                l;
            if (
                typeof e.tag != "string" &&
                typeof e.state.onbeforeremove == "function"
            ) {
                var g = m.call(e.state.onbeforeremove, e);
                g != null && typeof g.then == "function" && ((r = 1), (f = g));
            }
            if (e.attrs && typeof e.attrs.onbeforeremove == "function") {
                var g = m.call(e.attrs.onbeforeremove, e);
                g != null && typeof g.then == "function" && ((r |= 2), (l = g));
            }
            a(e, n);
            var C;
            if (!r) ee(e), fe(t, e, C);
            else {
                C = b;
                for (var h of Re(e)) tt.set(h, C);
                f != null &&
                    f.finally(function () {
                        r & 1 && ((r &= 2), r || (a(e, n), ee(e), fe(t, e, C)));
                    }),
                    l != null &&
                        l.finally(function () {
                            r & 2 &&
                                ((r &= 1), r || (a(e, n), ee(e), fe(t, e, C)));
                        });
            }
        }
        function fe(t, e, r) {
            if (e.dom != null)
                if (e.domSize == null)
                    tt.get(e.dom) === r && t.removeChild(e.dom);
                else for (var n of Re(e, { generation: r })) t.removeChild(n);
        }
        function ee(t) {
            if (
                (typeof t.tag != "string" &&
                    typeof t.state.onremove == "function" &&
                    m.call(t.state.onremove, t),
                t.attrs &&
                    typeof t.attrs.onremove == "function" &&
                    m.call(t.attrs.onremove, t),
                typeof t.tag != "string")
            )
                t.instance != null && ee(t.instance);
            else {
                var e = t.children;
                if (Array.isArray(e))
                    for (var r = 0; r < e.length; r++) {
                        var n = e[r];
                        n != null && ee(n);
                    }
            }
        }
        function Ut(t, e, r) {
            t.tag === "input" &&
                e.type != null &&
                t.dom.setAttribute("type", e.type);
            var n = e != null && t.tag === "input" && e.type === "file";
            for (var f in e) me(t, f, null, e[f], r, n);
        }
        function me(t, e, r, n, f, l) {
            if (
                !(
                    e === "key" ||
                    e === "is" ||
                    n == null ||
                    He(e) ||
                    (r === n && !Kt(t, e) && typeof n != "object") ||
                    (e === "type" && t.tag === "input")
                )
            ) {
                if (e[0] === "o" && e[1] === "n") return Ke(t, e, n);
                if (e.slice(0, 6) === "xlink:")
                    t.dom.setAttributeNS(
                        "http://www.w3.org/1999/xlink",
                        e.slice(6),
                        n
                    );
                else if (e === "style") Se(t.dom, r, n);
                else if (_e(t, e, f)) {
                    if (e === "value") {
                        if (
                            ((t.tag === "input" || t.tag === "textarea") &&
                                t.dom.value === "" + n &&
                                (l || t.dom === A())) ||
                            (t.tag === "select" &&
                                r !== null &&
                                t.dom.value === "" + n) ||
                            (t.tag === "option" &&
                                r !== null &&
                                t.dom.value === "" + n)
                        )
                            return;
                        if (l && "" + n != "") {
                            console.error(
                                "`value` is read-only on file inputs!"
                            );
                            return;
                        }
                    }
                    t.dom[e] = n;
                } else
                    typeof n == "boolean"
                        ? n
                            ? t.dom.setAttribute(e, "")
                            : t.dom.removeAttribute(e)
                        : t.dom.setAttribute(
                              e === "className" ? "class" : e,
                              n
                          );
            }
        }
        function Ht(t, e, r, n) {
            if (!(e === "key" || e === "is" || r == null || He(e)))
                if (e[0] === "o" && e[1] === "n") Ke(t, e, void 0);
                else if (e === "style") Se(t.dom, r, null);
                else if (
                    _e(t, e, n) &&
                    e !== "className" &&
                    e !== "title" &&
                    !(
                        e === "value" &&
                        (t.tag === "option" ||
                            (t.tag === "select" &&
                                t.dom.selectedIndex === -1 &&
                                t.dom === A()))
                    ) &&
                    !(t.tag === "input" && e === "type")
                )
                    t.dom[e] = null;
                else {
                    var f = e.indexOf(":");
                    f !== -1 && (e = e.slice(f + 1)),
                        r !== !1 &&
                            t.dom.removeAttribute(
                                e === "className" ? "class" : e
                            );
                }
        }
        function _t(t, e) {
            if ("value" in e)
                if (e.value === null)
                    t.dom.selectedIndex !== -1 && (t.dom.value = null);
                else {
                    var r = "" + e.value;
                    (t.dom.value !== r || t.dom.selectedIndex === -1) &&
                        (t.dom.value = r);
                }
            "selectedIndex" in e &&
                me(t, "selectedIndex", null, e.selectedIndex, void 0);
        }
        function St(t, e, r, n) {
            if (
                (e &&
                    e === r &&
                    console.warn(
                        "Don't reuse attrs object, use new object for every redraw, this will throw in next major"
                    ),
                r != null)
            ) {
                t.tag === "input" &&
                    r.type != null &&
                    t.dom.setAttribute("type", r.type);
                var f = t.tag === "input" && r.type === "file";
                for (var l in r) me(t, l, e && e[l], r[l], n, f);
            }
            var g;
            if (e != null)
                for (var l in e)
                    (g = e[l]) != null &&
                        (r == null || r[l] == null) &&
                        Ht(t, l, g, n);
        }
        function Kt(t, e) {
            return (
                e === "value" ||
                e === "checked" ||
                e === "selectedIndex" ||
                (e === "selected" && t.dom === A()) ||
                (t.tag === "option" && t.dom.parentNode === u.activeElement)
            );
        }
        function He(t) {
            return (
                t === "oninit" ||
                t === "oncreate" ||
                t === "onupdate" ||
                t === "onremove" ||
                t === "onbeforeremove" ||
                t === "onbeforeupdate"
            );
        }
        function _e(t, e, r) {
            return (
                r === void 0 &&
                (t.tag.indexOf("-") > -1 ||
                    (t.attrs != null && t.attrs.is) ||
                    (e !== "href" &&
                        e !== "list" &&
                        e !== "form" &&
                        e !== "width" &&
                        e !== "height")) &&
                e in t.dom
            );
        }
        var Qt = /[A-Z]/g;
        function Vt(t) {
            return "-" + t.toLowerCase();
        }
        function he(t) {
            return t[0] === "-" && t[1] === "-"
                ? t
                : t === "cssFloat"
                ? "float"
                : t.replace(Qt, Vt);
        }
        function Se(t, e, r) {
            if (e !== r)
                if (r == null) t.style = "";
                else if (typeof r != "object") t.style = r;
                else if (e == null || typeof e != "object") {
                    t.style.cssText = "";
                    for (var n in r) {
                        var f = r[n];
                        f != null && t.style.setProperty(he(n), String(f));
                    }
                } else {
                    for (var n in r) {
                        var f = r[n];
                        f != null &&
                            (f = String(f)) !== String(e[n]) &&
                            t.style.setProperty(he(n), f);
                    }
                    for (var n in e)
                        e[n] != null &&
                            r[n] == null &&
                            t.style.removeProperty(he(n));
                }
        }
        function pe() {
            this._ = c;
        }
        (pe.prototype = Object.create(null)),
            (pe.prototype.handleEvent = function (t) {
                var e = this["on" + t.type],
                    r;
                typeof e == "function"
                    ? (r = e.call(t.currentTarget, t))
                    : typeof e.handleEvent == "function" && e.handleEvent(t),
                    this._ && t.redraw !== !1 && (0, this._)(),
                    r === !1 && (t.preventDefault(), t.stopPropagation());
            });
        function Ke(t, e, r) {
            if (t.events != null) {
                if (((t.events._ = c), t.events[e] === r)) return;
                r != null && (typeof r == "function" || typeof r == "object")
                    ? (t.events[e] == null &&
                          t.dom.addEventListener(e.slice(2), t.events, !1),
                      (t.events[e] = r))
                    : (t.events[e] != null &&
                          t.dom.removeEventListener(e.slice(2), t.events, !1),
                      (t.events[e] = void 0));
            } else
                r != null &&
                    (typeof r == "function" || typeof r == "object") &&
                    ((t.events = new pe()),
                    t.dom.addEventListener(e.slice(2), t.events, !1),
                    (t.events[e] = r));
        }
        function ye(t, e, r) {
            typeof t.oninit == "function" && m.call(t.oninit, e),
                typeof t.oncreate == "function" &&
                    r.push(m.bind(t.oncreate, e));
        }
        function ge(t, e, r) {
            typeof t.onupdate == "function" && r.push(m.bind(t.onupdate, e));
        }
        function $t(t, e) {
            do {
                if (
                    t.attrs != null &&
                    typeof t.attrs.onbeforeupdate == "function"
                ) {
                    var r = m.call(t.attrs.onbeforeupdate, t, e);
                    if (r !== void 0 && !r) break;
                }
                if (
                    typeof t.tag != "string" &&
                    typeof t.state.onbeforeupdate == "function"
                ) {
                    var r = m.call(t.state.onbeforeupdate, t, e);
                    if (r !== void 0 && !r) break;
                }
                return !1;
            } while (!1);
            return (
                (t.dom = e.dom),
                (t.domSize = e.domSize),
                (t.instance = e.instance),
                (t.attrs = e.attrs),
                (t.children = e.children),
                (t.text = e.text),
                !0
            );
        }
        var te;
        return function (t, e, r) {
            if (!t)
                throw new TypeError(
                    "DOM element being rendered to does not exist."
                );
            if (te != null && t.contains(te))
                throw new TypeError(
                    "Node is currently being rendered to and thus is locked."
                );
            var n = c,
                f = te,
                l = [],
                g = A(),
                C = t.namespaceURI;
            (te = t), (c = typeof r == "function" ? r : void 0), (b = {});
            try {
                t.vnodes == null && (t.textContent = ""),
                    (e = Te.normalizeChildren(Array.isArray(e) ? e : [e])),
                    B(
                        t,
                        t.vnodes,
                        e,
                        l,
                        null,
                        C === "http://www.w3.org/1999/xhtml" ? void 0 : C
                    ),
                    (t.vnodes = e),
                    g != null &&
                        A() !== g &&
                        typeof g.focus == "function" &&
                        g.focus();
                for (var h = 0; h < l.length; h++) l[h]();
            } finally {
                (c = n), (te = f);
            }
        };
    };
});
var Pe = P((jr, at) => {
    "use strict";
    at.exports = nt()(typeof window != "undefined" ? window : null);
});
var lt = P((Mr, ut) => {
    "use strict";
    var ft = G();
    ut.exports = function (i, u, s) {
        var c = [],
            b = !1,
            o = -1;
        function a() {
            for (o = 0; o < c.length; o += 2)
                try {
                    i(c[o], ft(c[o + 1]), m);
                } catch (x) {
                    s.error(x);
                }
            o = -1;
        }
        function m() {
            b ||
                ((b = !0),
                u(function () {
                    (b = !1), a();
                }));
        }
        m.sync = a;
        function A(x, w) {
            if (w != null && w.view == null && typeof w != "function")
                throw new TypeError(
                    "m.mount expects a component, not a vnode."
                );
            var E = c.indexOf(x);
            E >= 0 && (c.splice(E, 2), E <= o && (o -= 2), i(x, [])),
                w != null && (c.push(x, w), i(x, ft(w), m));
        }
        return { mount: A, redraw: m };
    };
});
var le = P((Dr, ct) => {
    "use strict";
    var ir = Pe();
    ct.exports = lt()(
        ir,
        typeof requestAnimationFrame != "undefined"
            ? requestAnimationFrame
            : null,
        typeof console != "undefined" ? console : null
    );
});
var Le = P((Fr, st) => {
    "use strict";
    st.exports = function (i) {
        if (Object.prototype.toString.call(i) !== "[object Object]") return "";
        var u = [];
        for (var s in i) c(s, i[s]);
        return u.join("&");
        function c(b, o) {
            if (Array.isArray(o))
                for (var a = 0; a < o.length; a++) c(b + "[" + a + "]", o[a]);
            else if (Object.prototype.toString.call(o) === "[object Object]")
                for (var a in o) c(b + "[" + a + "]", o[a]);
            else
                u.push(
                    encodeURIComponent(b) +
                        (o != null && o !== ""
                            ? "=" + encodeURIComponent(o)
                            : "")
                );
        }
    };
});
var je = P((Ir, ot) => {
    "use strict";
    var nr = ie();
    ot.exports =
        Object.assign ||
        function (i, u) {
            for (var s in u) nr.call(u, s) && (i[s] = u[s]);
        };
});
var ce = P((Ur, mt) => {
    "use strict";
    var ar = Le(),
        fr = je();
    mt.exports = function (i, u) {
        if (/:([^\/\.-]+)(\.{3})?:/.test(i))
            throw new SyntaxError(
                "Template parameter names must be separated by either a '/', '-', or '.'."
            );
        if (u == null) return i;
        var s = i.indexOf("?"),
            c = i.indexOf("#"),
            b = c < 0 ? i.length : c,
            o = s < 0 ? b : s,
            a = i.slice(0, o),
            m = {};
        fr(m, u);
        var A = a.replace(/:([^\/\.-]+)(\.{3})?/g, function (W, V, J) {
                return (
                    delete m[V],
                    u[V] == null
                        ? W
                        : J
                        ? u[V]
                        : encodeURIComponent(String(u[V]))
                );
            }),
            x = A.indexOf("?"),
            w = A.indexOf("#"),
            E = w < 0 ? A.length : w,
            _ = x < 0 ? E : x,
            y = A.slice(0, _);
        s >= 0 && (y += i.slice(s, b)),
            x >= 0 && (y += (s < 0 ? "?" : "&") + A.slice(x, E));
        var I = ar(m);
        return (
            I && (y += (s < 0 && x < 0 ? "?" : "&") + I),
            c >= 0 && (y += i.slice(c)),
            w >= 0 && (y += (c < 0 ? "" : "&") + A.slice(w)),
            y
        );
    };
});
var yt = P((Hr, pt) => {
    "use strict";
    var ur = ce(),
        ht = ie();
    pt.exports = function (i, u) {
        function s(o) {
            return new Promise(o);
        }
        function c(o, a) {
            return new Promise(function (m, A) {
                o = ur(o, a.params);
                var x = a.method != null ? a.method.toUpperCase() : "GET",
                    w = a.body,
                    E =
                        (a.serialize == null ||
                            a.serialize === JSON.serialize) &&
                        !(
                            w instanceof i.FormData ||
                            w instanceof i.URLSearchParams
                        ),
                    _ =
                        a.responseType ||
                        (typeof a.extract == "function" ? "" : "json"),
                    y = new i.XMLHttpRequest(),
                    I = !1,
                    W = !1,
                    V = y,
                    J,
                    B = y.abort;
                (y.abort = function () {
                    (I = !0), B.call(this);
                }),
                    y.open(
                        x,
                        o,
                        a.async !== !1,
                        typeof a.user == "string" ? a.user : void 0,
                        typeof a.password == "string" ? a.password : void 0
                    ),
                    E &&
                        w != null &&
                        !b(a, "content-type") &&
                        y.setRequestHeader(
                            "Content-Type",
                            "application/json; charset=utf-8"
                        ),
                    typeof a.deserialize != "function" &&
                        !b(a, "accept") &&
                        y.setRequestHeader(
                            "Accept",
                            "application/json, text/*"
                        ),
                    a.withCredentials &&
                        (y.withCredentials = a.withCredentials),
                    a.timeout && (y.timeout = a.timeout),
                    (y.responseType = _);
                for (var z in a.headers)
                    ht.call(a.headers, z) &&
                        y.setRequestHeader(z, a.headers[z]);
                (y.onreadystatechange = function (p) {
                    if (!I && p.target.readyState === 4)
                        try {
                            var O =
                                    (p.target.status >= 200 &&
                                        p.target.status < 300) ||
                                    p.target.status === 304 ||
                                    /^file:\/\//i.test(o),
                                q = p.target.response,
                                F;
                            if (_ === "json") {
                                if (
                                    !p.target.responseType &&
                                    typeof a.extract != "function"
                                )
                                    try {
                                        q = JSON.parse(p.target.responseText);
                                    } catch (R) {
                                        q = null;
                                    }
                            } else
                                (!_ || _ === "text") &&
                                    q == null &&
                                    (q = p.target.responseText);
                            if (
                                (typeof a.extract == "function"
                                    ? ((q = a.extract(p.target, a)), (O = !0))
                                    : typeof a.deserialize == "function" &&
                                      (q = a.deserialize(q)),
                                O)
                            ) {
                                if (typeof a.type == "function")
                                    if (Array.isArray(q))
                                        for (var L = 0; L < q.length; L++)
                                            q[L] = new a.type(q[L]);
                                    else q = new a.type(q);
                                m(q);
                            } else {
                                var N = function () {
                                    try {
                                        F = p.target.responseText;
                                    } catch (ne) {
                                        F = q;
                                    }
                                    var R = new Error(F);
                                    (R.code = p.target.status),
                                        (R.response = q),
                                        A(R);
                                };
                                y.status === 0
                                    ? setTimeout(function () {
                                          W || N();
                                      })
                                    : N();
                            }
                        } catch (R) {
                            A(R);
                        }
                }),
                    (y.ontimeout = function (p) {
                        W = !0;
                        var O = new Error("Request timed out");
                        (O.code = p.target.status), A(O);
                    }),
                    typeof a.config == "function" &&
                        ((y = a.config(y, a, o) || y),
                        y !== V &&
                            ((J = y.abort),
                            (y.abort = function () {
                                (I = !0), J.call(this);
                            }))),
                    w == null
                        ? y.send()
                        : typeof a.serialize == "function"
                        ? y.send(a.serialize(w))
                        : w instanceof i.FormData ||
                          w instanceof i.URLSearchParams
                        ? y.send(w)
                        : y.send(JSON.stringify(w));
            });
        }
        (s.prototype = Promise.prototype), (s.__proto__ = Promise);
        function b(o, a) {
            for (var m in o.headers)
                if (ht.call(o.headers, m) && m.toLowerCase() === a) return !0;
            return !1;
        }
        return {
            request: function (o, a) {
                typeof o != "string"
                    ? ((a = o), (o = o.url))
                    : a == null && (a = {});
                var m = c(o, a);
                if (a.background === !0) return m;
                var A = 0;
                function x() {
                    --A === 0 && typeof u == "function" && u();
                }
                return w(m);
                function w(E) {
                    var _ = E.then;
                    return (
                        (E.constructor = s),
                        (E.then = function () {
                            A++;
                            var y = _.apply(E, arguments);
                            return (
                                y.then(x, function (I) {
                                    if ((x(), A === 0)) throw I;
                                }),
                                w(y)
                            );
                        }),
                        E
                    );
                }
            },
        };
    };
});
var wt = P((_r, gt) => {
    "use strict";
    var lr = le();
    gt.exports = yt()(typeof window != "undefined" ? window : null, lr.redraw);
});
var Me = P((Sr, qt) => {
    "use strict";
    function bt(i) {
        try {
            return decodeURIComponent(i);
        } catch (u) {
            return i;
        }
    }
    qt.exports = function (i) {
        if (i === "" || i == null) return {};
        i.charAt(0) === "?" && (i = i.slice(1));
        for (var u = i.split("&"), s = {}, c = {}, b = 0; b < u.length; b++) {
            var o = u[b].split("="),
                a = bt(o[0]),
                m = o.length === 2 ? bt(o[1]) : "";
            m === "true" ? (m = !0) : m === "false" && (m = !1);
            var A = a.split(/\]\[?|\[/),
                x = c;
            a.indexOf("[") > -1 && A.pop();
            for (var w = 0; w < A.length; w++) {
                var E = A[w],
                    _ = A[w + 1],
                    y = _ == "" || !isNaN(parseInt(_, 10));
                if (E === "") {
                    var a = A.slice(0, w).join();
                    s[a] == null && (s[a] = Array.isArray(x) ? x.length : 0),
                        (E = s[a]++);
                } else if (E === "__proto__") break;
                if (w === A.length - 1) x[E] = m;
                else {
                    var I = Object.getOwnPropertyDescriptor(x, E);
                    I != null && (I = I.value),
                        I == null && (x[E] = I = y ? [] : {}),
                        (x = I);
                }
            }
        }
        return c;
    };
});
var se = P((Kr, xt) => {
    "use strict";
    var cr = Me();
    xt.exports = function (i) {
        var u = i.indexOf("?"),
            s = i.indexOf("#"),
            c = s < 0 ? i.length : s,
            b = u < 0 ? c : u,
            o = i.slice(0, b).replace(/\/{2,}/g, "/");
        return (
            o ? o[0] !== "/" && (o = "/" + o) : (o = "/"),
            { path: o, params: u < 0 ? {} : cr(i.slice(u + 1, c)) }
        );
    };
});
var Ct = P((Qr, At) => {
    "use strict";
    var sr = se();
    At.exports = function (i) {
        var u = sr(i),
            s = Object.keys(u.params),
            c = [],
            b = new RegExp(
                "^" +
                    u.path.replace(
                        /:([^\/.-]+)(\.{3}|\.(?!\.)|-)?|[\\^$*+.()|\[\]{}]/g,
                        function (o, a, m) {
                            return a == null
                                ? "\\" + o
                                : (c.push({ k: a, r: m === "..." }),
                                  m === "..."
                                      ? "(.*)"
                                      : m === "."
                                      ? "([^/]+)\\."
                                      : "([^/]+)" + (m || ""));
                        }
                    ) +
                    "$"
            );
        return function (o) {
            for (var a = 0; a < s.length; a++)
                if (u.params[s[a]] !== o.params[s[a]]) return !1;
            if (!c.length) return b.test(o.path);
            var m = b.exec(o.path);
            if (m == null) return !1;
            for (var a = 0; a < c.length; a++)
                o.params[c[a].k] = c[a].r
                    ? m[a + 1]
                    : decodeURIComponent(m[a + 1]);
            return !0;
        };
    };
});
var De = P((Vr, zt) => {
    "use strict";
    var Et = ie(),
        Ot = new RegExp(
            "^(?:key|oninit|oncreate|onbeforeupdate|onupdate|onbeforeremove|onremove)$"
        );
    zt.exports = function (i, u) {
        var s = {};
        if (u != null)
            for (var c in i)
                Et.call(i, c) &&
                    !Ot.test(c) &&
                    u.indexOf(c) < 0 &&
                    (s[c] = i[c]);
        else for (var c in i) Et.call(i, c) && !Ot.test(c) && (s[c] = i[c]);
        return s;
    };
});
var Pt = P(($r, Rt) => {
    "use strict";
    var or = G(),
        mr = Oe(),
        Nt = ce(),
        Tt = se(),
        hr = Ct(),
        pr = je(),
        yr = De(),
        Fe = {};
    function gr(i) {
        try {
            return decodeURIComponent(i);
        } catch (u) {
            return i;
        }
    }
    Rt.exports = function (i, u) {
        var s =
                i == null
                    ? null
                    : typeof i.setImmediate == "function"
                    ? i.setImmediate
                    : i.setTimeout,
            c = Promise.resolve(),
            b = !1,
            o = !1,
            a = 0,
            m,
            A,
            x = Fe,
            w,
            E,
            _,
            y,
            I = {
                onbeforeupdate: function () {
                    return (a = a ? 2 : 1), !(!a || Fe === x);
                },
                onremove: function () {
                    i.removeEventListener("popstate", J, !1),
                        i.removeEventListener("hashchange", V, !1);
                },
                view: function () {
                    if (!(!a || Fe === x)) {
                        var p = [or(w, E.key, E)];
                        return x && (p = x.render(p[0])), p;
                    }
                },
            },
            W = (z.SKIP = {});
        function V() {
            b = !1;
            var p = i.location.hash;
            z.prefix[0] !== "#" &&
                ((p = i.location.search + p),
                z.prefix[0] !== "?" &&
                    ((p = i.location.pathname + p),
                    p[0] !== "/" && (p = "/" + p)));
            var O = p
                    .concat()
                    .replace(/(?:%[a-f89][a-f0-9])+/gim, gr)
                    .slice(z.prefix.length),
                q = Tt(O);
            pr(q.params, i.history.state);
            function F(N) {
                console.error(N), B(A, null, { replace: !0 });
            }
            L(0);
            function L(N) {
                for (; N < m.length; N++)
                    if (m[N].check(q)) {
                        var R = m[N].component,
                            ne = m[N].route,
                            Z = R,
                            X = (y = function ($) {
                                if (X === y) {
                                    if ($ === W) return L(N + 1);
                                    (w =
                                        $ != null &&
                                        (typeof $.view == "function" ||
                                            typeof $ == "function")
                                            ? $
                                            : "div"),
                                        (E = q.params),
                                        (_ = O),
                                        (y = null),
                                        (x = R.render ? R : null),
                                        a === 2
                                            ? u.redraw()
                                            : ((a = 2), u.redraw.sync());
                                }
                            });
                        R.view || typeof R == "function"
                            ? ((R = {}), X(Z))
                            : R.onmatch
                            ? c
                                  .then(function () {
                                      return R.onmatch(q.params, O, ne);
                                  })
                                  .then(X, O === A ? null : F)
                            : X("div");
                        return;
                    }
                if (O === A)
                    throw new Error(
                        "Could not resolve default route " + A + "."
                    );
                B(A, null, { replace: !0 });
            }
        }
        function J() {
            b || ((b = !0), s(V));
        }
        function B(p, O, q) {
            if (((p = Nt(p, O)), o)) {
                J();
                var F = q ? q.state : null,
                    L = q ? q.title : null;
                q && q.replace
                    ? i.history.replaceState(F, L, z.prefix + p)
                    : i.history.pushState(F, L, z.prefix + p);
            } else i.location.href = z.prefix + p;
        }
        function z(p, O, q) {
            if (!p)
                throw new TypeError(
                    "DOM element being rendered to does not exist."
                );
            if (
                ((m = Object.keys(q).map(function (L) {
                    if (L[0] !== "/")
                        throw new SyntaxError("Routes must start with a '/'.");
                    if (/:([^\/\.-]+)(\.{3})?:/.test(L))
                        throw new SyntaxError(
                            "Route parameter names must be separated with either '/', '.', or '-'."
                        );
                    return { route: L, component: q[L], check: hr(L) };
                })),
                (A = O),
                O != null)
            ) {
                var F = Tt(O);
                if (
                    !m.some(function (L) {
                        return L.check(F);
                    })
                )
                    throw new ReferenceError(
                        "Default route doesn't match any known routes."
                    );
            }
            typeof i.history.pushState == "function"
                ? i.addEventListener("popstate", J, !1)
                : z.prefix[0] === "#" &&
                  i.addEventListener("hashchange", V, !1),
                (o = !0),
                u.mount(p, I),
                V();
        }
        return (
            (z.set = function (p, O, q) {
                y != null && ((q = q || {}), (q.replace = !0)),
                    (y = null),
                    B(p, O, q);
            }),
            (z.get = function () {
                return _;
            }),
            (z.prefix = "#!"),
            (z.Link = {
                view: function (p) {
                    var O = mr(
                            p.attrs.selector || "a",
                            yr(p.attrs, [
                                "options",
                                "params",
                                "selector",
                                "onclick",
                            ]),
                            p.children
                        ),
                        q,
                        F,
                        L;
                    return (
                        (O.attrs.disabled = !!O.attrs.disabled)
                            ? ((O.attrs.href = null),
                              (O.attrs["aria-disabled"] = "true"))
                            : ((q = p.attrs.options),
                              (F = p.attrs.onclick),
                              (L = Nt(O.attrs.href, p.attrs.params)),
                              (O.attrs.href = z.prefix + L),
                              (O.attrs.onclick = function (N) {
                                  var R;
                                  typeof F == "function"
                                      ? (R = F.call(N.currentTarget, N))
                                      : F == null ||
                                        typeof F != "object" ||
                                        (typeof F.handleEvent == "function" &&
                                            F.handleEvent(N)),
                                      R !== !1 &&
                                          !N.defaultPrevented &&
                                          (N.button === 0 ||
                                              N.which === 0 ||
                                              N.which === 1) &&
                                          (!N.currentTarget.target ||
                                              N.currentTarget.target ===
                                                  "_self") &&
                                          !N.ctrlKey &&
                                          !N.metaKey &&
                                          !N.shiftKey &&
                                          !N.altKey &&
                                          (N.preventDefault(),
                                          (N.redraw = !1),
                                          z.set(L, null, q));
                              })),
                        O
                    );
                },
            }),
            (z.param = function (p) {
                return E && p != null ? E[p] : E;
            }),
            z
        );
    };
});
var jt = P((Jr, Lt) => {
    "use strict";
    var wr = le();
    Lt.exports = Pt()(typeof window != "undefined" ? window : null, wr);
});
var Ft = P((Br, Dt) => {
    "use strict";
    var oe = de(),
        br = wt(),
        Mt = le(),
        qr = Ne(),
        H = function () {
            return oe.apply(this, arguments);
        };
    H.m = oe;
    H.trust = oe.trust;
    H.fragment = oe.fragment;
    H.Fragment = "[";
    H.mount = Mt.mount;
    H.route = jt();
    H.render = Pe();
    H.redraw = Mt.redraw;
    H.request = br.request;
    H.parseQueryString = Me();
    H.buildQueryString = Le();
    H.parsePathname = se();
    H.buildPathname = ce();
    H.vnode = G();
    H.censor = De();
    H.domFor = qr.domFor;
    Dt.exports = H;
});
var xr = P((Gr, Ie) => {
    var It = Ft();
    typeof Ie != "undefined" ? (Ie.exports = It) : (window.m = It);
});
export default xr();
