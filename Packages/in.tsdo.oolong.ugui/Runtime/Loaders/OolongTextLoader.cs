using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class OolongTextLoader : OolongLoader
    {
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

        private delegate void TextAttrHandler(OolongTextLoader e, string value);
        private static readonly Dictionary<string, TextAttrHandler> s_attr = new Dictionary<string, TextAttrHandler>()
        {
            { "#", (e, v) => e.SetText(v) },
            { "text-align", (e, v) => e.SetTextAlign(v) },
            { "size", (e, v) => e.SetFontSize(v) },
            { "min-size", (e, v) => e.SetMinFontSize(v) },
            { "color", (e, v) => e.SetColor(v) },
            { "overflow", (e, v) => e.SetOverflow(v) },
            { "wrap", (e, v) => e.SetWrap(v) },
            { "passthrough", (e, v) => e.SetPassthrough(v) },
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

        private readonly Dictionary<string, string> _textAttr = new Dictionary<string, string>();

        public TextMeshProUGUI Instance;

        private TextAlignmentOptions _defaultAlign = TextAlignmentOptions.Center;
        public TextAlignmentOptions DefaultAlign
        {
            get => _defaultAlign;
            set
            {
                // TODO: 如果出现SetAttribute后设置DefaultAlign，应检测当前Attribute
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
                // TODO: 如果出现SetAttribute后设置DefaultOverflow，应检测当前Attribute
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
                // TODO: 如果出现SetAttribute后设置DefaultWrap，应检测当前Attribute
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
                // TODO: 如果出现SetAttribute后设置DefaultColor，应检测当前Attribute
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
                // TODO: 如果出现SetAttribute后设置DefaultStyles，应检测当前Attribute
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
        private bool _fontInitialized = false;

        public OolongTextLoader(TextMeshProUGUI text)
        {
            Instance = text;
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

            // Don't use default setting for these settings
            Instance.raycastTarget = true;
            Instance.enableWordWrapping = false;

            IsLayoutDirtyLate = true;
        }

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
            ReleaseMaterial();
            Instance.font = null;
            _fontInitialized = false;
            IsLayoutDirtyLate = true;
        }

        private void SetupFont()
        {
            Instance.font = TMP_Settings.defaultFontAsset;
            _fontInitialized = true;
        }

        public bool SetAttribute(string prefix, string key, string value)
        {
            if (prefix != null)
            {
                if (!key.StartsWith(prefix)) return false;
                key = key.Substring(prefix.Length);
            }

            if (!s_attr.ContainsKey(key))
            {
                // Provide arguments for smart strings
                _textAttr[key] = value;
                return false;
            }

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

        private void SetPassthrough(string v)
        {
            if (v == null)
            {
                Instance.raycastTarget = true;
                return;
            }

            Instance.raycastTarget = false;
        }

        private void SetText(string text)
        {
            Instance.text = OolongUGUI.TransformText(text);
        }

        private void SetOutlineColor(string v)
        {
            if (v == null)
            {
                _outlineEnabled = false;
                IsLayoutDirtyLate = true;
                return;
            }

            _outlineEnabled = true;
            _outlineColor = DocumentUtils.ParseColor(v);
            IsLayoutDirtyLate = true;
        }

        private void SetOutlineThickness(string v)
        {
            if (v == null)
            {
                _outlineThickness = 1.0f;
                IsLayoutDirtyLate = true;
                return;
            }

            _outlineThickness = float.Parse(v);
            IsLayoutDirtyLate = true;
        }

        private void SetWrap(string wrap)
        {
            if (wrap == null)
            {
                Instance.enableWordWrapping = false;
                return;
            }

            Instance.enableWordWrapping = wrap != "disabled";
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

        protected override void OnLayout()
        {
            base.OnLayout();

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

        protected override void OnLateLayout()
        {
            base.OnLateLayout();
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
                var material = GetMaterial();
                material.DisableKeyword(ShaderUtilities.Keyword_Outline);
                material.SetFloat(ShaderUtilities.ID_OutlineWidth, 0);
                material.SetFloat(ShaderUtilities.ID_FaceDilate, 0);
                Instance.UpdateMeshPadding();
            }
        }

        public override void Reuse()
        {
            Instance.font = null;
            _fontInitialized = false;
            IsLayoutDirtyLate = true;
            // Instance.enabled = true;
        }

        public override void Reset()
        {
            foreach (var kvp in s_attr)
                kvp.Value(this, null);

            ReleaseMaterial();
            // Instance.enabled = false;
            Instance.text = null;
            IsLayoutDirtyLate = false;
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
