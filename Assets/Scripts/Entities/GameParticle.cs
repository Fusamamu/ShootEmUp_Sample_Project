using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class GameParticle : MonoBehaviour, IEntity, IPoolAble<GameParticle>
    {
        [field: SerializeField] public ParticleSystem ShootingParticle          { get; private set; }
        [field: SerializeField] public ParticleSystem OnEnemyDestroyedParticle  { get; private set; }
        [field: SerializeField] public ParticleSystem OnPlayerDestroyedParticle { get; private set; }
        [field: SerializeField] public ParticleSystem OnAsteroidImpactParticle  { get; private set; }
        
        public IObjectPool<GameParticle> Pool { get; private set; }
        
        public bool IsInPool { get; set; }

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
        
        public void DestroyEntity()
        {
            ReturnToPool();
        }
    }
}
