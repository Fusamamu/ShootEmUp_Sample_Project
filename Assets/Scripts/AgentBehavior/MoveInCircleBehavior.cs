using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Color_Em_Up
{
    public class MoveInCircleBehavior : MonoBehaviour
    {
        private Transform target;
        
        [field: SerializeField] public Vector3 Center      { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float Radius        { get; private set; }
        [field: SerializeField] public float HeightOffset  { get; private set; }
        
        private Vector3 positionOffset;
        private float angle;

        private IDisposable moveInCircleProcess;
        
        public MoveInCircleBehavior SetTarget(Transform _target)
        {
            target = _target;
            return this;
        }
        
        public MoveInCircleBehavior SetCenter(Vector3 _center)
        {
            Center = _center;
            return this;
        }
        
        public MoveInCircleBehavior SetRotationSpeed(float _speed)
        {
            RotationSpeed = _speed;
            return this;
        }
        
        public MoveInCircleBehavior SetRadius(float _radius)
        {
            Radius = _radius;
            return this;
        }
        
        public MoveInCircleBehavior SetHeightOffset(float _height)
        {
            HeightOffset = _height;
            return this;
        }

        public MoveInCircleBehavior UseDefaultValue()
        {
            Center        = Vector3.zero;
            RotationSpeed = 1f;
            Radius        = 2f;
            HeightOffset  = 0f;
            return this;
        }
        
        public void StartMoveInCircle()
        {
            StopMoveInCircle();
            
            moveInCircleProcess = Observable.EveryLateUpdate().Subscribe(_ =>
            {
                positionOffset.Set
                (
                    Mathf.Cos( angle ) * Radius,
                    HeightOffset,
                    Mathf.Sin( angle ) * Radius
                );
            
                target.position = Center + positionOffset;
            
                angle += Time.deltaTime * RotationSpeed;

            }).AddTo(this);
        }

        public void StopMoveInCircle()
        {
            if (moveInCircleProcess != null)
            {
                moveInCircleProcess.Dispose();
                moveInCircleProcess = null;
            }
        }
    }
}
