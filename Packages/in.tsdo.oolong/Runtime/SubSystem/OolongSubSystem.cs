using UnityEngine.LowLevel;

#if UNITY_EDITOR || DEVELOPMENT_BUILD
using UnityEngine.Profiling;
#endif

namespace TSF.Oolong
{
    public abstract class OolongSubSystem
    {
        protected abstract void Invoke();
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        private CustomSampler _sampler = null;
        private CustomSampler Sampler => _sampler ??= CustomSampler.Create($"Oolong.{GetType().Name}");

        private void ProfiledInvoke()
        {
            Sampler.Begin();
            try
            {
                Invoke();
            }
            catch
            {
                // ignored
            }

            Sampler.End();
        }

        public PlayerLoopSystem.UpdateFunction GetUpdateDelegate() => ProfiledInvoke;
#else
        public PlayerLoopSystem.UpdateFunction GetUpdateDelegate() => Invoke;
#endif

        public static implicit operator MutableLoopSystem(OolongSubSystem oolongSubSystem)
        {
            return new MutableLoopSystem(oolongSubSystem);
        }
    }
}
