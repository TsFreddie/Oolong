import Home from "./Home";
import Menu from "./Menu";

export default class Main extends MithrilComponent {
    oncreate(vnode: m.VnodeDOM<{}, this>) {
        m.route(vnode.dom, "/", {
            "/": Home,
            "/menu": Menu,
        });
    }

    onremove(vnode: m.VnodeDOM<{}, this>) {
        m.mount(vnode.dom, null);
    }

    view() {
        return <panel></panel>;
    }
}
