using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    [RequireComponent(typeof(EnemyPool))]
    public class EnemyManager : AppManager, IEntityManager<EnemyPool, Enemy>
    {
        [field: SerializeField] public EnemyPool PoolSystem { get; private set; }

        public override void Initialized()
        {
            base.Initialized();

            if (!PoolSystem)
            {
                Debug.LogWarning($"Missing EnemyPool!");
                return;
            }
            
            PoolSystem.Initialized();
        }
        
        public IEnumerator SpawnEnemyIntervalAtPosition(EnemyData _enemyData, Vector3 _targetPos)
        {
            var _enemyType      = _enemyData.Type;
            var _count          = _enemyData.EnemyCount;
            var _secondInterval = _enemyData.SpawnInterval;
            
            while (_count >= 0)
            {
                yield return new WaitForSeconds(_secondInterval);
                
                var _enemy = SpawnEnemyAtPosition(_targetPos);
                
                _enemy.RenderControl
                    .SetColorType(_enemyType);

                switch (_enemyType)
                {
                    case EnemyType.A:
                        
                        _enemy.MoveInWaveBehavior
                            .Reset();
                            
                        _enemy.MoveBehavior
                            .SetMoveSpeed(150)
                            .SetForceMode(ForceMode.Force)
                            .MoveBackward();
                            
                        break;
                    case EnemyType.B:
                        _enemy.MoveInWaveBehavior
                            .Reset()
                            .SetMoveDirection(false, true)
                            .SetForwardSpeed(5f)
                            .SetSineSpeed(5f)
                            .StartMoveInSineWave();
                        break;
                    case EnemyType.C:
                        _enemy.MoveInWaveBehavior
                            .Reset()
                            .SetMoveDirection(true, true)
                            .SetForwardSpeed(5f)
                            .SetSineSpeed(5f)
                            .StartMoveInSineWave();
                        break;
                }
                
                _count--;
            }
        }
      
        public Enemy SpawnEnemyAtPosition(Vector3 _targetPos)
        {
            var _newEnemy = PoolSystem.Pool.Get();
            
            _newEnemy.transform.position = _targetPos;

            return _newEnemy;
        }
    }
}
