using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    [AddComponentMenu("")]
    public class OolongButton : OolongElement<OolongButton>, IDeselectHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Button _button;
        private OolongSelectableLoader _buttonLoader;
        private Action _onDeselect;
        private Action _onPointerDown;
        private Action _onPointerUp;

        public override void OnCreate()
        {
            base.OnCreate();
            var image = gameObject.AddComponent<Image>();
            _button = gameObject.AddComponent<Button>();
            _button.targetGraphic = image;
            _buttonLoader = new OolongSelectableLoader(_button);
        }

        public override void AddListener(string key, IOolongElement.JsCallback callback)
        {
            base.AddListener(key, callback);

            switch (key)
            {
                case "click":
                    _button.onClick.AddListener(() => callback());
                    break;
                case "unfocus":
                    _onDeselect += () => callback();
                    break;
                case "pointerdown":
                    _onPointerDown += () => callback();
                    break;
                case "pointerup":
                    _onPointerUp += () => callback();
                    break;
            }
        }

        public override void RemoveListener(string key)
        {
            base.RemoveListener(key);

            switch (key)
            {
                case "click":
                    _button.onClick.RemoveAllListeners();
                    break;
                case "unfocus":
                    _onDeselect = null;
                    break;
                case "pointerdown":
                    _onPointerDown = null;
                    break;
                case "pointerup":
                    _onPointerUp = null;
                    break;
            }
        }

        public override void OnReuse()
        {
            base.OnReuse();
            _buttonLoader.Reuse();
        }

        public override void OnReset()
        {
            base.OnReset();
            _buttonLoader.Reset();
            _button.onClick.RemoveAllListeners();
            _onDeselect = null;
        }

        protected override bool SetAttribute(string key, string value)
        {
            if (_buttonLoader.SetAttribute(key, value))
                return true;

            return false;
        }

        protected override void OnDestroy()
        {
            _buttonLoader.Release();
            _onDeselect = null;
            base.OnDestroy();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _onDeselect?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _onPointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _onPointerUp?.Invoke();
        }
    }
}
