using UnityEditor;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace TSF.Oolong
{
    public static class SubSystemInjector
    {
#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#else
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        public static void InjectSubSystem()
        {
            var loop = new MutableLoopSystem(PlayerLoop.GetCurrentPlayerLoop());
            loop.InsertAfter<Update.ScriptRunBehaviourUpdate>(new OolongEnvironment.OolongUpdate());
            loop.InsertAfter<FixedUpdate.ScriptRunBehaviourFixedUpdate>(new OolongEnvironment.OolongFixedUpdate());
            loop.InsertAfter<PreLateUpdate.ScriptRunBehaviourLateUpdate>(new OolongEnvironment.OolongLateUpdate());
            PlayerLoop.SetPlayerLoop(loop.ToPlayerLoopSystem());
        }
    }
}
