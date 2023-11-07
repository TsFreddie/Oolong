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
                    <Realtime>
                        {() => (
                            <text>
                                {this.count} - {Math.random().toString()}
                            </text>
                        )}
                    </Realtime>
                </button>
            </image>
        );
    }
}
