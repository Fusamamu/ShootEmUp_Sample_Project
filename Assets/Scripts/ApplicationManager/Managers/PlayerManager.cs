using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class PlayerManager : AppManager
    {
        [SerializeField] private int InitialLifeAmount = 3;
        [SerializeField] private int CurrentLifeAmount;
        
        [SerializeField] private Player CurrentActivePlayer;

        [SerializeField] private Player PlayerPrefab;
        [SerializeField] private Transform PlayerSpawnPosition;

        private UIManager uiManager;
        
        private TopLeftUI  topLeftUI;
        private GameOverUI gameOverUI;

        public event Action<Player> OnGameOverEvent = delegate { };
        
        public override void Initialized()
        {
            base.Initialized();
            CurrentLifeAmount = InitialLifeAmount;

            uiManager  = ApplicationManager.Instance.Get<UIManager>();
            
            topLeftUI  = uiManager.GetUI<TopLeftUI>();
            gameOverUI = uiManager.GetUI<GameOverUI>();
        }

        public Player SpawnPlayer()
        {
            if (!CurrentActivePlayer)
            {
                CurrentActivePlayer = Instantiate(PlayerPrefab, PlayerSpawnPosition.position, Quaternion.identity);
                CurrentActivePlayer.Initialized();
            }
            
            return CurrentActivePlayer;
        }

        public void ResetPlayerPosition()
        {
            if (CurrentActivePlayer)
            {
                StartCoroutine(CurrentActivePlayer.RespawnCoroutine(PlayerSpawnPosition.position));
            }
        }

        public void NotifyPlayerIsDestroyed(Player _player)
        {
            CurrentLifeAmount--;
            topLeftUI.PlayerLifeUI.DecreaseLife();
            
            if (CurrentLifeAmount == 0)
            {
                gameOverUI.Open();
                OnGameOverEvent?.Invoke(CurrentActivePlayer);
                return;
            }
            
            StartCoroutine(CurrentActivePlayer
                .RespawnCoroutine(PlayerSpawnPosition.position, CurrentActivePlayer.StartCoolDown));
        }
        
        public void Reset()
        {
            CurrentLifeAmount = InitialLifeAmount;
            topLeftUI.PlayerLifeUI.Reset();
        }
    }
}
