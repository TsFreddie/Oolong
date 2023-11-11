export default class Menu extends MithrilComponent {
    private count: number = 0;
    private margin: number = 0;
    private marginX: number = 0;
    private color = "#442c2c";

    oncreate(vnode: m.VnodeDOM<{}, this>) {
        vnode.dom.attrs.x = 2000;
        vnode.dom.attrs.x = 0;
        throw new Error("Method not implemented.");
    }

    view(vnode: m.Vnode<{}, this>) {
        return (
            <canvasgroup
                transition-property="scale, scale-x, alpha, x"
                transition-duration="400ms, 100ms, 100ms, 1s"
                transition-timing-function="cubic-bezier(0,.85,.64,.12)"
                alpha={1}
                scale={1}
                scale-x={1}
                onpointerenter={(e) => {
                    e.target.attrs.scale = 1.2;
                    e.target.attrs["scale-x"] = 3;
                    e.target.attrs.alpha = 0.5;
                }}
                onpointerexit={(e) => {
                    e.target.attrs.scale = 1;
                    e.target.attrs["scale-x"] = 1;
                    e.target.attrs.alpha = 1;
                }}
            >
                <image
                    src="#"
                    color={this.color}
                    onpointerenter={() => {
                        this.color = "#2c442c";
                        this.count = (this.count + 25) % 101;
                    }}
                    onpointerexit={() => {
                        this.color = "#442c2c";
                        this.count = (this.count + 25) % 101;
                    }}
                    transition-property="color, fill-amount"
                    transition-duration="100ms,1s"
                    type="fan-right"
                    amount={this.count}
                >
                    {/* <button
                    src="#"
                    transition-property="margin-x"
                    transition-duration="1s"
                    margin={this.margin}
                    margin-x={this.marginX}
                    color="#ececec"
                    onclick={() => {
                        this.margin = 100 - this.margin;
                        this.marginX = 100 - this.marginX;
                    }}
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
                </button> */}
                    <Realtime>{() => <text font="unifont" material="unifont-outline">{Math.random()}</text>}</Realtime>
                </image>
            </canvasgroup>
        );
    }
}
