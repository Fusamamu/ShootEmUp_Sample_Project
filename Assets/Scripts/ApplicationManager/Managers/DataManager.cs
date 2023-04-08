using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class DataManager : AppManager
    {
        [field: SerializeField] public int HighScore    { get; private set; }
        [field: SerializeField] public int CurrentScore { get; private set; }

        private UIManager uiManager;
        private TopLeftUI topLeftUI;
        
        public override void Initialized()
        {
            base.Initialized();

            uiManager = ApplicationManager.Instance.Get<UIManager>();
            topLeftUI = uiManager.GetUI<TopLeftUI>();
        }

        public DataManager SetCurrentScore(int _score)
        {
            CurrentScore = _score;
            topLeftUI.ScoreUI.SetScore(_score);
            return this;
        }
    }
}
