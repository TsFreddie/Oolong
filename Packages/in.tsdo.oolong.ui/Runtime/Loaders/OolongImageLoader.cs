using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    public class OolongImageLoader : OolongLoader
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
        private FlipGraphic _flipGraphic;

        private delegate void ImageAttrHandler(OolongImageLoader e, string value);
        private static readonly Dictionary<string, ImageAttrHandler> s_attr = new Dictionary<string, ImageAttrHandler>()
        {
            { "src", (e, v) => e.SetImage(v) },
            { "color", (e, v) => e.SetColor(v) },
            { "type", (e, v) => e.SetType(v) },
            { "fit", (e, v) => e.SetFit(v) },
            { "clockwise", (e, v) => e.SetClockwise(v) },
            { "amount", (e, v) => e.SetAmount(v) },
            { "passthrough", ((e, v) => e.SetClickThrough(v)) },
            { "extend", (e, v) => e.SetFloat(ref e._extendData.Extend, v) },
            { "extend-left", (e, v) => e.SetFloat(ref e._extendData.ExtendLeft, v) },
            { "extend-top", (e, v) => e.SetFloat(ref e._extendData.ExtendTop, v) },
            { "extend-right", (e, v) => e.SetFloat(ref e._extendData.ExtendRight, v) },
            { "extend-bottom", (e, v) => e.SetFloat(ref e._extendData.ExtendBottom, v) },
            { "extend-x", (e, v) => e.SetFloat(ref e._extendData.ExtendX, v) },
            { "extend-y", (e, v) => e.SetFloat(ref e._extendData.ExtendY, v) },
            { "mask", (e, v) => e.SetMask(v) },
            { "flip-x", (e, v) => e.SetFlipX(v) },
            { "flip-y", (e, v) => e.SetFlipY(v) },
            { "ppu", (e, v) => e.SetMultiplier(v) },
            { "async", (e, v) => e.SetAsync(v) },
        };

        private string _defaultType;
        public string DefaultType
        {
            get => _defaultType;
            set
            {
                // TODO: 如果出现SetAttribute后设置DefaultType，应检测当前Attribute
                _defaultType = value;
                SetType(value);
            }
        }

        public Image Instance;

        private Mask _mask;
        private bool _isAsync;
        private bool _loaded = false;
        private string _address;
        private AddressableHolder<Sprite> _handle;

        public bool HasImage { get; private set; } = false;

        public bool Loaded
        {
            get => _loaded;
            private set
            {
                _loaded = value;
                Instance.enabled = _enabled && Loaded;
            }
        }

        private bool _enabled = true;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                Instance.enabled = _enabled && Loaded;
            }
        }

        public OolongImageLoader(Image instance)
        {
            Instance = instance;
            Instance.fillClockwise = false;
            Instance.preserveAspect = false;

            Loaded = false;
            HasImage = false;
            IsLayoutDirty = true;
        }

        private void SetFloat(ref float f, string v)
        {
            var oldF = f;
            f = string.IsNullOrEmpty(v) ? 0 : float.Parse(v);
            if (!oldF.Equals(f)) IsLayoutDirty = true;
        }

        private void SetAsync(string v)
        {
            _isAsync = v != null;
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

        private void SetMultiplier(string multiplier)
        {
            Instance.pixelsPerUnitMultiplier = float.Parse(multiplier);
        }

        private void SetClickThrough(string v)
        {
            Instance.raycastTarget = v == null;
        }

        private void TryInitFlipGraphic()
        {
            if (_flipGraphic == null)
                _flipGraphic = Instance.gameObject.AddComponent<FlipGraphic>();
        }

        private void SetFlipX(string v)
        {
            TryInitFlipGraphic();
            _flipGraphic.FlipX = v != null;
        }

        private void SetFlipY(string v)
        {
            TryInitFlipGraphic();
            _flipGraphic.FlipY = v != null;
        }

        private void SetFit(string v)
        {
            Instance.preserveAspect = v != null;
        }

        private void SetAmount(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                Instance.fillAmount = 1;
                return;
            }

            Instance.fillAmount = float.Parse(v) / 100.0f;
        }

        private void SetClockwise(string v)
        {
            Instance.fillClockwise = v != null;
        }

        private void SetMask(string v)
        {
            var maskActive = _mask != null && _mask.enabled;

            if (v == null && maskActive)
            {
                _mask.enabled = false;
            }

            if (v != null)
            {
                if (_mask == null)
                    _mask = Instance.gameObject.AddComponent<Mask>();

                _mask.showMaskGraphic = v == "show";
                _mask.enabled = true;
            }
        }

        private void SetType(string v)
        {
            v ??= DefaultType;

            switch (v)
            {
                case "slice":
                    Instance.type = Image.Type.Sliced;
                    Instance.fillCenter = true;
                    break;
                case "border":
                    Instance.type = Image.Type.Sliced;
                    Instance.fillCenter = false;
                    break;
                case "tile":
                    Instance.type = Image.Type.Tiled;
                    break;
                case "bar":
                case "bar-right":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Horizontal;
                    Instance.fillOrigin = 0;
                    break;
                case "bar-left":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Horizontal;
                    Instance.fillOrigin = 1;
                    break;
                case "bar-down":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Vertical;
                    Instance.fillOrigin = 0;
                    break;
                case "bar-up":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Vertical;
                    Instance.fillOrigin = 1;
                    break;
                case "pie":
                case "pie-bl":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial90;
                    Instance.fillOrigin = 0;
                    break;
                case "pie-tl":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial90;
                    Instance.fillOrigin = 1;
                    break;
                case "pie-tr":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial90;
                    Instance.fillOrigin = 2;
                    break;
                case "pie-br":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial90;
                    Instance.fillOrigin = 2;
                    break;
                case "fan-bottom":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial180;
                    Instance.fillOrigin = 0;
                    break;
                case "fan":
                case "fan-left":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial180;
                    Instance.fillOrigin = 1;
                    break;
                case "fan-top":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial180;
                    Instance.fillOrigin = 2;
                    break;
                case "fan-right":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial180;
                    Instance.fillOrigin = 3;
                    break;
                case "ring":
                case "ring-bottom":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial360;
                    Instance.fillOrigin = 0;
                    break;
                case "ring-left":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial360;
                    Instance.fillOrigin = 1;
                    break;
                case "ring-top":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial360;
                    Instance.fillOrigin = 2;
                    break;
                case "ring-right":
                    Instance.type = Image.Type.Filled;
                    Instance.fillMethod = Image.FillMethod.Radial360;
                    Instance.fillOrigin = 3;
                    break;
                default: // "simple"
                    Instance.type = Image.Type.Simple;
                    Instance.preserveAspect = false;
                    break;
            }
        }

        public void SetImage(string address)
        {
            _address = address;
            DocumentUtils.OnDocumentUpdate += ProcessImage;
        }

        private async void ProcessImage()
        {
            DocumentUtils.OnDocumentUpdate -= ProcessImage;
            _handle.Release();

            if (string.IsNullOrEmpty(_address))
            {
                Instance.sprite = null;
                Loaded = false;
                HasImage = false;
                return;
            }

            HasImage = true;
            Sprite sprite = null;
            var isNone = _address == "none";
            if (!isNone)
            {
                if (_isAsync)
                    sprite = await _handle.Load(_address);
                else
                    sprite = _handle.LoadSync(_address);
            }

            if (sprite == null && !isNone)
                return;

            Instance.sprite = sprite;
            Loaded = true;
        }

        private void SetColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                Instance.color = Color.white;
                return;
            }

            Instance.color = DocumentUtils.ParseColor(color);
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
        }

        public override void Reuse() { }

        public override void Reset()
        {
            foreach (var kvp in s_attr)
                kvp.Value(this, null);
        }

        public override void Release()
        {
            base.Release();
            _handle.Release();
        }
    }
}
