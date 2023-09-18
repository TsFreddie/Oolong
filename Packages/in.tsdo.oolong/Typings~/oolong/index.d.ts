export {};

declare global {
    type ScriptBehaviourType = { new (): ScriptBehaviour };
    const SerializeField: (
        type: { new (): any } = null
    ) => (target: ScriptBehaviour, propertyKey: string) => void;
    const NonSerialized: () => (
        target: ScriptBehaviour,
        propertyKey: string
    ) => void;
    const ValueRange: (
        min: number,
        max: number
    ) => (target: ScriptBehaviour, propertyKey: string) => void;
    const Int: () => (target: ScriptBehaviour, propertyKey: string) => void;

    class ScriptBehaviour {
        /** @hidden */
        public mono: CS.TSF.Oolong.ScriptBehaviour;
    }
}
