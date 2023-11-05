export default class Menu extends MithrilComponent {
    oncreate(vnode: m.VnodeDOM<{}, this>) {
        super.oncreate(vnode);
        console.log(vnode.dom.mountId);
    }
    view(vnode: m.Vnode<{}, this>) {
        return (
            <button
                src="#"
                color="#550000"
                align="stretch"
                onclick={() => {
                    setTimeout(() => {
                        console.log();
                        this.redraw();
                    }, 500);
                }}
            >
                <text>{Math.random().toString()}</text>
            </button>
        );
    }
}
