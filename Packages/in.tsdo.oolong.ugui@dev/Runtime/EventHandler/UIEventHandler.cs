using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TSF.Oolong.UGUI
{
    public interface IUIEventHandler
    {
        void AddListener(IOolongLoader.JsCallback callback);
        void RemoveListener();
    }

    public static class UIEventHandler
    {
        private static readonly List<IUIEventHandler> s_handlerCache = new List<IUIEventHandler>();

        public static Type GetHandlerType(string key)
        {
            switch (key)
            {
                case "pointerenter": return typeof(OnPointerEnterHandler);
                case "pointerexit": return typeof(OnPointerExitHandler);
                case "pointerdown": return typeof(OnPointerDownHandler);
                case "pointerup": return typeof(OnPointerUpHandler);
                case "pointermove": return typeof(OnPointerMoveHandler);
                case "pointerclick": return typeof(OnPointerClickHandler);
                case "initializepotentialdrag": return typeof(OnInitializePotentialDragHandler);
                case "begindrag": return typeof(OnBeginDragHandler);
                case "drag": return typeof(OnDragHandler);
                case "enddrag": return typeof(OnEndDragHandler);
                case "drop": return typeof(OnDropHandler);
                case "scroll": return typeof(OnScrollHandler);
                case "updateselected": return typeof(OnUpdateSelectedHandler);
                case "select": return typeof(OnSelectHandler);
                case "deselect": return typeof(OnDeselectHandler);
                case "move": return typeof(OnMoveHandler);
                case "submit": return typeof(OnSubmitHandler);
                case "cancel": return typeof(OnCancelHandler);
            }
            return null;
        }

        public static bool AddListenerToGameObject(GameObject gameObject, string key, IOolongLoader.JsCallback callback)
        {
            var type = GetHandlerType(key);
            if (type == null) return false;

            var handler = gameObject.GetComponent(type) as IUIEventHandler;
            if (handler == null) handler = gameObject.AddComponent(type) as IUIEventHandler;
            if (handler == null) return false;
            handler.AddListener(callback);
            return true;
        }

        public static bool RemoveListenerFromGameObject(GameObject gameObject, string key)
        {
            var type = GetHandlerType(key);
            if (type == null) return false;

            var handler = gameObject.GetComponent(type) as IUIEventHandler;
            if (handler == null) return false;
            handler.RemoveListener();
            return true;
        }

        public static void ResetListeners(GameObject gameObject)
        {
            gameObject.GetComponents(s_handlerCache);
            foreach (var handler in s_handlerCache)
            {
                handler.RemoveListener();
            }
            s_handlerCache.Clear();
        }
    }

    public class OnPointerEnterHandler : MonoBehaviour, IPointerEnterHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnPointerExitHandler : MonoBehaviour, IPointerExitHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnPointerDownHandler : MonoBehaviour, IPointerDownHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnPointerUpHandler : MonoBehaviour, IPointerUpHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnPointerMoveHandler : MonoBehaviour, IPointerMoveHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnPointerClickHandler : MonoBehaviour, IPointerClickHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnInitializePotentialDragHandler : MonoBehaviour, IInitializePotentialDragHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnBeginDragHandler : MonoBehaviour, IBeginDragHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnDragHandler : MonoBehaviour, IDragHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnEndDragHandler : MonoBehaviour, IEndDragHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnDropHandler : MonoBehaviour, IDropHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnDrop(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnScrollHandler : MonoBehaviour, IScrollHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnScroll(PointerEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnUpdateSelectedHandler : MonoBehaviour, IUpdateSelectedHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnUpdateSelected(BaseEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnSelectHandler : MonoBehaviour, ISelectHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnSelect(BaseEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnDeselectHandler : MonoBehaviour, IDeselectHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnMoveHandler : MonoBehaviour, IMoveHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnMove(AxisEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnSubmitHandler : MonoBehaviour, ISubmitHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnSubmit(BaseEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
    public class OnCancelHandler : MonoBehaviour, ICancelHandler, IUIEventHandler
    {
        private IOolongLoader.JsCallback _callback;

#if UNITY_EDITOR
        private void OnEnable() {}
#endif

        public void AddListener(IOolongLoader.JsCallback callback)
        {
            _callback = callback;
            enabled = true;
        }

        public void RemoveListener()
        {
            _callback = null;
            enabled = false;
        }

        public void OnCancel(BaseEventData eventData)
        {
            _callback?.Invoke(eventData);
        }
    }
}
