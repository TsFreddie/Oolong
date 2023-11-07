using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    public interface IOolongLoader
    {
        public delegate void JsCallback(BaseEventData eventData);
        public bool AddListener(string key, JsCallback callback);
        public bool RemoveListener(string key);
        public void Release();
        public void Reuse();
        public void Reset();
        public bool SetAttribute(string key, string value);
        public void ResetTransitions();
        public void SetTransition(string key, float duration, CubicBezier timingFunction, float delay);
    }
}
