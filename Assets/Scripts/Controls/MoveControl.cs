using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Color_Em_Up
{
    public class MoveControl : MonoBehaviour
    {
        [SerializeField] private float Duration = 1f;

        private Tween moveProcess;

        public MoveControl SetDuration(float _value)
        {
            Duration = _value;
            return this;
        }
        
        public void MoveTo(Vector3 _targetPos)
        {
            StopMove();
            
            moveProcess = transform
                .DOMove(_targetPos, Duration)
                .SetEase(Ease.InOutExpo);
        }

        public void MoveLocalTo(Vector3 _targetPos)
        {
            StopMove();

            moveProcess = transform
                .DOLocalMove(_targetPos, Duration)
                .SetEase(Ease.Linear);
        }

        private void StopMove()
        {
            if (moveProcess != null)
            {
                moveProcess.Kill();
                moveProcess = null;
            }
        }
    }
}
