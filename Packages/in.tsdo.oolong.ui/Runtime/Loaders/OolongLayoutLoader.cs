using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    public class OolongLayoutLoader : OolongLoader
    {
        private delegate void LayoutAttrHandler(OolongLayoutLoader e, string value);
        private static readonly Dictionary<string, LayoutAttrHandler> s_attr = new Dictionary<string, LayoutAttrHandler>()
        {
            { "layout", ((e, v) => e.SetLayout(v)) },
            { "fit-content", ((e, v) => e.SetFitContent(v)) },
            { "reverse", ((e, v) => e.SetReverse(v)) },
            { "spacing", ((e, v) => e.SetFloat(ref e._spacing, v)) },
            { "spacing-x", ((e, v) => e.SetFloat(ref e._spacingX, v)) },
            { "spacing-y", ((e, v) => e.SetFloat(ref e._spacingY, v)) },
            { "cell-width", ((e, v) => e.SetFloat(ref e._cellWidth, v, 100)) },
            { "cell-height", ((e, v) => e.SetFloat(ref e._cellHeight, v, 100)) },
            { "padding", (e, v) => e.SetFloat(ref e._padding, v) },
            { "padding-left", (e, v) => e.SetFloat(ref e._paddingLeft, v) },
            { "padding-top", (e, v) => e.SetFloat(ref e._paddingTop, v) },
            { "padding-right", (e, v) => e.SetFloat(ref e._paddingRight, v) },
            { "padding-bottom", (e, v) => e.SetFloat(ref e._paddingBottom, v) },
            { "padding-x", (e, v) => e.SetFloat(ref e._paddingX, v) },
            { "padding-y", (e, v) => e.SetFloat(ref e._paddingY, v) },
            { "child-align", (e, v) => e.SetChildAlignment(v) },
            { "start-corner", (e, v) => e.SetStartCorner(v) },
            { "start-axis", (e, v) => e.SetStartAxis(v) },
            { "columns", (e, v) => e.SetFloat(ref e._columns, v) },
            { "rows", (e, v) => e.SetFloat(ref e._rows, v) },
        };

        private static readonly Dictionary<string, TextAnchor> s_anchors = new Dictionary<string, TextAnchor>()
        {
            { "top left", TextAnchor.UpperLeft },
            { "top center", TextAnchor.UpperCenter },
            { "top right", TextAnchor.UpperRight },
            { "middle left", TextAnchor.MiddleLeft },
            { "middle center", TextAnchor.MiddleCenter },
            { "middle right", TextAnchor.MiddleRight },
            { "bottom left", TextAnchor.LowerLeft },
            { "bottom center", TextAnchor.LowerCenter },
            { "bottom right", TextAnchor.LowerRight },
        };

        private static readonly Dictionary<string, GridLayoutGroup.Corner> s_corners = new Dictionary<string, GridLayoutGroup.Corner>()
        {
            { "top left", GridLayoutGroup.Corner.UpperLeft },
            { "top right", GridLayoutGroup.Corner.UpperRight },
            { "bottom left", GridLayoutGroup.Corner.LowerLeft },
            { "bottom right", GridLayoutGroup.Corner.LowerRight },
        };

        private readonly GameObject _obj;

        private HorizontalOrVerticalLayoutGroup _layoutGroup;
        private GridLayoutGroup _gridGroup;
        private ContentSizeFitter _fitter;

        private float _spacing;
        private float _spacingX;
        private float _spacingY;
        private bool _reverse;

        private float _padding;
        private float _paddingLeft;
        private float _paddingTop;
        private float _paddingRight;
        private float _paddingBottom;
        private float _paddingX;
        private float _paddingY;

        private float _cellWidth = 100;
        private float _cellHeight = 100;
        private float _columns;
        private float _rows;
        private GridLayoutGroup.Corner _startCorner = GridLayoutGroup.Corner.UpperLeft;
        private GridLayoutGroup.Axis _startAxis = GridLayoutGroup.Axis.Horizontal;

        private TextAnchor _childAlignment = TextAnchor.UpperLeft;

        public OolongLayoutLoader(GameObject obj)
        {
            _obj = obj;
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

        private void SetChildAlignment(string v)
        {
            if (v == null || !s_anchors.ContainsKey(v))
            {
                _childAlignment = TextAnchor.UpperLeft;
                return;
            }

            _childAlignment = s_anchors[v];
            IsLayoutDirty = true;
        }

        private void SetStartCorner(string v)
        {
            if (v == null || !s_corners.ContainsKey(v))
            {
                _startCorner = GridLayoutGroup.Corner.UpperLeft;
                return;
            }

            _startCorner = s_corners[v];
            IsLayoutDirty = true;
        }

        private void SetStartAxis(string v)
        {
            if (v == null || v != "vertical")
            {
                _startAxis = GridLayoutGroup.Axis.Horizontal;
                return;
            }

            _startAxis = GridLayoutGroup.Axis.Vertical;
            IsLayoutDirty = true;
        }

        private void SetReverse(string v)
        {
            if (v == null)
                _reverse = false;
            else
                _reverse = true;

            IsLayoutDirty = true;
        }

        protected override void OnLayout()
        {
            base.OnLayout();

            LayoutGroup group = null;
            if (_layoutGroup != null)
            {
                _layoutGroup.spacing = _spacing + (_layoutGroup is HorizontalLayoutGroup ? _spacingX : _spacingY);
                _layoutGroup.reverseArrangement = _reverse;
                group = _layoutGroup;
            }
            else if (_gridGroup)
            {
                _gridGroup.spacing = new Vector2(_spacing + _spacingX, _spacing + _spacingY);
                _gridGroup.startCorner = _startCorner;
                _gridGroup.startAxis = _startAxis;
                _gridGroup.cellSize = new Vector2(_cellWidth, _cellHeight);

                if (_columns > 0 && _rows > 0)
                {
                    Debug.LogWarning("[OolongMithril] Both columns and rows are set. Only one should be set. None of them are used.");
                }
                else if (_columns > 0)
                {
                    _gridGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
                    _gridGroup.constraintCount = (int)_columns;
                }
                else if (_rows > 0)
                {
                    _gridGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
                    _gridGroup.constraintCount = (int)_rows;
                }
                else
                {
                    _gridGroup.constraint = GridLayoutGroup.Constraint.Flexible;
                }
                group = _gridGroup;
            }

            if (group == null) return;
            var paddingX = _padding + _paddingX;
            var paddingY = _padding + _paddingY;
            var paddingLeft = Mathf.RoundToInt(paddingX + _paddingLeft);
            var paddingRight = Mathf.RoundToInt(paddingX + _paddingRight);
            var paddingTop = Mathf.RoundToInt(paddingY + _paddingTop);
            var paddingBottom = Mathf.RoundToInt(paddingY + _paddingBottom);
            group.padding = new RectOffset(paddingLeft, paddingRight, paddingTop, paddingBottom);
            group.childAlignment = _childAlignment;
        }


        public override void Reuse() { }

        public override void Reset()
        {
            foreach (var kvp in s_attr)
                kvp.Value(this, null);
        }

        private void SetFitContent(string v)
        {
            if (v == null && _fitter != null)
            {
                if (_fitter != null)
                    _fitter.enabled = false;
            }
            else if (v != null && _fitter == null)
            {
                if (_fitter == null)
                    _fitter = _obj.AddComponent<ContentSizeFitter>();
            }

            if (v != null && _fitter != null)
            {
                switch (v)
                {
                    case "x":
                        _fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                        break;
                    case "y":
                        _fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                        break;
                    default: // "xy"
                        _fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                        _fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                        break;
                }
                _fitter.enabled = true;
            }
        }

        private void SetLayout(string v)
        {
            switch (v)
            {
                case "horizontal":
                    if (_gridGroup != null)
                    {
                        Object.DestroyImmediate(_gridGroup);
                        _gridGroup = null;
                    }

                    if (!(_layoutGroup is HorizontalLayoutGroup))
                    {
                        Object.DestroyImmediate(_layoutGroup);
                        _layoutGroup = null;
                    }

                    if (_layoutGroup == null)
                    {
                        _layoutGroup = _obj.AddComponent<HorizontalLayoutGroup>();
                        _layoutGroup.childControlHeight = true;
                        _layoutGroup.childControlWidth = true;
                        _layoutGroup.childScaleHeight = false;
                        _layoutGroup.childScaleWidth = false;
                        _layoutGroup.childForceExpandHeight = false;
                        _layoutGroup.childForceExpandWidth = false;
                        IsLayoutDirty = true;
                    }

                    break;
                case "vertical":
                    if (_gridGroup != null)
                    {
                        Object.DestroyImmediate(_gridGroup);
                        _gridGroup = null;
                    }

                    if (!(_layoutGroup is VerticalLayoutGroup))
                    {
                        Object.DestroyImmediate(_layoutGroup);
                        _layoutGroup = null;
                    }

                    if (_layoutGroup == null)
                    {
                        _layoutGroup = _obj.AddComponent<VerticalLayoutGroup>();
                        _layoutGroup.childControlHeight = true;
                        _layoutGroup.childControlWidth = true;
                        _layoutGroup.childScaleHeight = false;
                        _layoutGroup.childScaleWidth = false;
                        _layoutGroup.childForceExpandHeight = false;
                        _layoutGroup.childForceExpandWidth = false;
                        IsLayoutDirty = true;
                    }
                    break;
                case "grid":
                    if (_layoutGroup != null)
                    {
                        Object.DestroyImmediate(_layoutGroup);
                        _layoutGroup = null;
                    }

                    if (_gridGroup == null)
                    {
                        _gridGroup = _obj.AddComponent<GridLayoutGroup>();
                        IsLayoutDirty = true;
                    }
                    break;
                default:
                    if (_layoutGroup != null)
                        Object.DestroyImmediate(_layoutGroup);
                    if (_gridGroup != null)
                        Object.DestroyImmediate(_gridGroup);
                    _layoutGroup = null;
                    _gridGroup = null;
                    break;
            }
        }
    }
}
