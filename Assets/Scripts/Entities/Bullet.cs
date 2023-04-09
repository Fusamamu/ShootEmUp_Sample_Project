using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class Bullet : MonoBehaviour, IEntity, IPoolAble<Bullet>
    {
        public IObjectPool<Bullet> Pool { get; private set; }
        
        public bool IsInPool { get; set; }
        
        [SerializeField] private float Damage;
        [SerializeField] private float Velocity;
        [SerializeField] private Vector3 Direction;
        
        [SerializeField] private double SelfDestroyTimer = 5;
        
        [field: SerializeField] public ColliderControl ColliderControl { get; private set; }
        [field: SerializeField] public RenderControl   RenderControl   { get; private set; }

        public void Initialized()
        {
         
        }
        
        public void SetPool(IObjectPool<Bullet> _pool)
        {
            Pool = _pool;
        }
        
        public void ReturnToPool()
        {
            if(!IsInPool)
                Pool?.Release(this);
        }

        public Bullet SetDirection(Vector3 _direction)
        {
            Direction = _direction.normalized;
            return this;
        }

        public Bullet SetVelocity(float _velocity)
        {
            Velocity = _velocity;
            return this;
        }

        public void Shoot()
        {
            ColliderControl.Rigidbody.AddForce(Direction * Velocity, ForceMode.Impulse);
        }

        public void OnCollisionEnter(Collision _other)
        {
            if (_other.gameObject.TryGetComponent<ITarget>(out var _target))
                _target.OnHitHandler(this);
           
            DestroyEntity();
        }
        
        public void DestroyEntity()
        {
            ReturnToPool();
        }
    }
}
