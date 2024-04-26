using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    public enum ButtonState
    {
        Base,
        Normal,
        Highlight,
        Pressed,
        Selected,
        Disabled
    }

    public class OolongSelectableLoader : OolongLoader<OolongSelectableLoader>
    {
        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "src", ((e, v) => e.SetImage(ButtonState.Base, v)) },
            { "color", ((e, v) => e.SetColor(ButtonState.Base, v)) },
            {
                "normal", ((e, v) =>
                {
                    if (v == null) e.ResetButtonState(ButtonState.Normal);
                    e.SetColor(ButtonState.Normal, v);
                })
            },
            {
                "highlight", ((e, v) =>
                {
                    if (v == null) e.ResetButtonState(ButtonState.Highlight);
                    else if (v.StartsWith("#")) e.SetColor(ButtonState.Highlight, v);
                    else e.SetImage(ButtonState.Highlight, v);
                })
            },
            {
                "press", ((e, v) =>
                {
                    if (v == null) e.ResetButtonState(ButtonState.Pressed);
                    else if (v.StartsWith("#")) e.SetColor(ButtonState.Pressed, v);
                    else e.SetImage(ButtonState.Pressed, v);
                })
            },
            {
                "select", ((e, v) =>
                {
                    if (v == null) e.ResetButtonState(ButtonState.Selected);
                    else if (v.StartsWith("#")) e.SetColor(ButtonState.Selected, v);
                    else e.SetImage(ButtonState.Selected, v);
                })
            },
            {
                "disable", ((e, v) =>
                {
                    if (v == null) e.ResetButtonState(ButtonState.Disabled);
                    else if (v.StartsWith("#")) e.SetColor(ButtonState.Disabled, v);
                    else e.SetImage(ButtonState.Disabled, v);
                })
            },
            { "fade-duration", ((e, v) => e.SetFadeDuration(v)) },
            { "disabled", ((e, v) => e.SetDisabled(v)) },
            { "async", ((e, v) => e.SetAsync(v)) },
        };

        public readonly IOolongSelectable Instance;
        private readonly OolongImageLoader _image; // ignoring src and color
        private AddressableHolder<Sprite> _baseSprite;
        private AddressableHolder<Sprite> _highlightSprite;
        private AddressableHolder<Sprite> _selectedSprite;
        private AddressableHolder<Sprite> _pressedSprite;
        private AddressableHolder<Sprite> _disabledSprite;


        private bool _loaded = false;
        private bool _isAsync = false;
        private string _tagName;

        private IOolongLoader.JsCallback _onCanvasGroupChange;

        public bool HasImage { get; private set; } = false;
        public Image TargetImage => Instance.targetGraphic as Image;
        public Graphic TargetGraphic => Instance.targetGraphic;

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

        private Color _baseColor = Color.white;

        public OolongSelectableLoader(Image image, IOolongSelectable instance, string tagName)
        {
            Instance = instance;
            Instance.enabled = false;
            _image = new OolongImageLoader(image, tagName);
            Instance.targetGraphic = image;
            _tagName = tagName;
        }

        public OolongSelectableLoader(IOolongSelectable instance, string tagName) : this(instance.gameObject.AddComponent<Image>(), instance, tagName)
        {
        }

        public OolongSelectableLoader(GameObject gameObject, string tagName)
            : this(gameObject.AddComponent<OolongSelectable>(), tagName)
        {
        }

        public override bool SetAttribute(string key, string value)
        {
            if (base.SetAttribute(key, value)) return true;
            if (_image?.SetAttribute(key, value) ?? false) return true;
            return false;
        }

        private void SetAsync(string v)
        {
            _isAsync = v != null;
        }


        private void SetFadeDuration(string fade)
        {
            var block = Instance.colors;
            if (string.IsNullOrEmpty(fade))
            {
                block.fadeDuration = 0.1f;
                Instance.colors = block;
                return;
            }

            block.fadeDuration = float.Parse(fade);
            Instance.colors = block;
        }

        private void SetDisabled(string disabled)
        {
            Instance.interactable = disabled == null;
        }

        private void ResetButtonState(ButtonState state)
        {
            var block = Instance.colors;
            switch (state)
            {
                case ButtonState.Highlight:
                    {
                        _highlightSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.highlightedSprite = null;
                        Instance.spriteState = sprites;
                        block.highlightedColor = Color.white;
                        break;
                    }
                case ButtonState.Pressed:
                    {
                        _pressedSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.pressedSprite = null;
                        Instance.spriteState = sprites;
                        block.pressedColor = new Color32(200, 200, 200, 255);
                        break;
                    }
                case ButtonState.Selected:
                    {
                        _selectedSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.selectedSprite = null;
                        Instance.spriteState = sprites;
                        block.selectedColor = Color.white;
                        break;
                    }
                case ButtonState.Disabled:
                    {
                        _disabledSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.disabledSprite = null;
                        Instance.spriteState = sprites;
                        block.disabledColor = new Color32(200, 200, 200, 128);
                        break;
                    }
            }
            Instance.colors = block;
            Loaded = false;
            Enabled = true;
        }

        private void SetColor(ButtonState state, string color)
        {
            switch (state)
            {
                case ButtonState.Base:
                    {
                        _baseColor = string.IsNullOrEmpty(color) ? Color.white : DocumentUtils.ParseColor(color);
                        Instance.targetGraphic.color = _baseColor;
                        break;
                    }
                case ButtonState.Normal:
                    {
                        var block = Instance.colors;
                        block.normalColor = DocumentUtils.ParseColor(color);
                        Instance.colors = block;
                        Instance.transition = Selectable.Transition.ColorTint;
                        break;
                    }
                case ButtonState.Highlight:
                    {
                        _highlightSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.highlightedSprite = null;
                        Instance.spriteState = sprites;
                        var block = Instance.colors;
                        block.highlightedColor = DocumentUtils.ParseColor(color);
                        Instance.colors = block;
                        Instance.transition = Selectable.Transition.ColorTint;
                        break;
                    }
                case ButtonState.Pressed:
                    {
                        _pressedSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.pressedSprite = null;
                        Instance.spriteState = sprites;
                        var block = Instance.colors;
                        block.pressedColor = DocumentUtils.ParseColor(color);
                        Instance.colors = block;
                        Instance.transition = Selectable.Transition.ColorTint;
                        break;
                    }
                case ButtonState.Selected:
                    {
                        _selectedSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.selectedSprite = null;
                        Instance.spriteState = sprites;
                        var block = Instance.colors;
                        block.selectedColor = DocumentUtils.ParseColor(color);
                        Instance.colors = block;
                        Instance.transition = Selectable.Transition.ColorTint;
                        break;
                    }
                case ButtonState.Disabled:
                    {
                        _disabledSprite.Release();
                        var sprites = Instance.spriteState;
                        sprites.disabledSprite = null;
                        Instance.spriteState = sprites;
                        var block = Instance.colors;
                        block.selectedColor = DocumentUtils.ParseColor(color);
                        Instance.colors = block;
                        Instance.transition = Selectable.Transition.ColorTint;
                        break;
                    }
            }
        }

        private void SetSprite(ButtonState state, Sprite sprite)
        {
            switch (state)
            {
                case ButtonState.Base:
                    var image = Instance.image;
                    if (image) image.sprite = sprite;
                    return;
                case ButtonState.Normal:
                    return;
                case ButtonState.Highlight:
                    {
                        var sprites = Instance.spriteState;
                        sprites.highlightedSprite = sprite;
                        Instance.spriteState = sprites;
                        Instance.transition = Selectable.Transition.SpriteSwap;
                        break;
                    }
                case ButtonState.Pressed:
                    {
                        var sprites = Instance.spriteState;
                        sprites.pressedSprite = sprite;
                        Instance.spriteState = sprites;
                        Instance.transition = Selectable.Transition.SpriteSwap;
                        break;
                    }
                case ButtonState.Selected:
                    {
                        var sprites = Instance.spriteState;
                        sprites.selectedSprite = sprite;
                        Instance.spriteState = sprites;
                        Instance.transition = Selectable.Transition.SpriteSwap;
                        break;
                    }
                case ButtonState.Disabled:
                    {
                        var sprites = Instance.spriteState;
                        sprites.disabledSprite = sprite;
                        Instance.spriteState = sprites;
                        Instance.transition = Selectable.Transition.SpriteSwap;
                        break;
                    }
            }
        }

        private async void SetImage(ButtonState state, string address)
        {
            switch (state)
            {
                case ButtonState.Base:
                    _baseSprite.Release();
                    break;
                case ButtonState.Normal:
                    break;
                case ButtonState.Highlight:
                    _highlightSprite.Release();
                    break;
                case ButtonState.Pressed:
                    _pressedSprite.Release();
                    break;
                case ButtonState.Selected:
                    _selectedSprite.Release();
                    break;
                case ButtonState.Disabled:
                    _disabledSprite.Release();
                    break;
            }

            if (string.IsNullOrEmpty(address))
            {
                SetSprite(state, null);
                if (_image != null) _image.Instance.enabled = false;
                if (state == ButtonState.Base)
                {
                    HasImage = false;
                    Loaded = false;
                }
                return;
            }

            Sprite sprite = null;
            var isNone = address == "#";
            if (!isNone)
            {
                address = OolongUGUI.TransformAddress(_tagName, address);
            }

            switch (state)
            {
                case ButtonState.Base:
                    HasImage = true;
                    if (isNone)
                        sprite = Resources.Load<Sprite>("Stub/White");
                    else
                        sprite = _isAsync ? await _baseSprite.Load(address) : _baseSprite.LoadSync(address);
                    Loaded = true;
                    break;
                case ButtonState.Normal:
                    break;
                case ButtonState.Highlight:
                    sprite = _isAsync ? await _highlightSprite.Load(address) : _highlightSprite.LoadSync(address);
                    break;
                case ButtonState.Pressed:
                    sprite = _isAsync ? await _pressedSprite.Load(address) : _pressedSprite.LoadSync(address);
                    break;
                case ButtonState.Selected:
                    sprite = _isAsync ? await _selectedSprite.Load(address) : _selectedSprite.LoadSync(address);
                    break;
                case ButtonState.Disabled:
                    sprite = _isAsync ? await _disabledSprite.Load(address) : _disabledSprite.LoadSync(address);
                    break;
            }

            if (sprite == null && (state != ButtonState.Base || !isNone))
                return;

            SetSprite(state, sprite);
            if (_image != null) _image.Instance.enabled = true;
        }

        public override bool AddListener(string key, IOolongLoader.JsCallback callback)
        {
            if (base.AddListener(key, callback)) return true;

            switch (key)
            {
                case "canvasgroupchanged":
                    _onCanvasGroupChange = callback;
                    Instance.OnCanvasGroupChange += OnCanvasGroupChange;
                    return true;
            }
            return false;
        }

        public override bool RemoveListener(string key)
        {
            if (base.RemoveListener(key)) return true;

            switch (key)
            {
                case "canvasgroupchanged":
                    _onCanvasGroupChange = null;
                    Instance.OnCanvasGroupChange -= OnCanvasGroupChange;
                    return true;
            }
            return false;
        }

        public override bool TryGetAttribute(string key, out string value)
        {
            switch (key)
            {
                case "interactable":
                    value = Instance.IsInteractable() ? "yes" : "no";
                    return true;
            }
            return base.TryGetAttribute(key, out value);
        }

        private void OnCanvasGroupChange()
        {
            _onCanvasGroupChange?.Invoke(null);
        }

        public override void Reset()
        {
            base.Reset();

            _onCanvasGroupChange = null;
            Instance.OnCanvasGroupChange -= OnCanvasGroupChange;

            _baseSprite.Release();
            _highlightSprite.Release();
            _pressedSprite.Release();
            _selectedSprite.Release();
            _disabledSprite.Release();
            _image?.Release();
        }

        public override void Release()
        {
            base.Release();

            _baseSprite.Release();
            _highlightSprite.Release();
            _pressedSprite.Release();
            _selectedSprite.Release();
            _disabledSprite.Release();
            _image?.Release();
        }
    }
}
