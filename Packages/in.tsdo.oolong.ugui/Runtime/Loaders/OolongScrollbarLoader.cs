using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    public class OolongScrollbarLoader : OolongLoader<OolongScrollbarLoader>
    {
        /*
         * TODO: Currently implemented for ScrollView only, the following attributes is still missing:
         * direction
         * size
         * steps
         */
        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "min-length", (e, v) => e.SetMinLength(v) }
        };

        public readonly Scrollbar Instance;

        // TODO: This will be used to lock direction for ScrollView.
        private bool _directionLocked = false;
        private float _halfMinHandleLength = 10.0f;
        private RectTransform _slidingArea;
        private RectTransform _handleRect;

        private readonly OolongSelectableLoader _selectable;
        private readonly OolongImageLoader _image;

        public bool Enabled => _selectable.HasImage;

        public OolongScrollbarLoader(GameObject obj, string tagName)
        {
            Instance = obj.AddComponent<Scrollbar>();
            _image = new OolongImageLoader(obj.AddComponent<Image>(), tagName) { DefaultType = "slice" };

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
            _selectable = new OolongSelectableLoader(Instance, tagName);
        }

        public OolongScrollbarLoader(GameObject obj, Scrollbar.Direction direction, string tagName) : this(obj, tagName)
        {
            Instance.direction = direction;
            _directionLocked = true;
        }

        private bool SetAttributeInternal(string key, string value)
        {
            if (base.SetAttribute(key, value)) return true;
            if (_selectable.SetAttribute(key, value)) return true;
            if (key.StartsWith("bg-") && _image.SetAttribute(key.Substring(3), value))
                return true;
            return false;
        }

        public override bool SetAttribute(string key, string value)
        {
            var result = SetAttributeInternal(key, value);
            Instance.gameObject.SetActive(Enabled);
            return result;
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

        public override void Reset()
        {
            base.Reset();
            _selectable.Reset();
            _image.Reset();
        }

        public override void Release()
        {
            base.Release();
            _selectable.Release();
            _image.Release();
        }
    }
}
