using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class GameOverUI : GameUI
    {
        [SerializeField] private ButtonUI ContinueButton;
        [SerializeField] private ButtonUI QuitButton;
        
        public override void Initialized()
        {
            base.Initialized();

            ContinueButton.Button.onClick.AddListener(OnContinueButtonClicked);
            QuitButton    .Button.onClick.AddListener(OnQuitButtonClickedHandler);
        }
        
        private void OnContinueButtonClicked()
        {
            Close(_ui =>
            {
                ApplicationManager.Instance.Get<LevelManager>().RestartLevel();
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
            ContinueButton.Dispose();
            QuitButton    .Dispose();
        }
    }
}

