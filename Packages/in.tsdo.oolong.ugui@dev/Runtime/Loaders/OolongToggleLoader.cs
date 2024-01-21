using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    public class OolongToggleLoader : OolongLoader<OolongToggleLoader>
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

        public readonly OolongToggle Instance;

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "value", (e, v) => e.SetIsOn(v) },
            { "tab", (e, v) => e.SetGroup(v, false) },
            { "group", (e, v) => e.SetGroup(v, true) },
        };

        public OolongToggleLoader(GameObject gameObject, Graphic checkmark = null)
        {
            Instance = gameObject.AddComponent<OolongToggle>();
            Instance.SetIsOnWithoutNotify(false);
            if (checkmark)
                Instance.graphic = checkmark;
        }

        private void RemoveGroup()
        {
            // remove from group
            var group = Instance.group;
            if (group == null)
                return;

            var groupName = group.name;
            Instance.group = null;
            if (!s_toggleGroups.ContainsKey(groupName))
                return;

            if (!s_toggleGroups[groupName].DecreaseCounter())
                return;

            s_toggleGroups.Remove(groupName);
            Object.Destroy(group.gameObject);
        }

        private void SetGroup(string v, bool allowOff = false)
        {
            // remove from group
            RemoveGroup();

            if (v == null)
                return;

            if (s_toggleGroups.TryGetValue(v, out var toggleGroup))
            {
                Instance.group = toggleGroup.Instance;
                toggleGroup.IncreaseCounter();
            }
            else
            {
                var newGroup = new RefCountToggleGroup(v, allowOff);
                s_toggleGroups.Add(v, newGroup);
                Instance.group = newGroup.Instance;
                newGroup.IncreaseCounter();
            }
        }

        private void SetIsOn(string v)
        {
            Instance.SetIsOnWithoutNotify(v != "off");
        }

        public override bool AddListener(string key, IOolongLoader.JsCallback callback)
        {
            if (base.AddListener(key, callback)) return true;

            switch (key)
            {
                case "valuechanged":
                    Instance.onValueChanged.AddListener(_ => callback(null));
                    return true;
            }
            return false;
        }

        public override bool RemoveListener(string key)
        {
            if (base.RemoveListener(key)) return true;

            switch (key)
            {
                case "valuechanged":
                    Instance.onValueChanged.RemoveAllListeners();
                    return true;
            }
            return false;
        }

        public override bool TryGetAttribute(string key, out string value)
        {
            switch (key)
            {
                case "value":
                    value = Instance.isOn ? "on" : "off";
                    return true;
            }
            return base.TryGetAttribute(key, out value);
        }

        public override void Reset()
        {
            base.Reset();
            RemoveGroup();
            Instance.onValueChanged.RemoveAllListeners();
            Instance.SetIsOnWithoutNotify(false);
        }

        public override void Release()
        {
            base.Release();
            RemoveGroup();
        }
    }
}
