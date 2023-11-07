using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public class OolongButton : OolongElement<OolongButton>
    {
        private Button _button;
        private OolongSelectableLoader _buttonLoader;

        public override void OnCreate()
        {
            base.OnCreate();
            var image = gameObject.AddComponent<Image>();
            _button = gameObject.AddComponent<Button>();
            _button.targetGraphic = image;
            _buttonLoader = new OolongSelectableLoader(_button, TagName);
        }

        public override bool AddListener(string key, OolongElement.JsCallback callback)
        {
            if (base.AddListener(key, callback)) return true;

            switch (key)
            {
                case "click":
                    _button.onClick.AddListener(() => callback(null));
                    return true;
            }
            return false;
        }

        public override bool RemoveListener(string key)
        {
            if (base.RemoveListener(key)) return true;

            switch (key)
            {
                case "click":
                    _button.onClick.RemoveAllListeners();
                    return true;
            }
            return false;
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
            base.OnDestroy();
        }
    }
}
