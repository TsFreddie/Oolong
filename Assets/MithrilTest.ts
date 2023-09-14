export default class TestBehaviour extends ScriptBehaviour {
    async onEnable() {
        const result = await m.request<string>({
            url: "https://www.baidu.com",
            method: "GET",
            responseType: "text",
        });
        console.log(result);
    }

    onDisable() {
        console.log("disabled");
    }
}
