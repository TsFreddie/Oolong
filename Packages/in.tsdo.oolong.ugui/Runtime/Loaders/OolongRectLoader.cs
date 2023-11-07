using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    public class OolongRectLoader : OolongLoader<OolongRectLoader>
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

        private struct LayoutData : IEquatable<LayoutData>
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
            public float MinWidth;
            public float MinHeight;
            public float FlexWidth;
            public float FlexHeight;

            public bool Equals(LayoutData other) => Width.Equals(other.Width) && Height.Equals(other.Height) && MarginLeft.Equals(other.MarginLeft) && MarginTop.Equals(other.MarginTop) && MarginRight.Equals(other.MarginRight) && MarginBottom.Equals(other.MarginBottom) && MarginX.Equals(other.MarginX) && MarginY.Equals(other.MarginY) && Margin.Equals(other.Margin) && Rotation.Equals(other.Rotation) && Z.Equals(other.Z) && MinWidth.Equals(other.MinWidth) && MinHeight.Equals(other.MinHeight) && FlexWidth.Equals(other.FlexWidth) && FlexHeight.Equals(other.FlexHeight);
            public override bool Equals(object obj) => obj is LayoutData other && Equals(other);
            public override int GetHashCode()
            {
                var hashCode = new HashCode();
                hashCode.Add(Width);
                hashCode.Add(Height);
                hashCode.Add(MarginLeft);
                hashCode.Add(MarginTop);
                hashCode.Add(MarginRight);
                hashCode.Add(MarginBottom);
                hashCode.Add(MarginX);
                hashCode.Add(MarginY);
                hashCode.Add(Margin);
                hashCode.Add(Rotation);
                hashCode.Add(Z);
                hashCode.Add(MinWidth);
                hashCode.Add(MinHeight);
                hashCode.Add(FlexWidth);
                hashCode.Add(FlexHeight);
                return hashCode.ToHashCode();
            }
        }

        private class LayoutDataTransitionProperty : TransitionProperty<LayoutData>
        {
            public LayoutDataTransitionProperty(Action<LayoutData> applyCallback) : base(applyCallback)
            {
            }
            protected override LayoutData Lerp(LayoutData from, LayoutData to, float t)
            {
                return new LayoutData()
                {
                    Width = Mathf.Lerp(from.Width, to.Width, t),
                    Height = Mathf.Lerp(from.Height, to.Height, t),
                    MarginLeft = Mathf.Lerp(from.MarginLeft, to.MarginLeft, t),
                    MarginTop = Mathf.Lerp(from.MarginTop, to.MarginTop, t),
                    MarginRight = Mathf.Lerp(from.MarginRight, to.MarginRight, t),
                    MarginBottom = Mathf.Lerp(from.MarginBottom, to.MarginBottom, t),
                    MarginX = Mathf.Lerp(from.MarginX, to.MarginX, t),
                    MarginY = Mathf.Lerp(from.MarginY, to.MarginY, t),
                    Margin = Mathf.Lerp(from.Margin, to.Margin, t),
                    Rotation = Mathf.Lerp(from.Rotation, to.Rotation, t),
                    Z = Mathf.Lerp(from.Z, to.Z, t),
                    MinWidth = Mathf.Lerp(from.MinWidth, to.MinWidth, t),
                    MinHeight = Mathf.Lerp(from.MinHeight, to.MinHeight, t),
                    FlexWidth = Mathf.Lerp(from.FlexWidth, to.FlexWidth, t),
                    FlexHeight = Mathf.Lerp(from.FlexHeight, to.FlexHeight, t),
                };
            }
        }

        private struct LayoutElementData
        {
            public LayoutElement Instance;
            public float Priority;
            public bool IgnoreLayout;
        }

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
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
            { "min-width", (e, v) => e.SetFloat(ref e._layoutData.MinWidth, v, -1) },
            { "min-height", (e, v) => e.SetFloat(ref e._layoutData.MinHeight, v, -1) },
            { "flex-width", (e, v) => e.SetFloat(ref e._layoutData.FlexWidth, v, -1) },
            { "flex-height", (e, v) => e.SetFloat(ref e._layoutData.FlexHeight, v, -1) },
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
        private readonly LayoutDataTransitionProperty _layoutDataTransition;
        private LayoutElementData _layoutElementData;

        private AlignType _align = AlignType.Stretch;
        private Vector2 _anchor = Vector2.zero;

        private bool _autoAnchor = true;

        public OolongRectLoader(Transform transform) : this(transform as RectTransform)
        {
        }

        public OolongRectLoader(RectTransform rect)
        {
            Instance = rect;
            IsUpdatePending = true;
            _layoutData.FlexHeight = -1;
            _layoutData.FlexWidth = -1;
            _layoutData.MinHeight = -1;
            _layoutData.MinHeight = -1;
            _layoutElementData.IgnoreLayout = false;
            _layoutDataTransition = new LayoutDataTransitionProperty(ApplyLayout);
            Transitions.Add("rect", _layoutDataTransition);
        }

        private void SetIgnoreLayout(string v)
        {
            _layoutElementData.IgnoreLayout = v != null;
        }

        private void SetAnchor(string value)
        {
            var oldAutoAnchor = _autoAnchor;
            var oldAnchor = _anchor;

            if (string.IsNullOrEmpty(value))
            {
                _autoAnchor = true;
                if (oldAutoAnchor != _autoAnchor)
                    IsUpdatePending = true;
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
                IsUpdatePending = true;
        }

        private void SetAlign(string value)
        {
            var oldAlign = _align;
            if (string.IsNullOrEmpty(value))
            {
                _align = AlignType.Stretch;
                if (_align != oldAlign)
                    IsUpdatePending = true;
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
                if (s_alignMap.TryGetValue(value, out var num))
                {
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
                if (s_alignMap.TryGetValue(strA, out var num1))
                {
                    CheckNum(num1);
                }
                else
                {
                    Debug.LogWarning($"Unknown align type: {value}");
                }

                var strB = value.Substring(splitIndex + 1);
                if (s_alignMap.TryGetValue(strB, out var num))
                {
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
                IsUpdatePending = true;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _layoutDataTransition.SetValue(_layoutData);
        }

        private void ApplyLayout(LayoutData layoutData)
        {
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

            var marginX = layoutData.Margin + layoutData.MarginX;
            var marginY = layoutData.Margin + layoutData.MarginY;

            switch (_align)
            {
                case AlignType.TopLeft:
                    Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft - layoutData.MarginRight, -marginY - layoutData.MarginTop + layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.TopCenter:
                    Instance.anchoredPosition = new Vector2(layoutData.MarginLeft - layoutData.MarginRight, -marginY - layoutData.MarginTop + layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.TopRight:
                    Instance.anchoredPosition = new Vector2(-marginX - layoutData.MarginRight + layoutData.MarginLeft, -marginY - layoutData.MarginTop + layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.MiddleLeft:
                    Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft - layoutData.MarginRight, -layoutData.MarginTop + layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.MiddleCenter:
                    Instance.anchoredPosition = new Vector2(layoutData.MarginLeft - layoutData.MarginRight, -layoutData.MarginTop + layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.MiddleRight:
                    Instance.anchoredPosition = new Vector2(-marginX - layoutData.MarginRight + layoutData.MarginLeft, -layoutData.MarginTop + layoutData.MarginBottom);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.BottomLeft:
                    Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft - layoutData.MarginRight, marginY + layoutData.MarginBottom - layoutData.MarginTop);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.BottomCenter:
                    Instance.anchoredPosition = new Vector2(layoutData.MarginLeft - layoutData.MarginRight, marginY + layoutData.MarginBottom - layoutData.MarginTop);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.BottomRight:
                    Instance.anchoredPosition = new Vector2(-marginX - layoutData.MarginRight + layoutData.MarginLeft, marginY + layoutData.MarginBottom - layoutData.MarginTop);
                    Instance.sizeDelta = new Vector2(layoutData.Width, layoutData.Height);
                    break;
                case AlignType.TopStretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft) * pivot.x - (marginX + layoutData.MarginRight) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, -marginY - layoutData.MarginTop + layoutData.MarginBottom);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - layoutData.MarginRight - layoutData.MarginLeft, layoutData.Height);
                        break;
                    }
                case AlignType.MiddleStretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft) * pivot.x - (marginX + layoutData.MarginRight) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, -layoutData.MarginTop + layoutData.MarginBottom);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - layoutData.MarginRight - layoutData.MarginLeft, layoutData.Height);
                        break;
                    }
                case AlignType.BottomStretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft) * pivot.x - (marginX + layoutData.MarginRight) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, marginY + layoutData.MarginBottom - layoutData.MarginTop);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - layoutData.MarginRight - layoutData.MarginLeft, layoutData.Height);
                        break;
                    }
                case AlignType.LeftStretch:
                    {
                        var posY = (marginY + layoutData.MarginBottom) * pivot.y - (marginY + layoutData.MarginTop) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft - layoutData.MarginRight, posY);
                        Instance.sizeDelta = new Vector2(layoutData.Width, -marginY * 2 - layoutData.MarginBottom - layoutData.MarginTop);
                        break;
                    }
                case AlignType.CenterStretch:
                    {
                        var posY = (marginY + layoutData.MarginBottom) * pivot.y - (marginY + layoutData.MarginTop) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(layoutData.MarginLeft - layoutData.MarginRight, posY);
                        Instance.sizeDelta = new Vector2(layoutData.Width, -marginY * 2 - layoutData.MarginBottom - layoutData.MarginTop);
                        break;
                    }
                case AlignType.RightStretch:
                    {
                        var posY = (marginY + layoutData.MarginBottom) * pivot.y - (marginY + layoutData.MarginTop) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(layoutData.MarginLeft - layoutData.MarginRight, posY);
                        Instance.sizeDelta = new Vector2(layoutData.Width, -marginY * 2 - layoutData.MarginBottom - layoutData.MarginTop);
                        break;
                    }
                case AlignType.Stretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft) * pivot.x - (marginX + layoutData.MarginRight) * (1f - pivot.x);
                        var posY = (marginY + layoutData.MarginBottom) * pivot.y - (marginY + layoutData.MarginTop) * (1f - pivot.y);
                        var sizeX = -marginX * 2 - layoutData.MarginRight - layoutData.MarginLeft;
                        var sizeY = -marginY * 2 - layoutData.MarginBottom - layoutData.MarginTop;
                        Instance.anchoredPosition = new Vector2(posX, posY);
                        Instance.sizeDelta = new Vector2(sizeX, sizeY);
                        break;
                    }
            }

            Instance.localRotation = Quaternion.Euler(0, 0, layoutData.Rotation);

            var parent = Instance.parent;
            var shouldHaveElementLayout = parent && parent.GetComponent<LayoutGroup>() != null;
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
                var width = Mathf.Max(layoutData.Width, layoutData.MinWidth);
                var height = Mathf.Max(layoutData.Height, layoutData.MinHeight);
                if (width == 0) width = -1;
                if (height == 0) height = -1;

                layoutElement.minWidth = layoutData.MinWidth;
                layoutElement.minHeight = layoutData.MinHeight;
                layoutElement.preferredWidth = width;
                layoutElement.preferredHeight = height;
                layoutElement.flexibleWidth = layoutData.FlexWidth;
                layoutElement.flexibleHeight = layoutData.FlexHeight;
                layoutElement.ignoreLayout = _layoutElementData.IgnoreLayout;
            }

            var localPosition = Instance.localPosition;
            localPosition.z = -layoutData.Z;
            Instance.localPosition = localPosition;
        }

        public override void Reuse()
        {
            base.Reuse();
            IsUpdatePending = true;
        }

        public override void Reset()
        {
            base.Reset();

            _layoutData = default;
            _layoutData.FlexHeight = -1;
            _layoutData.FlexWidth = -1;
            _layoutData.MinHeight = -1;
            _layoutData.MinHeight = -1;
            _layoutElementData.IgnoreLayout = false;
            _layoutElementData.Priority = 0.0f;

            _align = AlignType.Stretch;
            _anchor = Vector2.zero;
            _autoAnchor = true;
        }
    }
}
