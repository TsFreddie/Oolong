using System;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public class ColorTransitionProperty : TransitionProperty<Color>
    {
        public ColorTransitionProperty(Action<Color> applyCallback = null, Color defaultValue = default) :
            base(applyCallback, defaultValue)
        {
        }
        protected override Color Lerp(Color from, Color to, float t) => Color.Lerp(from, to, t);
    }
}
