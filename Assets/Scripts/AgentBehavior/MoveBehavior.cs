using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class MoveBehavior : MonoBehaviour
    {
        [SerializeField] private Rigidbody TargetRigidbody;
        
        [SerializeField] private float MovementSpeed;
        [SerializeField] private ForceMode ForceMode;
        
        public MoveBehavior SetTargetRigidbody(Rigidbody _rigidbody)
        {
            TargetRigidbody = _rigidbody;
            return this;
        }

        public MoveBehavior SetMoveSpeed(float _speed)
        {
            MovementSpeed = _speed;
            return this;
        }
        
        public MoveBehavior SetForceMode(ForceMode _forceMode)
        {
            ForceMode = _forceMode;
            return this;
        }
        
        public void MoveForward()
        {
            TargetRigidbody.AddForce(Vector3.forward * MovementSpeed, ForceMode);
        }
        
        public void MoveBackward()
        {
            TargetRigidbody.AddForce(Vector3.back * MovementSpeed, ForceMode);
        }
        
        public void MoveLeft()
        {
            TargetRigidbody.AddForce(Vector3.left * MovementSpeed, ForceMode);
        }
        
        public void MoveRight()
        {
            TargetRigidbody.AddForce(Vector3.right * MovementSpeed, ForceMode);
        }
    }
}
