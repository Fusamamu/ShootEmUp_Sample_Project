using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Color_Em_Up
{
    public class MoveInWaveBehavior : MonoBehaviour
    {
        private Transform target;

        [field: SerializeField] public Vector3 OriginPosition { get; private set; }
        [field: SerializeField] public float   SineSpeed      { get; private set; }
        [field: SerializeField] public float   HeightOffset   { get; private set; }

        private IDisposable moveProcess;
        
        public MoveInWaveBehavior SetTarget(Transform _target)
        {
            target         = _target;
            OriginPosition = _target.transform.position;
            return this;
        }

        public MoveInWaveBehavior SetSineSpeed(float _speed)
        {
            SineSpeed = _speed;
            return this;
        }
        
        public MoveInWaveBehavior SetHeightOffset(float _height)
        {
            HeightOffset = _height;
            return this;
        }

        public void StartMoveInSineWave()
        {
            StopMove();
            
            moveProcess = Observable.EveryLateUpdate().Subscribe(_ =>
            {
                transform.position = OriginPosition + new Vector3(Mathf.Sin(Time.time * SineSpeed), HeightOffset, 0.0f);

            }).AddTo(this);
        }

        public void StopMove()
        {
            if (moveProcess != null)
            {
                moveProcess.Dispose();
                moveProcess = null;
            }
        }
    }
}
