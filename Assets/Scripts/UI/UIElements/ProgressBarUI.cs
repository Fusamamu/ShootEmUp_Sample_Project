using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MPUIKIT;
using UnityEngine;

namespace Color_Em_Up
{
    public class ProgressBarUI : MonoBehaviour
    {
        [SerializeField] private MPImage Progress;
        [SerializeField] private MPImage BarFrame;

        [SerializeField] private MMF_Player OnProgressBarCompleteAnimation;

        public void Initialized()
        {
            
        }

        public void SetProgressPercent(float _value)
        {
            Progress.fillAmount = _value;

            if (Progress.fillAmount >= 1.0f)
            {
                if(OnProgressBarCompleteAnimation)
                    OnProgressBarCompleteAnimation.PlayFeedbacks();
            }
        }

        public void ResetBar()
        {
            Progress.fillAmount = 0;
        }
    }
}
