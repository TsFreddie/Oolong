using System.Collections.Generic;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class OolongCanvasGroupLoader : OolongLoader<OolongCanvasGroupLoader>
    {
        public readonly CanvasGroup Instance;
        public readonly RectTransform Content;

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "alpha", ((e, v) => e.SetFloat(ref e._alpha, v, 1.0f)) },
            { "disabled", ((e, v) => e.SetDisabled(v)) },
            { "passthrough", ((e, v) => e.SetClickThrough(v)) },
            { "scale", ((e, v) => e.SetScale(v)) },
            { "delayed", ((e, v) => e.SetDelayed(v)) },
            { "rotation", (e, v) => e.SetRotation(v) },
        };

        private bool _delayed;
        private bool _delayFulfilled;
        private float _alpha = 1.0f;

        public OolongCanvasGroupLoader(GameObject gameObject) : this(gameObject.transform) { }
        public OolongCanvasGroupLoader(Transform transform)
        {
            Content = DocumentUtils.CreateChildRect(transform, "::inner");
            Instance = Content.gameObject.AddComponent<CanvasGroup>();
        }

        private void SetDelayed(string v)
        {
            _delayed = v != null;
            _delayFulfilled = false;
            IsUpdatePending = true;
        }

        private void SetDisabled(string v)
        {
            Instance.interactable = v == null;
        }

        private void SetClickThrough(string v)
        {
            Instance.blocksRaycasts = v == null;
        }

        private void SetScale(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                Content.localScale = Vector3.one;
                return;
            }

            var scale = float.Parse(v);
            Content.localScale = new Vector3(scale, scale, scale);
        }

        private void SetRotation(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                Content.localRotation = Quaternion.identity;
                return;
            }

            var rotation = float.Parse(v);
            Content.localRotation = Quaternion.Euler(0, 0, rotation);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (_delayed && !_delayFulfilled)
            {
                Instance.alpha = 0.0f;
                _delayFulfilled = true;
                IsUpdatePending = true;
            }
            else
            {
                Instance.alpha = _alpha;
            }
        }

        public override void Reset()
        {
            base.Reset();
            _alpha = 1.0f;
            _delayed = false;
            _delayFulfilled = false;
        }

        public override void Release()
        {
            base.Release();
            _alpha = 1.0f;
            _delayed = false;
            _delayFulfilled = false;
        }
    }
}
