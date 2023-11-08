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

        private struct LayoutDataTransition
        {
            public FloatTransitionProperty Width;
            public FloatTransitionProperty Height;
            public FloatTransitionProperty MarginLeft;
            public FloatTransitionProperty MarginTop;
            public FloatTransitionProperty MarginRight;
            public FloatTransitionProperty MarginBottom;
            public FloatTransitionProperty MarginX;
            public FloatTransitionProperty MarginY;
            public FloatTransitionProperty Margin;
            public FloatTransitionProperty Rotation;
            public FloatTransitionProperty Z;
            public FloatTransitionProperty MinWidth;
            public FloatTransitionProperty MinHeight;
            public FloatTransitionProperty FlexWidth;
            public FloatTransitionProperty FlexHeight;
        }

        private struct LayoutElementData
        {
            public LayoutElement Instance;
            public int Priority;
            public bool IgnoreLayout;
        }

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "align", (e, v) => e.SetAlign(v) },
            { "anchor", (e, v) => e.SetAnchor(v) },
            { "width", (e, v) => e.SetLayoutTransition(e._layoutData.Width, v) },
            { "height", (e, v) => e.SetLayoutTransition(e._layoutData.Height, v) },
            { "margin", (e, v) => e.SetLayoutTransition(e._layoutData.Margin, v) },
            { "margin-left", (e, v) => e.SetLayoutTransition(e._layoutData.MarginLeft, v) },
            { "margin-top", (e, v) => e.SetLayoutTransition(e._layoutData.MarginTop, v) },
            { "margin-right", (e, v) => e.SetLayoutTransition(e._layoutData.MarginRight, v) },
            { "margin-bottom", (e, v) => e.SetLayoutTransition(e._layoutData.MarginBottom, v) },
            { "margin-x", (e, v) => e.SetLayoutTransition(e._layoutData.MarginX, v) },
            { "margin-y", (e, v) => e.SetLayoutTransition(e._layoutData.MarginY, v) },
            { "z", (e, v) => e.SetLayoutTransition(e._layoutData.Z, v) },
            { "rotation", (e, v) => e.SetLayoutTransition(e._layoutData.Rotation, v) },
            { "min-width", (e, v) => e.SetLayoutTransition(e._layoutData.MinWidth, v) },
            { "min-height", (e, v) => e.SetLayoutTransition(e._layoutData.MinHeight, v) },
            { "flex-width", (e, v) => e.SetLayoutTransition(e._layoutData.FlexWidth, v) },
            { "flex-height", (e, v) => e.SetLayoutTransition(e._layoutData.FlexHeight, v) },
            { "ignore-layout", (e, v) => e.SetIgnoreLayout(v) },
            { "priority", (e, v) => e.SetInt(ref e._layoutElementData.Priority, v) },
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
        // private LayoutData _layoutData;
        private LayoutDataTransition _layoutData;
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

            _layoutData = new LayoutDataTransition()
            {
                Width = new FloatTransitionProperty(TriggerLayoutUpdate),
                Height = new FloatTransitionProperty(TriggerLayoutUpdate),
                MarginLeft = new FloatTransitionProperty(TriggerLayoutUpdate),
                MarginTop = new FloatTransitionProperty(TriggerLayoutUpdate),
                MarginRight = new FloatTransitionProperty(TriggerLayoutUpdate),
                MarginBottom = new FloatTransitionProperty(TriggerLayoutUpdate),
                MarginX = new FloatTransitionProperty(TriggerLayoutUpdate),
                MarginY = new FloatTransitionProperty(TriggerLayoutUpdate),
                Margin = new FloatTransitionProperty(TriggerLayoutUpdate),
                Rotation = new FloatTransitionProperty(TriggerLayoutUpdate),
                Z = new FloatTransitionProperty(TriggerLayoutUpdate),
                MinWidth = new FloatTransitionProperty(TriggerLayoutUpdate, -1),
                MinHeight = new FloatTransitionProperty(TriggerLayoutUpdate, -1),
                FlexWidth = new FloatTransitionProperty(TriggerLayoutUpdate, -1),
                FlexHeight = new FloatTransitionProperty(TriggerLayoutUpdate, -1),
            };

            {
                Transitions.Add("width", _layoutData.Width);
                Transitions.Add("height", _layoutData.Height);
                Transitions.Add("margin-left", _layoutData.MarginLeft);
                Transitions.Add("margin-top", _layoutData.MarginTop);
                Transitions.Add("margin-right", _layoutData.MarginRight);
                Transitions.Add("margin-bottom", _layoutData.MarginBottom);
                Transitions.Add("margin-x", _layoutData.MarginX);
                Transitions.Add("margin-y", _layoutData.MarginY);
                Transitions.Add("margin", _layoutData.Margin);
                Transitions.Add("rotation", _layoutData.Rotation);
                Transitions.Add("z", _layoutData.Z);
                Transitions.Add("min-width", _layoutData.MinWidth);
                Transitions.Add("min-height", _layoutData.MinHeight);
                Transitions.Add("flex-width", _layoutData.FlexWidth);
                Transitions.Add("flex-height", _layoutData.FlexHeight);
            }
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
            ApplyLayout(_layoutData);
        }

        private void TriggerLayoutUpdate(float _)
        {
            IsUpdatePending = true;
        }

        private void SetLayoutTransition(FloatTransitionProperty f, string v)
        {
            if (string.IsNullOrEmpty(v) || !float.TryParse(v, out var value))
            {
                f.Reset();
                return;
            }
            DocumentUtils.OnTransitionValueUpdate += () => f.SetValue(value);
        }

        private void ApplyLayout(LayoutDataTransition layoutData)
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

            var marginX = layoutData.Margin.Current + layoutData.MarginX.Current;
            var marginY = layoutData.Margin.Current + layoutData.MarginY.Current;

            switch (_align)
            {
                case AlignType.TopLeft:
                    Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft.Current - layoutData.MarginRight.Current, -marginY - layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.TopCenter:
                    Instance.anchoredPosition = new Vector2(layoutData.MarginLeft.Current - layoutData.MarginRight.Current, -marginY - layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.TopRight:
                    Instance.anchoredPosition = new Vector2(-marginX - layoutData.MarginRight.Current + layoutData.MarginLeft.Current, -marginY - layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.MiddleLeft:
                    Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft.Current - layoutData.MarginRight.Current, -layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.MiddleCenter:
                    Instance.anchoredPosition = new Vector2(layoutData.MarginLeft.Current - layoutData.MarginRight.Current, -layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.MiddleRight:
                    Instance.anchoredPosition = new Vector2(-marginX - layoutData.MarginRight.Current + layoutData.MarginLeft.Current, -layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.BottomLeft:
                    Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft.Current - layoutData.MarginRight.Current, marginY + layoutData.MarginBottom.Current - layoutData.MarginTop.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.BottomCenter:
                    Instance.anchoredPosition = new Vector2(layoutData.MarginLeft.Current - layoutData.MarginRight.Current, marginY + layoutData.MarginBottom.Current - layoutData.MarginTop.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.BottomRight:
                    Instance.anchoredPosition = new Vector2(-marginX - layoutData.MarginRight.Current + layoutData.MarginLeft.Current, marginY + layoutData.MarginBottom.Current - layoutData.MarginTop.Current);
                    Instance.sizeDelta = new Vector2(layoutData.Width.Current, layoutData.Height.Current);
                    break;
                case AlignType.TopStretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft.Current) * pivot.x - (marginX + layoutData.MarginRight.Current) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, -marginY - layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - layoutData.MarginRight.Current - layoutData.MarginLeft.Current, layoutData.Height.Current);
                        break;
                    }
                case AlignType.MiddleStretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft.Current) * pivot.x - (marginX + layoutData.MarginRight.Current) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, -layoutData.MarginTop.Current + layoutData.MarginBottom.Current);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - layoutData.MarginRight.Current - layoutData.MarginLeft.Current, layoutData.Height.Current);
                        break;
                    }
                case AlignType.BottomStretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft.Current) * pivot.x - (marginX + layoutData.MarginRight.Current) * (1f - pivot.x);
                        Instance.anchoredPosition = new Vector2(posX, marginY + layoutData.MarginBottom.Current - layoutData.MarginTop.Current);
                        Instance.sizeDelta = new Vector2(-marginX * 2 - layoutData.MarginRight.Current - layoutData.MarginLeft.Current, layoutData.Height.Current);
                        break;
                    }
                case AlignType.LeftStretch:
                    {
                        var posY = (marginY + layoutData.MarginBottom.Current) * pivot.y - (marginY + layoutData.MarginTop.Current) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(marginX + layoutData.MarginLeft.Current - layoutData.MarginRight.Current, posY);
                        Instance.sizeDelta = new Vector2(layoutData.Width.Current, -marginY * 2 - layoutData.MarginBottom.Current - layoutData.MarginTop.Current);
                        break;
                    }
                case AlignType.CenterStretch:
                    {
                        var posY = (marginY + layoutData.MarginBottom.Current) * pivot.y - (marginY + layoutData.MarginTop.Current) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(layoutData.MarginLeft.Current - layoutData.MarginRight.Current, posY);
                        Instance.sizeDelta = new Vector2(layoutData.Width.Current, -marginY * 2 - layoutData.MarginBottom.Current - layoutData.MarginTop.Current);
                        break;
                    }
                case AlignType.RightStretch:
                    {
                        var posY = (marginY + layoutData.MarginBottom.Current) * pivot.y - (marginY + layoutData.MarginTop.Current) * (1f - pivot.y);
                        Instance.anchoredPosition = new Vector2(layoutData.MarginLeft.Current - layoutData.MarginRight.Current, posY);
                        Instance.sizeDelta = new Vector2(layoutData.Width.Current, -marginY * 2 - layoutData.MarginBottom.Current - layoutData.MarginTop.Current);
                        break;
                    }
                case AlignType.Stretch:
                    {
                        var posX = (marginX + layoutData.MarginLeft.Current) * pivot.x - (marginX + layoutData.MarginRight.Current) * (1f - pivot.x);
                        var posY = (marginY + layoutData.MarginBottom.Current) * pivot.y - (marginY + layoutData.MarginTop.Current) * (1f - pivot.y);
                        var sizeX = -marginX * 2 - layoutData.MarginRight.Current - layoutData.MarginLeft.Current;
                        var sizeY = -marginY * 2 - layoutData.MarginBottom.Current - layoutData.MarginTop.Current;
                        Instance.anchoredPosition = new Vector2(posX, posY);
                        Instance.sizeDelta = new Vector2(sizeX, sizeY);
                        break;
                    }
            }

            Instance.localRotation = Quaternion.Euler(0, 0, layoutData.Rotation.Current);

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
                var width = Mathf.Max(layoutData.Width.Current, layoutData.MinWidth.Current);
                var height = Mathf.Max(layoutData.Height.Current, layoutData.MinHeight.Current);
                if (width == 0) width = -1;
                if (height == 0) height = -1;

                layoutElement.minWidth = layoutData.MinWidth.Current;
                layoutElement.minHeight = layoutData.MinHeight.Current;
                layoutElement.preferredWidth = width;
                layoutElement.preferredHeight = height;
                layoutElement.flexibleWidth = layoutData.FlexWidth.Current;
                layoutElement.flexibleHeight = layoutData.FlexHeight.Current;
                layoutElement.layoutPriority = _layoutElementData.Priority;
                layoutElement.ignoreLayout = _layoutElementData.IgnoreLayout;
            }

            var localPosition = Instance.localPosition;
            localPosition.z = -layoutData.Z.Current;
            Instance.localPosition = localPosition;
        }

        public override void SetTransition(string key, float duration, CubicBezier timingFunction, float delay)
        {
            if (key == "rect")
            {
                foreach (var p in Transitions.Values)
                {
                    p.Duration = duration;
                    p.TimingFunction = timingFunction;
                    p.Delay = delay;
                }
                return;
            }

            base.SetTransition(key, duration, timingFunction, delay);
        }

        public override void Reuse()
        {
            base.Reuse();
            IsUpdatePending = true;
        }

        public override void Reset()
        {
            base.Reset();

            _layoutData.Width.Reset();
            _layoutData.Height.Reset();
            _layoutData.MarginLeft.Reset();
            _layoutData.MarginTop.Reset();
            _layoutData.MarginRight.Reset();
            _layoutData.MarginBottom.Reset();
            _layoutData.MarginX.Reset();
            _layoutData.MarginY.Reset();
            _layoutData.Margin.Reset();
            _layoutData.Rotation.Reset();
            _layoutData.Z.Reset();
            _layoutData.MinWidth.Reset();
            _layoutData.MinHeight.Reset();
            _layoutData.FlexWidth.Reset();
            _layoutData.FlexHeight.Reset();

            _layoutElementData.IgnoreLayout = false;
            _layoutElementData.Priority = 0;

            _align = AlignType.Stretch;
            _anchor = Vector2.zero;
            _autoAnchor = true;
        }
    }
}
