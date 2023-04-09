using System;
using System.Collections;
using MoreMountains.Feedbacks;
using UniRx;
using UnityEngine;

namespace Color_Em_Up
{
    public class Player : MonoBehaviour, IEntity
    {
        private InputManager inputManager;
        
        [field: SerializeField] public MovementControl MovementControl { get; private set; }
        [field: SerializeField] public WeaponControl   WeaponControl   { get; private set; }
        
        [field: SerializeField] public ColliderControl ColliderControl { get; private set; }
        [field: SerializeField] public RenderControl   RenderControl   { get; private set; }
        
        [field: SerializeField] public BodyTiltingBehavior BodyTiltingBehavior { get; private set; }

        [SerializeField] private MMF_Player OnRespawnAnimation;

        private PlayerManager   playerManager;

        [Header("Cool Down Setting")]
        [SerializeField] private bool IsCoolDown;
        [SerializeField] private float CoolDownTimer = 3;

        private IDisposable startCoolDownTimer;

        public void Initialized()
        {
            inputManager = ApplicationManager.Instance.Get<InputManager>();
            inputManager.PlayerInput.Enable();

            ColliderControl
                .DisableCollider()
                .EnableColliderAfterSecond(3f);

            MovementControl
                .BindInput(inputManager.PlayerInput)
                .SetTargetRigidbody(ColliderControl.Rigidbody);
            
            WeaponControl  
                .BindInput(inputManager.PlayerInput)
                .Initialize();

            BodyTiltingBehavior.Initialized();
            BodyTiltingBehavior.StartTilting();

            playerManager = ApplicationManager.Instance.Get<PlayerManager>();
            
            if(OnRespawnAnimation)
                OnRespawnAnimation.Initialization();
        }
        
        public IEnumerator RespawnCoroutine(Vector3 _targetPos, Action _onRespawnCompleted = null)
        {
            ColliderControl.Rigidbody.velocity = Vector3.zero;
            transform.position = _targetPos;
            
            gameObject.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(true);
            
            if(OnRespawnAnimation)
                OnRespawnAnimation.PlayFeedbacks();
            
            _onRespawnCompleted?.Invoke();
        }
        
        public void OnCollisionEnter(Collision _other)
        {
            if (_other.gameObject.TryGetComponent<Enemy>(out var _enemy))
            {
                _enemy.DestroyEntity();
            }

            if (!IsCoolDown)
                DestroyEntity();
        }
        
        public void DestroyEntity()
        {
            playerManager.NotifyPlayerIsDestroyed(this);
        }
        
        public void StartCoolDown()
        {
            IsCoolDown = true;

            startCoolDownTimer = Observable.EveryUpdate().Subscribe(_ =>
            {
                CoolDownTimer -= Time.deltaTime;

                if (CoolDownTimer <= 0)
                {
                    CoolDownTimer = 3f;
                    IsCoolDown    = false;
                    startCoolDownTimer?.Dispose();
                }

            }).AddTo(this);
        }
        
        private void OnDestroy()
        {
            inputManager.PlayerInput.Disable();

            MovementControl.UnbindInput(inputManager.PlayerInput);
            WeaponControl  .UnbindInput(inputManager.PlayerInput);
        }
    }
}
