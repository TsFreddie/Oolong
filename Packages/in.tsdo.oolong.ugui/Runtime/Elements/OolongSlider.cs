using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public class OolongSlider : OolongElement<OolongSlider>, IDeselectHandler
    {
        private OolongSliderLoader _slider;
        private Action _onDeselect;

        public float Value
        {
            get { return _slider.Instance.value; }
            set { _slider.Instance.value = value; }
        }

        public override void OnCreate()
        {
            base.OnCreate();
            _slider = new OolongSliderLoader(gameObject, TagName);
        }

        protected override bool SetAttribute(string key, string value)
        {
            if (_slider.SetAttribute(key, value)) return true;
            return false;
        }

        public override void AddListener(string key, IOolongElement.JsCallback callback)
        {
            base.AddListener(key, callback);

            switch (key)
            {
                case "change":
                    _slider.Instance.onValueChanged.AddListener(_ => callback());
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
                case "change":
                    _slider.Instance.onValueChanged.RemoveAllListeners();
                    break;
                case "unfocus":
                    _onDeselect = null;
                    break;
            }
        }

        public override void OnReuse()
        {
            base.OnReuse();
            _slider.Reuse();
        }

        public override void OnReset()
        {
            base.OnReset();
            _slider.Reset();
            _slider.Instance.onValueChanged.RemoveAllListeners();
            _onDeselect = null;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _slider.Release();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _onDeselect?.Invoke();
        }
    }
}
