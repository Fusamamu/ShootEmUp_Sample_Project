using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    [RequireComponent(typeof(BulletPool))]
    public class BulletManager : AppManager, IEntityManager<BulletPool, Bullet>
    {
        [field: SerializeField] public BulletPool PoolSystem { get; private set; }

        public override void Initialized()
        {
            base.Initialized();

            if (!PoolSystem)
            {
                Debug.LogWarning($"Missing BulletPool!");
                return;
            }
            
            PoolSystem.Initialized();
        }
    }
}
