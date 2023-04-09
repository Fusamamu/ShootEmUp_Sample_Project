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
        [field: SerializeField] public float   ForwardSpeed   { get; private set; }
        [field: SerializeField] public float   SineSpeed      { get; private set; }
        [field: SerializeField] public float   HeightOffset   { get; private set; }
        
        [field: SerializeField] public bool    MoveVertical   { get; private set; }
        [field: SerializeField] public bool    MoveLateral    { get; private set; }

        private IDisposable moveProcess;

        public MoveInWaveBehavior Reset()
        {
            MoveVertical = false;
            MoveLateral  = false;
            return this;
        }
        
        public MoveInWaveBehavior SetForwardSpeed(float _speed)
        {
            ForwardSpeed = _speed;
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

        public MoveInWaveBehavior SetMoveDirection(bool _vertical, bool _lateral)
        {
            MoveVertical = _vertical;
            MoveLateral  = _lateral;
            return this;
        }

        public void StartMoveInSineWave()
        {
            StopMove();
            
            moveProcess = Observable.EveryLateUpdate().Subscribe(_ =>
            {
                var _zPos = transform.position.z - Time.deltaTime * ForwardSpeed;
                var _sineResult = Mathf.Sin(_zPos) * 3;

                if (MoveVertical && !MoveLateral)
                {
                    transform.position = new Vector3(transform.position.x, _sineResult, _zPos);
                }
                else if (MoveLateral && !MoveVertical)
                {
                    transform.position = new Vector3(_sineResult, HeightOffset, _zPos);
                }
                else if (MoveVertical && MoveLateral)
                {
                    transform.position = new Vector3(_sineResult, _sineResult, _zPos);
                }

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
