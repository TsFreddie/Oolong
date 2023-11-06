using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TSF.Oolong.UGUI
{
    public static class DocumentUtils
    {
        public static Action OnDocumentUpdate;
        public static Action OnDocumentLateUpdate;

        private static readonly Dictionary<string, Queue<IOolongElement>> s_pooledElements = new Dictionary<string, Queue<IOolongElement>>();

        private static readonly Dictionary<string, Type> s_elements = new Dictionary<string, Type>()
        {
            { "div", typeof(OolongPanel) }, // Empty Component
            { "panel", typeof(OolongPanel) },
            { "image", typeof(OolongImage) },
            { "text", typeof(OolongText) },
            { "button", typeof(OolongButton) },
            { "toggle", typeof(OolongToggle) },
            { "scrollview", typeof(OolongScrollView) },
            { "input", typeof(OolongInputField) },
            { "slider", typeof(OolongSlider) },
            { "container", typeof(OolongContainer) },
        };

        private static Transform s_elementPoolRoot = null;

        private static Transform GetPoolParent()
        {
            if (s_elementPoolRoot != null)
            {
                return s_elementPoolRoot;
            }

            s_elementPoolRoot = new GameObject("ElementPool").transform;
            Object.DontDestroyOnLoad(s_elementPoolRoot.gameObject);
            return s_elementPoolRoot;
        }

        public static void AttachElement(IOolongElement parent, IOolongElement node)
        {
            var scale = node.transform.localScale;
            node.ParentElement = parent;
            node.transform.SetParent(parent.RootTransform);
            parent.AddChild(node);
            node.transform.localScale = scale;
            node.transform.localRotation = Quaternion.identity;
            node.gameObject.SetActive(true);
        }

        public static void DetachElement(IOolongElement node)
        {
            Debug.Log("不应出现");
            // var scale = node.transform.localScale;
            // node.ParentElement = null;
            // node.transform.SetParent(null);
            // node.transform.localScale = scale;
            // node.transform.localRotation = Quaternion.identity;
            // node.gameObject.SetActive(false);
        }

        public static void RemoveElement(IOolongElement parent, IOolongElement node)
        {
            if (node.transform.parent != parent.RootTransform)
            {
                Debug.Log("元素同步出现问题");
            }

            var scale = node.transform.localScale;
            var tagName = node.TagName;
            parent.RemoveChild(node);
            node.OnReset();
            node.gameObject.SetActive(false);
            var pool = GetPoolParent();
            node.transform.SetParent(pool);
            node.transform.localScale = scale;
            node.transform.localRotation = Quaternion.identity;

            // Do not pool destroyed elements
            if (node is MonoBehaviour behaviour && !behaviour)
                return;

            if (s_pooledElements.TryGetValue(tagName, out var queue))
            {
                queue.Enqueue(node);
            }
            else
            {
                var newQueue = new Queue<IOolongElement>();
                newQueue.Enqueue(node);
                s_pooledElements.Add(tagName, newQueue);
            }
        }

        public static void ResetElement(IOolongElement node)
        {
            var scale = node.transform.localScale;
            var tagName = node.TagName;
            node.OnReset();
            node.gameObject.SetActive(false);
            var pool = GetPoolParent();
            node.transform.SetParent(pool);
            node.transform.localScale = scale;
            node.transform.localRotation = Quaternion.identity;

            if (s_pooledElements.TryGetValue(tagName, out var queue))
            {
                queue.Enqueue(node);
            }
            else
            {
                var newQueue = new Queue<IOolongElement>();
                newQueue.Enqueue(node);
                s_pooledElements.Add(tagName, newQueue);
            }
        }

        public static int InsertElement(IOolongElement parent, IOolongElement node, int index)
        {
            var scale = node.transform.localScale;
            node.ParentElement = parent;
            node.transform.SetParent(parent.RootTransform);
            parent.AddChild(node);
            node.transform.localScale = scale;
            node.transform.localRotation = Quaternion.identity;
            node.transform.SetSiblingIndex(index);
            node.gameObject.SetActive(true);
            return index;
        }

        public static IOolongElement CreateElement(string tagName)
        {
            var type = s_elements[tagName];

            if (s_pooledElements.TryGetValue(tagName, out var queue))
            {
                if (queue.Count > 0)
                {
                    var pooledElement = queue.Dequeue();
                    pooledElement.OnReuse();
                    return pooledElement;
                }
            }

            var obj = new GameObject(string.Format("<{0}>", tagName));
            obj.SetActive(false);

            var eventHandler = obj.AddComponent<UIEventHandler>();
            eventHandler.enabled = false;
            if (!(obj.AddComponent(type) is IOolongElement element))
                throw new Exception("Element must be derived from IOolongElement");

            element.SetEventHandler(eventHandler);
            element.OnCreate();
            element.TagName = tagName;
            return element;
        }

        public static void CacheElement(string tagName, int count)
        {
            var type = s_elements[tagName];

            for (var i = 0; i < count; i++)
            {
                var obj = new GameObject(string.Format("<{0}>", tagName));
                obj.SetActive(false);

                if (!(obj.AddComponent(type) is IOolongElement element))
                    continue;

                element.OnCreate();
                element.TagName = tagName;
                ResetElement(element);
            }
        }

        public static RectTransform CreateChildRect(Transform parent, string name)
        {
            var childObj = new GameObject(name ?? "::after");
            var childRect = childObj.AddComponent<RectTransform>();
            childRect.SetParent(parent);
            childRect.localPosition = Vector3.zero;
            childRect.localScale = Vector3.one;
            childRect.localRotation = Quaternion.identity;
            childRect.anchorMax = Vector2.one;
            childRect.anchorMin = Vector2.zero;
            childRect.sizeDelta = Vector2.zero;

            return childRect;
        }

        public static Color ParseColor(string color)
        {
            if (string.IsNullOrEmpty(color)) return Color.white;
            return ColorUtility.TryParseHtmlString(color, out var c) ? c : Color.white;
        }

        public static void Dispose()
        {
            s_pooledElements.Clear();
        }

        public static void UpdateLayout()
        {
            OnDocumentUpdate?.Invoke();
        }

        public static void LateUpdateLayout()
        {
            OnDocumentLateUpdate?.Invoke();
        }
    }
}
