using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    [RequireComponent(typeof(BulletPool))]
    public class BulletManager : AppManager
    {
        [field: SerializeField] public BulletPool BulletPool { get; private set; }

        public override void Initialized()
        {
            base.Initialized();

            if (!BulletPool)
            {
                Debug.LogWarning($"Missing BulletPool!");
                return;
            }
            
            BulletPool.Initialized();
        }
    }
}
