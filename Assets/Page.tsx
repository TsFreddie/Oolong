export default class Page extends MithrilComponent {
    oncreate(vnode: m.VnodeDOM<{}, this>) {
        m.route.set("/home", vnode);
    }

    view() {
        return (
            <>
                <panel></panel>
            </>
        );
    }
}
