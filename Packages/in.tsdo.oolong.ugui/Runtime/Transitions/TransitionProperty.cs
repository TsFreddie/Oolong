using System;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public abstract class TransitionProperty<T> : ITransitionProperty where T : struct, IEquatable<T>
    {
        private readonly Action<T> _applyCallback;
        private bool _isStarted;
        private float _startTime;
        private T _from;
        private T _start;
        private T _to;
        private T _current;
        private readonly T _defaultValue;
        private float _progress;
        private bool _hasInitialValue;
        private float _duration;
        private float _delay;
        private CubicBezier _timingFunction;

        public CubicBezier TimingFunction { get; set; } = CubicBezier.Ease;
        public float Delay { get; set; } = 0.0f;
        public float Duration { get; set; } = 0.0f;
        public T Current => _current;

        public TransitionProperty(Action<T> applyCallback = null, T defaultValue = default)
        {
            _defaultValue = defaultValue;
            _current = _defaultValue;
            _applyCallback = applyCallback;
        }

        public void SetValue(T value)
        {
            if (!_hasInitialValue)
            {
                _hasInitialValue = true;
                _current = value;
                _start = value;
                _from = value;
                _to = value;
                _applyCallback?.Invoke(value);
                return;
            }

            if (Delay == 0.0f && Duration == 0.0f)
            {
                // no transition, apply immediately
                _current = value;
                _start = value;
                _from = value;
                _to = value;
                _applyCallback?.Invoke(value);
                return;
            }

            if (value.Equals(_to))
            {
                // unchanged, don't do anything
                return;
            }

            if (value.Equals(_from))
            {
                // toggle value, shorten duration
                _duration = Duration * _progress;
                _from = _to;
            }
            else
            {
                _duration = Duration;
                _from = _current;
            }

            _delay = Delay;
            _timingFunction = TimingFunction;
            _start = _current;
            _to = value;
            Start();
        }

        private void Start()
        {
            _progress = 0.0f;
            _startTime = Time.time;

            if (_isStarted)
                return;

            _isStarted = true;
            DocumentUtils.OnDocumentLateUpdate += OnLateUpdate;
        }

        private void Stop()
        {
            if (!_isStarted)
                return;

            _isStarted = false;
            DocumentUtils.OnDocumentLateUpdate -= OnLateUpdate;
        }

        private void OnLateUpdate()
        {
            if (_duration < Mathf.Epsilon)
            {
                // safe guard 0 duration
                _current = _to;
                _applyCallback?.Invoke(_current);
                return;
            }

            var t = Mathf.Clamp01((Time.time - _startTime - _delay) / _duration);
            if (t < 0.0f)
                return;

            if (t >= 1.0f)
                Stop();

            _progress = _timingFunction.Evaluate(t);
            _current = Lerp(_start, _to, _progress);
            _applyCallback?.Invoke(_current);
        }

        public void Clear()
        {
            _hasInitialValue = false;
            _current = _defaultValue;
            _progress = 0.0f;
            _duration = Duration;
            _applyCallback?.Invoke(_current);
            Stop();
        }

        public void Reset()
        {
            Delay = 0.0f;
            Duration = 0.0f;
            TimingFunction = CubicBezier.Ease;
        }

        protected abstract T Lerp(T from, T to, float t);
    }
}
