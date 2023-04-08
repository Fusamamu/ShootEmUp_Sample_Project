using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class DataManager : AppManager
    {
        [field: SerializeField] public int HighScore    { get; private set; }
        [field: SerializeField] public int CurrentScore { get; private set; }

        [SerializeField] private UIManager UIManager;
        [SerializeField] private TopLeftUI TopLeftUI;
        
        public override void Initialized()
        {
            base.Initialized();
        }

        public DataManager IncreaseScore(int _value)
        {
            CurrentScore += _value;
            TopLeftUI.ScoreUI.SetScore(CurrentScore);
            return this;
        }

        public DataManager SetCurrentScore(int _score)
        {
            CurrentScore = _score;
            TopLeftUI.ScoreUI.SetScore(CurrentScore);
            return this;
        }
    }
}
