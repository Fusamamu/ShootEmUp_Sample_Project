using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Color_Em_Up
{
    public class DataManager : AppManager
    {
        [field: SerializeField] public int HighScore    { get; private set; }
        [field: SerializeField] public int CurrentScore { get; private set; }

        public int[] TopHighScore = new int[3];

        [SerializeField] private UIManager UIManager;
        [SerializeField] private TopLeftUI TopLeftUI;
        
        public override void Initialized()
        {
            base.Initialized();

            for (var _i = 0; _i < TopHighScore.Length; _i++)
                TopHighScore[_i] = 0;

            if (PlayerPrefs.HasKey("Saved"))
            {
                TopHighScore[0] = PlayerPrefs.GetInt("FirstPlace");
                TopHighScore[1] = PlayerPrefs.GetInt("SecondPlace");
                TopHighScore[2] = PlayerPrefs.GetInt("ThirdPlace");
            }
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

        public DataManager UpdateHighScore()
        {
            var _scores = new List<int> { CurrentScore };

            foreach (var _score in TopHighScore)
                _scores.Add(_score);

            _scores = _scores.OrderByDescending(_i => _i).ToList();

            for (var _i = 0; _i < TopHighScore.Length; _i++)
                TopHighScore[_i] = _scores[_i];

            return this;
        }

        public DataManager SaveData()
        {
            PlayerPrefs.SetInt("Saved", 1);
            
            PlayerPrefs.SetInt("CurrentScore", CurrentScore);
            
            PlayerPrefs.SetInt("FirstPlace" , TopHighScore[0]);
            PlayerPrefs.SetInt("SecondPlace", TopHighScore[1]);
            PlayerPrefs.SetInt("ThirdPlace" , TopHighScore[2]);
            
            return this;
        }
    }
}
