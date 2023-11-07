using System.Runtime.CompilerServices;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public readonly struct CubicBezier
    {
        private const float Precision = 1e-6f;

        private readonly float _ax;
        private readonly float _bx;
        private readonly float _cx;
        private readonly float _ay;
        private readonly float _by;
        private readonly float _cy;

        public CubicBezier(float p1X, float p1Y, float p2X, float p2Y)
        {
            _cx = 3f * p1X;
            _bx = 3f * (p2X - p1X) - _cx;
            _ax = 1f - _cx - _bx;
            _cy = 3f * p1Y;
            _by = 3f * (p2Y - p1Y) - _cy;
            _ay = 1f - _cy - _by;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float SampleCurveX(float t)
        {
            return ((_ax * t + _bx) * t + _cx) * t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float SampleCurveY(float t)
        {
            return ((_ay * t + _by) * t + _cy) * t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float SampleCurveDerivativeX(float t)
        {
            return (3f * _ax * t + 2f * _bx) * t + _cx;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float SolveCurveX(float x)
        {
            float t2;
            float x2;
            int i;

            // First try a few iterations of Newton's method -- normally very fast.
            for (t2 = x, i = 0; i < 8; i++)
            {
                x2 = SampleCurveX(t2) - x;
                if (Mathf.Abs(x2) < Precision)
                {
                    return t2;
                }
                var d2 = SampleCurveDerivativeX(t2);
                if (Mathf.Abs(d2) < Precision)
                {
                    break;
                }
                t2 -= x2 / d2;
            }

            var t0 = 0.0f;
            var t1 = 1.0f;
            t2 = x;

            if (t2 < t0)
            {
                return t0;
            }
            if (t2 > t1)
            {
                return t1;
            }

            while (t0 < t1)
            {
                x2 = SampleCurveX(t2);
                if (Mathf.Abs(x2 - x) < Precision)
                {
                    return t2;
                }
                if (x > x2)
                {
                    t0 = t2;
                }
                else
                {
                    t1 = t2;
                }
                t2 = (t1 - t0) * 0.5f + t0;
            }

            return t2;
        }

        public float Evaluate(float x)
        {
            return SampleCurveY(SolveCurveX(x));
        }

        public static CubicBezier Ease = new CubicBezier(0.25f, 0.1f, 0.25f, 1f);
        public static CubicBezier Linear = new CubicBezier(0f, 0f, 1f, 1f);
        public static CubicBezier EaseIn = new CubicBezier(0.42f, 0f, 1f, 1f);
        public static CubicBezier EaseOut = new CubicBezier(0f, 0f, 0.58f, 1f);
        public static CubicBezier EaseInOut = new CubicBezier(0.42f, 0f, 0.58f, 1f);
    }
}
