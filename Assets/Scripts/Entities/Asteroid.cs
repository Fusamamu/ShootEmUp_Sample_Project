using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class Asteroid : MonoBehaviour, IEntity, ITarget, IPoolAble<Asteroid>
    {
        public IObjectPool<Asteroid> Pool { get; private set; }
        
        public bool IsInPool { get; set; }
        
        [field: SerializeField] public MoveBehavior    MoveBehavior    { get; private set; }
        
        [field: SerializeField] public ColliderControl ColliderControl { get; private set; }
        [field: SerializeField] public RenderControl   RenderControl   { get; private set; }
        
        private ParticleManager particleManager;
        private AudioManager    audioManager;

        public void Initialized()
        {
            particleManager = ApplicationManager.Instance.Get<ParticleManager>();
            audioManager    = ApplicationManager.Instance.Get<AudioManager>();
            
            MoveBehavior
                .SetTargetRigidbody(ColliderControl.Rigidbody);
        }
        
        public void SetPool(IObjectPool<Asteroid> _pool)
        {
            Pool = _pool;
        }
        
        public void ReturnToPool()
        {
            if(!IsInPool)
                Pool?.Release(this);
        }
        
        public void OnHitHandler(Bullet _bullet)
        {
            particleManager.PlayParticle(ParticleType.ASTEROID_IMPACT, transform.position);
            audioManager   .PlaySound   (SoundType.Explode);
        }
        
        public void DestroyEntity()
        {
            ReturnToPool();
        }
    }
}
