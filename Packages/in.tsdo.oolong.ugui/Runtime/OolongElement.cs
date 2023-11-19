using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Scripting;

namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public class OolongElement : MonoBehaviour
    {
        #region private
        private readonly HashSet<OolongElement> _children = new HashSet<OolongElement>();

        private List<string> _transitionAttrs;
        private List<float> _transitionDelays;
        private List<float> _transitionDurations;
        private List<CubicBezier> _transitionTimingFunctions;
        private static Regex s_functionListRegex = new Regex(@"\s*([^,(]+(?:\([^)]*\))?)\s*");

        private IOolongLoader _loader;
        private Transform _rootTransform;
        #endregion

        #region public
        public string TagName { get; set; } = "undefined";
        public Transform RootTransform
        {
            get
            {
                if (_rootTransform == null)
                    _rootTransform = transform;
                return _rootTransform;
            }
            set => _rootTransform = value;
        }
        public OolongElement ParentElement { get; set; } = null;
        public new int GetInstanceID() => base.GetInstanceID();

        /// <summary>
        /// Keep track of all attribute values
        /// </summary>
        public Dictionary<string, string> Attrs = new Dictionary<string, string>();
        #endregion

        protected virtual void OnDestroy()
        {
            _loader?.Release();
        }

        public void AddChild(OolongElement e)
        {
            _children.Add(e);
        }

        public void RemoveChild(OolongElement e)
        {
            _children.Remove(e);
        }

        [Preserve]
        public bool SetElementAttribute(string key, string value)
        {
            if (value == null)
                Attrs.Remove(key);
            else
                Attrs[key] = value;

            switch (key)
            {
                case "id":
                    name = string.Concat("#", value);
                    return true;
                case "transition-property":
                    SetTransitionList(ref _transitionAttrs, value, v => v.Trim());
                    return true;
                case "transition-delay":
                    SetTransitionList(ref _transitionDelays, value, TransitionUtils.ParseHumanTime);
                    return true;
                case "transition-duration":
                    SetTransitionList(ref _transitionDurations, value, TransitionUtils.ParseHumanTime);
                    return true;
                case "transition-timing-function":
                    SetTransitionFunctionList(ref _transitionTimingFunctions, value, TransitionUtils.ParseTimingFunction);
                    return true;
            }

            return _loader?.SetAttribute(key, value) ?? false;
        }

        [Preserve]
        public string GetElementAttribute(string key)
        {
            if (_loader?.TryReadValue(key, out var value) ?? false)
                return value;

            return Attrs.TryGetValue(key, out value) ? value : null;
        }

        [Preserve]
        public void AddListener(string key, IOolongLoader.JsCallback callback)
        {
            if (UIEventHandler.AddListenerToGameObject(gameObject, key, callback)) return;
            _loader?.AddListener(key, callback);
        }

        [Preserve]
        public void RemoveListener(string key)
        {
            if (UIEventHandler.RemoveListenerFromGameObject(gameObject, key)) return;
            _loader?.RemoveListener(key);
        }

        public void OnCreate(IOolongLoader loader)
        {
            _loader = loader;
        }

        public void OnReset()
        {
            _loader?.Reset();
            UIEventHandler.ResetListeners(gameObject);
            name = string.Concat("<", TagName, ">");

            foreach (var child in _children)
            {
                DocumentUtils.ResetElement(child);
            }
            _children.Clear();
        }

        public void OnReuse()
        {
            _loader?.Reuse();
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
                    DocumentUtils.OnTransitionUpdate += OnTransitionDirty;
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

        private void SetTransitionList<TK>(ref List<TK> list, string value, Func<string, TK> parse)
        {
            if (string.IsNullOrEmpty(value))
            {
                ClearList(ref list);
                IsTransitionDirty = true;
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

        private void SetTransitionFunctionList<TK>(ref List<TK> list, string value, Func<string, TK> parse)
        {
            if (string.IsNullOrEmpty(value))
            {
                ClearList(ref list);
                IsTransitionDirty = true;
                return;
            }

            EnsureList(ref list);
            var matches = s_functionListRegex.Matches(value);
            foreach (Match match in matches)
            {
                list.Add(parse(match.Groups[0].Value));
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

        private void OnResetTransition()
        {
            _loader?.ResetTransitions();
        }

        private void OnSetTransition(string attr, float duration, CubicBezier timingFunction, float delay)
        {
            _loader?.SetTransition(attr, duration, timingFunction, delay);
        }
    }
}
