using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Color_Em_Up
{
    public class WaveProgressBarUI : MonoBehaviour
    {
        [field: SerializeField] public int CurrentProgressBarIndex { get; private set; }
        
        [SerializeField] private TextMeshProUGUI WaveText;
        
        public List<ProgressBarUI> AllProgressBarUi = new List<ProgressBarUI>();

        public bool TryGetProgressBar(int _index, out ProgressBarUI _progressBarUI)
        {
            if (AllProgressBarUi[_index] != null)
            {
                _progressBarUI = AllProgressBarUi[_index];
                return true;
            }

            _progressBarUI = null;
            return false;
        }

        public void ResetAllProgressBars()
        {
            foreach (var _bar in AllProgressBarUi)
            {
                _bar.ResetBar();
            }
        }
    }
}
