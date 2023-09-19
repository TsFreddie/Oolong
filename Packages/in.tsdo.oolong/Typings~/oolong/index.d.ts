/// <reference types="csharp"/>
export {};
declare global {
    export type ScriptBehaviourType = {
        new (): ScriptBehaviour;
    };
    declare class OolongManager {
        private behaviours;
        private gameObjects;
        private updates;
        private fixedUpdates;
        private lateUpdates;
        attach(behaviour: CS.TSF.Oolong.ScriptBehaviour, scriptClass: ScriptBehaviourType, jsonData: string): void;
        detach(instanceId: number): void;
        update(): void;
        fixedUpdate(): void;
        lateUpdate(): void;
        dispose(): void;
    }
    export declare class ScriptBehaviour {
        mono: CS.TSF.Oolong.ScriptBehaviour;
        instanceId: number;
        gameObjectId: number;
    }
    export declare const Oolong: OolongManager;
}
