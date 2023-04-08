using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class GameParticle : MonoBehaviour, IPoolAble<GameParticle>
    {
        [field: SerializeField] public ParticleSystem ShootingParticle         { get; private set; }
        [field: SerializeField] public ParticleSystem OnEnemyDestroyedParticle { get; private set; }
        
        public IObjectPool<GameParticle> Pool { get; private set; }

        public void Initialized()
        {
          
        }
        
        public void SetPool(IObjectPool<GameParticle> _pool)
        {
            Pool = _pool;
        }
        
        public void ReturnToPool()
        {
            Pool?.Release(this);
        }
    }
}
