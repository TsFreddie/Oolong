using System;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class FloatTransitionProperty : TransitionProperty<float>
    {
        public FloatTransitionProperty(Action<float> applyCallback = null, float defaultValue = default) :
            base(applyCallback, defaultValue)
        {
        }
        protected override float Lerp(float from, float to, float t) => Mathf.Lerp(from, to, t);
    }
}
