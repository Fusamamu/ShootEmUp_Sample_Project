using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Color_Em_Up
{
    public class GameUI : MonoBehaviour
    {
        [field: SerializeField] public bool IsOpened { get; private set; }
        
        [ReadOnly, SerializeField] protected Canvas        UICanvas;
        [ReadOnly, SerializeField] protected RectTransform CanvasRectTransform;
        
        private UIManager uiManager;
        
        public virtual void Initialized()
        {
            uiManager = ApplicationManager.Instance.Get<UIManager>();
            uiManager.Add(this);
        }
        
        public virtual void Open(Action<GameUI> _openCompleted = null)
        {
            UICanvas.enabled = true;
            IsOpened = true;
            _openCompleted?.Invoke(this);
        }
        
        public virtual void Close(Action<GameUI> _onCloseCompleted  = null)
        {
            UICanvas.enabled = false;
            IsOpened = false;
            _onCloseCompleted?.Invoke(this);
        }
    }
}
