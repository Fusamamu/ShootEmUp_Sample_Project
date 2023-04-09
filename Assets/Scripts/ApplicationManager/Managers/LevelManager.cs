using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class LevelManager : AppManager
    {
        [field: SerializeField] public int CurrentLevelIndex { get; private set; }

        public List<LevelData> LevelData = new List<LevelData>();

        private Dictionary<int, LevelData> levelTable = new Dictionary<int, LevelData>();

        private DataManager     dataManager;
        private AudioManager    audioManager;
        private PlayerManager   playerManager;
        private EnemyManager    enemyManager;
        private WaveManager     waveManager;
        private ParticleManager particleManager;
        private BulletManager   bulletManager;
        private AsteroidManager asteroidManager;
        
        private UIManager   uiManager;
        private TopHeaderUI topHeaderUI;

        private Coroutine levelUpdateProcess;

        [SerializeField] private Material LevelBackgroundMaterial;
        
        public override void Initialized()
        {
            base.Initialized();

            dataManager     = ApplicationManager.Instance.Get<DataManager>();
            audioManager    = ApplicationManager.Instance.Get<AudioManager>();
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
            audioManager.PlaySound(SoundType.BGM);
            
            playerManager  .SpawnPlayer();
            asteroidManager.StartSpawn();
            
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
            
            uiManager.GetUI<GameOverUI>().Open();
        }

        public IEnumerator StartLevel()
        {
            if (!levelTable.TryGetValue(CurrentLevelIndex, out var _levelData))
                yield break;

            yield return ChangeLevelBackgroundColor(_levelData.LevelBackgroundColor);
            
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

        private IEnumerator ChangeLevelBackgroundColor(Color _color)
        {
            float _elapsedTime = 0.0f;
            
            while (_elapsedTime < 1.0f) 
            {
                _elapsedTime += Time.deltaTime;
                LevelBackgroundMaterial.color = Color.Lerp(LevelBackgroundMaterial.color, _color, _elapsedTime / 1.0f);
                yield return null;
            }
        }
        
        public void StopUpdateLevel()
        {
            StopCoroutine(levelUpdateProcess);
            levelUpdateProcess = null;
        }

        public void RestartLevel()
        {
            bulletManager  .PoolSystem.ClearPool();
            particleManager.PoolSystem.ClearPool();
            enemyManager   .PoolSystem.ClearPool();
            asteroidManager.PoolSystem.ClearPool();
            
            foreach (var _reset in ApplicationManager.Instance.GetAllResetManagers())
                _reset.Reset();
            
            dataManager.ResetCurrentScore();
            CurrentLevelIndex = 0;
            
            RunLevel();
        }
    }
}
