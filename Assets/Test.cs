using TSF.Oolong;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int Info;
    public GameObject Hi;
    public void Start()
    {
        OolongEnvironment.JsEnv.Eval($"console.log(globalThis.TypeScriptBehaviour);");
        OolongEnvironment.JsEnv.ExecuteModule("_oolong_/index");
    }
}
