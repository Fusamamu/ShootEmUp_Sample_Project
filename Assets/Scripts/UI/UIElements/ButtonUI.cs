using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Color_Em_Up
{
    public class ButtonUI : UIElement
    {
        public Button Button;

        public override void Initialized()
        {
            base.Initialized();
        }
        
        protected override void OnFocus(PointerEventData _event)
        {
            base.OnFocus(_event);
        }

        protected override void OnLostFocus(PointerEventData _event)
        {
            base.OnLostFocus(_event);
        }

        protected override void OnClicked(PointerEventData _event)
        {
            base.OnClicked(_event);
        }

        public override void Dispose()
        {
            if(Button)
                Button.onClick.RemoveAllListeners();
        }
    }
}
