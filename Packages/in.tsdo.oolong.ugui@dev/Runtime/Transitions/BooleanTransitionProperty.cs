using System;

namespace TSF.Oolong.UGUI
{
    public class BooleanTransitionProperty : TransitionProperty<bool>
    {
        public BooleanTransitionProperty(Action<bool> applyCallback = null, bool defaultValue = default) :
            base(applyCallback, defaultValue)
        {
        }
        protected override bool Lerp(bool from, bool to, float t) => t < 0.5f ? from : to;
    }
}
