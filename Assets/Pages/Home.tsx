export default class Menu extends MithrilComponent {
    private count: number = 0;
    private margin: number = 0;

    view(vnode: m.Vnode<{}, this>) {
        return (
            <image src="#" color="#2c2c2c">
                <button
                    src="#"
                    margin={this.margin}
                    color="#ececec"
                    transition-property="rect"
                    transition-duration="1s"
                    onclick={() => (this.margin = 100 - this.margin)}
                >
                    <scrollrect>
                        <toggle
                            src="#"
                            align="center"
                            width={64}
                            height={64}
                            cm-align="center"
                            cm-src="#"
                            cm-color="#000000"
                            cm-width={32}
                            cm-height={32}
                        ></toggle>
                    </scrollrect>
                </button>
            </image>
        );
    }
}
