using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

namespace Color_Em_Up
{
    public class LevelManager : AppManager
    {
        [field: SerializeField] public int CurrentLevelIndex { get; private set; }

        public List<LevelData> LevelData = new List<LevelData>();

        private Dictionary<int, LevelData> levelTable = new Dictionary<int, LevelData>();

        private PlayerManager   playerManager;
        private EnemyManager    enemyManager;
        private WaveManager     waveManager;
        private ParticleManager particleManager;
        private BulletManager   bulletManager;
        private AsteroidManager asteroidManager;
        
        private UIManager   uiManager;
        private TopHeaderUI topHeaderUI;

        private StateMachine gameStateMachine = new StateMachine();

        private string levelRun      = "LevelChange";
        private string levelChange   = "LevelChange";
        private string gameOverState = "GameOver";

        private Coroutine levelUpdateProcess;
        
        public override void Initialized()
        {
            base.Initialized();

            playerManager   = ApplicationManager.Instance.Get<PlayerManager>();
            enemyManager    = ApplicationManager.Instance.Get<EnemyManager>();
            waveManager     = ApplicationManager.Instance.Get<WaveManager>();
            
            particleManager = ApplicationManager.Instance.Get<ParticleManager>();
            bulletManager   = ApplicationManager.Instance.Get<BulletManager>();
            asteroidManager = ApplicationManager.Instance.Get<AsteroidManager>();
            
            uiManager       = ApplicationManager.Instance.Get<UIManager>();

            topHeaderUI = uiManager.GetUI<TopHeaderUI>();

            for (var _i = 0; _i < LevelData.Count; _i++)
            {
                var _levelData = LevelData[_i];
                _levelData.LevelIndex = _i;
                levelTable.Add(_i, _levelData);
            }

            gameStateMachine.AddState(levelRun, 
                new State(onEnter: _state =>
                {

                }, onLogic: _state =>
                {
                    
                },onExit: _state =>
                {
                  
                }));
            
            gameStateMachine.AddState(levelChange, 
                new State(onEnter: _state =>
                {

                }, onLogic: _state =>
                {
                    
                },onExit: _state =>
                {
                  
                }));
            
            
            gameStateMachine.AddState(gameOverState, 
                new State(onEnter: _state =>
                {

                }, onLogic: _state =>
                {
                    
                },onExit: _state =>
                {
                  
                }));

            playerManager.OnGameOverEvent += _player =>
            {
                StopUpdateLevel();
            };
        }

        public LevelManager SetLeveIndex(int _index)
        {
            CurrentLevelIndex = _index;
            return this;
        }

        public void RunLevel()
        {
            playerManager.SpawnPlayer();
            
            levelUpdateProcess = StartCoroutine(UpdateLevel());
        }

        private IEnumerator UpdateLevel()
        {
            while (CurrentLevelIndex < LevelData.Count)
            {
                topHeaderUI
                    .SetLevelUI(CurrentLevelIndex + 1)
                    .WaveProgressBarUI
                    .ResetAllProgressBars();
                
                yield return SetLeveIndex(CurrentLevelIndex).StartLevel();
                   
                CurrentLevelIndex++;
            }
        }

        public IEnumerator StartLevel()
        {
            if (!levelTable.TryGetValue(CurrentLevelIndex, out var _levelData))
                yield break;
            
            var _currentWaveIndex = 0;

            while (_currentWaveIndex < _levelData.WaveCount)
            {
                var _currentWave = _levelData.WaveData[_currentWaveIndex];
                
                yield return waveManager
                    .SetWaveIndex  (_currentWaveIndex)
                    .StartWaveTimer(_currentWave)
                    .StartWave     (_currentWave);
                
                _currentWaveIndex++;
            }
        }

        public void StopUpdateLevel()
        {
            StopCoroutine(levelUpdateProcess);
            levelUpdateProcess = null;
        }

        public void RestartLevel()
        {
            enemyManager   .PoolSystem.ClearPool();
            bulletManager  .PoolSystem.ClearPool();
            particleManager.PoolSystem.ClearPool();
            asteroidManager.PoolSystem.ClearPool();
            
            waveManager  .Reset();
            playerManager.Reset();
            
            CurrentLevelIndex = 0;
            RunLevel();
        }
    }
}
