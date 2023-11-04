using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public class OolongToggle : OolongElement<OolongToggle>, IDeselectHandler
    {
        private class RefCountToggleGroup
        {
            public ToggleGroup Instance { get; }
            private int _refCount = 0;
            public RefCountToggleGroup(string name, bool allowOff)
            {
                var obj = new GameObject(name);
                Instance = obj.AddComponent<ToggleGroup>();
                Instance.allowSwitchOff = allowOff;
                _refCount = 0;
            }

            public void IncreaseCounter() { _refCount++; }
            public bool DecreaseCounter() { return --_refCount <= 0; }
        }

        private static readonly Dictionary<string, RefCountToggleGroup> s_toggleGroups = new Dictionary<string, RefCountToggleGroup>();

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "active", (e, v) => e.SetActive(v) },
            { "tab", (e, v) => e.SetGroup(v, false) },
            { "group", (e, v) => e.SetGroup(v, true) },
        };

        private Toggle _toggle;
        private OolongSelectableLoader _toggleLoader;
        private OolongImageLoader _checkmark;
        private OolongRectLoader _checkmarkRect;
        private RectTransform _root;
        private Action _onDeselect;

        private void SetGroup(string v, bool allowOff = false)
        {
            // remove from group
            var group = _toggle.group;
            if (group != null)
            {
                var groupName = group.name;
                _toggle.group = null;
                if (s_toggleGroups.ContainsKey(groupName))
                {
                    if (s_toggleGroups[groupName].DecreaseCounter())
                    {
                        s_toggleGroups.Remove(groupName);
                        Destroy(group.gameObject);
                    }
                }
            }

            if (v == null)
                return;

            if (s_toggleGroups.ContainsKey(v))
            {
                var existingGroup = s_toggleGroups[v];
                _toggle.group = existingGroup.Instance;
                existingGroup.IncreaseCounter();
            }
            else
            {
                var newGroup = new RefCountToggleGroup(v, allowOff);
                s_toggleGroups.Add(v, newGroup);
                _toggle.group = newGroup.Instance;
                newGroup.IncreaseCounter();
            }
        }

        private void SetActive(string v)
        {
            _toggle.SetIsOnWithoutNotify(v != null);
        }

        public bool IsOn
        {
            get { return _toggle.isOn; }
            set { _toggle.SetIsOnWithoutNotify(value); }
        }

        public override void AddListener(string key, IOolongElement.JsCallback callback)
        {
            base.AddListener(key, callback);

            switch (key)
            {
                case "change":
                    _toggle.onValueChanged.AddListener(_ => callback());
                    break;
                case "unfocus":
                    _onDeselect += () => callback();
                    break;
            }

        }

        public override void RemoveListener(string key)
        {
            base.RemoveListener(key);

            switch (key)
            {
                case "change":
                    _toggle.onValueChanged.RemoveAllListeners();
                    break;
                case "unfocus":
                    _onDeselect = null;
                    break;
            }
        }

        public override void OnCreate()
        {
            base.OnCreate();
            var image = gameObject.AddComponent<Image>();
            _toggle = gameObject.AddComponent<Toggle>();
            _toggle.targetGraphic = image;
            _toggleLoader = new OolongSelectableLoader(_toggle);

            _checkmarkRect = new OolongRectLoader(CreateChildRect("::checkmark"));

            _checkmark = new OolongImageLoader(_checkmarkRect.Instance.gameObject.AddComponent<Image>());
            _toggle.graphic = _checkmark.Instance;
            _toggle.SetIsOnWithoutNotify(false);

            _root = CreateChildRect("::content");
        }

        protected override bool SetAttribute(string key, string value)
        {
            if (_toggleLoader.SetAttribute(key, value)) return true;
            if (_checkmark.SetAttribute("cm-", key, value)) return true;
            if (_checkmarkRect.SetAttribute("cm-", key, value)) return true;
            return false;
        }

        public override Transform RootTransform => _root;

        public override void OnReuse()
        {
            base.OnReuse();
            _checkmark.Reuse();
            _checkmarkRect.Reuse();
        }

        public override void OnReset()
        {
            base.OnReset();
            _checkmark.Reset();
            _checkmarkRect.Reset();
            _toggle.onValueChanged.RemoveAllListeners();
            _onDeselect = null;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            SetGroup(null);
            _checkmark.Release();
            _checkmarkRect.Release();
        }
        public void OnDeselect(BaseEventData eventData)
        {
            _onDeselect?.Invoke();
        }
    }
}
