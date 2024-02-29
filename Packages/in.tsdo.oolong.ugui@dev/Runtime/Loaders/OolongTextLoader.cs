#if UNITY_TMP || UNITY_UGUI_2

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class OolongTextLoader : OolongLoader<OolongTextLoader>
    {
        public readonly TextMeshProUGUI Instance;
        // Keep a copy of the element so TextTransformer can use the element's attributes
        public readonly OolongElement Element;

        private struct ExtendData
        {
            public float ExtendLeft;
            public float ExtendTop;
            public float ExtendRight;
            public float ExtendBottom;
            public float ExtendX;
            public float ExtendY;
            public float Extend;
        }

        private ExtendData _extendData;

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "#", (e, v) => e.SetText(v) },
            { "text", (e, v) => e.SetText(v) },
            { "material", (e, v) => e.SetMaterial(v) },
            { "text-align", (e, v) => e.SetTextAlign(v) },
            { "size", (e, v) => e.SetFontSize(v) },
            { "min-size", (e, v) => e.SetMinFontSize(v) },
            { "color", (e, v) => e.SetColor(v) },
            { "overflow", (e, v) => e.SetOverflow(v) },
            { "wrap", (e, v) => e.SetWrap(v) },
            { "passthrough", (e, v) => e.SetPassthrough(v) },
            { "rich-text", (e, v) => e.SetRichText(v) },
            { "extend", (e, v) => e.SetFloat(ref e._extendData.Extend, v) },
            { "extend-left", (e, v) => e.SetFloat(ref e._extendData.ExtendLeft, v) },
            { "extend-top", (e, v) => e.SetFloat(ref e._extendData.ExtendTop, v) },
            { "extend-right", (e, v) => e.SetFloat(ref e._extendData.ExtendRight, v) },
            { "extend-bottom", (e, v) => e.SetFloat(ref e._extendData.ExtendBottom, v) },
            { "extend-x", (e, v) => e.SetFloat(ref e._extendData.ExtendX, v) },
            { "extend-y", (e, v) => e.SetFloat(ref e._extendData.ExtendY, v) },
            { "styles", (e, v) => e.SetStyle(v) },
            { "outline", (e, v) => e.SetOutlineColor(v) },
            { "outline-thickness", (e, v) => e.SetOutlineThickness(v) },
            { "letter-spacing", (e, v) => e.SetFloat(ref e._letterSpacing, v) },
            { "word-spacing", (e, v) => e.SetFloat(ref e._wordSpacing, v) },
            { "line-spacing", (e, v) => e.SetFloat(ref e._lineSpacing, v) },
            { "paragraph-spacing", (e, v) => e.SetFloat(ref e._paragraphSpacing, v) },
            { "font", (e, v) => e.SetFont(v) },
        };

        private TextAlignmentOptions _defaultAlign = TextAlignmentOptions.Center;
        public TextAlignmentOptions DefaultAlign
        {
            get => _defaultAlign;
            set
            {
                _defaultAlign = value;
                Instance.alignment = _defaultAlign;
            }
        }

        private TextOverflowModes _defaultOverflow = TextOverflowModes.Overflow;
        public TextOverflowModes DefaultOverflow
        {
            get => _defaultOverflow;
            set
            {
                _defaultOverflow = value;
                Instance.overflowMode = _defaultOverflow;
            }
        }

        private bool _defaultWrap = false;
        public bool DefaultWrap
        {
            get => _defaultWrap;
            set
            {
                _defaultWrap = value;
                Instance.enableWordWrapping = _defaultWrap;
            }
        }

        private Color _defaultColor = Color.black;
        public Color DefaultColor
        {
            get => _defaultColor;
            set
            {
                _defaultColor = value;
                Instance.color = _defaultColor;
            }
        }

        private FontStyles _defaultStyle = FontStyles.Normal;
        public FontStyles DefaultStyle
        {
            get => _defaultStyle;
            set
            {
                _defaultStyle = value;
                Instance.fontStyle = _defaultStyle;
            }
        }

        private bool _outlineEnabled = false;
        private Color _outlineColor;
        private float _outlineThickness = 1.0f;
        private float _letterSpacing = 0.0f;
        private float _wordSpacing = 0.0f;
        private float _lineSpacing = 0.0f;
        private float _paragraphSpacing = 0.0f;
        private Material _materialInstance;

        private string _font;
        private string _material;
        private bool _fontInitialized = false;

        private string _text;
        private bool _textUpdatePending = false;

        public OolongTextLoader(GameObject gameObject, OolongElement element)
        {
            Instance = gameObject.AddComponent<TextMeshProUGUI>();
            Instance.alignment = TextAlignmentOptions.Center;
            Instance.color = Color.black;
            Instance.enableKerning = TMP_Settings.enableKerning;
            Instance.extraPadding = TMP_Settings.enableExtraPadding;
            Instance.tintAllSprites = TMP_Settings.enableTintAllSprites;
            Instance.parseCtrlCharacters = TMP_Settings.enableParseEscapeCharacters;
            Instance.fontSize = TMP_Settings.defaultFontSize;
            Instance.fontSizeMin = TMP_Settings.defaultFontSize;
            Instance.fontSizeMax = TMP_Settings.defaultFontSize;
            Instance.isTextObjectScaleStatic = TMP_Settings.isTextObjectScaleStatic;

            Instance.raycastTarget = true;
            Instance.enableWordWrapping = false;

            Element = element;

            IsLateUpdatePending = true;
        }

        private void SetFont(string v)
        {
            _font = string.IsNullOrEmpty(v) ? null : v;
            _fontInitialized = false;
            IsLateUpdatePending = true;
        }

        private void SetMaterial(string v)
        {
            _material = string.IsNullOrEmpty(v) ? null : v;
            _fontInitialized = false;
            IsLateUpdatePending = true;
        }

        private void SetupFont()
        {
            OolongTextMeshPro.GetFont(_font, _material, out var font, out var material);
            Instance.font = font;
            Instance.fontSharedMaterial = material;
            _fontInitialized = true;
        }

        private void SetPassthrough(string v)
        {
            if (v == null)
            {
                Instance.raycastTarget = true;
                return;
            }

            Instance.raycastTarget = false;
        }

        private void SetRichText(string v)
        {
            if (v == null)
            {
                Instance.richText = false;
                return;
            }

            Instance.richText = v != "disabled";
        }

        private void SetText(string text)
        {
            _text = text;
            RefreshText();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RefreshText()
        {
            if (!_textUpdatePending)
            {
                _textUpdatePending = true;
                DocumentUtils.OnDocumentUpdate += UpdateText;
            }
        }

        private void UpdateText()
        {
            _textUpdatePending = false;
            DocumentUtils.OnDocumentUpdate -= UpdateText;

            if (_text == null)
            {
                Instance.text = null;
                return;
            }
            Instance.text = OolongUGUI.TransformText(_text, this);
        }

        private void SetOutlineColor(string v)
        {
            if (v == null)
            {
                _outlineEnabled = false;
                IsLateUpdatePending = true;
                return;
            }

            _outlineEnabled = true;
            _outlineColor = DocumentUtils.ParseColor(v);
            IsLateUpdatePending = true;
        }

        private void SetOutlineThickness(string v)
        {
            if (v == null)
            {
                _outlineThickness = 1.0f;
                IsLateUpdatePending = true;
                return;
            }

            _outlineThickness = float.Parse(v);
            IsLateUpdatePending = true;
        }

        private void SetWrap(string v)
        {
            if (v == null)
            {
                Instance.enableWordWrapping = false;
                return;
            }

            Instance.enableWordWrapping = v != "disabled";
        }

        private void SetOverflow(string overflow)
        {
            if (overflow == null)
            {
                Instance.overflowMode = _defaultOverflow;
                return;
            }

            switch (overflow)
            {
                case "overflow":
                    Instance.overflowMode = TextOverflowModes.Overflow;
                    break;
                case "ellipsis":
                    Instance.overflowMode = TextOverflowModes.Ellipsis;
                    break;
                case "masking":
                    Instance.overflowMode = TextOverflowModes.Masking;
                    break;
                case "truncate":
                    Instance.overflowMode = TextOverflowModes.Truncate;
                    break;
                case "page":
                    Instance.overflowMode = TextOverflowModes.Page;
                    break;
                default:
                    Instance.overflowMode = _defaultOverflow;
                    break;
            }
        }

        private void SetStyle(string styles)
        {
            if (string.IsNullOrEmpty(styles))
            {
                Instance.fontStyle = _defaultStyle;
                return;
            }

            Instance.fontStyle = FontStyles.Normal;

            var words = styles.Split(' ');
            foreach (var word in words)
            {
                switch (word)
                {
                    case "bold":
                        Instance.fontStyle |= FontStyles.Bold;
                        break;
                    case "italic":
                        Instance.fontStyle |= FontStyles.Italic;
                        break;
                    case "underline":
                        Instance.fontStyle |= FontStyles.Underline;
                        break;
                    case "strikethrough":
                        Instance.fontStyle |= FontStyles.Strikethrough;
                        break;
                    case "uppercase":
                        Instance.fontStyle |= FontStyles.UpperCase;
                        break;
                    case "lowercase":
                        Instance.fontStyle |= FontStyles.LowerCase;
                        break;
                    case "smallcaps":
                        Instance.fontStyle |= FontStyles.SmallCaps;
                        break;
                    case "subscript":
                        Instance.fontStyle |= FontStyles.Subscript;
                        break;
                    case "superscript":
                        Instance.fontStyle |= FontStyles.Superscript;
                        break;
                    case "highlight":
                        Instance.fontStyle |= FontStyles.Highlight;
                        break;
                }
            }
        }

        private void SetTextAlign(string align)
        {
            if (string.IsNullOrEmpty(align))
            {
                Instance.alignment = _defaultAlign;
                return;
            }

            var words = align.Split(' ');
            var value = 0x0202; // default to middle center
            foreach (var word in words)
            {
                switch (word)
                {
                    case "left":
                        value = value & 0xFF00 | 0x0001;
                        break;
                    case "center":
                        value = value & 0xFF00 | 0x0002;
                        break;
                    case "right":
                        value = value & 0xFF00 | 0x0004;
                        break;
                    case "justify":
                        value = value & 0xFF00 | 0x0008;
                        break;
                    case "flush":
                        value = value & 0xFF00 | 0x0010;
                        break;
                    case "geo":
                        value = value & 0xFF00 | 0x0020;
                        break;
                    case "top":
                        value = value & 0x00FF | 0x0100;
                        break;
                    case "middle":
                        value = value & 0x00FF | 0x0200;
                        break;
                    case "bottom":
                        value = value & 0x00FF | 0x0400;
                        break;
                    case "baseline":
                        value = value & 0x00FF | 0x0800;
                        break;
                    case "midline":
                        value = value & 0x00FF | 0x1000;
                        break;
                    case "capline":
                        value = value & 0x00FF | 0x2000;
                        break;
                }
            }
            Instance.alignment = (TextAlignmentOptions)value;
        }

        private void SetColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                Instance.color = Color.black;
                return;
            }

            Instance.color = DocumentUtils.ParseColor(color);
        }

        private void SetFontSize(string size)
        {
            if (string.IsNullOrEmpty(size))
            {
                Instance.fontSize = TMP_Settings.defaultFontSize;
                Instance.fontSizeMax = TMP_Settings.defaultFontSize;
                return;
            }

            var value = float.Parse(size);
            Instance.fontSize = value;
            Instance.fontSizeMax = value;
        }

        private void SetMinFontSize(string size)
        {
            if (string.IsNullOrEmpty(size))
            {
                Instance.enableAutoSizing = false;
                return;
            }

            var value = float.Parse(size);
            Instance.enableAutoSizing = true;
            Instance.fontSizeMin = value;
        }

        public override bool SetAttribute(string key, string value)
        {
            var foundAttributes = base.SetAttribute(key, value);

            if (!foundAttributes)
            {
                // Refresh text if the attribute is not handled by any of the loaders.
                // Because an unhandled attribute is likely to be a text attribute.
                // Inherently, user should avoid using loader attributes as localization arguments.
                // Also, user should avoid rapidly changing unhandled attributes.
                RefreshText();
            }

            return foundAttributes;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            var extendX = _extendData.Extend + _extendData.ExtendX;
            var extendY = _extendData.Extend + _extendData.ExtendY;
            var extendLeft = extendX + _extendData.ExtendLeft;
            var extendRight = extendX + _extendData.ExtendRight;
            var extendTop = extendY + _extendData.ExtendTop;
            var extendBottom = extendY + _extendData.ExtendBottom;
            Instance.raycastPadding = new Vector4(-extendLeft, -extendBottom, -extendRight, -extendTop);

            Instance.characterSpacing = _letterSpacing;
            Instance.wordSpacing = _wordSpacing;
            Instance.lineSpacing = _lineSpacing;
            Instance.paragraphSpacing = _paragraphSpacing;
        }

        private void ReleaseMaterial()
        {
            if (_materialInstance == null)
                return;

            Object.Destroy(_materialInstance);
            _materialInstance = null;
        }

        private Material GetMaterial()
        {
            if (_materialInstance == null)
            {
                _materialInstance = Instance.fontMaterial;
                return _materialInstance;
            }

            if (_materialInstance != Instance.fontMaterial)
            {
                ReleaseMaterial();
                _materialInstance = Instance.fontMaterial;
                return _materialInstance;
            }

            return _materialInstance;
        }

        protected override void OnLateUpdate()
        {
            base.OnLateUpdate();
            if (!_fontInitialized || Instance.font == null)
                SetupFont();

            if (_outlineEnabled)
            {
                var material = GetMaterial();
                material.EnableKeyword(ShaderUtilities.Keyword_Outline);
                material.SetColor(ShaderUtilities.ID_OutlineColor, _outlineColor);
                material.SetFloat(ShaderUtilities.ID_OutlineWidth, _outlineThickness);
                material.SetFloat(ShaderUtilities.ID_FaceDilate, _outlineThickness);
                Instance.UpdateMeshPadding();
            }
            else
            {
                Instance.material = null;
                Instance.UpdateMeshPadding();
                ReleaseMaterial();
            }
        }

        public override void Reuse()
        {
            base.Reuse();

            Instance.font = null;
            _fontInitialized = false;
            IsLateUpdatePending = true;
        }

        public override void Reset()
        {
            base.Reset();

            ReleaseMaterial();
            Instance.text = null;
            IsLateUpdatePending = false;
            if (_textUpdatePending)
            {
                DocumentUtils.OnDocumentUpdate -= UpdateText;
                _textUpdatePending = false;
            }
        }


        public override void Release()
        {
            base.Release();
            ReleaseMaterial();
            Instance.text = null;
            Instance.font = null;
        }
    }
}

#endif
