using System;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class FloatTransitionProperty : TransitionProperty<float>
    {
        public FloatTransitionProperty(Action<float> applyCallback) : base(applyCallback) { }
        protected override float Lerp(float from, float to, float t) => Mathf.Lerp(from, to, t);
    }
}
