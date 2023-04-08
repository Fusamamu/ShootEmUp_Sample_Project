using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public class PoolSystem<T> : MonoBehaviour where T : Component, IEntity
    {
        public IObjectPool<T> Pool { get; private set; }

        [SerializeField] protected int PoolSize = 100;
        [SerializeField] protected T Prefab;
        
        public virtual void Initialized()
        {
            Pool = new ObjectPool<T>(CreateObject, OnGetObject, OnRelease, OnObjectDestroyed, maxSize: PoolSize);
        }
        
        protected virtual T CreateObject()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnGetObject(T _placement)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnRelease(T _placement)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnObjectDestroyed(T _placement)
        {
            throw new NotImplementedException();
        }
        
        public virtual void ClearPool()
        {
            throw new NotImplementedException();
        }
    }
}
