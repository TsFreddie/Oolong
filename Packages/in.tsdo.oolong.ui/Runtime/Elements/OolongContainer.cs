using System.Collections.Generic;
using UnityEngine;

namespace TSF.Oolong.UI
{
    [AddComponentMenu("")]
    public class OolongContainer : OolongElement<OolongContainer>
    {
        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "alpha", ((e, v) => e.SetAlpha(v)) },
            { "disabled", ((e, v) => e.SetDisabled(v)) },
            { "passthrough", ((e, v) => e.SetClickThrough(v)) },
            { "scale", ((e, v) => e.SetScale(v)) },
            { "delayed", ((e, v) => e.SetDelayed(v)) },
            { "rotation", (e, v) => e.SetRotation(v) },
        };

        private CanvasGroup _group;
        private RectTransform _innerRect;

        public override Transform RootTransform => _innerRect;

        /// <summary>
        /// 内容是否晚一帧出现（以方便Overlay截屏时不带有内容）
        /// </summary>
        private bool _delayed;

        private bool _delayFulfilled = false;

        private float _alpha = 1.0f;

        public override void OnCreate()
        {
            base.OnCreate();
            _innerRect = CreateChildRect("::inner");
            _group = _innerRect.gameObject.AddComponent<CanvasGroup>();
        }

        private void SetDelayed(string v)
        {
            _delayed = v != null;
            _delayFulfilled = false;
            IsLayoutDirty = true;
        }

        private void SetAlpha(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _alpha = 1;
                return;
            }

            _alpha = float.Parse(v);
            IsLayoutDirty = true;
        }

        private void SetDisabled(string v)
        {
            _group.interactable = v == null;
        }

        private void SetClickThrough(string v)
        {
            _group.blocksRaycasts = v == null;
        }

        private void SetScale(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _innerRect.localScale = Vector3.one;
                return;
            }

            var scale = float.Parse(v);
            _innerRect.localScale = new Vector3(scale, scale, scale);
        }

        private void SetRotation(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                _innerRect.localRotation = Quaternion.identity;
                return;
            }

            var rotation = float.Parse(v);
            _innerRect.localRotation = Quaternion.Euler(0, 0, rotation);
        }

        protected override void OnLayout()
        {
            base.OnLayout();
            if (_delayed && !_delayFulfilled)
            {
                _group.alpha = 0.0f;
                _delayFulfilled = true;
                IsLayoutDirty = true;
            }
            else
            {
                // TODO: 开始动画？
                _group.alpha = _alpha;
            }
        }
    }
}
