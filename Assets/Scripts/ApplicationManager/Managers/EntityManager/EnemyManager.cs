using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    [RequireComponent(typeof(EnemyPool))]
    public class EnemyManager : AppManager
    {
        [SerializeField] private EnemyPool EnemyPool;

        public override void Initialized()
        {
            base.Initialized();

            if (!EnemyPool)
            {
                Debug.LogWarning($"Missing EnemyPool!");
                return;
            }
            
            EnemyPool.Initialized();
        }
        
        //Can pass enemy data
        public IEnumerator SpawnEnemyIntervalAtPosition(int _count, float _secondInterval, Vector3 _targetPos)
        {
            while (_count >= 0)
            {
                yield return new WaitForSeconds(_secondInterval);
                
                var _enemy = SpawnEnemyAtPosition(_targetPos);
                
                _enemy.MoveBehavior
                    .SetMoveSpeed(150)
                    .SetForceMode(ForceMode.Force)
                    .MoveBackward();
                
                _count--;
            }
        }
      
        public Enemy SpawnEnemyAtPosition(Vector3 _targetPos)
        {
            var _newEnemy = EnemyPool.Pool.Get();
            
            _newEnemy.transform.position = _targetPos;

            return _newEnemy;
        }
    }
}
