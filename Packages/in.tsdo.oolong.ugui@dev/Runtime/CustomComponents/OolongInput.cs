#if UNITY_TMP || UNITY_UGUI_2

using TMPro;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    /// <summary>
    /// Add event handler for OnCanvasGroup change event
    /// </summary>
    public class OolongInput : TMP_InputField, IOolongSelectable
    {
        public event CanvasGroupChanged OnCanvasGroupChange;

        protected override void OnCanvasGroupChanged()
        {
            base.OnCanvasGroupChanged();
            OnCanvasGroupChange?.Invoke();
        }
    }
}

#endif
