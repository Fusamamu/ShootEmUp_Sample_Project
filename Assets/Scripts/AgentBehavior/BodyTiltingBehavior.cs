using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Color_Em_Up
{
    public class BodyTiltingBehavior : MonoBehaviour
    {
        [Header("Pitch")]
        [SerializeField] private float PitchForce    = 10.0f;  
        [SerializeField] private float PitchMinAngle = -25.0f;  
        [SerializeField] private float PitchMaxAngle = 25.0f;  

        [Header("Roll")]
        [SerializeField] private float RollForce    = 10.0f;  
        [SerializeField] private float RollMinAngle = -25.0f;  
        [SerializeField] private float RollMaxAngle = 25.0f;  
        
        [SerializeField] private float RestTime = 1.0f;  

        private float pitchAngle, pitchVelocity;
        private float rollAngle , rollVelocity;

        private Vector3 oldPosition;
        private Vector3 originalAngles;

        private IDisposable tilting;

        public void Initialized()
        {
            var _transform = transform;
            
            oldPosition    = _transform.position;
            originalAngles = _transform.rotation.eulerAngles;
        }

        public void StartTilting()
        {
            StopTilting();
            
            tilting = Observable.EveryUpdate().Subscribe(_ =>
            {
                Vector3 _currentPos = transform.position;
                Vector3 _offset = _currentPos - oldPosition;

                if (_offset.sqrMagnitude > Mathf.Epsilon)
                {
                    pitchAngle = Mathf.Clamp(pitchAngle + _offset.z * PitchForce, PitchMinAngle, PitchMaxAngle);
                    rollAngle = Mathf.Clamp(rollAngle + _offset.x * RollForce, RollMinAngle, RollMaxAngle);
                }

                pitchAngle = Mathf.SmoothDamp(pitchAngle, 0.0f, ref pitchVelocity, RestTime * Time.deltaTime * 10.0f);
                rollAngle = Mathf.SmoothDamp(rollAngle, 0.0f, ref rollVelocity, RestTime * Time.deltaTime * 10.0f);

                transform.rotation = Quaternion.Euler(originalAngles.x + pitchAngle,
                    originalAngles.y,
                    originalAngles.z - rollAngle);

                oldPosition = _currentPos;
            }).AddTo(this);
        }

        public void StopTilting()
        {
            if (tilting != null)
            {
                tilting.Dispose();
                tilting = null;
            }
        }
    }
}
