export default class Menu extends MithrilComponent {
    private count: number = 0;

    view(vnode: m.Vnode<{}, this>) {
        return (
            <button
                src="#"
                color="#550000"
                align="stretch"
                onclick={() => {
                    m.request<any>({
                        url: "https://api.dictionaryapi.dev/api/v2/entries/en/hello",
                        responseType: "arraybuffer"
                    }).then((data) => {
                        var arraybuffer = data;
                        var byteArray = new Uint8Array(arraybuffer);
                        var utf8str = new TextDecoder("utf-8").decode(byteArray);
                        console.log(utf8str);
                    });
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
