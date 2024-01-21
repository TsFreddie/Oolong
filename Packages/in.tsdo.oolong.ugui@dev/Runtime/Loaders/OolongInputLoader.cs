using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace TSF.Oolong.UGUI
{
    public class OolongInputLoader : OolongLoader<OolongInputLoader>
    {
        public readonly OolongInput Instance;
        public readonly RectTransform Content;
        public readonly RectTransform TextArea;

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "value", ((e, v) => e.SetValue(v)) },
            { "padding", (e, v) => e.SetFloat(ref e._padding, v) },
            { "padding-left", (e, v) => e.SetFloat(ref e._paddingLeft, v) },
            { "padding-top", (e, v) => e.SetFloat(ref e._paddingTop, v) },
            { "padding-right", (e, v) => e.SetFloat(ref e._paddingRight, v) },
            { "padding-bottom", (e, v) => e.SetFloat(ref e._paddingBottom, v) },
            { "padding-x", (e, v) => e.SetFloat(ref e._paddingX, v) },
            { "padding-y", (e, v) => e.SetFloat(ref e._paddingY, v) },
            { "caret-width", (e, v) => e.SetFloat(ref e._caretWidth, v) },
            { "caret-blink-rate", (e, v) => e.SetFloat(ref e._caretBlinkRate, v) },
            { "caret-color", (e, v) => e.SetCaretColor(v) },
            { "selection-color", (e, v) => e.SetColor(ref e._selectionColor, v, new Color32(168, 206, 255, 192)) },
            { "font", (e, v) => e.SetFont(v) },
        };

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

        private void SetFont(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _font = null;
                return;
            }

            _font = v;
            _fontInitialized = false;
            IsLateUpdatePending = true;
        }

        private void SetupFont()
        {
            OolongTextMeshPro.GetFont(_font, null, out var font, out var _);
            Instance.fontAsset = font;
            _fontInitialized = true;
        }

        protected override void OnLateUpdate()
        {
            base.OnLateUpdate();

            if ((!_fontInitialized || Instance.fontAsset == null))
                SetupFont();
        }

        private void SetColor(ref Color c, string v, Color def)
        {
            var oldC = c;
            c = string.IsNullOrEmpty(v) ? def : DocumentUtils.ParseColor(v);
            if (!oldC.Equals(c)) IsUpdatePending = true;
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

        public OolongInputLoader(GameObject gameObject, RectTransform textArea, Graphic placeHolder, TMP_Text text)
        {
            var transform = gameObject.transform;
            Instance = gameObject.AddComponent<OolongInput>();
            TextArea = textArea;
            Instance.textViewport = textArea;
            Instance.placeholder = placeHolder;
            Instance.textComponent = text;
            Instance.lineType = TMP_InputField.LineType.SingleLine;

            Content = DocumentUtils.CreateChildRect(transform, "::content");
            IsLateUpdatePending = true;
        }

        private void SetValue(string v)
        {
            if (v == null) v = string.Empty;
            Instance.SetTextWithoutNotify(v);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            var paddingX = _padding + _paddingX;
            var paddingY = _padding + _paddingY;
            var paddingLeft = paddingX + _paddingLeft;
            var paddingRight = paddingX + _paddingRight;
            var paddingTop = paddingY + _paddingTop;
            var paddingBottom = paddingY + _paddingBottom;

            TextArea.offsetMin = new Vector2(paddingLeft, paddingTop);
            TextArea.offsetMax = new Vector2(-paddingRight, -paddingBottom);
            Instance.caretWidth = Mathf.RoundToInt(_caretWidth);
            Instance.caretBlinkRate = _caretBlinkRate;
            Instance.selectionColor = _selectionColor;

            Instance.customCaretColor = _customCaretColor;
            if (_customCaretColor)
                Instance.caretColor = _caretColor;
        }

        public override bool AddListener(string key, IOolongLoader.JsCallback callback)
        {
            if (base.AddListener(key, callback)) return true;

            switch (key)
            {
                case "valuechanged":
                    Instance.onValueChanged.AddListener(_ => callback(null));
                    return true;
                case "endedit":
                    Instance.onEndEdit.AddListener(_ => callback(null));
                    return true;
                case "inputselect":
                    Instance.onSelect.AddListener(_ => callback(null));
                    return true;
                case "inputdeselect":
                    Instance.onDeselect.AddListener(_ => callback(null));
                    return true;
            }
            return false;
        }

        public override bool RemoveListener(string key)
        {
            if (base.RemoveListener(key)) return true;

            switch (key)
            {
                case "valuechanged":
                    Instance.onValueChanged.RemoveAllListeners();
                    return true;
                case "endedit":
                    Instance.onEndEdit.RemoveAllListeners();
                    return true;
                case "inputselect":
                    Instance.onSelect.RemoveAllListeners();
                    return true;
                case "inputdeselect":
                    Instance.onDeselect.RemoveAllListeners();
                    return true;
            }
            return false;
        }

        public override bool TryGetAttribute(string key, out string value)
        {
            switch (key)
            {
                case "value":
                    value = Instance.text;
                    return true;
            }
            return base.TryGetAttribute(key, out value);
        }

        public override void Reuse()
        {
            base.Reuse();
            _fontInitialized = false;
        }

        public override void Reset()
        {
            base.Reset();
            Instance.onValueChanged.RemoveAllListeners();
            Instance.onEndEdit.RemoveAllListeners();
            Instance.onSelect.RemoveAllListeners();
            Instance.onDeselect.RemoveAllListeners();
        }

        public override void Release()
        {
            base.Release();
            Instance.onValueChanged.RemoveAllListeners();
            Instance.onEndEdit.RemoveAllListeners();
            Instance.onSelect.RemoveAllListeners();
            Instance.onDeselect.RemoveAllListeners();
        }
    }
}
