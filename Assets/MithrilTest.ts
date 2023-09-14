import Page from "./Page";

export default class TestBehaviour extends ScriptBehaviour {
    async start() {
        const body = new UnityElement(this.mono);

        m.mount(body, Page);
    }
}
