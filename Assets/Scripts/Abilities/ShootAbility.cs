using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Color_Em_Up
{
    public class ShootAbility : AgentAbility
    {
        private BulletManager bulletManager;

        private IDisposable shoot;
        
        public override void Initialized()
        {
            bulletManager = ApplicationManager.Instance.Get<BulletManager>();
        }
        
        public override void Perform()
        {
            var _bullet = bulletManager.PoolSystem.Pool.Get();
            
            shoot = Observable.EveryUpdate().Subscribe(_ =>
            {

            });
        }

        public override void Stop()
        {
            
        }
    }
}
