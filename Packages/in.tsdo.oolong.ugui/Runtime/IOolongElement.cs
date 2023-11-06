using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    public interface IOolongElement
    {
        public delegate void JsCallback(BaseEventData eventData);

        // ReSharper disable once InconsistentNaming
        public Transform transform { get; }
        // ReSharper disable once InconsistentNaming
        public GameObject gameObject { get; }
        public Transform RootTransform { get; }
        public IOolongElement ParentElement { get; set; }
        public void AddChild(IOolongElement e);
        public void RemoveChild(IOolongElement e);
        public void SetEventHandler(UIEventHandler handler);
        public void OnCreate();
        public void OnReuse();
        public void OnReset();
        public string TagName { get; set; }
        public void SetElementAttribute(string key, string value);
        public bool AddListener(string key, JsCallback callback);
        public bool RemoveListener(string key);
        public Component GetComponent(Type type);
        public Component GetComponent(string type);
        public T GetComponent<T>();
        public int GetInstanceID();
    }
}
