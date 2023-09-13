using UnityEditor;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace TSF.Oolong
{
    public class OolongUpdate : OolongSubSystem
    {
        protected override void Invoke()
        {
            OolongEnvironment.s_scriptUpdate?.Invoke();
        }
    }

    public class OolongFixedUpdate : OolongSubSystem
    {
        protected override void Invoke()
        {
            OolongEnvironment.s_scriptFixedUpdate?.Invoke();
        }
    }

    public class OolongLateUpdate : OolongSubSystem
    {
        protected override void Invoke()
        {
            OolongEnvironment.s_scriptLateUpdate?.Invoke();
        }
    }

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
            loop.InsertAfter<Update.ScriptRunBehaviourUpdate>(new OolongUpdate());
            loop.InsertAfter<FixedUpdate.ScriptRunBehaviourFixedUpdate>(new OolongFixedUpdate());
            loop.InsertAfter<PreLateUpdate.ScriptRunBehaviourLateUpdate>(new OolongLateUpdate());
            PlayerLoop.SetPlayerLoop(loop.ToPlayerLoopSystem());
        }
    }
}
