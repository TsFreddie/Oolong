using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    [AddComponentMenu("")]
    public class OolongPanel : OolongElement<OolongPanel>
    {
        private OolongLayoutLoader _layout;

        public override void OnCreate()
        {
            base.OnCreate();
            _layout = new OolongLayoutLoader(gameObject);
        }

        protected override bool SetAttribute(string key, string value)
        {
            return _layout.SetAttribute(key, value);
        }

        public override void OnReuse()
        {
            base.OnReuse();
            _layout.Reuse();
        }

        public override void OnReset()
        {
            base.OnReset();
            _layout.Reset();
        }

        protected override void OnDestroy()
        {
            _layout.Release();
            _layout = null;
            base.OnDestroy();
        }
    }
}
