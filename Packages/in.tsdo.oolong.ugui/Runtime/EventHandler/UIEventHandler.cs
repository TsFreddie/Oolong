using UnityEngine;
using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    public class UIEventHandler : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerClickHandler,
        IInitializePotentialDragHandler,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler,
        IDropHandler,
        IScrollHandler,
        IUpdateSelectedHandler,
        ISelectHandler,
        IDeselectHandler,
        IMoveHandler,
        ISubmitHandler,
        ICancelHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
        }
        public void OnPointerExit(PointerEventData eventData)
        {
        }
        public void OnPointerDown(PointerEventData eventData)
        {
        }
        public void OnPointerUp(PointerEventData eventData)
        {
        }
        public void OnPointerClick(PointerEventData eventData)
        {
        }
        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
        }
        public void OnDrag(PointerEventData eventData)
        {
        }
        public void OnEndDrag(PointerEventData eventData)
        {
        }
        public void OnDrop(PointerEventData eventData)
        {
        }
        public void OnScroll(PointerEventData eventData)
        {
        }
        public void OnUpdateSelected(BaseEventData eventData)
        {
        }
        public void OnSelect(BaseEventData eventData)
        {
        }
        public void OnDeselect(BaseEventData eventData)
        {
        }
        public void OnMove(AxisEventData eventData)
        {
        }
        public void OnSubmit(BaseEventData eventData)
        {
        }
        public void OnCancel(BaseEventData eventData)
        {
        }
    }
}
