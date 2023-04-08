using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class AsteroidManager : AppManager, IEntityManager<AsteroidPool, Asteroid>
    {
        [field: SerializeField] public AsteroidPool PoolSystem { get; private set; }

        public override void Initialized()
        {
            base.Initialized();

            if (!PoolSystem)
            {
                Debug.LogWarning($"Missing AsteroidPool!");
                return;
            }
            
            PoolSystem.Initialized();
        }
        
        public Asteroid SpawnAsteroidAtPosition(Vector3 _targetPos)
        {
            var _newAsteroid = PoolSystem.Pool.Get();
            _newAsteroid.transform.position = _targetPos;

            return _newAsteroid;
        }
    }
}
