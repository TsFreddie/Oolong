export default class Menu extends MithrilComponent {
    private count: number = 0;

    view(vnode: m.Vnode<{}, this>) {
        return (
            <button
                src="#"
                color="#550000"
                align="stretch"
                onclick={() => {
                    this.count++;
                }}
            >
                <Realtime>
                    {() => (
                        <text>
                            {this.count} - {Math.random().toString()}
                        </text>
                    )}
                </Realtime>
            </button>
        );
    }
}
