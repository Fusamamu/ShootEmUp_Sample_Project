using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class Wall : MonoBehaviour
    {
        public void OnTriggerExit(Collider _collider)
        {
            if (_collider.gameObject.TryGetComponent<Player>(out var _player))
            {
                ApplicationManager
                    .Instance.Get<PlayerManager>()
                    .ResetPlayerPosition();
            }
            
            if (_collider.gameObject.TryGetComponent<Bullet>(out var _bullet))
                _bullet.ReturnToPool();
            
            if (_collider.gameObject.TryGetComponent<Enemy>(out var _enemy))
                _enemy.ReturnToPool();
            
            if (_collider.gameObject.TryGetComponent<Asteroid>(out var _asteroid))
                _asteroid.ReturnToPool();
        }
    }
}
