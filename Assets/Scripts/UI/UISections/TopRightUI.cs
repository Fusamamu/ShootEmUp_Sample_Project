using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class TopRightUI : GameUI
    {
        [SerializeField] private ButtonUI MenuButton;

        public override void Initialized()
        {
            base.Initialized();
            
            MenuButton.Button.onClick.AddListener(OnMenuButtonClickedHandler);
        }

        private void OnMenuButtonClickedHandler()
        {
            Time.timeScale = 0;
            ApplicationManager.Instance.Get<UIManager>().GetUI<MenuUI>().Open();
        }
        
        public override void Open(Action<GameUI> _onOpenCompleted = null)
        {
            base.Open(_onOpenCompleted);
        }
        
        public override void Close(Action<GameUI> _onCloseCompleted = null)
        {
            base.Close(_onCloseCompleted);
        }

        private void OnDestroy()
        {
            MenuButton.Dispose();
        }
    }
}
