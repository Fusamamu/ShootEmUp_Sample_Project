using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Color_Em_Up
{
    public class MovementControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody TargetRigidbody;
        
        [SerializeField] private float MovementSpeed;
        
        public MovementControl SetTargetRigidbody(Rigidbody _rigidbody)
        {
            TargetRigidbody = _rigidbody;
            return this;
        }

        public MovementControl SetMoveSpeed(float _speed)
        {
            MovementSpeed = _speed;
            return this;
        }

        public MovementControl BindInput(PlayerInput _input)
        {
            _input.Movement.MoveForward .performed += MoveForward;
            _input.Movement.MoveBackward.performed += MoveBackward;
            _input.Movement.MoveLeft    .performed += MoveLeft;
            _input.Movement.MoveRight   .performed += MoveRight;
            
            return this;
        }

        public MovementControl UnbindInput(PlayerInput _input)
        {
            _input.Movement.MoveForward .performed -= MoveForward;
            _input.Movement.MoveBackward.performed -= MoveBackward;
            _input.Movement.MoveLeft    .performed -= MoveLeft;
            _input.Movement.MoveRight   .performed -= MoveRight;
            
            return this;
        }
        
        private void MoveForward(InputAction.CallbackContext _callbackContext)
        {
            TargetRigidbody.AddForce(Vector3.forward * MovementSpeed, ForceMode.Impulse);
        }
        
        private void MoveBackward(InputAction.CallbackContext _callbackContext)
        {
            TargetRigidbody.AddForce(Vector3.back * MovementSpeed, ForceMode.Impulse);
        }
        
        private void MoveLeft(InputAction.CallbackContext _callbackContext)
        {
            TargetRigidbody.AddForce(Vector3.left * MovementSpeed, ForceMode.Impulse);
        }
        
        private void MoveRight(InputAction.CallbackContext _callbackContext)
        {
            TargetRigidbody.AddForce(Vector3.right * MovementSpeed, ForceMode.Impulse);
        }
    }
}
