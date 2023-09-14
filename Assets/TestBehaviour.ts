interface TestStruct {
    /**
     * @minimum 0
     * @maximum 1
     */
    num: number;
    str: string;
    toggle: boolean;
}

export default class TestBehaviour extends ScriptBehaviour {
    public obj: CS.UnityEngine.GameObject;
    public info: TestStruct;
    public objArr: CS.UnityEngine.GameObject[];

    public action: () => void;

    onEnable() {
        console.log("enabled");
    }

    onDisable() {
        console.log("disabled");
    }
}
