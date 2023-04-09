using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Color_Em_Up
{
    public class FinalScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI FinalScoreText;

        [SerializeField] private TextMeshProUGUI ScoreText_1;
        [SerializeField] private TextMeshProUGUI ScoreText_2;
        [SerializeField] private TextMeshProUGUI ScoreText_3;

        private DataManager dataManager;

        public void Initialized()
        {
            dataManager = ApplicationManager.Instance.Get<DataManager>();
        }

        public void UpdateScore()
        {
            dataManager
                .UpdateHighScore()
                .SaveData();
            
            SetFinalScore(dataManager.CurrentScore);

            SetScoreAtPlacement(0, dataManager.TopHighScore[0]);
            SetScoreAtPlacement(1, dataManager.TopHighScore[1]);
            SetScoreAtPlacement(2, dataManager.TopHighScore[2]);
        }

        public void SetFinalScore(int _value)
        {
            FinalScoreText.SetText($"FINAL SCORE | {_value}");
        }
        
        public void SetScoreAtPlacement(int _index, int _value)
        {
            switch (_index)
            {
                case 0:
                    ScoreText_1.SetText($"1 : {_value}");
                    break;
                case 1:
                    ScoreText_2.SetText($"2 : {_value}");
                    break;
                case 2:
                    ScoreText_3.SetText($"3 : {_value}");
                    break;
            }
        }
    }
}
