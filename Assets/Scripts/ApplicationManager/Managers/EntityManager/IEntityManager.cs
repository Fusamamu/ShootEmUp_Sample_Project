using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public interface IEntityManager<T, TU> where T : PoolSystem<TU> where TU : Component, IEntity
    {
        public T PoolSystem { get; }
    }
}
