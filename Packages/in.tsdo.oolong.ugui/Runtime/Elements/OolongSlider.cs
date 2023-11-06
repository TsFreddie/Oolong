using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public class OolongSlider : OolongElement<OolongSlider>
    {
        private OolongSliderLoader _slider;

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

        public override bool AddListener(string key, IOolongElement.JsCallback callback)
        {
            if (base.AddListener(key, callback)) return true;

            switch (key)
            {
                case "valuechanged":
                    _slider.Instance.onValueChanged.AddListener(_ => callback(null));
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
                    _slider.Instance.onValueChanged.RemoveAllListeners();
                    return true;
            }
            return false;
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
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _slider.Release();
        }
    }
}
