using System.Collections.Generic;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class OolongCanvasGroupLoader : OolongLoader<OolongCanvasGroupLoader>
    {
        public readonly CanvasGroup Instance;

        protected override Dictionary<string, AttrHandler> Attrs => s_attrs;
        private static readonly Dictionary<string, AttrHandler> s_attrs = new Dictionary<string, AttrHandler>()
        {
            { "alpha", ((e, v) => e.SetLayoutTransition(e._transition.Alpha, v)) },
            { "scale", ((e, v) => e.SetLayoutTransition(e._transition.Scale, v)) },
            { "scale-x", ((e, v) => e.SetLayoutTransition(e._transition.ScaleX, v)) },
            { "scale-y", ((e, v) => e.SetLayoutTransition(e._transition.ScaleY, v)) },
            { "disabled", ((e, v) => e.SetDisabled(v)) },
            { "passthrough", ((e, v) => e.SetClickThrough(v)) },
            { "delayed", ((e, v) => e.SetDelayed(v)) },
        };

        private struct TransitionData
        {
            public FloatTransitionProperty Alpha;
            public FloatTransitionProperty Scale;
            public FloatTransitionProperty ScaleX;
            public FloatTransitionProperty ScaleY;
        }

        private readonly TransitionData _transition;
        private bool _delayed;
        private bool _delayFulfilled;

        public OolongCanvasGroupLoader(GameObject gameObject)
        {
            Instance = gameObject.AddComponent<CanvasGroup>();

            _transition = new TransitionData()
            {
                Alpha = new FloatTransitionProperty(QueueUpdate, 1.0f),
                Scale = new FloatTransitionProperty(QueueUpdate, 1.0f),
                ScaleX = new FloatTransitionProperty(QueueUpdate, 1.0f),
                ScaleY = new FloatTransitionProperty(QueueUpdate, 1.0f),
            };

            Transitions.Add("alpha", _transition.Alpha);
            Transitions.Add("scale", _transition.Scale);
            Transitions.Add("scale-x", _transition.ScaleX);
            Transitions.Add("scale-y", _transition.ScaleY);
        }

        private void QueueUpdate(float _)
        {
            IsUpdatePending = true;
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
                Instance.alpha = _transition.Alpha.Current;
            }

            var scaleX = _transition.Scale.Current * _transition.ScaleX.Current;
            var scaleY = _transition.Scale.Current * _transition.ScaleY.Current;

            Instance.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
        }

        public override void Reset()
        {
            base.Reset();
            Instance.enabled = true;
            _delayed = false;
            _delayFulfilled = false;
        }

        public override void Release()
        {
            base.Release();
            _delayed = false;
            _delayFulfilled = false;
        }
    }
}
