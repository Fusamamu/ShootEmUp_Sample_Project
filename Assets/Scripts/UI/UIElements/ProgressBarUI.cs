using System;
using System.Collections;
using System.Collections.Generic;
using MPUIKIT;
using UnityEngine;

namespace Color_Em_Up
{
    public class ProgressBarUI : MonoBehaviour
    {
        [SerializeField] private MPImage Progress;
        [SerializeField] private MPImage BarFrame;

        private void Start()
        {
            
        }

        public void SetProgressPercent(float _percent)
        {
            Progress.fillAmount = _percent;
        }
    }
}
