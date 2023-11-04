using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class BezierCurve
    {
        private const int NewtonIterations = 4;
        private const float NewtonMinSlope = 0.001f;
        private const float SubdivisionPrecision = 0.0000001f;
        private const int SubdivisionMaxIterations = 10;

        private const int SplineTableSize = 11;
        private const float SampleStepSize = 1.0f / (SplineTableSize - 1.0f);
        private const int LastSample = SplineTableSize - 1;

        private static float A(float aA1, float aA2) => 1.0f - 3.0f * aA2 + 3.0f * aA1;
        private static float B(float aA1, float aA2) => 3.0f * aA2 - 6.0f * aA1;
        private static float C(float aA1) => 3.0f * aA1;

        private float _mX1;
        private float _mY1;
        private float _mX2;
        private float _mY2;

        private float[] _sampleValues;

        private static float CalcBezier(float aT, float aA1, float aA2) => ((A(aA1, aA2) * aT + B(aA1, aA2)) * aT + C(aA1)) * aT;
        private static float GetSlope(float aT, float aA1, float aA2) => 3.0f * A(aA1, aA2) * aT * aT + 2.0f * B(aA1, aA2) * aT + C(aA1);

        private static float BinarySubdivide(float aX, float aA, float aB, float mX1, float mX2)
        {
            float currentX, currentT = 0;
            var i = 0;
            do
            {
                currentT = aA + (aB - aA) / 2.0f;
                currentX = CalcBezier(currentT, mX1, mX2) - aX;
                if (currentX > 0.0)
                {
                    aB = currentT;
                }
                else
                {
                    aA = currentT;
                }
            }
            while (Math.Abs(currentX) > SubdivisionPrecision && ++i < SubdivisionMaxIterations);
            return currentT;
        }

        private static float NewtonRaphsonIterate(float aX, float aGuessT, float mX1, float mX2)
        {
            for (var i = 0; i < NewtonIterations; ++i)
            {
                var currentSlope = GetSlope(aGuessT, mX1, mX2);
                if (currentSlope == 0.0)
                {
                    return aGuessT;
                }
                var currentX = CalcBezier(aGuessT, mX1, mX2) - aX;
                aGuessT -= currentX / currentSlope;
            }
            return aGuessT;
        }

        public BezierCurve(float mX1, float mY1, float mX2, float mY2)
        {
            if (!(0 <= mX1 && mX1 <= 1 && 0 <= mX2 && mX2 <= 1))
            {
                throw new Exception("bezier x values must be in [0, 1] range");
            }

            this._mX1 = mX1;
            this._mY1 = mY1;
            this._mX2 = mX2;
            this._mY2 = mY2;

            _sampleValues = new float[SplineTableSize];
            for (var i = 0; i < SplineTableSize; i++)
            {
                _sampleValues[i] = CalcBezier(i * SampleStepSize, mX1, mX2);
            }
        }

        private float GetTForX(float aX)
        {
            var intervalStart = 0.0f;
            var currentSample = 1;

            for (; currentSample != LastSample && _sampleValues[currentSample] <= aX; ++currentSample)
            {
                intervalStart += SampleStepSize;
            }
            --currentSample;

            var dist = (aX - _sampleValues[currentSample]) / (_sampleValues[currentSample + 1] - _sampleValues[currentSample]);
            var guessForT = intervalStart + dist * SampleStepSize;

            var initialSlope = GetSlope(guessForT, _mX1, _mX2);
            if (initialSlope >= NewtonMinSlope)
            {
                return NewtonRaphsonIterate(aX, guessForT, _mX1, _mX2);
            }
            return initialSlope == 0.0 ? guessForT : BinarySubdivide(aX, intervalStart, intervalStart + SampleStepSize, _mX1, _mX2);
        }

        public float Get(float x)
        {
            if (x <= 0) return 0;
            if (x >= 1) return 1;
            return CalcBezier(GetTForX(x), _mY1, _mY2);
        }
    }
}
