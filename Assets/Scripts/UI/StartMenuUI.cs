using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class StartMenuUI : GameUI
    {
        [SerializeField] private ButtonUI StartButton;
        [SerializeField] private ButtonUI QuitButton;

        public override void Initialized()
        {
            base.Initialized();
            
            StartButton.Button.onClick.AddListener(OnStartButtonClickedHandler);
            QuitButton .Button.onClick.AddListener(OnQuitButtonClickedHandler);
        }

        private void OnStartButtonClickedHandler()
        {
            Close(_ui =>
            {
                ApplicationManager.Instance.Get<LevelManager>().RunLevel();
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
            StartButton.Dispose();
            QuitButton .Dispose();
        }
    }
}
