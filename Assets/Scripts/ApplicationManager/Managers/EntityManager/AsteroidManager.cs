using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class AsteroidManager : AppManager, IEntityManager<AsteroidPool, Asteroid>
    {
        [field: SerializeField] public AsteroidPool PoolSystem { get; private set; }

        [SerializeField] private SpawnPoint SpawnPoint;
        
        private bool spawnAsteroid;

        private Coroutine spawnAsteroidCoroutine;

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

        public void StartSpawn()
        {
            spawnAsteroid = true;
            spawnAsteroidCoroutine = StartCoroutine(SpawnAsteroidIntervalAtPosition(2f));
        }

        public void StopSpawn()
        {
            spawnAsteroid = false;
            StopCoroutine(spawnAsteroidCoroutine);
            spawnAsteroidCoroutine = null;
        }
        
        public IEnumerator SpawnAsteroidIntervalAtPosition(float _secondInterval)
        {
            while (spawnAsteroid)
            {
                yield return new WaitForSeconds(_secondInterval);
                
                var _enemy = SpawnAsteroidAtPosition(SpawnPoint.GetRandomPoint());
                
                _enemy.MoveBehavior
                    .SetMoveSpeed(150)
                    .SetForceMode(ForceMode.Force)
                    .MoveBackward();
            }
        }
        
        public Asteroid SpawnAsteroidAtPosition(Vector3 _targetPos)
        {
            var _newAsteroid = PoolSystem.Pool.Get();
            _newAsteroid.transform.position = _targetPos;

            return _newAsteroid;
        }
    }
}
