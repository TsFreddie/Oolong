using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
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

    public class OolongSelectableLoader : OolongLoader
    {
        private delegate void SelectableAttrHandler(OolongSelectableLoader e, string value);
        private static readonly Dictionary<string, SelectableAttrHandler> s_attr = new Dictionary<string, SelectableAttrHandler>()
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
            { "fade", ((e, v) => e.SetFade(v)) },
            { "disabled", ((e, v) => e.SetDisabled(v)) },
            { "async", ((e, v) => e.SetAsync(v)) },
        };

        public Selectable Instance;
        private OolongImageLoader _image; // Not using it's loader. Selectable will manage the sprite.
        private AddressableHolder<Sprite> HighlightSprite;
        private AddressableHolder<Sprite> SelectedSprite;
        private AddressableHolder<Sprite> PressedSprite;
        private AddressableHolder<Sprite> DisabledSprite;


        private bool _loaded = false;
        private bool _isAsync = false;

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

        private Color _baseColor = Color.white;

        public OolongSelectableLoader(Selectable instance)
        {
            Instance = instance;
            Instance.enabled = false;
            _image = new OolongImageLoader(instance.image);
        }

        public bool SetAttribute(string prefix, string key, string value)
        {
            if (prefix != null)
            {
                if (!key.StartsWith(prefix)) return false;
                key = key.Substring(prefix.Length);
            }

            if (s_attr.ContainsKey(key))
            {
                s_attr[key](this, value);
                return true;
            }

            return _image.SetAttribute(key, value);
        }

        public bool SetAttribute(string key, string value)
        {
            return SetAttribute(null, key, value);
        }

        private void SetAsync(string v)
        {
            _isAsync = v != null;
        }


        private void SetFade(string fade)
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
                        HighlightSprite?.Release();
                        var sprites = Instance.spriteState;
                        sprites.highlightedSprite = null;
                        Instance.spriteState = sprites;
                        block.highlightedColor = Color.white;
                        break;
                    }
                case ButtonState.Pressed:
                    {
                        PressedSprite?.Release();
                        var sprites = Instance.spriteState;
                        sprites.pressedSprite = null;
                        Instance.spriteState = sprites;
                        block.pressedColor = new Color32(200, 200, 200, 255);
                        break;
                    }
                case ButtonState.Selected:
                    {
                        SelectedSprite?.Release();
                        var sprites = Instance.spriteState;
                        sprites.selectedSprite = null;
                        Instance.spriteState = sprites;
                        block.selectedColor = Color.white;
                        break;
                    }
                case ButtonState.Disabled:
                    {
                        DisabledSprite?.Release();
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
                        HighlightSprite?.Release();
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
                        PressedSprite?.Release();
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
                        SelectedSprite?.Release();
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
                        DisabledSprite?.Release();
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
                    image.sprite = sprite;
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
                    AddressableBinder.Release<Sprite>(Instance);
                    break;
                case ButtonState.Normal:
                    break;
                case ButtonState.Highlight:
                    HighlightSprite?.Release();
                    break;
                case ButtonState.Pressed:
                    PressedSprite?.Release();
                    break;
                case ButtonState.Selected:
                    SelectedSprite?.Release();
                    break;
                case ButtonState.Disabled:
                    DisabledSprite?.Release();
                    break;
            }

            if (string.IsNullOrEmpty(address))
            {
                SetSprite(state, null);
                _image.Instance.enabled = false;
                if (state == ButtonState.Base)
                {
                    HasImage = false;
                    Loaded = false;
                }
                return;
            }

            Sprite sprite = null;

            switch (state)
            {
                case ButtonState.Base:
                    HasImage = true;
                    if (address == "none")
                        sprite = null;
                    else
                        sprite = _isAsync
                            ? await AddressableBinder.Load<Sprite>(Instance, address)
                            : AddressableBinder.LoadSync<Sprite>(Instance, address);
                    Loaded = true;
                    break;
                case ButtonState.Normal:
                    break;
                case ButtonState.Highlight:
                    HighlightSprite ??= new AddressableHolder<Sprite>();
                    sprite = _isAsync ? await HighlightSprite.Load(address) : HighlightSprite.LoadSync(address);
                    break;
                case ButtonState.Pressed:
                    PressedSprite ??= new AddressableHolder<Sprite>();
                    sprite = _isAsync ? await PressedSprite.Load(address) : PressedSprite.LoadSync(address);
                    break;
                case ButtonState.Selected:
                    SelectedSprite ??= new AddressableHolder<Sprite>();
                    sprite = _isAsync ? await SelectedSprite.Load(address) : SelectedSprite.LoadSync(address);
                    break;
                case ButtonState.Disabled:
                    DisabledSprite ??= new AddressableHolder<Sprite>();
                    sprite = _isAsync ? await DisabledSprite.Load(address) : DisabledSprite.LoadSync(address);
                    break;
            }

            if (sprite == null && (state != ButtonState.Base || address != "none"))
                return;

            SetSprite(state, sprite);
            _image.Instance.enabled = true;
        }

        public override void Reuse() { }

        public override void Reset()
        {
            foreach (var kvp in s_attr)
                kvp.Value(this, null);

            HighlightSprite?.Release();
            PressedSprite?.Release();
            SelectedSprite?.Release();
            DisabledSprite?.Release();
            _image.Release();
        }

        public override void Release()
        {
            base.Release();
            AddressableBinder.Release<Sprite>(Instance);
            HighlightSprite?.Release();
            PressedSprite?.Release();
            SelectedSprite?.Release();
            DisabledSprite?.Release();
            _image.Release();
        }
    }
}
