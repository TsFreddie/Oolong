using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    /// <summary>
    /// Add event handler for OnCanvasGroup change event
    /// </summary>
    public class OolongToggle : Toggle, IOolongSelectable
    {
        public event CanvasGroupChanged OnCanvasGroupChange;

        protected override void OnCanvasGroupChanged()
        {
            base.OnCanvasGroupChanged();
            OnCanvasGroupChange?.Invoke();
        }
    }
}
