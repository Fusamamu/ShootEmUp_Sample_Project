using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class PlayerManager : AppManager
    {
        [SerializeField] private Player CurrentActivePlayer;

        [SerializeField] private Player PlayerPrefab;
        
        [SerializeField] private Transform PlayerSpawnPosition;
        
        public override void Initialized()
        {
            base.Initialized();
        }

        public Player SpawnPlayer()
        {
            var _player = Instantiate(PlayerPrefab, PlayerSpawnPosition.position, Quaternion.identity);
            _player.Initialized();
            
            CurrentActivePlayer = _player;
            
            return _player;
        }
    }
}
