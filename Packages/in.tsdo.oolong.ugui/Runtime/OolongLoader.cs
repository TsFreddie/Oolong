using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public abstract class OolongLoader
    {
        public Dictionary<string, ITransitionProperty> TransitionProperties { get; } = new Dictionary<string, ITransitionProperty>();

        private bool _isLayoutDirty;
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

        protected virtual void OnLayout() { IsLayoutDirty = false; }

        private bool _isLayoutDirtyLate;
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
        protected virtual void OnLateLayout() { IsLayoutDirtyLate = false; }

        public virtual void Release()
        {
            IsLayoutDirty = false;
            IsLayoutDirtyLate = false;
            ResetTransitions();
        }

        public abstract void Reset();
        public abstract void Reuse();

        public void ResetTransitions()
        {
            foreach (var prop in TransitionProperties.Values)
            {
                prop.Reset();
            }
        }

        public bool SetTransition(string prefix, string key, float duration, CubicBezier timingFunction, float delay)
        {
            if (prefix != null)
            {
                if (!key.StartsWith(prefix)) return false;
                key = key.Substring(prefix.Length);
            }

            if (!TransitionProperties.TryGetValue(key, out var prop))
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
    }
}
