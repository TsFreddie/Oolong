interface TestStruct {
    a: number;
    b: string;
}

export default class TestBehaviour extends ScriptBehaviour {
    // public test: 100n;

    @ValueRange(0, 1)
    public test: number;

    onEnable() {
        console.log("enabled");
    }

    onDisable() {
        console.log("disabled");
    }
}
