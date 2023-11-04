using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    public class OolongScrollbarLoader : OolongLoader
    {
        // TODO: 若需要通用scrollbar元素，别忘了在这里先实现 direction, value, size 和 steps
        // TODO: 目前只是为了支持ScrollView和InputField所以只做了部分参数
        private delegate void ScrollbarAttrHandler(OolongScrollbarLoader e, string value);
        private static readonly Dictionary<string, ScrollbarAttrHandler> s_attr = new Dictionary<string, ScrollbarAttrHandler>() { { "min-length", (e, v) => e.SetMinLength(v) } };

        public Scrollbar Instance;

        // TODO: 若支持通用scrollbar，使用这个参数跳过direction设置。因为scrollview中的滚动条不应该可以修改方向
        private bool _directionLocked = false;
        private float _halfMinHandleLength = 10.0f;
        private RectTransform _slidingArea;
        private RectTransform _handleRect;

        private readonly OolongSelectableLoader _selectable;
        private readonly OolongImageLoader _image;

        public bool Enabled => _selectable.HasImage;

        public OolongScrollbarLoader(GameObject obj)
        {
            Instance = obj.AddComponent<Scrollbar>();
            _image = new OolongImageLoader(obj.AddComponent<Image>()) { DefaultType = "slice" };

            var offsetPositive = new Vector2(_halfMinHandleLength, _halfMinHandleLength);
            var offsetNegative = new Vector2(-_halfMinHandleLength, -_halfMinHandleLength);

            _slidingArea = DocumentUtils.CreateChildRect(obj.transform, "::sliding-area");
            _slidingArea.anchorMin = Vector2.zero;
            _slidingArea.anchorMax = Vector2.one;
            _slidingArea.offsetMin = offsetPositive;
            _slidingArea.offsetMax = offsetNegative;

            _handleRect = DocumentUtils.CreateChildRect(_slidingArea.transform, "::handle");
            Instance.handleRect = _handleRect;
            // Let scrollbar correct the anchor
            _handleRect.anchorMin = Vector2.zero;
            _handleRect.anchorMax = Vector2.one;
            _handleRect.offsetMin = offsetNegative;
            _handleRect.offsetMax = offsetPositive;
            Instance.targetGraphic = _handleRect.gameObject.AddComponent<Image>();
            _selectable = new OolongSelectableLoader(Instance);
        }

        public OolongScrollbarLoader(GameObject obj, Scrollbar.Direction direction) : this(obj)
        {
            Instance.direction = direction;
            _directionLocked = true;
        }

        private bool SetAttributeInternal(string prefix, string key, string value)
        {
            if (prefix != null)
            {
                if (!key.StartsWith(prefix)) return false;
                key = key.Substring(prefix.Length);
            }

            if (_selectable.SetAttribute(key, value)) return true;
            if (_image.SetAttribute("bg-", key, value)) return true;

            if (!s_attr.ContainsKey(key))
                return false;

            s_attr[key](this, value);
            return true;
        }

        public bool SetAttribute(string prefix, string key, string value)
        {
            var result = SetAttributeInternal(prefix, key, value);
            Instance.gameObject.SetActive(Enabled);
            return result;
        }

        public bool SetAttribute(string key, string value)
        {
            return SetAttribute(null, key, value);
        }

        private void SetMinLength(string v)
        {
            var value = 10.0f;
            if (v != null) value = float.Parse(v);

            _halfMinHandleLength = value / 2.0f;

            var offsetPositive = new Vector2(_halfMinHandleLength, _halfMinHandleLength);
            var offsetNegative = new Vector2(-_halfMinHandleLength, -_halfMinHandleLength);
            _slidingArea.offsetMin = offsetPositive;
            _slidingArea.offsetMax = offsetNegative;
            _handleRect.offsetMin = offsetNegative;
            _handleRect.offsetMax = offsetPositive;
        }

        public override void Reuse() { }

        public override void Reset()
        {
            _selectable.Reset();
            _image.Reset();
            foreach (var kvp in s_attr)
                kvp.Value(this, null);
        }

        public override void Release()
        {
            base.Release();
            _selectable.Release();
            _image.Release();
        }
    }
}
