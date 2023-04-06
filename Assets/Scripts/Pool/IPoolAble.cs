using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Color_Em_Up
{
    public interface IPoolAble<T> where T : Component
    {
        public IObjectPool<T> Pool { get; }

        public void SetPool(IObjectPool<T> _pool);
        public void ReturnToPool();
    }
}
