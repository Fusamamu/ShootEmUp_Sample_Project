using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class Player : MonoBehaviour
    {
        private InputManager inputManager;
        
        [field: SerializeField] public MovementControl MovementControl { get; private set; }
        [field: SerializeField] public WeaponControl   WeaponControl   { get; private set; }
        
        [field: SerializeField] public ColliderControl ColliderControl { get; private set; }
        [field: SerializeField] public RenderControl   RenderControl   { get; private set; }
        
        [field: SerializeField] public BodyTiltingBehavior BodyTiltingBehavior { get; private set; }

        public void Initialized()
        {
            inputManager = ApplicationManager.Instance.Get<InputManager>();
            inputManager.PlayerInput.Enable();

            MovementControl
                .BindInput(inputManager.PlayerInput)
                .SetTargetRigidbody(ColliderControl.Rigidbody);
            
            WeaponControl  
                .BindInput(inputManager.PlayerInput)
                .Initialize();

            BodyTiltingBehavior.Initialized();
            BodyTiltingBehavior.StartTilting();
        }

        private void OnDestroy()
        {
            inputManager.PlayerInput.Disable();

            MovementControl.UnbindInput(inputManager.PlayerInput);
            WeaponControl  .UnbindInput(inputManager.PlayerInput);
        }
    }
}
