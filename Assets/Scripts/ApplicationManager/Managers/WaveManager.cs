using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Color_Em_Up
{
    public class WaveManager : AppManager
    {
        [SerializeField] public int CurrentWaveIndex { get; private set; }

        [SerializeField] private int WaveCount;
        [SerializeField] private float WaveTimer;
        [SerializeField] private float WaveCountDownSpeed;

        [SerializeField] private SpawnPoint SpawnPoint;

        private EnemyManager    enemyManager;
        private AsteroidManager asteroidManager;
        private UIManager       uiManager;

        private Dictionary<int, bool> waveProgressTable = new Dictionary<int, bool>();

        private IDisposable startWaveTimer;
        
        public override void Initialized()
        {
            base.Initialized();

            enemyManager    = ApplicationManager.Instance.Get<EnemyManager>();
            asteroidManager = ApplicationManager.Instance.Get<AsteroidManager>();

            for (var _i = 0; _i < WaveCount - 1; _i++)
                waveProgressTable.Add(_i, false);
        }

        public IEnumerator StartWave(WaveData _waveData)
        {
            StartWaveTimer(_waveData.TimeLength);
            
            var _currentEnemyGroupIndex = 0;
            
            while (_currentEnemyGroupIndex < _waveData.EnemyGroupCount)
            {
                var _enemyData = _waveData.EnemyData[_currentEnemyGroupIndex];

                yield return enemyManager.SpawnEnemyIntervalAtPosition(
                    _enemyData.EnemyCount, 
                    _enemyData.SpawnInterval, 
                    SpawnPoint.GetRandomPoint()
                    );

                _currentEnemyGroupIndex++;
            }
        }

        private void StartWaveTimer(float _timeLength)
        {
            WaveTimer = _timeLength;
            
            startWaveTimer = Observable.EveryUpdate().Subscribe(_ =>
            {
                WaveTimer -= Time.deltaTime * WaveCountDownSpeed;

                if (WaveTimer <= 0)
                {
                    startWaveTimer?.Dispose();
                }

            }).AddTo(this);
        }
        
        // public async UniTaskVoid StartWave(int _waveIndex)
        // {
        //     while (!waveProgressTable[CurrentWaveIndex] && CurrentWaveIndex < WaveCount)
        //     {
        //         await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken: cancellationToken);
        //         
        //         asteroidManager
        //             .SpawnAsteroidAtPosition(SpawnPoint.GetRandomPoint())
        //             .MoveBehavior
        //                 .SetMoveSpeed(150)
        //                 .SetForceMode(ForceMode.Force)
        //                 .MoveBackward();
        //     }
        //     
        //     await UniTask.WaitUntil(() => completeWave, cancellationToken: cancellationToken);
        // }

        // public IEnumerator StartWave()
        // {
        //     var _originTimer = WaveTimer;
        //     
        //     while (!waveProgressTable[CurrentWaveIndex])
        //     {
        //         WaveTimer -= Time.deltaTime * WaveCountDownSpeed;
        //         if (WaveTimer <= 0)
        //         {
        //             waveProgressTable[CurrentWaveIndex] = true;
        //             
        //             CurrentWaveIndex++;
        //             
        //             if(CurrentWaveIndex >= WaveCount)
        //                 yield break;
        //             
        //             WaveTimer = _originTimer;
        //             startWaveTimer?.Dispose();
        //         }
        //
        //         yield return StartCoroutine(Spawn());
        //     }
        // }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(2);
            
            asteroidManager
                .SpawnAsteroidAtPosition(SpawnPoint.GetRandomPoint())
                .MoveBehavior
                .SetMoveSpeed(150)
                .SetForceMode(ForceMode.Force)
                .MoveBackward();
        }
    }
}
