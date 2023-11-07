using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public abstract class OolongElement<T> : MonoBehaviour, OolongElement where T : OolongElement<T>
    {
        protected delegate void AttrHandler(T e, string value);
        protected virtual Dictionary<string, AttrHandler> Attrs => null;

        public string TagName { get; set; } = "undefined";

        public virtual Transform RootTransform => transform;
        public OolongElement ParentElement { get; set; } = null;

        private OolongRectLoader _rect;
        private UIEventHandler _eventHandler;
        private HashSet<OolongElement> _children = new HashSet<OolongElement>();

        private List<string> _transitionAttrs;
        private List<float> _transitionDelays;
        private List<float> _transitionDurations;
        private List<CubicBezier> _transitionTimingFunctions;

        public void AddChild(OolongElement e)
        {
            _children.Add(e);
        }

        public void RemoveChild(OolongElement e)
        {
            _children.Remove(e);
        }

        public void SetElementAttribute(string key, string value)
        {
            switch (key)
            {
                case "id":
                    name = string.Concat("#", value);
                    return;
                case "transition-property":
                    SetTransitionList(ref _transitionAttrs, value, v => v.Trim());
                    return;
                case "transition-delay":
                    SetTransitionList(ref _transitionDelays, value, TransitionUtils.ParseHumanTime);
                    return;
                case "transition-duration":
                    SetTransitionList(ref _transitionDurations, value, TransitionUtils.ParseHumanTime);
                    return;
                case "transition-timing-function":
                    SetTransitionList(ref _transitionTimingFunctions, value, TransitionUtils.ParseTimingFunction);
                    return;
            }

            if (SetAttribute(key, value)) return;
            if (Attrs != null && Attrs.ContainsKey(key))
            {
                Attrs[key](this as T, value);
                return;
            }
            _rect.SetAttribute(key, value);
        }

        private void SetTransitionList<TK>(ref List<TK> list, string value, Func<string, TK> parse)
        {
            if (string.IsNullOrEmpty(value))
            {
                ClearList(ref list);
                return;
            }

            EnsureList(ref list);
            var values = value.Split(',');
            foreach (var v in values)
            {
                list.Add(parse(v));
            }
            IsTransitionDirty = true;
        }

        private void EnsureList<TK>(ref List<TK> list)
        {
            list ??= ListPool<TK>.Get();
        }

        private void ClearList<TK>(ref List<TK> list)
        {
            if (list == null) return;
            ListPool<TK>.Release(list);
            list = null;
        }

        private TK GetFromList<TK>(List<TK> list, int index, TK def)
        {
            if (list == null || list.Count == 0) return def;
            if (index < 0 || index >= list.Count) return list[^1];
            return list[index];
        }


        protected virtual bool SetAttribute(string key, string value) => false;

        public virtual bool AddListener(string key, OolongElement.JsCallback callback)
        {
            return _eventHandler.AddListener(key, callback);
        }

        public virtual bool RemoveListener(string key)
        {
            return _eventHandler.RemoveListener(key);
        }

        public virtual void SetEventHandler(UIEventHandler handler)
        {
            _eventHandler = handler;
        }

        public virtual void OnCreate()
        {
            _rect = new OolongRectLoader(gameObject.AddComponent<RectTransform>());
        }

        public virtual void OnReset()
        {
            _rect.Reset();
            _eventHandler.Reset();
            name = string.Concat("<", TagName, ">");

            foreach (var child in _children)
            {
                DocumentUtils.ResetElement(child);
            }
            _children.Clear();

            if (Attrs == null)
                return;

            foreach (var kvp in Attrs)
            {
                kvp.Value(this as T, null);
            }
        }

        public virtual void OnReuse() { _rect.Reuse(); }

        protected virtual void OnDestroy()
        {
            _rect?.Release();
            IsLayoutDirty = false;
            IsLayoutDirtyLate = false;
        }

        public static RectTransform CreateChildRect(Transform parent, string name)
        {
            return DocumentUtils.CreateChildRect(parent, name);
        }

        public RectTransform CreateChildRect(string childName)
        {
            return DocumentUtils.CreateChildRect(transform, childName);
        }

        private bool _isTransitionDirty;
        protected bool IsTransitionDirty
        {
            get { return _isTransitionDirty; }
            set
            {
                if (_isTransitionDirty == value) return;
                _isTransitionDirty = value;
                if (_isTransitionDirty)
                    DocumentUtils.OnDocumentPreUpdate += OnTransitionDirty;
                else
                    DocumentUtils.OnDocumentPreUpdate -= OnTransitionDirty;
            }
        }

        private void OnTransitionDirty()
        {
            IsTransitionDirty = false;

            OnResetTransition();
            if (_transitionAttrs != null)
            {
                for (var i = 0; i < _transitionAttrs.Count; i++)
                {
                    var attr = _transitionAttrs[i];
                    var duration = GetFromList(_transitionDurations, i, 0.0f);
                    var timingFunction = GetFromList(_transitionTimingFunctions, i, CubicBezier.Ease);
                    var delay = GetFromList(_transitionDelays, i, 0.0f);
                    OnSetTransition(attr, duration, timingFunction, delay);
                }
            }
        }

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

        protected virtual void OnLayout()
        {
            IsLayoutDirty = false;
        }

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
        protected virtual void OnLateLayout()
        {
            IsLayoutDirtyLate = false;
        }

        protected virtual void OnResetTransition()
        {
            _rect.ResetTransitions();
        }

        protected virtual bool OnSetTransition(string attr, float duration, CubicBezier timingFunction, float delay)
        {
            return _rect.SetTransition(attr, duration, timingFunction, delay);
        }
    }
}
