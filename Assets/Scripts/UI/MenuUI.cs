using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class MenuUI : GameUI
    {
        [SerializeField] private ButtonUI ResumeButton;
        [SerializeField] private ButtonUI QuitButton;

        public override void Initialized()
        {
            base.Initialized();
            
            ResumeButton.Button.onClick.AddListener(OnResumeButtonClickedHandler);
            QuitButton  .Button.onClick.AddListener(OnQuitButtonClickedHandler);
        }

        private void OnResumeButtonClickedHandler()
        {
            Close(_ui =>
            {
                Time.timeScale = 1;
            });
        }

        private void OnQuitButtonClickedHandler()
        {
            if (Application.isPlaying)
            {
                Application.Quit();
            }
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
            ResumeButton.Dispose();
            QuitButton  .Dispose();
        }
    }
}
