using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    public abstract class OolongLoader<T> : IOolongLoader where T : OolongLoader<T>
    {
        public delegate void AttrHandler(T loader, string value);

        protected virtual Dictionary<string, AttrHandler> Attrs => null;
        protected Dictionary<string, ITransitionProperty> Transitions => _transitions ??= new Dictionary<string, ITransitionProperty>();

        private Dictionary<string, ITransitionProperty> _transitions;

        private bool _isUpdatePending;
        private bool _isLateUpdatePending;

        protected bool IsUpdatePending
        {
            get { return _isUpdatePending; }
            set
            {
                if (_isUpdatePending == value) return;
                _isUpdatePending = value;
                if (_isUpdatePending)
                    DocumentUtils.OnDocumentUpdate += OnUpdate;
                else
                    DocumentUtils.OnDocumentUpdate -= OnUpdate;
            }
        }

        protected bool IsLateUpdatePending
        {
            get { return _isLateUpdatePending; }
            set
            {
                if (_isLateUpdatePending == value) return;
                _isLateUpdatePending = value;
                if (_isLateUpdatePending)
                    DocumentUtils.OnDocumentLateUpdate += OnLateUpdate;
                else
                    DocumentUtils.OnDocumentLateUpdate -= OnLateUpdate;
            }
        }

        public virtual void Release()
        {
            IsUpdatePending = false;
            IsLateUpdatePending = false;
            ResetTransitions();
        }

        public virtual bool AddListener(string key, IOolongLoader.JsCallback callback) => false;
        public virtual bool RemoveListener(string key) => false;

        protected virtual void OnUpdate() { IsUpdatePending = false; }
        protected virtual void OnLateUpdate() { IsLateUpdatePending = false; }

        public virtual void Reset()
        {
            if (this is not T loader) return;

            foreach (var handler in Attrs.Values)
                handler(loader, null);
        }

        public virtual void Reuse() { }

        public virtual bool SetAttribute(string key, string value)
        {
            if (Attrs == null) return false;
            if (this is not T loader) return false;

            if (!Attrs.ContainsKey(key))
                return false;

            Attrs[key](loader, value);
            return true;
        }

        public void ResetTransitions()
        {
            if (_transitions == null) return;
            foreach (var prop in _transitions.Values)
            {
                prop.Reset();
            }
        }

        public void SetTransition(string key, float duration, CubicBezier timingFunction, float delay)
        {
            if (_transitions == null) return;
            if (!_transitions.TryGetValue(key, out var prop))
                return;

            prop.Duration = duration;
            prop.TimingFunction = timingFunction;
            prop.Delay = delay;
        }

        protected void SetFloat(ref float f, string v, float def = 0.0f)
        {
            var oldF = f;
            f = string.IsNullOrEmpty(v) || !float.TryParse(v, out var value) ? def : value;
            if (!oldF.Equals(f)) IsUpdatePending = true;
        }

        protected void SetFloatWithoutUpdate(ref float f, string v, float def = 0.0f)
        {
            f = string.IsNullOrEmpty(v) || !float.TryParse(v, out var value) ? def : value;
        }
    }
}
