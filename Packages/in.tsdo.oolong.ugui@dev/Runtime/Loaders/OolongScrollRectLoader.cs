using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
namespace TSF.Oolong.UGUI
{
    public class OolongScrollRectLoader : OolongLoader<OolongScrollRectLoader>
    {
        private struct ScrollViewData
        {
            public float ScrollbarWidth;
            public float ScrollbarHeight;
            public float ScrollbarOccupyWidth;
            public float ScrollbarOccupyHeight;
            public float ScrollbarOffsetX;
            public float ScrollbarOffsetY;
            public ScrollRect.ScrollbarVisibility ScrollbarVisibilityX;
            public ScrollRect.ScrollbarVisibility ScrollbarVisibilityY;
        }

        public readonly ScrollRect Instance;
        public readonly RectTransform Viewport;
        public readonly RectTransform Content;

        private string _tagName;
        private OolongScrollbarLoader _scrollbarX;
        private OolongScrollbarLoader _scrollbarY;

        private ScrollViewData _scrollViewData = new ScrollViewData()
        {
            ScrollbarWidth = 20,
            ScrollbarHeight = 20,
            ScrollbarOccupyWidth = -1,
            ScrollbarOccupyHeight = -1,
            ScrollbarVisibilityX = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport,
            ScrollbarVisibilityY = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport,
        };

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            // TODO: allow changing scroll position?
            { "sx-width", ((e, v) => e.SetFloat(ref e._scrollViewData.ScrollbarWidth, v, 20)) },
            { "sy-height", ((e, v) => e.SetFloat(ref e._scrollViewData.ScrollbarHeight, v, 20)) },
            { "sx-occupy-width", ((e, v) => e.SetFloat(ref e._scrollViewData.ScrollbarOccupyWidth, v, -1)) },
            { "sy-occupy-height", ((e, v) => e.SetFloat(ref e._scrollViewData.ScrollbarOccupyHeight, v, -1)) },
            { "sx-offset", ((e, v) => e.SetFloat(ref e._scrollViewData.ScrollbarOffsetY, v)) },
            { "sy-offset", ((e, v) => e.SetFloat(ref e._scrollViewData.ScrollbarOffsetX, v)) },
            { "sx-visibility", ((e, v) => e.SetVisibility(ref e._scrollViewData.ScrollbarVisibilityX, v)) },
            { "sy-visibility", ((e, v) => e.SetVisibility(ref e._scrollViewData.ScrollbarVisibilityY, v)) },
            { "elasticity", (e, v) => e.SetElasticity(v) },
            { "inertia", (e, v) => e.SetInertia(v) },
            { "sensitivity", (e, v) => e.SetSensitivity(v) },
            { "direction", (e, v) => e.SetDirection(v) }
        };

        public OolongScrollRectLoader(GameObject obj, string tagName)
        {
            Instance = obj.AddComponent<ScrollRect>();
            _tagName = tagName;

            Viewport = DocumentUtils.CreateChildRect(obj.transform, "::viewport");
            Instance.viewport = Viewport;
            Content = DocumentUtils.CreateChildRect(Viewport, "::content");
            Instance.content = Content;
        }

        private void CreateScrollbar(bool isHorizontal)
        {
            var childObj = new GameObject(isHorizontal ? "::scrollbar-x" : "::scrollbar-y");
            var scrollbarRect = childObj.AddComponent<RectTransform>();
            scrollbarRect.SetParent(Instance.transform);
            scrollbarRect.localPosition = Vector3.zero;
            scrollbarRect.localScale = Vector3.one;
            scrollbarRect.localRotation = Quaternion.identity;
            if (isHorizontal)
            {
                scrollbarRect.pivot = Vector2.zero;
                scrollbarRect.anchorMin = Vector2.zero;
                scrollbarRect.anchorMax = new Vector2(1.0f, 0.0f);
                _scrollbarX = new OolongScrollbarLoader(childObj.gameObject, Scrollbar.Direction.LeftToRight, _tagName);
                Instance.horizontalScrollbar = _scrollbarX.Instance;
                Instance.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
                Instance.horizontalScrollbarSpacing = 0.0f;
                scrollbarRect.sizeDelta = new Vector2(scrollbarRect.sizeDelta.x, 20.0f);
            }
            else
            {
                scrollbarRect.pivot = Vector2.one;
                scrollbarRect.anchorMin = new Vector2(1.0f, 0.0f);
                scrollbarRect.anchorMax = Vector2.one;
                _scrollbarY = new OolongScrollbarLoader(childObj.gameObject, Scrollbar.Direction.BottomToTop, _tagName);
                Instance.verticalScrollbar = _scrollbarY.Instance;
                Instance.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
                Instance.verticalScrollbarSpacing = 0.0f;
                scrollbarRect.sizeDelta = new Vector2(20.0f, scrollbarRect.sizeDelta.y);
            }
        }

        private void SetVisibility(ref ScrollRect.ScrollbarVisibility data, string v)
        {
            IsUpdatePending = true;

            if (v == null)
            {
                data = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
                return;
            }

            switch (v)
            {
                case "always":
                    data = ScrollRect.ScrollbarVisibility.Permanent;
                    break;
                case "reserve":
                    data = ScrollRect.ScrollbarVisibility.AutoHide;
                    break;
                default: // "auto"
                    data = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
                    break;
            }
        }

        private void SetElasticity(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                Instance.movementType = ScrollRect.MovementType.Elastic;
                Instance.elasticity = 0.1f;
                return;
            }

            var value = float.Parse(v);

