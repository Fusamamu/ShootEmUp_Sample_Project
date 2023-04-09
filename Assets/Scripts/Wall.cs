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

            if (_collider.gameObject.TryGetComponent<IPoolReturnAble>(out var _returnAbleObject))
            {
                _returnAbleObject.ReturnToPool();
            }
        }
    }
}
