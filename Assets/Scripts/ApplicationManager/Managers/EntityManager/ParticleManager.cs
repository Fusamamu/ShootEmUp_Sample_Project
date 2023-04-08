using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class ParticleManager : AppManager, IEntityManager<ParticlePool, GameParticle>
    {
        [field: SerializeField] public ParticlePool PoolSystem { get; private set; }

        public override void Initialized()
        {
            base.Initialized();

            if (!PoolSystem)
            {
                Debug.LogWarning($"Missing ParticlePool!");
                return;
            }
            
            PoolSystem.Initialized();
        }
    }
}