            if (value < 0)
            {
                Instance.movementType = ScrollRect.MovementType.Clamped;
            }
            else
            {
                Instance.movementType = ScrollRect.MovementType.Elastic;
                Instance.elasticity = value;
            }
        }

        private void SetInertia(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                Instance.inertia = true;
                Instance.decelerationRate = 0.135f;
                return;
            }

            var value = float.Parse(v);

            if (value == 0)
            {
                Instance.inertia = false;
            }
            else
            {
                Instance.inertia = true;
                Instance.decelerationRate = value;
            }
        }

        private void SetSensitivity(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                Instance.scrollSensitivity = 1.0f;
                return;
            }

            var value = float.Parse(v);
            Instance.scrollSensitivity = value;
        }

        private void SetDirection(string v)
        {
            switch (v)
            {
                case "horizontal":
                    Instance.horizontal = true;
                    Instance.vertical = false;
                    break;
                case "vertical":
                    Instance.horizontal = false;
                    Instance.vertical = true;
                    break;
                case "none":
                    Instance.horizontal = false;
                    Instance.vertical = false;
                    break;
                default: // "both"
                    Instance.horizontal = true;
                    Instance.vertical = true;
                    break;
            }
        }

        public override bool SetAttribute(string key, string value)
        {
            var isScrollBarX = key.StartsWith("sx-");
            var isScrollBarY = key.StartsWith("sy-");
            if (_scrollbarX == null && isScrollBarX) CreateScrollbar(true);
            if (_scrollbarY == null && isScrollBarY) CreateScrollbar(false);

            if (s_attrs.TryGetValue(key, out var attr))
            {
                attr(this, value);
                return true;
            }

            if (isScrollBarX && _scrollbarX != null && _scrollbarX.SetAttribute(key.Substring(3), value)) return true;
            if (isScrollBarY && _scrollbarY != null && _scrollbarY.SetAttribute(key.Substring(3), value)) return true;
            return false;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            Instance.horizontalScrollbarVisibility = _scrollViewData.ScrollbarVisibilityX;
            Instance.verticalScrollbarVisibility = _scrollViewData.ScrollbarVisibilityY;

            var hasScrollX = _scrollbarX != null && _scrollbarX.Enabled;
            var hasScrollY = _scrollbarY != null && _scrollbarY.Enabled;

            var offsetX = _scrollViewData.ScrollbarOffsetX;
            var offsetY = _scrollViewData.ScrollbarOffsetY;

            var occupyX = _scrollViewData.ScrollbarOccupyWidth < 0 ? _scrollViewData.ScrollbarWidth : _scrollViewData.ScrollbarOccupyWidth;
            var occupyY = _scrollViewData.ScrollbarOccupyHeight < 0 ? _scrollViewData.ScrollbarHeight : _scrollViewData.ScrollbarOccupyHeight;

            var spacingX = occupyX - offsetX;
            var spacingY = occupyY - offsetY;

            if (hasScrollX)
            {
                var rect = _scrollbarX.Instance.GetComponent<RectTransform>();
                rect.offsetMin = new Vector2(0.0f, -offsetY);
                rect.offsetMax = new Vector2(-spacingX, spacingY);
                Instance.horizontalScrollbar = _scrollbarX.Instance;
            }
            else
            {
                Instance.horizontalScrollbar = null;
            }

            if (hasScrollY)
            {
                var rect = _scrollbarY.Instance.GetComponent<RectTransform>();
                rect.offsetMin = new Vector2(-spacingX, spacingY);
                rect.offsetMax = new Vector2(offsetX, 0.0f);
                Instance.verticalScrollbar = _scrollbarY.Instance;
            }
            else
            {
                Instance.verticalScrollbar = null;
            }

            Viewport.offsetMin = new Vector2(0.0f, hasScrollX ? spacingY : 0.0f);
            Viewport.offsetMax = new Vector2(hasScrollX ? -spacingX : 0.0f, 0.0f);
            Instance.horizontalScrollbarSpacing = spacingX - _scrollViewData.ScrollbarWidth;
            Instance.verticalScrollbarSpacing = spacingY - _scrollViewData.ScrollbarHeight;
        }

        public override bool AddListener(string key, IOolongLoader.JsCallback callback)
        {
            if (base.AddListener(key, callback)) return true;

            if (key != "valuechanged")
                return false;

            Instance.onValueChanged.AddListener(_ => callback(null));
            return true;
        }

        public override bool RemoveListener(string key)
        {
            if (base.RemoveListener(key)) return true;

            if (key != "valuechanged")
                return false;

            Instance.onValueChanged.RemoveAllListeners();
            return true;
        }

        public override bool TryGetAttribute(string key, out string value)
        {
            switch (key)
            {
                case "scrollX":
                    value = Instance.normalizedPosition.x.ToString(CultureInfo.InvariantCulture);
                    return true;
                case "scrollY":
                    value = Instance.normalizedPosition.y.ToString(CultureInfo.InvariantCulture);
                    return true;
            }
            return base.TryGetAttribute(key, out value);
        }

        public override void Reuse()
        {
            base.Reuse();
            _scrollbarX?.Reuse();
            _scrollbarY?.Reuse();
        }

        public override void Reset()
        {
            base.Reset();
            _scrollbarX?.Reset();
            _scrollbarY?.Reset();
            Instance.onValueChanged.RemoveAllListeners();
        }

        protected void OnDestroy()
        {
            _scrollbarX?.Release();
            _scrollbarY?.Release();
        }
    }
}
