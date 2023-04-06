using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Color_Em_Up
{
    [RequireComponent(typeof(PointerEventHandle))]
    public class UIElement : MonoBehaviour, IDisposable
    {
        [field: SerializeField] public bool IsFocus { get; private set; }

        [field: SerializeField] public ColliderControl ColliderControl { get; private set; }

        [SerializeField] private MMF_Player OnFocusAnimation;
        [SerializeField] private MMF_Player OnLostFocusAnimation;
        [SerializeField] private MMF_Player OnClickedAnimation;
        
        [field: SerializeField] public PointerEventHandle PointerEventHandle  { get; private set; }
        
        public virtual void Initialized()
        {
            PointerEventHandle
                .AddTriggers(Trigger.ON_POINTER_ENTER, Trigger.ON_POINTER_EXIT, Trigger.ON_POINTER_CLICKED)
                .SubscribeOnPointerEnter  ((_handle, _data) => OnFocus    (_data))
                .SubscribeOnPointerExit   ((_handle, _data) => OnLostFocus(_data))
                .SubscribeOnPointerClicked((_handle, _data) => OnClicked  (_data))
                .Initialized();
        }
        
        protected virtual void OnFocus(PointerEventData _event)
        {
            IsFocus = true;
            
            if (OnFocusAnimation)
                OnFocusAnimation.PlayFeedbacks();
        }

        protected virtual void OnLostFocus(PointerEventData _event)
        {
            if(!OnFocusAnimation) return;
            
            if (OnFocusAnimation.IsPlaying)
                OnFocusAnimation.StopFeedbacks();
            
            if (OnLostFocusAnimation)
                OnLostFocusAnimation.PlayFeedbacks();
            
            IsFocus = false;
        }

        protected virtual void OnClicked(PointerEventData _event)
        {
            if(OnClickedAnimation)
                OnClickedAnimation.PlayFeedbacks();
        }
        
        public virtual void Dispose()
        {
            PointerEventHandle.Dispose();
        }
    }
}
