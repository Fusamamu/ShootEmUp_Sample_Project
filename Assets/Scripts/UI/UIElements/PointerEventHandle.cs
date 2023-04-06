using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

namespace Color_Em_Up
{
    public enum Trigger
    {
        ON_POINTER_ENTER,
        ON_POINTER_EXIT, 
        ON_POINTER_CLICKED,
        ON_POINTER_DOWN,
        ON_POINTER_BEGIN_DRAG,
        ON_POINTER_DRAG,
        ON_POINTER_ENGDRAG
    }
    
    public class PointerEventHandle : MonoBehaviour, IDisposable
    {
        public bool IsInit;
        
        private event Action<PointerEventHandle, PointerEventData> onPointerEnter; 
        private event Action<PointerEventHandle, PointerEventData> onPointerExit;
        private event Action<PointerEventHandle, PointerEventData> onPointerClicked;
        
        private event Action<PointerEventHandle, PointerEventData> onPointerDown; 
        private event Action<PointerEventHandle, PointerEventData> onBeginDrag;
        private event Action<PointerEventHandle, PointerEventData> onDrag;
        private event Action<PointerEventHandle, PointerEventData> onEndDrag;

        private readonly Dictionary<Trigger, IDisposable> triggers = new Dictionary<Trigger, IDisposable>();

        public PointerEventHandle Initialized()
        {
            if (IsInit) 
                return this;
            
            IsInit = true;
            return this;
        }
        
        public PointerEventHandle SubscribeOnPointerEnter(Action<PointerEventHandle, PointerEventData> _handler)
        {
            onPointerEnter -= _handler;
            onPointerEnter += _handler;
            return this;
        }
        
        public PointerEventHandle SubscribeOnPointerExit(Action<PointerEventHandle, PointerEventData> _handler)
        {
            onPointerExit -= _handler;
            onPointerExit += _handler;
            return this;
        }
        
        public PointerEventHandle SubscribeOnPointerClicked(Action<PointerEventHandle, PointerEventData> _handler)
        {
            onPointerClicked -= _handler;
            onPointerClicked += _handler;
            return this;
        }

        public PointerEventHandle SubscribeOnPointerDown(Action<PointerEventHandle, PointerEventData> _handler)
        {
            onPointerDown -= _handler;
            onPointerDown += _handler;
            return this;
        }

        public PointerEventHandle AddTriggers(params Trigger[] _triggers)
        {
            foreach (var _trigger in _triggers)
                AddTrigger(_trigger);
            return this;
        }

        public PointerEventHandle AddTrigger(Trigger _triggerType)
        {
            IDisposable _pointerTrigger = null;
            
            switch (_triggerType)
            {
                case Trigger.ON_POINTER_ENTER: 
                    _pointerTrigger = gameObject.AddComponent<ObservablePointerEnterTrigger>().OnPointerEnterAsObservable().Subscribe(_pointerEvent =>
                    {
                        onPointerEnter?.Invoke(this, _pointerEvent);
                    }).AddTo(this);
                    break;
                
                case Trigger.ON_POINTER_EXIT:
                    _pointerTrigger = gameObject.AddComponent<ObservablePointerExitTrigger>().OnPointerExitAsObservable().Subscribe(_pointerEvent =>
                    {
                        onPointerExit?.Invoke(this, _pointerEvent);
                    }).AddTo(this);
                    break;
                
                case Trigger.ON_POINTER_CLICKED:
                    _pointerTrigger = gameObject.AddComponent<ObservablePointerClickTrigger>().OnPointerClickAsObservable().Subscribe(_pointerEvent =>
                    {
                        onPointerClicked?.Invoke(this, _pointerEvent);
                    }).AddTo(this);
                    break;
                
                case Trigger.ON_POINTER_DOWN:
                    _pointerTrigger = gameObject.AddComponent<ObservablePointerDownTrigger>().OnPointerDownAsObservable().Subscribe(_pointerEvent =>
                    {
                        onPointerDown?.Invoke(this, _pointerEvent);
                    }).AddTo(this);
                    break;
            }
            
            AddTrigger(_triggerType, _pointerTrigger);
            return this;
        }

        private PointerEventHandle AddTrigger(Trigger _triggerType, IDisposable _pointerTrigger)
        {
            if (!triggers.ContainsKey(_triggerType))
                triggers.Add(_triggerType, _pointerTrigger);
            else
            {
                triggers[_triggerType].Dispose();
                triggers[_triggerType] = _pointerTrigger;
            }
            return this;
        }

        public PointerEventHandle RemoveTrigger(Trigger _triggerType)
        {
            if (triggers.TryGetValue(_triggerType, out var _pointerTrigger))
            {
                _pointerTrigger.Dispose();
                triggers.Remove(_triggerType);
            }
            return this;
        }
        
        public PointerEventHandle UnSubscribeAll()
        {
            if (onPointerDown != null)
                foreach (var _del in onPointerDown.GetInvocationList())
                    onPointerDown -= _del as Action<PointerEventHandle, PointerEventData>;
            
            if(onBeginDrag != null)
                foreach (var _del in onBeginDrag.GetInvocationList())
                    onBeginDrag -= _del as Action<PointerEventHandle, PointerEventData>;
            
            if(onDrag != null)
                foreach (var _del in onDrag.GetInvocationList())
                    onDrag -= _del as Action<PointerEventHandle, PointerEventData>;

            if(onEndDrag != null)
                foreach (var _del in onEndDrag.GetInvocationList())
                    onEndDrag -= _del as Action<PointerEventHandle, PointerEventData>;

            return this;
        }
        
        public void Dispose()
        {
            UnSubscribeAll();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}
