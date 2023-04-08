using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Color_Em_Up
{
    public class WaveManager : AppManager
    {
        [field: SerializeField] public int CurrentWaveIndex { get; private set; }

        [SerializeField] private int WaveCount;
        [SerializeField] private float WaveTimer;
        [SerializeField] private float WaveCountDownSpeed;

        [SerializeField] private SpawnPoint SpawnPoint;

        private EnemyManager    enemyManager;
        private AsteroidManager asteroidManager;
        
        private UIManager       uiManager;
        
        private LevelDetailUI     levelDetailUI;
        private WaveProgressBarUI waveProgressBarUI;

        private Dictionary<int, bool> waveProgressTable = new Dictionary<int, bool>();

        private IDisposable startWaveTimer;
        
        public override void Initialized()
        {
            base.Initialized();

            uiManager       = ApplicationManager.Instance.Get<UIManager>();
            enemyManager    = ApplicationManager.Instance.Get<EnemyManager>();
            asteroidManager = ApplicationManager.Instance.Get<AsteroidManager>();

            levelDetailUI     = uiManager.GetUI<LevelDetailUI>();
            waveProgressBarUI = uiManager.GetUI<TopHeaderUI>().WaveProgressBarUI;

            for (var _i = 0; _i < WaveCount - 1; _i++)
                waveProgressTable.Add(_i, false);
        }

        public WaveManager SetWaveIndex(int _index)
        {
            CurrentWaveIndex = _index;
            return this;
        }

        public WaveManager StartWaveTimer(WaveData _waveData)
        {
            WaveTimer = _waveData.TimeLength;
            
            if (!waveProgressBarUI.TryGetProgressBar(CurrentWaveIndex, out var _progressBarUI))
            {
                return this;
            }
            
            _progressBarUI.ResetBar();

            startWaveTimer = Observable.EveryUpdate().Subscribe(_ =>
            {
                WaveTimer -= Time.deltaTime * WaveCountDownSpeed;

                var _percent = 1 - WaveTimer / _waveData.TimeLength;
                
                _progressBarUI.SetProgressPercent(_percent);

                if (WaveTimer <= 0)
                {
                    StopWaveTime();
                }

            }).AddTo(this);

            return this;
        }
        
        public IEnumerator StartWave(WaveData _waveData)
        {
            var _currentEnemyGroupIndex = 0;
            
            while (_currentEnemyGroupIndex < _waveData.EnemyGroupCount)
            {
                var _enemyData = _waveData.EnemyData[_currentEnemyGroupIndex];

                yield return enemyManager.SpawnEnemyIntervalAtPosition(
                    _enemyData.EnemyCount, 
                    _enemyData.SpawnInterval, 
                    SpawnPoint.GetRandomPoint()
                    );

                yield return new WaitUntil(() => WaveTimer <= 0);

                yield return levelDetailUI
                    .SetDetail("Starting Next Wave")
                    .ShowDetailFor(2.5f);

                _currentEnemyGroupIndex++;
            }
        }

        private void StopWaveTime()
        {
            startWaveTimer?.Dispose();
            startWaveTimer = null;
        }
        
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
