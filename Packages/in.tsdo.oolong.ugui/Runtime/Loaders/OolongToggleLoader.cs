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
        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "active", (e, v) => e.SetActive(v) },
            { "tab", (e, v) => e.SetGroup(v, false) },
            { "group", (e, v) => e.SetGroup(v, true) },
        };

        public readonly Toggle Instance;

        public OolongToggleLoader(GameObject gameObject, Graphic checkmark = null)
        {
            Instance = gameObject.AddComponent<Toggle>();
            Instance.SetIsOnWithoutNotify(false);
            if (checkmark)
                Instance.graphic = checkmark;
        }

        private void SetGroup(string v, bool allowOff = false)
        {
            // remove from group
            var group = Instance.group;
            if (group != null)
            {
                var groupName = group.name;
                Instance.group = null;
                if (s_toggleGroups.ContainsKey(groupName))
                {
                    if (s_toggleGroups[groupName].DecreaseCounter())
                    {
                        s_toggleGroups.Remove(groupName);
                        Object.Destroy(group.gameObject);
                    }
                }
            }

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

        private void SetActive(string v)
        {
            Instance.SetIsOnWithoutNotify(v != null);
        }
    }
}
