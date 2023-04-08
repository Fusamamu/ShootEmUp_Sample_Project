using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class ParticleManager : AppManager
    {
        [field: SerializeField] public ParticlePool ParticlePool { get; private set; }

        public override void Initialized()
        {
            base.Initialized();

            if (!ParticlePool)
            {
                Debug.LogWarning($"Missing ParticlePool!");
                return;
            }
            
            ParticlePool.Initialized();
        }
    }
}
