using UnityEngine;
using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    public class UIEventHandler : MonoBehaviour,
        IPointerEnterHandler, 
        IPointerExitHandler, 
        IPointerDownHandler, 
        IPointerUpHandler, 
        IPointerMoveHandler, 
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
        private int _eventCount;
        private int EventCount
        {
            get => _eventCount;
            set
            {
                _eventCount = value;
                enabled = _eventCount > 0;
            }
        }
        private IOolongLoader.JsCallback _onPointerEnter;
        private IOolongLoader.JsCallback _onPointerExit;
        private IOolongLoader.JsCallback _onPointerDown;
        private IOolongLoader.JsCallback _onPointerUp;
        private IOolongLoader.JsCallback _onPointerMove;
        private IOolongLoader.JsCallback _onPointerClick;
        private IOolongLoader.JsCallback _onInitializePotentialDrag;
        private IOolongLoader.JsCallback _onBeginDrag;
        private IOolongLoader.JsCallback _onDrag;
        private IOolongLoader.JsCallback _onEndDrag;
        private IOolongLoader.JsCallback _onDrop;
        private IOolongLoader.JsCallback _onScroll;
        private IOolongLoader.JsCallback _onUpdateSelected;
        private IOolongLoader.JsCallback _onSelect;
        private IOolongLoader.JsCallback _onDeselect;
        private IOolongLoader.JsCallback _onMove;
        private IOolongLoader.JsCallback _onSubmit;
        private IOolongLoader.JsCallback _onCancel;

        public bool AddListener(string key, IOolongLoader.JsCallback callback)
        {
            switch (key)
            {
                case "pointerenter":
                    if (_onPointerEnter == null) EventCount++;
                    _onPointerEnter = callback;
                    return true;
                case "pointerexit":
                    if (_onPointerExit == null) EventCount++;
                    _onPointerExit = callback;
                    return true;
                case "pointerdown":
                    if (_onPointerDown == null) EventCount++;
                    _onPointerDown = callback;
                    return true;
                case "pointerup":
                    if (_onPointerUp == null) EventCount++;
                    _onPointerUp = callback;
                    return true;
                case "pointermove":
                    if (_onPointerMove == null) EventCount++;
                    _onPointerMove = callback;
                    return true;
                case "pointerclick":
                    if (_onPointerClick == null) EventCount++;
                    _onPointerClick = callback;
                    return true;
                case "initializepotentialdrag":
                    if (_onInitializePotentialDrag == null) EventCount++;
                    _onInitializePotentialDrag = callback;
                    return true;
                case "begindrag":
                    if (_onBeginDrag == null) EventCount++;
                    _onBeginDrag = callback;
                    return true;
                case "drag":
                    if (_onDrag == null) EventCount++;
                    _onDrag = callback;
                    return true;
                case "enddrag":
                    if (_onEndDrag == null) EventCount++;
                    _onEndDrag = callback;
                    return true;
                case "drop":
                    if (_onDrop == null) EventCount++;
                    _onDrop = callback;
                    return true;
                case "scroll":
                    if (_onScroll == null) EventCount++;
                    _onScroll = callback;
                    return true;
                case "updateselected":
                    if (_onUpdateSelected == null) EventCount++;
                    _onUpdateSelected = callback;
                    return true;
                case "select":
                    if (_onSelect == null) EventCount++;
                    _onSelect = callback;
                    return true;
                case "deselect":
                    if (_onDeselect == null) EventCount++;
                    _onDeselect = callback;
                    return true;
                case "move":
                    if (_onMove == null) EventCount++;
                    _onMove = callback;
                    return true;
                case "submit":
                    if (_onSubmit == null) EventCount++;
                    _onSubmit = callback;
                    return true;
                case "cancel":
                    if (_onCancel == null) EventCount++;
                    _onCancel = callback;
                    return true;
            }
            return false;
        }

        public bool RemoveListener(string key)
        {
            switch (key)
            {
                case "pointerenter":
                    if (_onPointerEnter != null) EventCount--;
                    _onPointerEnter = null;
                    return true;
                case "pointerexit":
                    if (_onPointerExit != null) EventCount--;
                    _onPointerExit = null;
                    return true;
                case "pointerdown":
                    if (_onPointerDown != null) EventCount--;
                    _onPointerDown = null;
                    return true;
                case "pointerup":
                    if (_onPointerUp != null) EventCount--;
                    _onPointerUp = null;
                    return true;
                case "pointermove":
                    if (_onPointerMove != null) EventCount--;
                    _onPointerMove = null;
                    return true;
                case "pointerclick":
                    if (_onPointerClick != null) EventCount--;
                    _onPointerClick = null;
                    return true;
                case "initializepotentialdrag":
                    if (_onInitializePotentialDrag != null) EventCount--;
                    _onInitializePotentialDrag = null;
                    return true;
                case "begindrag":
                    if (_onBeginDrag != null) EventCount--;
                    _onBeginDrag = null;
                    return true;
                case "drag":
                    if (_onDrag != null) EventCount--;
                    _onDrag = null;
                    return true;
                case "enddrag":
                    if (_onEndDrag != null) EventCount--;
                    _onEndDrag = null;
                    return true;
                case "drop":
                    if (_onDrop != null) EventCount--;
                    _onDrop = null;
                    return true;
                case "scroll":
                    if (_onScroll != null) EventCount--;
                    _onScroll = null;
                    return true;
                case "updateselected":
                    if (_onUpdateSelected != null) EventCount--;
                    _onUpdateSelected = null;
                    return true;
                case "select":
                    if (_onSelect != null) EventCount--;
                    _onSelect = null;
                    return true;
                case "deselect":
                    if (_onDeselect != null) EventCount--;
                    _onDeselect = null;
                    return true;
                case "move":
                    if (_onMove != null) EventCount--;
                    _onMove = null;
                    return true;
                case "submit":
                    if (_onSubmit != null) EventCount--;
                    _onSubmit = null;
                    return true;
                case "cancel":
                    if (_onCancel != null) EventCount--;
                    _onCancel = null;
                    return true;
            }
            return false;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            _onPointerEnter?.Invoke(eventData);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            _onPointerExit?.Invoke(eventData);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _onPointerDown?.Invoke(eventData);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            _onPointerUp?.Invoke(eventData);
        }
        public void OnPointerMove(PointerEventData eventData)
        {
            _onPointerMove?.Invoke(eventData);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            _onPointerClick?.Invoke(eventData);
        }
        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            _onInitializePotentialDrag?.Invoke(eventData);
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _onBeginDrag?.Invoke(eventData);
        }
        public void OnDrag(PointerEventData eventData)
        {
            _onDrag?.Invoke(eventData);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _onEndDrag?.Invoke(eventData);
        }
        public void OnDrop(PointerEventData eventData)
        {
            _onDrop?.Invoke(eventData);
        }
        public void OnScroll(PointerEventData eventData)
        {
            _onScroll?.Invoke(eventData);
        }
        public void OnUpdateSelected(BaseEventData eventData)
        {
            _onUpdateSelected?.Invoke(eventData);
        }
        public void OnSelect(BaseEventData eventData)
        {
            _onSelect?.Invoke(eventData);
        }
        public void OnDeselect(BaseEventData eventData)
        {
            _onDeselect?.Invoke(eventData);
        }
        public void OnMove(AxisEventData eventData)
        {
            _onMove?.Invoke(eventData);
        }
        public void OnSubmit(BaseEventData eventData)
        {
            _onSubmit?.Invoke(eventData);
        }
        public void OnCancel(BaseEventData eventData)
        {
            _onCancel?.Invoke(eventData);
        }

        public void Reset()
        {
            _eventCount = 0;
            enabled = false;
            _onPointerEnter = null;
            _onPointerExit = null;
            _onPointerDown = null;
            _onPointerUp = null;
            _onPointerMove = null;
            _onPointerClick = null;
            _onInitializePotentialDrag = null;
            _onBeginDrag = null;
            _onDrag = null;
            _onEndDrag = null;
            _onDrop = null;
            _onScroll = null;
            _onUpdateSelected = null;
            _onSelect = null;
            _onDeselect = null;
            _onMove = null;
            _onSubmit = null;
            _onCancel = null;
        }

#if UNITY_EDITOR
        private void OnEnable() { }
#endif
    }
}
