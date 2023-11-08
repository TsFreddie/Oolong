using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TSF.Oolong.UGUI
{
    public static class DocumentUtils
    {
        public static Action OnTransitionUpdate;
        public static Action OnTransitionValueUpdate;
        public static Action OnDocumentUpdate;
        public static Action OnDocumentLateUpdate;

        private static readonly Dictionary<string, Queue<OolongElement>> s_pooledElements = new Dictionary<string, Queue<OolongElement>>();

        private delegate IOolongLoader ElementLoaderFactory(OolongElement element);
        private static readonly Dictionary<string, ElementLoaderFactory> s_elements = new Dictionary<string, ElementLoaderFactory>()
        {
            {
                "div", (e) =>
                    new OolongRectLoader(e.transform)
            },
            {
                "panel", (e) =>
                    new OolongRectLoader(e.transform)
            },
            {
                "canvasgroup", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .Add(new OolongCanvasGroupLoader(e.transform))
            },
            {
                "image", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .Add(new OolongImageLoader(e.gameObject, e.TagName))
            },
            {
                "text", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .Add(new OolongTextLoader(e.gameObject, e))
            },
            {
                "button", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .Add(new OolongButtonLoader(e.gameObject), out var button)
                        .Add(new OolongSelectableLoader(button.Instance, e.TagName, true))
            },
            {
                "toggle", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .CreateChildRect(e.transform, "::checkmark", out var checkmarkRect)
                        .Add("cm-", new OolongRectLoader(checkmarkRect))
                        .Add("cm-", new OolongImageLoader(checkmarkRect.gameObject, e.TagName), out var checkmark)
                        .Add(new OolongToggleLoader(e.gameObject, checkmark.Instance), out var toggle)
                        .Add(new OolongSelectableLoader(toggle.Instance, e.TagName, true))
                        .CreateChildRect(e.transform, "::content", out var content)
                        .SetRoot(e, content)
            },
            {
                "scrollrect", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .Add(new OolongScrollRectLoader(e.gameObject, e.TagName), out var scrollRect)
                        .Add("content-", new OolongRectLoader(scrollRect.Content))
                        .Add(new OolongLayoutLoader(scrollRect.Content.gameObject))
                        .Add(new OolongRectMaskLoader(scrollRect.Viewport.gameObject, true))
                        .SetRoot(e, scrollRect.Content)
            },
            {
                "slider", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .Add(new OolongSliderLoader(e.gameObject, e.TagName))
            },
            {
                "input", (e) =>
                    new OolongChainLoader()
                        .Add(new OolongRectLoader(e.transform))
                        .CreateChildRect(e.transform, "::textarea", out var textAreaRect)
                        .CreateChildRect(textAreaRect, "::placeholder", out var placeHolderRect)
                        .CreateChildRect(textAreaRect, "::text", out var textRect)
                        .Add("ph-", new OolongTextLoader(placeHolderRect.gameObject, e)
                        {
                            DefaultAlign = TextAlignmentOptions.Left,
                            DefaultOverflow = TextOverflowModes.Ellipsis,
                            DefaultStyle = FontStyles.Italic,
                            DefaultColor = Color.gray,
                            Instance =
                            {
                                enableWordWrapping = false
                            }
                        }, out var placeHolder)
                        .Add("text-", new OolongTextLoader(textRect.gameObject, e)
                        {
                            DefaultAlign = TextAlignmentOptions.Left,
                            DefaultOverflow = TextOverflowModes.Overflow,
                            Instance =
                            {
                                enableWordWrapping = false
                            }
                        }, out var text)
                        .Add(new OolongInputLoader(e.gameObject, textAreaRect, placeHolder.Instance, text.Instance), out var input)
                        .Add(new OolongSelectableLoader(input.Instance, e.TagName, true))
                        .Add(new OolongRectMaskLoader(textAreaRect.gameObject))
                        .SetRoot(e, input.Content)
            }
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

        public static void AttachElement(OolongElement parent, OolongElement node)
        {
            var transform = node.transform;
            var scale = transform.localScale;
            node.ParentElement = parent;
            transform.SetParent(parent.RootTransform);
            parent.AddChild(node);
            transform.localScale = scale;
            transform.localRotation = Quaternion.identity;
            node.gameObject.SetActive(true);
        }

        public static void DetachElement(OolongElement node)
        {
            Debug.Log("不应出现");
            // var scale = node.transform.localScale;
            // node.ParentElement = null;
            // node.transform.SetParent(null);
            // node.transform.localScale = scale;
            // node.transform.localRotation = Quaternion.identity;
            // node.gameObject.SetActive(false);
        }

        public static void RemoveElement(OolongElement parent, OolongElement node)
        {
            var transform = node.transform;
            if (transform.parent != parent.RootTransform)
            {
                Debug.Log("元素同步出现问题");
            }

            var scale = transform.localScale;
            var tagName = node.TagName;
            parent.RemoveChild(node);
            node.OnReset();
            node.gameObject.SetActive(false);
            var pool = GetPoolParent();
            transform.SetParent(pool);
            transform.localScale = scale;
            transform.localRotation = Quaternion.identity;

            // Do not pool destroyed elements
            if (node is MonoBehaviour behaviour && !behaviour)
                return;

            if (s_pooledElements.TryGetValue(tagName, out var queue))
            {
                queue.Enqueue(node);
            }
            else
            {
                var newQueue = new Queue<OolongElement>();
                newQueue.Enqueue(node);
                s_pooledElements.Add(tagName, newQueue);
            }
        }

        public static void ResetElement(OolongElement node)
        {
            var transform = node.transform;
            var scale = transform.localScale;
            var tagName = node.TagName;
            node.OnReset();
            node.gameObject.SetActive(false);
            var pool = GetPoolParent();
            transform.SetParent(pool);
            transform.localScale = scale;
            transform.localRotation = Quaternion.identity;

            if (s_pooledElements.TryGetValue(tagName, out var queue))
            {
                queue.Enqueue(node);
            }
            else
            {
                var newQueue = new Queue<OolongElement>();
                newQueue.Enqueue(node);
                s_pooledElements.Add(tagName, newQueue);
            }
        }

        public static int InsertElement(OolongElement parent, OolongElement node, int index)
        {
            var transform = node.transform;
            var scale = transform.localScale;
            node.ParentElement = parent;
            transform.SetParent(parent.RootTransform);
            parent.AddChild(node);
            transform.localScale = scale;
            transform.localRotation = Quaternion.identity;
            transform.SetSiblingIndex(index);
            node.gameObject.SetActive(true);
            return index;
        }

        private static OolongElement CreateElementOfTag(string tagName)
        {
            var obj = new GameObject(string.Format("<{0}>", tagName));
            obj.SetActive(false);

            var eventHandler = obj.AddComponent<UIEventHandler>();
            eventHandler.enabled = false;
            obj.AddComponent<RectTransform>();
            var element = obj.AddComponent<OolongElement>();
            element.TagName = tagName;
            element.SetEventHandler(eventHandler);
            element.OnCreate(s_elements.TryGetValue(tagName, out var factory) ? factory(element) : null);
            return element;
        }

        public static OolongElement CreateElement(string tagName)
        {
            if (s_pooledElements.TryGetValue(tagName, out var queue))
            {
                if (queue.Count > 0)
                {
                    var pooledElement = queue.Dequeue();
                    pooledElement.OnReuse();
                    return pooledElement;
                }
            }

            return CreateElementOfTag(tagName);
        }

        public static void CacheElement(string tagName, int count)
        {
            var type = s_elements[tagName];

            for (var i = 0; i < count; i++)
            {
                var obj = new GameObject(string.Format("<{0}>", tagName));
                obj.SetActive(false);

                var element = CreateElementOfTag(tagName);
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

        public static bool TryParseColor(string color, out Color value)
        {
            if (string.IsNullOrEmpty(color))
            {
                value = Color.white;
                return true;
            }

            var result = ColorUtility.TryParseHtmlString(color, out value);
            if (!result)
                value = Color.white;

            return result;
        }


        public static void Dispose()
        {
            s_pooledElements.Clear();
        }

        public static void UpdateLayout()
        {
            OnTransitionUpdate?.Invoke();
            OnTransitionValueUpdate?.Invoke();
            OnTransitionUpdate = null;
            OnTransitionValueUpdate = null;
            OnDocumentUpdate?.Invoke();
        }

        public static void LateUpdateLayout()
        {
            OnDocumentLateUpdate?.Invoke();
        }
    }
}
