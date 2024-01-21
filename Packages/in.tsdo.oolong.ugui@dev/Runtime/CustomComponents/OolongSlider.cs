using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    /// <summary>
    /// Add event handler for OnCanvasGroup change event
    /// </summary>
    public class OolongSlider : Slider, IOolongSelectable
    {
        public event CanvasGroupChanged OnCanvasGroupChange;

        protected override void OnCanvasGroupChanged()
        {
            base.OnCanvasGroupChanged();
            OnCanvasGroupChange?.Invoke();
        }
    }
}
