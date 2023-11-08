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
                    <toggle
                        src="#"
                        align="center"
                        bg-src="#"
                        width={64}
                        height={64}
                        cm-src="#"
                        cm-color="#000000"
                        onvaluechanged={(event) => {
                            console.log(event.target.attrs.value);
                        }}
                    ></toggle>
                </button>
            </image>
        );
    }
}
