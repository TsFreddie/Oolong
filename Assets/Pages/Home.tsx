export default class Menu extends MithrilComponent {
    private count: number = 0;
    private margin: number = 0;
    private marginX: number = 0;
    private color = "#442c2c";

    view(vnode: m.Vnode<{}, this>) {
        return (
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
            </image>
        );
    }
}
