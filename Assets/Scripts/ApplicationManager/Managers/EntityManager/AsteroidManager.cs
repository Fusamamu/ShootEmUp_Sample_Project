using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class AsteroidManager : AppManager
    {
        [SerializeField] private AsteroidPool AsteroidPool;

        public override void Initialized()
        {
            base.Initialized();

            if (!AsteroidPool)
            {
                Debug.LogWarning($"Missing AsteroidPool!");
                return;
            }
            
            AsteroidPool.Initialized();
        }
        
        public Asteroid SpawnAsteroidAtPosition(Vector3 _targetPos)
        {
            var _newAsteroid = AsteroidPool.Pool.Get();
            _newAsteroid.transform.position = _targetPos;

            return _newAsteroid;
        }
    }
}
