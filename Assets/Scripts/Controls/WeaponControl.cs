using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Color_Em_Up
{
    public class WeaponControl : MonoBehaviour
    {
        [SerializeField] private Transform CannonTarget;
        [SerializeField] private Transform BulletSpawnOrigin;

        [SerializeField] private Vector3 CurrentRotation = Vector3.zero;
        
        [field: SerializeField] public float StepDegree { get; private set; }
        [field: SerializeField] public float Duration   { get; private set; }

        private Tween rotateTween;

        private BulletManager bulletManager;

        public ParticleSystem ShootingParticle;

        public void Initialize()
        {
            bulletManager = ApplicationManager.Instance.Get<BulletManager>();
        }

        public WeaponControl BindInput(PlayerInput _input)
        {
            _input.Aim.RotateLeft .performed += RotateLeft;
            _input.Aim.RotateRight.performed += RotateRight;
            _input.Attack.Shoot   .performed += Shoot;
            return this;
        }
        
        public WeaponControl UnbindInput(PlayerInput _input)
        {
            _input.Aim.RotateLeft .performed -= RotateLeft;
            _input.Aim.RotateRight.performed -= RotateRight;
            _input.Attack.Shoot   .performed -= Shoot;
            return this;
        }

        public void RotateLeft(InputAction.CallbackContext _callbackContext)
        {
            StopRotate();
            CurrentRotation -= new Vector3(0, StepDegree, 0);

            if (CurrentRotation.y <= -360f)
                CurrentRotation = Vector3.zero;
            
            rotateTween = CannonTarget.DORotate(CurrentRotation, Duration, RotateMode.Fast);
        }

        public void RotateRight(InputAction.CallbackContext _callbackContext)
        {
            StopRotate();
            CurrentRotation += new Vector3(0, StepDegree, 0);
            
            if (CurrentRotation.y >= 360f)
                CurrentRotation = Vector3.zero;
            
            rotateTween = CannonTarget.DORotate(CurrentRotation, Duration, RotateMode.Fast);
        }

        private void StopRotate()
        {
            rotateTween?.Kill();
            rotateTween = null;
        }

        public void Shoot(InputAction.CallbackContext _callbackContext)
        {
            var _bullet = bulletManager.BulletPool.Pool.Get();

            if (_bullet)
            {
                var _direction = Quaternion.Euler(CurrentRotation) * Vector3.forward;
                
                _bullet.transform.position = BulletSpawnOrigin.position;
                _bullet
                    .SetDirection(_direction)
                    .SetVelocity(20)
                    .Shoot();
            }

            if (ShootingParticle)
            {
                ShootingParticle.transform.position = BulletSpawnOrigin.position;

                if (ShootingParticle.isPlaying)
                    ShootingParticle.Stop();
                    
                ShootingParticle.Play();
            }
        }
    }
}
