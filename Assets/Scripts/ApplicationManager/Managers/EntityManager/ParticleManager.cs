using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public enum ParticleType
    {
        EXPLODE, ASTEROID_IMPACT, PLAYER_DESTROYED
    }
    
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

        public void PlayParticle(ParticleType _type, Vector3 _targetPos)
        {
            ParticleSystem _particle = null;
            
            switch (_type)
            {
                case ParticleType.EXPLODE:
                    _particle = PoolSystem.Pool.Get().OnEnemyDestroyedParticle;
                    break;
                
                case ParticleType.ASTEROID_IMPACT:
                    _particle = PoolSystem.Pool.Get().OnAsteroidImpactParticle;
                    break;
                
                case ParticleType.PLAYER_DESTROYED:
                    _particle = PoolSystem.Pool.Get().OnPlayerDestroyedParticle;
                    break;
            }

            if (_particle)
            {
                _particle.transform.position = _targetPos;
                _particle.Play();
            }
        }
    }
}
