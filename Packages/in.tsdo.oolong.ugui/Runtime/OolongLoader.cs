using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    public abstract class OolongLoader<T> : IOolongLoader where T : OolongLoader<T>
    {
        public delegate void JsCallback(BaseEventData eventData);
        public delegate void AttrHandler(T loader, string value);

        protected virtual Dictionary<string, AttrHandler> Attrs => null;
        private HashSet<ITransitionProperty> _transitions;
        private Dictionary<string, ITransitionProperty> _transitionMap;

        private bool _isLayoutDirty;
        private bool _isLayoutDirtyLate;

        protected bool IsLayoutDirty
        {
            get { return _isLayoutDirty; }
            set
            {
                if (_isLayoutDirty == value) return;
                _isLayoutDirty = value;
                if (_isLayoutDirty)
                    DocumentUtils.OnDocumentUpdate += OnLayout;
                else
                    DocumentUtils.OnDocumentUpdate -= OnLayout;
            }
        }

        protected bool IsLayoutDirtyLate
        {
            get { return _isLayoutDirtyLate; }
            set
            {
                if (_isLayoutDirtyLate == value) return;
                _isLayoutDirtyLate = value;
                if (_isLayoutDirtyLate)
                    DocumentUtils.OnDocumentLateUpdate += OnLateLayout;
                else
                    DocumentUtils.OnDocumentLateUpdate -= OnLateLayout;
            }
        }

        public virtual void Release()
        {
            IsLayoutDirty = false;
            IsLayoutDirtyLate = false;
            ResetTransitions();
        }

        public virtual bool AddListener(string key, IOolongLoader.JsCallback callback) => false;
        public virtual bool RemoveListener(string key) => false;
        protected virtual void OnLayout() { IsLayoutDirty = false; }
        protected virtual void OnLateLayout() { IsLayoutDirtyLate = false; }
        public abstract void Reset();
        public abstract void Reuse();

        public virtual bool SetAttribute(string prefix, string key, string value)
        {
            if (this is not T loader) return false;

            if (prefix != null)
            {
                if (!key.StartsWith(prefix)) return false;
                key = key.Substring(prefix.Length);
            }

            if (!Attrs.ContainsKey(key))
                return false;

            Attrs[key](loader, value);
            return true;
        }

        public void ResetTransitions()
        {
            if (_transitions == null) return;
            foreach (var prop in _transitions)
            {
                prop.Reset();
            }
        }

        public bool SetTransition(string prefix, string key, float duration, CubicBezier timingFunction, float delay)
        {
            if (_transitions == null) return false;
            if (prefix != null)
            {
                if (!key.StartsWith(prefix)) return false;
                key = key.Substring(prefix.Length);
            }

            if (!_transitionMap.TryGetValue(key, out var prop))
                return false;

            prop.Duration = duration;
            prop.TimingFunction = timingFunction;
            prop.Delay = delay;
            return true;
        }

        public bool SetTransition(string key, float duration, CubicBezier timingFunction, float delay)
        {
            return SetTransition(null, key, duration, timingFunction, delay);
        }

        protected void SetFloat(ref float f, string v, float def = 0.0f)
        {
            var oldF = f;
            f = string.IsNullOrEmpty(v) || !float.TryParse(v, out var value) ? def : value;
            if (!oldF.Equals(f)) IsLayoutDirty = true;
        }
    }
}
