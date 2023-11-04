using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public abstract class OolongElement<T> : MonoBehaviour, IOolongElement, IPointerEnterHandler, IPointerExitHandler where T : OolongElement<T>
    {
        protected delegate void AttrHandler(T e, string value);
        protected virtual Dictionary<string, AttrHandler> Attrs => null;

        public string TagName { get; set; } = "undefined";

        public virtual Transform RootTransform => transform;
        public IOolongElement ParentElement { get; set; } = null;

        private OolongRectLoader _rect;

        private HashSet<IOolongElement> _children = new HashSet<IOolongElement>();

        private Action _onMouseEnter;
        private Action _onMouseExit;

        public void AddChild(IOolongElement e)
        {
            _children.Add(e);
        }

        public void RemoveChild(IOolongElement e)
        {
            _children.Remove(e);
        }

        public void SetElementAttribute(string key, string value)
        {
            if (key == "id") name = string.Concat("#", value);
            if (SetAttribute(key, value)) return;
            if (Attrs != null && Attrs.ContainsKey(key))
            {
                Attrs[key](this as T, value);
                return;
            }
            _rect.SetAttribute(key, value);
        }

        protected virtual bool SetAttribute(string key, string value) => false;

        public virtual void AddListener(string key, IOolongElement.JsCallback callback)
        {
            switch (key)
            {
                case "mouseenter":
                    _onMouseEnter += () => callback();
                    break;
                case "mouseleave":
                    _onMouseExit += () => callback();
                    break;
            }
        }

        public virtual void RemoveListener(string key)
        {
            switch (key)
            {
                case "mouseenter":
                    _onMouseEnter = null;
                    break;
                case "mouseleave":
                    _onMouseExit = null;
                    break;
            }
        }

        public virtual Transform Root => transform;

        public virtual void OnCreate()
        {
            _rect = new OolongRectLoader(gameObject.AddComponent<RectTransform>());
        }

        public virtual void OnReset()
        {
            _rect.Reset();
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

            _onMouseEnter = null;
            _onMouseExit = null;
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            _onMouseEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _onMouseExit?.Invoke();
        }
    }
}