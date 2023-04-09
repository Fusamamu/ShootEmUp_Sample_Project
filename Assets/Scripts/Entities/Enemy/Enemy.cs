using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class Enemy : MonoBehaviour, IEntity, ITarget, IPoolAble<Enemy>
    {
        public IObjectPool<Enemy> Pool { get; private set; }

        public bool IsInPool { get; set; }
        
        [field: SerializeField] public MoveBehavior         MoveBehavior         { get; private set; }
        [field: SerializeField] public MoveInWaveBehavior   MoveInWaveBehavior   { get; private set; }
        [field: SerializeField] public MoveInCircleBehavior MoveInCircleBehavior { get; private set; }
        [field: SerializeField] public BodyTiltingBehavior  BodyTiltingBehavior  { get; private set; }
        
        [field: SerializeField] public ColliderControl      ColliderControl { get; private set; }
        [field: SerializeField] public EnemyRenderControl   RenderControl   { get; private set; }
        
        private DataManager     dataManager;
        private ParticleManager particleManager;
        private AudioManager    audioManager;
        
        public void Initialized()
        {
            dataManager     = ApplicationManager.Instance.Get<DataManager>();
            particleManager = ApplicationManager.Instance.Get<ParticleManager>();
            audioManager    = ApplicationManager.Instance.Get<AudioManager>();
            
            MoveBehavior
                .SetTargetRigidbody(ColliderControl.Rigidbody);

            MoveInCircleBehavior
                .SetTarget(transform);
            
            BodyTiltingBehavior.Initialized();
            BodyTiltingBehavior.StartTilting();
            
            RenderControl.Initialized();
        }
        
        public void SetPool(IObjectPool<Enemy> _pool)
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
            DestroyEntity();
        }

        public void DestroyEntity()
        {
            dataManager.IncreaseScore(10);
            
            // var _particle = particleManager.PoolSystem.Pool.Get().OnEnemyDestroyedParticle;
            // _particle.transform.position = transform.position;
            // _particle.Play();
            
            particleManager.PlayParticle(ParticleType.EXPLODE, transform.position);
            audioManager   .PlaySound(SoundType.Explode);
            
            ReturnToPool();
        }
    }
}
