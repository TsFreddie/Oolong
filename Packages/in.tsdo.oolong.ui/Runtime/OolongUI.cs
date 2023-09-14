using System.Collections;
using System.Collections.Generic;
using TSF.Oolong;
using UnityEngine;

public static class OolongUI
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        OolongEnvironment.JsEnv.ExecuteModule("InitializeDOM");
        OolongEnvironment.JsEnv.ExecuteModule("InitializeMithril");
    }
}
