using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    [AddComponentMenu("")]
    public class OolongInputField : OolongElement<OolongInputField>, IDeselectHandler
    {
        private TMP_InputField _input;

        private RectTransform _content;
        private RectTransform _textArea;
        private OolongSelectableLoader _selectable;
        private OolongTextLoader _placeholder;
        private OolongTextLoader _text;
        private RectMask2D _mask;

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "ph-text", ((e, v) => e.SetPlaceholderText(v)) },
            { "value", ((e, v) => e.SetValue(v)) },
            { "padding", (e, v) => e.SetFloat(ref e._padding, v) },
            { "padding-left", (e, v) => e.SetFloat(ref e._paddingLeft, v) },
            { "padding-top", (e, v) => e.SetFloat(ref e._paddingTop, v) },
            { "padding-right", (e, v) => e.SetFloat(ref e._paddingRight, v) },
            { "padding-bottom", (e, v) => e.SetFloat(ref e._paddingBottom, v) },
            { "padding-x", (e, v) => e.SetFloat(ref e._paddingX, v) },
            { "padding-y", (e, v) => e.SetFloat(ref e._paddingY, v) },
            { "clip-border", (e, v) => e.SetFloat(ref e._clipBorder, v) },
            { "caret-width", (e, v) => e.SetFloat(ref e._caretWidth, v) },
            { "caret-blink-rate", (e, v) => e.SetFloat(ref e._caretBlinkRate, v) },
            { "caret-color", (e, v) => e.SetCaretColor(v) },
            { "selection-color", (e, v) => e.SetColor(ref e._selectionColor, v, new Color32(168, 206, 255, 192)) },
            { "font", (e, v) => e.SetFont(v) },
        };

        public override Transform RootTransform => _content;

        public string Value => _input.text;

        private float _padding;
        private float _paddingLeft;
        private float _paddingTop;
        private float _paddingRight;
        private float _paddingBottom;
        private float _paddingX;
        private float _paddingY;
        private float _clipBorder;
        private float _caretWidth = 1;
        private float _caretBlinkRate = 0.85f;
        private Color _selectionColor = new Color32(168, 206, 255, 192);
        private Color _caretColor = new Color32(255, 255, 255, 255);
        private bool _customCaretColor = false;

        private string _font;
        private bool _fontInitialized = false;
        private Action _onDeselect;

        private void SetFont(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _font = null;
                return;
            }

            _font = v;
            _fontInitialized = false;
            IsLayoutDirtyLate = true;
        }

        private void OnFontChanged()
        {
            _input.fontAsset = null;
            _fontInitialized = false;
            IsLayoutDirtyLate = true;
        }

        private void SetupFont()
        {
            _input.fontAsset = TMP_Settings.defaultFontAsset;
            _fontInitialized = true;
        }

        protected override void OnLateLayout()
        {
            base.OnLateLayout();

            if ((!_fontInitialized || _input.fontAsset == null))
                SetupFont();
        }

        private void SetFloat(ref float f, string v)
        {
            var oldF = f;
            f = string.IsNullOrEmpty(v) ? 0 : float.Parse(v);
            if (!oldF.Equals(f)) IsLayoutDirty = true;
        }

        private void SetColor(ref Color c, string v, Color def)
        {
            var oldC = c;
            c = string.IsNullOrEmpty(v) ? def : DocumentUtils.ParseColor(v);
            if (!oldC.Equals(c)) IsLayoutDirty = true;
        }

        private void SetCaretColor(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _customCaretColor = false;
            }
            else
            {
                _customCaretColor = true;
                _caretColor = DocumentUtils.ParseColor(v);
            }
        }

        public override void OnCreate()
        {
            base.OnCreate();
            _input = gameObject.AddComponent<TMP_InputField>();
            var image = gameObject.AddComponent<Image>();
            _input.targetGraphic = image;
            _selectable = new OolongSelectableLoader(_input);
            _textArea = CreateChildRect("::textarea");
            var textAreaObj = _textArea.gameObject;

            // TODO: 支持配置 RectMask2D
            _mask = textAreaObj.AddComponent<RectMask2D>();
            _input.textViewport = _textArea;

            var placeholderRect = CreateChildRect(_textArea, "::placeholder");
            var textRect = CreateChildRect(_textArea, "::text");

            _placeholder = new OolongTextLoader(placeholderRect.gameObject.AddComponent<TextMeshProUGUI>());
            _placeholder.DefaultAlign = TextAlignmentOptions.Left;
            _placeholder.DefaultOverflow = TextOverflowModes.Ellipsis;
            _placeholder.DefaultStyle = FontStyles.Italic;
            _placeholder.DefaultColor = Color.gray;
            _placeholder.Instance.enableWordWrapping = false;
            _text = new OolongTextLoader(textRect.gameObject.AddComponent<TextMeshProUGUI>());
            _text.DefaultAlign = TextAlignmentOptions.Left;
            _text.DefaultOverflow = TextOverflowModes.Overflow;
            _input.placeholder = _placeholder.Instance;
            _input.textComponent = _text.Instance;
            _text.Instance.enableWordWrapping = false;
            _input.lineType = TMP_InputField.LineType.SingleLine;

            _content = CreateChildRect("::content");
            IsLayoutDirtyLate = true;
        }

        private void SetPlaceholderText(string v)
        {
            if (v == null) v = string.Empty;
            _placeholder.Instance.text = v;
        }

        private void SetValue(string v)
        {
            if (v == null) v = string.Empty;
            _input.SetTextWithoutNotify(v);
        }

        protected override void OnLayout()
        {
            base.OnLayout();

            IsLayoutDirty = false;

            var paddingX = _padding + _paddingX;
            var paddingY = _padding + _paddingY;
            var paddingLeft = paddingX + _paddingLeft;
            var paddingRight = paddingX + _paddingRight;
            var paddingTop = paddingY + _paddingTop;
            var paddingBottom = paddingY + _paddingBottom;

            _textArea.offsetMin = new Vector2(paddingLeft, paddingTop);
            _textArea.offsetMax = new Vector2(-paddingRight, -paddingBottom);
            _mask.padding = new Vector4(
                -paddingLeft + _clipBorder,
                -paddingBottom + _clipBorder,
                -paddingRight + _clipBorder,
                -paddingTop + _clipBorder);

            _input.caretWidth = Mathf.RoundToInt(_caretWidth);
            _input.caretBlinkRate = _caretBlinkRate;
            _input.selectionColor = _selectionColor;

            _input.customCaretColor = _customCaretColor;
            if (_customCaretColor)
                _input.caretColor = _caretColor;
        }

        protected override bool SetAttribute(string key, string value)
        {
            if (key == "#") return true;
            if (_selectable.SetAttribute(key, value)) return true;
            if (_text.SetAttribute("text-", key, value)) return true;
            if (_placeholder.SetAttribute("ph-", key, value)) return true;
            return false;
        }

        public override void AddListener(string key, IOolongElement.JsCallback callback)
        {
            base.AddListener(key, callback);

            switch (key)
            {
                case "input":
                    _input.onValueChanged.AddListener(_ => callback());
                    break;
                case "change":
                    _input.onEndEdit.AddListener(_ => callback());
                    break;
                case "select":
                    _input.onSelect.AddListener(_ => callback());
                    break;
                case "deselect":
                    _input.onDeselect.AddListener(_ => callback());
                    break;
                case "unfocus":
                    _onDeselect += () => callback();
                    break;
            }
        }

        public override void RemoveListener(string key)
        {
            base.RemoveListener(key);

            switch (key)
            {
                case "input":
                    _input.onValueChanged.RemoveAllListeners();
                    break;
                case "change":
                    _input.onEndEdit.RemoveAllListeners();
                    break;
                case "select":
                    _input.onSelect.RemoveAllListeners();
                    break;
                case "deselect":
                    _input.onDeselect.RemoveAllListeners();
                    break;
                case "unfocus":
                    _onDeselect = null;
                    break;
            }
        }

        public override void OnReuse()
        {
            base.OnReuse();
            _selectable.Reuse();
            _placeholder.Reuse();
            _text.Reuse();
            _fontInitialized = false;
        }

        public override void OnReset()
        {
            base.OnReset();
            _selectable.Reset();
            _placeholder.Reset();
            _text.Reset();
            _input.onValueChanged.RemoveAllListeners();
            _input.onEndEdit.RemoveAllListeners();
            _input.onSelect.RemoveAllListeners();
            _input.onDeselect.RemoveAllListeners();
            _onDeselect = null;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _selectable.Release();
            _placeholder.Release();
            _text.Release();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _onDeselect?.Invoke();
        }
    }
}
