using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class Enemy : MonoBehaviour, IPoolAble<Enemy>
    {
        public IObjectPool<Enemy> Pool { get; private set; }
        
        private EnemyManager enemyManager;

        public ShootAbility ShootAbility;
        
        [field: SerializeField] public MoveBehavior         MoveBehavior         { get; private set; }
        [field: SerializeField] public MoveInWaveBehavior   MoveInWaveBehavior   { get; private set; }
        [field: SerializeField] public MoveInCircleBehavior MoveInCircleBehavior { get; private set; }
        
        [field: SerializeField] public ColliderControl ColliderControl { get; private set; }
        [field: SerializeField] public RenderControl   RenderControl   { get; private set; }

        public void Initialized()
        {
            enemyManager = ApplicationManager.Instance.Get<EnemyManager>();
            
            MoveBehavior
                .SetTargetRigidbody(ColliderControl.Rigidbody);

            MoveInWaveBehavior  .SetTarget(transform);
            MoveInCircleBehavior.SetTarget(transform);
        }
        
        public void SetPool(IObjectPool<Enemy> _pool)
        {
            Pool = _pool;
        }
        
        public void ReturnToPool()
        {
            Pool?.Release(this);
        }
    }
}
