using TMPro;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public class OolongText : OolongElement<OolongText>
    {
        private OolongTextLoader _text;

        public override void OnCreate()
        {
            base.OnCreate();
            _text = new OolongTextLoader(gameObject.AddComponent<TextMeshProUGUI>());
        }

        protected override bool SetAttribute(string key, string value)
        {
            return _text.SetAttribute(key, value);
        }

        public override void OnReuse()
        {
            base.OnReuse();
            _text.Reuse();
        }

        public override void OnReset()
        {
            base.OnReset();
            _text.Reset();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _text.Release();
        }
    }
}
