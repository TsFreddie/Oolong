using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    public class OolongImageLoader : OolongLoader<OolongImageLoader>
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

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "src", (e, v) => e.SetImage(v) },
            { "type", (e, v) => e.SetType(v) },
            { "fit", (e, v) => e.SetFit(v) },
            { "clockwise", (e, v) => e.SetClockwise(v) },
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
            { "color", (e, v) => e.SetLayoutTransition(e._color, v) },
            { "fill-amount", (e, v) => e.SetLayoutTransition(e._amount, v) },
        };

        private string _defaultType;
        public string DefaultType
        {
            get => _defaultType;
            set
            {
                _defaultType = value;
                SetType(value);
            }
        }

        public readonly Image Instance;

        private Mask _mask;
        private bool _isAsync;
        private bool _loaded = false;
        private string _address;
        private readonly string _tagName;
        private AddressableHolder<Sprite> _handle;

        private readonly ColorTransitionProperty _color;
        private readonly FloatTransitionProperty _amount;

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

        public OolongImageLoader(GameObject gameObject, string tagName) : this(gameObject.AddComponent<Image>(), tagName)
        {
        }

        public OolongImageLoader(Image instance, string tagName)
        {
            Instance = instance;
            Instance.fillClockwise = false;
            Instance.preserveAspect = false;

            Loaded = false;
            HasImage = false;
            IsUpdatePending = true;

            _color = new ColorTransitionProperty(SetColor, Color.white);
            _amount = new FloatTransitionProperty(SetFillAmount, 1.0f);
            Transitions.Add("color", _color);
            Transitions.Add("fill-amount", _amount);

            _tagName = tagName;
        }

        private void SetFillAmount(float v)
        {
            Instance.fillAmount = v / 100.0f;
        }

        private void SetColor(Color v)
        {
            Instance.color = v;
        }

        private void SetAsync(string v)
        {
            _isAsync = v != null;
        }

        private void SetMultiplier(string value)
        {
            if (!float.TryParse(value, out var multiplier))
                multiplier = 1.0f;
            Instance.pixelsPerUnitMultiplier = multiplier;
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
            var isNone = _address == "#";
            if (!isNone)
            {
                _address = OolongUGUI.TransformAddress(_tagName, _address);
                if (_isAsync)
                    sprite = await _handle.Load(_address);
                else
                    sprite = _handle.LoadSync(_address);
            }
            else
            {
                sprite = Resources.Load<Sprite>("Stub/White");
            }

            if (sprite == null)
                return;

            Instance.sprite = sprite;
            Loaded = true;
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
        }

        public override void Release()
        {
            base.Release();
            _handle.Release();
        }
    }
}
