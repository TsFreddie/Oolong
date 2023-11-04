using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    [AddComponentMenu("")]
    public class OolongImage : OolongElement<OolongImage>
    {
        private OolongImageLoader _image;

        public override void OnCreate()
        {
            base.OnCreate();
            _image = new OolongImageLoader(gameObject.AddComponent<Image>(), TagName);
        }

        protected override bool SetAttribute(string key, string value)
        {
            return _image.SetAttribute(key, value);
        }

        public override void OnReuse()
        {
            base.OnReuse();
            _image.Reuse();
        }

        public override void OnReset()
        {
            base.OnReset();
            _image.Reset();
        }

        protected override void OnDestroy()
        {
            _image.Release();
            _image = null;
            base.OnDestroy();
        }
    }
}
