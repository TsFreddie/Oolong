using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    [AddComponentMenu("")]
    public class OolongScrollView : OolongElement<OolongScrollView>
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

        private ScrollRect _scrollRect;
        private OolongRectLoader _content;
        private OolongLayoutLoader _contentLayout;
        private RectTransform _contentRect;
        private OolongScrollbarLoader _scrollbarX;
        private OolongScrollbarLoader _scrollbarY;
        private RectTransform _viewport;

        private ScrollViewData _scrollViewData = new ScrollViewData()
        {
            ScrollbarWidth = 20,
            ScrollbarHeight = 20,
            ScrollbarOccupyWidth = -1,
            ScrollbarOccupyHeight = -1,
            ScrollbarVisibilityX = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport,
            ScrollbarVisibilityY = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport,
        };

        public override Transform RootTransform => _contentRect;

        public Vector2 ScrollPosition
        {
            get
            {
                return _scrollRect.normalizedPosition;
            }
            set
            {
                _scrollRect.normalizedPosition = value;
            }
        }

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
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

        public override void OnCreate()
        {
            base.OnCreate();
            _scrollRect = gameObject.AddComponent<ScrollRect>();
            _viewport = CreateChildRect("::viewport");
            var viewportObj = _viewport.gameObject;

            // TODO: 支持配置 RectMask2D
            viewportObj.AddComponent<RectMask2D>();
            viewportObj.AddComponent<NonDrawingGraphic>();
            _scrollRect.viewport = _viewport;
            _viewport.pivot = new Vector2(0.0f, 1.0f);
            _contentRect = CreateChildRect(_viewport, "::content");
            _content = new OolongRectLoader(_contentRect);
            _scrollRect.content = _contentRect;
            _contentLayout = new OolongLayoutLoader(_contentRect.gameObject);
        }

        private void CreateScrollbar(bool isHorizontal)
        {
            // TODO: 固定pivot

            var childObj = new GameObject(isHorizontal ? "::scrollbar-x" : "::scrollbar-y");
            var scrollbarRect = childObj.AddComponent<RectTransform>();
            scrollbarRect.SetParent(transform);
            scrollbarRect.localPosition = Vector3.zero;
            scrollbarRect.localScale = Vector3.one;
            scrollbarRect.localRotation = Quaternion.identity;
            if (isHorizontal)
            {
                scrollbarRect.pivot = Vector2.zero;
                scrollbarRect.anchorMin = Vector2.zero;
                scrollbarRect.anchorMax = new Vector2(1.0f, 0.0f);
                _scrollbarX = new OolongScrollbarLoader(childObj.gameObject, Scrollbar.Direction.LeftToRight);
                _scrollRect.horizontalScrollbar = _scrollbarX.Instance;
                _scrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
                _scrollRect.horizontalScrollbarSpacing = 0.0f;
                scrollbarRect.sizeDelta = new Vector2(scrollbarRect.sizeDelta.x, 20.0f);
            }
            else
            {
                scrollbarRect.pivot = Vector2.one;
                scrollbarRect.anchorMin = new Vector2(1.0f, 0.0f);
                scrollbarRect.anchorMax = Vector2.one;
                _scrollbarY = new OolongScrollbarLoader(childObj.gameObject, Scrollbar.Direction.BottomToTop);
                _scrollRect.verticalScrollbar = _scrollbarY.Instance;
                _scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
                _scrollRect.verticalScrollbarSpacing = 0.0f;
                scrollbarRect.sizeDelta = new Vector2(20.0f, scrollbarRect.sizeDelta.y);
            }
        }

        private void SetVisibility(ref ScrollRect.ScrollbarVisibility data, string v)
        {
            IsLayoutDirty = true;

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

        protected override bool SetAttribute(string key, string value)
        {
            if (_scrollbarX == null && key.StartsWith("sx-")) CreateScrollbar(true);
            if (_scrollbarY == null && key.StartsWith("sy-")) CreateScrollbar(false);

            if (s_attrs.ContainsKey(key))
            {
                s_attrs[key](this, value);
                return true;
            }

            if (_scrollbarX != null && _scrollbarX.SetAttribute("sx-", key, value)) return true;
            if (_scrollbarY != null && _scrollbarY.SetAttribute("sy-", key, value)) return true;

            if (_content.SetAttribute("content-", key, value)) return true;
            if (_contentLayout.SetAttribute(key, value)) return true;
            return false;
        }

        private void SetFloat(ref float f, string v, float def = 0.0f)
        {
            var oldF = f;
            f = string.IsNullOrEmpty(v) ? def : float.Parse(v);
            if (!oldF.Equals(f)) IsLayoutDirty = true;
        }

        private void SetElasticity(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _scrollRect.movementType = ScrollRect.MovementType.Elastic;
                _scrollRect.elasticity = 0.1f;
                return;
            }

            var value = float.Parse(v);

            if (value < 0)
            {
                _scrollRect.movementType = ScrollRect.MovementType.Clamped;
            }
            else
            {
                _scrollRect.movementType = ScrollRect.MovementType.Elastic;
                _scrollRect.elasticity = value;
            }
        }

        private void SetInertia(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _scrollRect.inertia = true;
                _scrollRect.decelerationRate = 0.135f;
                return;
            }

            var value = float.Parse(v);

            if (value == 0)
            {
                _scrollRect.inertia = false;
            }
            else
            {
                _scrollRect.inertia = true;
                _scrollRect.decelerationRate = value;
            }
        }

        private void SetSensitivity(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _scrollRect.scrollSensitivity = 1.0f;
                return;
            }

            var value = float.Parse(v);
            _scrollRect.scrollSensitivity = value;
        }

        private void SetDirection(string v)
        {
            switch (v)
            {
                case "horizontal":
                    _scrollRect.horizontal = true;
                    _scrollRect.vertical = false;
                    break;
                case "vertical":
                    _scrollRect.horizontal = false;
                    _scrollRect.vertical = true;
                    break;
                case "none":
                    _scrollRect.horizontal = false;
                    _scrollRect.vertical = false;
                    break;
                default: // "both"
                    _scrollRect.horizontal = true;
                    _scrollRect.vertical = true;
                    break;
            }
        }

        protected override void OnLayout()
        {
            base.OnLayout();

            _scrollRect.horizontalScrollbarVisibility = _scrollViewData.ScrollbarVisibilityX;
            _scrollRect.verticalScrollbarVisibility = _scrollViewData.ScrollbarVisibilityY;

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
                _scrollRect.horizontalScrollbar = _scrollbarX.Instance;
            }
            else
            {
                _scrollRect.horizontalScrollbar = null;
            }

            if (hasScrollY)
            {
                var rect = _scrollbarY.Instance.GetComponent<RectTransform>();
                rect.offsetMin = new Vector2(-spacingX, spacingY);
                rect.offsetMax = new Vector2(offsetX, 0.0f);
                _scrollRect.verticalScrollbar = _scrollbarY.Instance;
            }
            else
            {
                _scrollRect.verticalScrollbar = null;
            }

            _viewport.offsetMin = new Vector2(0.0f, hasScrollX ? spacingY : 0.0f);
            _viewport.offsetMax = new Vector2(hasScrollX ? -spacingX : 0.0f, 0.0f);
            _scrollRect.horizontalScrollbarSpacing = spacingX - _scrollViewData.ScrollbarWidth;
            _scrollRect.verticalScrollbarSpacing = spacingY - _scrollViewData.ScrollbarHeight;
        }

        public override void AddListener(string key, IOolongElement.JsCallback callback)
        {
            base.AddListener(key, callback);

            if (key == "change")
                _scrollRect.onValueChanged.AddListener(_ => callback());
        }

        public override void RemoveListener(string key)
        {
            base.RemoveListener(key);

            if (key == "change")
                _scrollRect.onValueChanged.RemoveAllListeners();
        }

        public override void OnReuse()
        {
            base.OnReuse();
            _content.Reuse();
            _contentLayout.Reuse();
            _scrollbarX?.Reuse();
            _scrollbarY?.Reuse();
        }

        public override void OnReset()
        {
            base.OnReset();
            _content.Reset();
            _contentLayout.Reset();
            _scrollbarX?.Reset();
            _scrollbarY?.Reset();
            _scrollRect.onValueChanged.RemoveAllListeners();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _content.Release();
            _contentLayout.Release();
            _scrollbarX?.Release();
            _scrollbarY?.Release();
        }
    }
}
