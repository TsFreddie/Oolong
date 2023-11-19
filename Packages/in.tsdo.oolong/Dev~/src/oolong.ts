export type ScriptBehaviourType = { new (): ScriptBehaviour };

const extractMethod = (script: ScriptBehaviour, methodName: string) => {
  if (methodName in script) {
    var method = (script as any)[methodName];
    if (typeof method == 'function') {
      return method;
    }
  }
  return null;
};

class OolongManager {
  // Behaviour InstanceId -> ScriptBehaviour
  private behaviours: { [instanceId: number]: ScriptBehaviour } = {};

  // GameObject InstanceId -> ScriptName -> Behaviour InstanceId
  private gameObjects: { [instanceId: number]: { [typeName: string]: number[] } } = {};

  // Update Hooks
  private updates: { [instanceId: number]: () => void } = {};
  private fixedUpdates: { [instanceId: number]: () => void } = {};
  private lateUpdates: { [instanceId: number]: () => void } = {};

  public attach(
    behaviour: CS.TSF.Oolong.ScriptBehaviour,
    scriptClass: ScriptBehaviourType,
    jsonData: string
  ) {
    const instanceId = behaviour.GetScriptInstanceID();
    const gameObjectId = behaviour.GetGameObjectInstanceID();
    const typeName = scriptClass.name;

    const script = new scriptClass();
    script.mono = behaviour;
    script.instanceId = instanceId;
    script.gameObjectId = gameObjectId;

    // TODO: Deserialize data
    let data: any;

    try {
      data = jsonData ? JSON.parse(jsonData) : null;
    } catch (e) {
      console.error(`Failed to parse serialized data for ${typeName} with error: ${e}`);
      return;
    }

    // Lifecycle Hooks
    let update = extractMethod(script, 'update');
    let fixedUpdate = extractMethod(script, 'fixedUpdate');
    let lateUpdate = extractMethod(script, 'lateUpdate');
    if (update) update = update.bind(script);
    if (fixedUpdate) fixedUpdate = fixedUpdate.bind(script);
    if (lateUpdate) lateUpdate = lateUpdate.bind(script);

    let awake = extractMethod(script, 'awake');
    let start = extractMethod(script, 'start');
    let onEnableInternal = extractMethod(script, 'onEnable');
    let onDisableInternal = extractMethod(script, 'onDisable');
    let onDestroy = extractMethod(script, 'onDestroy');

    if (awake) awake = awake.bind(script);
    if (start) start = start.bind(script);
    if (onEnableInternal) onEnableInternal = onEnableInternal.bind(script);
    if (onDisableInternal) onDisableInternal = onDisableInternal.bind(script);
    if (onDestroy) onDestroy = onDestroy.bind(script);

    const enable = () => {
      if (update) this.updates[instanceId] = update;
      if (fixedUpdate) this.fixedUpdates[instanceId] = fixedUpdate;
      if (lateUpdate) this.lateUpdates[instanceId] = lateUpdate;
    };

    const disable = () => {
      delete this.updates[instanceId];
      delete this.fixedUpdates[instanceId];
      delete this.lateUpdates[instanceId];
    };

    let onEnable: () => void = enable;
    let onDisable: () => void = disable;

    if (onEnableInternal) {
      onEnable = () => {
        enable();
        onEnableInternal();
      };
    }
    if (onDisableInternal) {
      onDisable = () => {
        disable();
        onDisableInternal();
      };
    }
    behaviour.SetHooks(awake, start, onEnable, onDisable, onDestroy);

    this.behaviours[instanceId] = script;

    if (!(gameObjectId in this.gameObjects)) {
      this.gameObjects[gameObjectId] = {};
    }
    if (!(scriptClass.name in this.gameObjects[gameObjectId])) {
      this.gameObjects[gameObjectId][typeName] = [];
    }
    this.gameObjects[gameObjectId][typeName].push(instanceId);
  }

  public detach(instanceId: number) {
    const script = this.behaviours[instanceId];
    const gameObjectId = script.gameObjectId;
    delete this.behaviours[instanceId];
    const typeName = script.constructor.name;
    const index = this.gameObjects[gameObjectId][typeName].indexOf(instanceId);
    this.gameObjects[gameObjectId][typeName].splice(index, 1);
    if (this.gameObjects[gameObjectId][typeName].length == 0) {
      delete this.gameObjects[gameObjectId][typeName];
    }
    delete this.updates[instanceId];
    delete this.fixedUpdates[instanceId];
    delete this.lateUpdates[instanceId];
  }

  public update() {
    for (const key in this.updates) {
      this.updates[key]();
    }
  }

  public fixedUpdate() {
    for (const key in this.fixedUpdates) {
      this.fixedUpdates[key]();
    }
  }

  public lateUpdate() {
    for (const key in this.lateUpdates) {
      this.lateUpdates[key]();
    }
  }

  public dispose() {
    for (const key in this.behaviours) {
      this.behaviours[key].mono.ClearHooks();
    }
  }
}

export class ScriptBehaviour {
  /** @hidden */
  public mono: CS.TSF.Oolong.ScriptBehaviour;
  public instanceId: number;
  public gameObjectId: number;
}

export const Oolong = new OolongManager();
