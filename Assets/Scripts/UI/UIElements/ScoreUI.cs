using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Color_Em_Up
{
    public class ScoreUI : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }

        public ScoreUI SetScore(int _value)
        {
            ScoreText.SetText(_value.ToString());
            return this;
        }
    }
}
