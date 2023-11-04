using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    public class OolongRectLoader : OolongLoader
    {
        private enum AlignType
        {
            TopLeft = 0,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight,
            TopStretch,
            MiddleStretch,
            BottomStretch,
            LeftStretch,
            CenterStretch,
            RightStretch,
            Stretch,
        }

        private struct LayoutData
        {
            public float Width;
            public float Height;
            public float MarginLeft;
            public float MarginTop;
            public float MarginRight;
            public float MarginBottom;
            public float MarginX;
            public float MarginY;
            public float Margin;
            public float Rotation;
            public float Z;
        }

        public struct LayoutElementData
        {
            public LayoutElement Instance;
            public float MinWidth;
            public float MinHeight;
            public float FlexWidth;
            public float FlexHeight;
            public float Priority;
            public bool IgnoreLayout;
        }

        private delegate void RectAttrHandler(OolongRectLoader e, string value);
        private static readonly Dictionary<string, RectAttrHandler> s_attr = new Dictionary<string, RectAttrHandler>()
        {
            { "align", (e, v) => e.SetAlign(v) },
            { "width", (e, v) => e.SetFloat(ref e._layoutData.Width, v) },
            { "height", (e, v) => e.SetFloat(ref e._layoutData.Height, v) },
            { "margin", (e, v) => e.SetFloat(ref e._layoutData.Margin, v) },
            { "margin-left", (e, v) => e.SetFloat(ref e._layoutData.MarginLeft, v) },
            { "margin-top", (e, v) => e.SetFloat(ref e._layoutData.MarginTop, v) },
            { "margin-right", (e, v) => e.SetFloat(ref e._layoutData.MarginRight, v) },
            { "margin-bottom", (e, v) => e.SetFloat(ref e._layoutData.MarginBottom, v) },
            { "margin-x", (e, v) => e.SetFloat(ref e._layoutData.MarginX, v) },
            { "margin-y", (e, v) => e.SetFloat(ref e._layoutData.MarginY, v) },
            { "z", (e, v) => e.SetFloat(ref e._layoutData.Z, v) },
            { "rotation", (e, v) => e.SetFloat(ref e._layoutData.Rotation, v) },
            { "anchor", (e, v) => e.SetAnchor(v) },
            { "min-width", (e, v) => e.SetFloat(ref e._layoutElementData.MinWidth, v, -1) },
            { "min-height", (e, v) => e.SetFloat(ref e._layoutElementData.MinHeight, v, -1) },
            { "flex-width", (e, v) => e.SetFloat(ref e._layoutElementData.FlexWidth, v, -1) },
            { "flex-height", (e, v) => e.SetFloat(ref e._layoutElementData.FlexHeight, v, -1) },
            { "ignore-layout", (e, v) => e.SetIgnoreLayout(v) },
            { "priority", (e, v) => e.SetFloat(ref e._layoutElementData.Priority, v) },
        };

        private static readonly Dictionary<string, int> s_alignMap = new Dictionary<string, int>()
        {
            { "top", 0 },
            { "middle", 1 },
            { "bottom", 2 },
            { "left", 3 },
            { "center", 4 },
            { "right", 5 },
            { "stretch", 6 },
        };

        public readonly RectTransform Instance;
        private LayoutData _layoutData;
        private LayoutElementData _layoutElementData;

        private AlignType _align = AlignType.Stretch;
        private Vector2 _anchor = Vector2.zero;

        private bool _autoAnchor = true;

        public OolongRectLoader(RectTransform instance)
        {
            Instance = instance;
            IsLayoutDirty = true;
            _layoutElementData.FlexHeight = -1;
            _layoutElementData.FlexWidth = -1;
            _layoutElementData.MinHeight = -1;
            _layoutElementData.MinHeight = -1;
            _layoutElementData.IgnoreLayout = false;
        }

        public bool SetAttribute(string prefix, string key, string value)
        {
            if (prefix != null)
            {
                if (!key.StartsWith(prefix)) return false;
                key = key.Substring(prefix.Length);
            }

            if (!s_attr.ContainsKey(key))
                return false;

            s_attr[key](this, value);
            return true;
        }

        public void SetIgnoreLayout(string v)
        {
            _layoutElementData.IgnoreLayout = v != null;
        }

        public bool SetAttribute(string key, string value)
        {
            return SetAttribute(null, key, value);
        }

        private void SetFloat(ref float f, string v, float def = 0.0f)
        {
            var oldF = f;
            f = string.IsNullOrEmpty(v) ? def : float.Parse(v);
            if (!oldF.Equals(f)) IsLayoutDirty = true;
        }

        private void SetAnchor(string value)
        {
            var oldAutoAnchor = _autoAnchor;
            var oldAnchor = _anchor;

            if (string.IsNullOrEmpty(value))
            {
                _autoAnchor = true;
                if (oldAutoAnchor != _autoAnchor)
                    IsLayoutDirty = true;
                return;
            }

            var splitIndex = value.IndexOf(' ');

            if (splitIndex < 0)
            {
                var num = float.Parse(value);
                _autoAnchor = false;
                _anchor = new Vector2(num / 100.0f, num / 100.0f);
            }
            else
            {
                var x = float.Parse(value.Substring(0, splitIndex));
                var y = float.Parse(value.Substring(splitIndex + 1));
                _autoAnchor = false;
                _anchor = new Vector2(x / 100.0f, 1 - y / 100.0f);
            }

            if (_autoAnchor != oldAutoAnchor || _anchor != oldAnchor)
                IsLayoutDirty = true;
        }

        private void SetAlign(string value)
        {
            var oldAlign = _align;
            if (string.IsNullOrEmpty(value))
            {
                _align = AlignType.Stretch;
                if (_align != oldAlign)
                    IsLayoutDirty = true;
                return;
            }

            var splitIndex = value.IndexOf(' ');
            var xAlign = 1; // 默认 center
            var yAlign = 1; // 默认 middle
            var isStretch = false;
            var hasX = false;
            var hasY = false;

            void CheckNum(int num)
            {
                if (num == 6)
                {
                    isStretch = true;
                    return;
                }

                if (num >= 3)
                {
                    xAlign = num - 3;
                    hasX = true;
                    return;
                }

                yAlign = num;
                hasY = true;
            }

            if (splitIndex < 0)
            {
                if (s_alignMap.ContainsKey(value))
                {
                    var num = s_alignMap[value];
                    CheckNum(num);
                }
                else
                {
                    Debug.LogWarning($"Unknown align type: {value}");
                }
            }
            else
            {
                var strA = value.Substring(0, splitIndex);
                if (s_alignMap.ContainsKey(strA))
                {
                    var num = s_alignMap[strA];
                    CheckNum(num);
                }
                else
                {
                    Debug.LogWarning($"Unknown align type: {value}");
                }

                var strB = value.Substring(splitIndex + 1);
                if (s_alignMap.ContainsKey(strB))
                {
                    var num = s_alignMap[strB];
                    CheckNum(num);
                }
                else
                {
                    Debug.LogWarning($"Unknown align type: {value}");
                }
            }

            if (isStretch)
            {
                if (hasY)
                    _align = AlignType.TopStretch + yAlign;
                else if (hasX)
                    _align = AlignType.LeftStretch + xAlign;
                else
                    _align = AlignType.Stretch;
            }
            else
            {
                _align = AlignType.TopLeft + yAlign * 3 + xAlign;
            }
            if (_align != oldAlign)
                IsLayoutDirty = true;
        }

        protected override void OnLayout()
        {
            base.OnLayout();

            // Set Align
            switch (_align)
            {
                case AlignType.TopLeft:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(0f, 1f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0f, 1f);
                    break;
                case AlignType.TopCenter:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(0.5f, 1f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0.5f, 1f);
                    break;
                case AlignType.TopRight:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(1f, 1f);
                    if (_autoAnchor) Instance.pivot = new Vector2(1f, 1f);
                    break;
                case AlignType.MiddleLeft:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(0f, 0.5f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0f, 0.5f);
                    break;
                case AlignType.MiddleCenter:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(0.5f, 0.5f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case AlignType.MiddleRight:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(1f, 0.5f);
                    if (_autoAnchor) Instance.pivot = new Vector2(1f, 0.5f);
                    break;
                case AlignType.BottomLeft:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(0f, 0f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0f, 0f);
                    break;
                case AlignType.BottomCenter:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(0.5f, 0f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0.5f, 0f);
                    break;
                case AlignType.BottomRight:
                    Instance.anchorMin = Instance.anchorMax = new Vector2(1f, 0f);
                    if (_autoAnchor) Instance.pivot = new Vector2(1f, 0f);
                    break;
                case AlignType.LeftStretch:
                    Instance.anchorMin = new Vector2(0f, 0f);
                    Instance.anchorMax = new Vector2(0f, 1f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0f, 0.5f);
                    break;
                case AlignType.CenterStretch:
                    Instance.anchorMin = new Vector2(0.5f, 0f);
                    Instance.anchorMax = new Vector2(0.5f, 1f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case AlignType.RightStretch:
                    Instance.anchorMin = new Vector2(1f, 0f);
                    Instance.anchorMax = new Vector2(1f, 1f);
                    if (_autoAnchor) Instance.pivot = new Vector2(1f, 0.5f);
                    break;
                case AlignType.TopStretch:
                    Instance.anchorMin = new Vector2(0f, 1f);
                    Instance.anchorMax = new Vector2(1f, 1f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0.5f, 1f);
                    break;
                case AlignType.MiddleStretch:
                    Instance.anchorMin = new Vector2(0f, 0.5f);
                    Instance.anchorMax = new Vector2(1f, 0.5f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case AlignType.BottomStretch:
                    Instance.anchorMin = new Vector2(0f, 0f);
                    Instance.anchorMax = new Vector2(1f, 0f);
                    if (_autoAnchor) Instance.pivot = new Vector2(0.5f, 0f);
                    break;
                case AlignType.Stretch:
                    Instance.anchorMin = Vector2.zero;
                    Instance.anchorMax = Vector2.one;
                    if (_autoAnchor) Instance.pivot = Vector2.one * 0.5f;
                    break;
            }

            if (!_autoAnchor)
                Instance.pivot = _anchor;

            var pivot = Instance.pivot;

            var marginX = _layoutData.Margin + _layoutData.MarginX;
            var marginY = _layoutData.Margin + _layoutData.MarginY;

            switch (_align)
            {
                case AlignType.TopLeft:
                    Instance.anchoredPosition = new Vector2(marginX + _layoutData.MarginLeft - _layoutData.MarginRight, -marginY - _layoutData.MarginTop + _layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.TopCenter:
                    Instance.anchoredPosition = new Vector2(_layoutData.MarginLeft - _layoutData.MarginRight, -marginY - _layoutData.MarginTop + _layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.TopRight:
                    Instance.anchoredPosition = new Vector2(-marginX - _layoutData.MarginRight + _layoutData.MarginLeft, -marginY - _layoutData.MarginTop + _layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.MiddleLeft:
                    Instance.anchoredPosition = new Vector2(marginX + _layoutData.MarginLeft - _layoutData.MarginRight, -_layoutData.MarginTop + _layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.MiddleCenter:
                    Instance.anchoredPosition = new Vector2(_layoutData.MarginLeft - _layoutData.MarginRight, -_layoutData.MarginTop + _layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.MiddleRight:
                    Instance.anchoredPosition = new Vector2(-marginX - _layoutData.MarginRight + _layoutData.MarginLeft, -_layoutData.MarginTop + _layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.BottomLeft:
                    Instance.anchoredPosition = new Vector2(marginX + _layoutData.MarginLeft - _layoutData.MarginRight, marginY + _layoutData.MarginBottom - _layoutData.MarginTop);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.BottomCenter:
                    Instance.anchoredPosition = new Vector2(_layoutData.MarginLeft - _layoutData.MarginRight, marginY + _layoutData.MarginBottom - _layoutData.MarginTop);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.BottomRight:
                    Instance.anchoredPosition = new Vector2(-marginX - _layoutData.MarginRight + _layoutData.MarginLeft, marginY + _layoutData.MarginBottom - _layoutData.MarginTop);
                    Instance.sizeDelta = new Vector2(_layoutData.Width, _layoutData.Height);
                    break;
                case AlignType.TopStretch:
                    {
                        var posX = (marginX + _layoutData.MarginLeft) * pivot.x - (marginX + _layoutData.MarginRight) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, -marginY - _layoutData.MarginTop + _layoutData.MarginBottom);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - _layoutData.MarginRight - _layoutData.MarginLeft, _layoutData.Height);
                        break;
                    }
                case AlignType.MiddleStretch:
                    {
                        var posX = (marginX + _layoutData.MarginLeft) * pivot.x - (marginX + _layoutData.MarginRight) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, -_layoutData.MarginTop + _layoutData.MarginBottom);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - _layoutData.MarginRight - _layoutData.MarginLeft, _layoutData.Height);
                        break;
                    }
                case AlignType.BottomStretch:
                    {
                        var posX = (marginX + _layoutData.MarginLeft) * pivot.x - (marginX + _layoutData.MarginRight) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, marginY + _layoutData.MarginBottom - _layoutData.MarginTop);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - _layoutData.MarginRight - _layoutData.MarginLeft, _layoutData.Height);
                        break;
                    }
                case AlignType.LeftStretch:
                    {
                        var posY = (marginY + _layoutData.MarginBottom) * pivot.y - (marginY + _layoutData.MarginTop) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(marginX + _layoutData.MarginLeft - _layoutData.MarginRight, posY);
                        Instance.sizeDelta = new Vector2(_layoutData.Width, -marginY * 2 - _layoutData.MarginBottom - _layoutData.MarginTop);
                        break;
                    }
                case AlignType.CenterStretch:
                    {
                        var posY = (marginY + _layoutData.MarginBottom) * pivot.y - (marginY + _layoutData.MarginTop) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(_layoutData.MarginLeft - _layoutData.MarginRight, posY);
                        Instance.sizeDelta = new Vector2(_layoutData.Width, -marginY * 2 - _layoutData.MarginBottom - _layoutData.MarginTop);
                        break;
                    }
                case AlignType.RightStretch:
                    {
                        var posY = (marginY + _layoutData.MarginBottom) * pivot.y - (marginY + _layoutData.MarginTop) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(_layoutData.MarginLeft - _layoutData.MarginRight, posY);
                        Instance.sizeDelta = new Vector2(_layoutData.Width, -marginY * 2 - _layoutData.MarginBottom - _layoutData.MarginTop);
                        break;
                    }
                case AlignType.Stretch:
                    {
                        var posX = (marginX + _layoutData.MarginLeft) * pivot.x - (marginX + _layoutData.MarginRight) * (1f - pivot.x);
                        var posY = (marginY + _layoutData.MarginBottom) * pivot.y - (marginY + _layoutData.MarginTop) * (1f - pivot.y);
                        var sizeX = -marginX * 2 - _layoutData.MarginRight - _layoutData.MarginLeft;
                        var sizeY = -marginY * 2 - _layoutData.MarginBottom - _layoutData.MarginTop;
                        Instance.anchoredPosition = new Vector2(posX, posY);
                        Instance.sizeDelta = new Vector2(sizeX, sizeY);
                        break;
                    }
            }

            Instance.localRotation = Quaternion.Euler(0, 0, _layoutData.Rotation);

            var shouldHaveElementLayout = Instance.parent.GetComponent<LayoutGroup>() != null;
            var layoutElement = _layoutElementData.Instance;
            var hasElementLayout = layoutElement != null && layoutElement.enabled;

            if (shouldHaveElementLayout != hasElementLayout)
            {
                if (shouldHaveElementLayout)
                {
                    if (layoutElement == null)
                    {
                        layoutElement = Instance.gameObject.AddComponent<LayoutElement>();
                        _layoutElementData.Instance = layoutElement;
                    }
                    layoutElement.enabled = true;
                }
                else if (layoutElement != null)
                {
                    layoutElement.enabled = false;
                }
            }

            if (layoutElement && shouldHaveElementLayout)
            {
                var width = Mathf.Max(_layoutData.Width, _layoutElementData.MinWidth);
                var height = Mathf.Max(_layoutData.Height, _layoutElementData.MinHeight);
                if (width == 0) width = -1;
                if (height == 0) height = -1;

                layoutElement.minWidth = _layoutElementData.MinWidth;
                layoutElement.minHeight = _layoutElementData.MinHeight;
                layoutElement.preferredWidth = width;
                layoutElement.preferredHeight = height;
                layoutElement.flexibleWidth = _layoutElementData.FlexWidth;
                layoutElement.flexibleHeight = _layoutElementData.FlexHeight;
                layoutElement.ignoreLayout = _layoutElementData.IgnoreLayout;
            }

            var localPosition = Instance.localPosition;
            localPosition.z = -_layoutData.Z;
            Instance.localPosition = localPosition;
        }

        public override void Reuse()
        {
            IsLayoutDirty = true;
        }

        public override void Reset()
        {
            _layoutData = default;
            var backupInstance = _layoutElementData.Instance;
            _layoutElementData = default;
            _layoutElementData.FlexHeight = -1;
            _layoutElementData.FlexWidth = -1;
            _layoutElementData.MinHeight = -1;
            _layoutElementData.MinHeight = -1;
            _layoutElementData.IgnoreLayout = false;
            _layoutElementData.Instance = backupInstance;

            _align = AlignType.Stretch;
            _anchor = Vector2.zero;
            _autoAnchor = true;
        }
    }
}
