using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class Asteroid : MonoBehaviour, IPoolAble<Asteroid>
    {
        public IObjectPool<Asteroid> Pool { get; private set; }
        
        [field: SerializeField] public MoveBehavior MoveBehavior { get; private set; }
        
        [field: SerializeField] public ColliderControl ColliderControl { get; private set; }
        [field: SerializeField] public RenderControl   RenderControl   { get; private set; }

        public void Initialized()
        {
            MoveBehavior
                .SetTargetRigidbody(ColliderControl.Rigidbody);
        }
        
        public void SetPool(IObjectPool<Asteroid> _pool)
        {
            Pool = _pool;
        }
        
        public void ReturnToPool()
        {
            Pool?.Release(this);
        }
    }
}
