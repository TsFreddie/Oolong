using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    public class OolongSliderLoader : OolongLoader<OolongSliderLoader>
    {
        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            //
            { "direction", (e, v) => { e.SetDirection(v); } },
            { "inset", (e, v) => { e.SetFloat(ref e._handleInset, v); } },
            { "handle-width", (e, v) => { e.SetFloat(ref e._handleWidth, v, 20.0f); } },
            { "handle-height", (e, v) => { e.SetFloat(ref e._handleHeight, v, 20.0f); } },
            { "thickness", (e, v) => { e.SetFloat(ref e._thickness, v, 10.0f); } },
            { "value", (e, v) => { e.SetValue(v); } },
            { "min", (e, v) => { e.SetMin(v); } },
            { "max", (e, v) => { e.SetMax(v); } },
            { "int", (e, v) => { e.SetInteger(v); } },
            { "handle-offset-x", (e, v) => { e.SetFloat(ref e._handleOffsetX, v); } },
            { "handle-offset-y", (e, v) => { e.SetFloat(ref e._handleOffsetY, v); } },
        };

        public readonly Slider Instance;

        private bool _directionLocked = false;
        private readonly RectTransform _fillArea;
        private readonly RectTransform _slidingArea;
        private readonly RectTransform _fillRect;
        private readonly RectTransform _bgRect;
        private readonly RectTransform _handleRect;
        private readonly RectTransform _sliderRect;

        private readonly OolongSelectableLoader _selectable;
        private readonly OolongImageLoader _image;
        private readonly OolongImageLoader _fill;

        private float _handleInset = 0.0f;
        private Slider.Direction _direction = Slider.Direction.LeftToRight;
        private float _thickness = 10.0f;
        private float _handleWidth = 20.0f;
        private float _handleHeight = 20.0f;
        private float _handleOffsetX = 0.0f;
        private float _handleOffsetY = 0.0f;

        public bool Enabled => _selectable.HasImage;

        public OolongSliderLoader(GameObject obj, string tagName)
        {
            Instance = obj.AddComponent<Slider>();
            _sliderRect = Instance.GetComponent<RectTransform>();

            _fillArea = DocumentUtils.CreateChildRect(obj.transform, "::fill-area");
            _fillArea.anchorMin = Vector2.zero;
            _fillArea.anchorMax = Vector2.one;
            _fillArea.offsetMin = Vector2.zero;
            _fillArea.offsetMax = Vector2.zero;

            _bgRect = DocumentUtils.CreateChildRect(_fillArea.transform, "::background");
            _bgRect.anchorMin = Vector2.zero;
            _bgRect.anchorMax = Vector2.one;
            _bgRect.offsetMin = Vector2.zero;
            _bgRect.offsetMax = Vector2.zero;
            _image = new OolongImageLoader(_bgRect.gameObject.AddComponent<Image>(), tagName) { DefaultType = "slice" };

            _fillRect = DocumentUtils.CreateChildRect(_fillArea.transform, "::fill");
            Instance.fillRect = _fillRect;
            _fillRect.anchorMin = Vector2.zero;
            _fillRect.anchorMax = Vector2.one;
            _fillRect.offsetMin = Vector2.zero;
            _fillRect.offsetMax = Vector2.zero;
            _fill = new OolongImageLoader(_fillRect.gameObject.AddComponent<Image>(), tagName) { DefaultType = "slice" };

            _slidingArea = DocumentUtils.CreateChildRect(obj.transform, "::sliding-area");
            _slidingArea.anchorMin = Vector2.zero;
            _slidingArea.anchorMax = Vector2.one;
            _slidingArea.offsetMin = Vector2.zero;
            _slidingArea.offsetMax = Vector2.zero;

            _handleRect = DocumentUtils.CreateChildRect(_slidingArea.transform, "::handle");
            Instance.handleRect = _handleRect;
            _handleRect.anchorMin = Vector2.zero;
            _handleRect.anchorMax = Vector2.one;
            _handleRect.offsetMin = Vector2.zero;
            _handleRect.offsetMax = Vector2.zero;
            Instance.targetGraphic = _handleRect.gameObject.AddComponent<Image>();
            _selectable = new OolongSelectableLoader(Instance, tagName);

            IsLayoutDirty = true;
        }

        public OolongSliderLoader(GameObject obj, Slider.Direction direction, string tagName) : this(obj, tagName)
        {
            Instance.direction = direction;
            _directionLocked = true;
        }

        private bool SetAttributeInternal(string prefix, string key, string value)
        {
            if (base.SetAttribute(prefix, key, value)) return true;
            if (_selectable.SetAttribute(prefix, key, value)) return true;
            if (_image.SetAttribute($"bg-{prefix}", key, value)) return true;
            if (_fill.SetAttribute($"fill-{prefix}", key, value)) return true;
            return true;
        }

        public override bool SetAttribute(string prefix, string key, string value)
        {
            var result = SetAttributeInternal(prefix, key, value);
            Instance.gameObject.SetActive(Enabled);
            return result;
        }

        private void SetValue(string v)
        {
            if (v == null) return;
            Instance.SetValueWithoutNotify(float.Parse(v));
        }

        private void SetMin(string v)
        {
            if (v == null) return;
            Instance.minValue = float.Parse(v);
        }

        private void SetMax(string v)
        {
            if (v == null) return;
            Instance.maxValue = float.Parse(v);
        }

        private void SetInteger(string v)
        {
            Instance.wholeNumbers = v != null;
        }

        private void SetDirection(string v)
        {
            if (_directionLocked) return;
            _direction = v switch
            {
                "rl" => Slider.Direction.RightToLeft,
                "bt" => Slider.Direction.BottomToTop,
                "tb" => Slider.Direction.TopToBottom,
                _ => Slider.Direction.LeftToRight
            };
        }

        protected override void OnLayout()
        {
            base.OnLayout();
            Instance.direction = _direction;
            var isHorizontal = _direction == Slider.Direction.LeftToRight || _direction == Slider.Direction.RightToLeft;

            var inset = _handleInset * 2;
            _slidingArea.sizeDelta = new Vector2(-inset, -inset);

            var sizeX = isHorizontal ? _handleWidth : _handleWidth - _sliderRect.sizeDelta.x + inset;
            var sizeY = isHorizontal ? _handleHeight - _sliderRect.sizeDelta.y + inset : _handleHeight;
            _handleRect.sizeDelta = new Vector2(sizeX, sizeY);

            _fillArea.sizeDelta = isHorizontal ? new Vector2(-inset, _thickness - _sliderRect.sizeDelta.y) : new Vector2(_thickness - _sliderRect.sizeDelta.x, -inset);
            _bgRect.sizeDelta = isHorizontal ? new Vector2(inset, 0) : new Vector2(0, inset);
            switch (_direction)
            {
                case Slider.Direction.LeftToRight:
                    _fillRect.offsetMin = new Vector2(-_handleInset, 0);
                    _fillRect.offsetMax = Vector2.zero;
                    break;
                case Slider.Direction.TopToBottom:
                    _fillRect.offsetMin = Vector2.zero;
                    _fillRect.offsetMax = new Vector2(0, _handleInset);
                    break;
                case Slider.Direction.RightToLeft:
                    _fillRect.offsetMin = new Vector2(0, _handleInset);
                    _fillRect.offsetMax = Vector2.zero;
                    break;
                case Slider.Direction.BottomToTop:
                    _fillRect.offsetMin = new Vector2(_handleInset, 0);
                    _fillRect.offsetMax = Vector2.zero;
                    break;
            }

            _handleRect.anchoredPosition = new Vector2(_handleOffsetX, -_handleOffsetY);
        }

        public override void Reuse() { }


        public override void Reset()
        {
            _selectable.Reset();
            _image.Reset();
            _fill.Reset();

            foreach (var kvp in s_attrs)
                kvp.Value(this, null);
        }

        public override void Release()
        {
            base.Release();
            _selectable.Release();
            _image.Release();
            _fill.Release();
        }
    }
}
