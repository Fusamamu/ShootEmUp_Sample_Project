//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Resources/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""09974e4a-74d6-4c8d-b324-fce1e9dc8bd9"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""1bbe7258-85d2-4090-bdf0-63d443fced04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveBackward"",
                    ""type"": ""Button"",
                    ""id"": ""bfb30d34-464c-49ac-a4ed-12d9a9a9d282"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f4731692-6fac-4e38-b6f5-269b901a1a69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""52762d64-34c8-41e3-902d-931bdfda79de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0c508a0f-37d7-4852-bd89-9932730b77c7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b7ab337-411d-48fb-a171-95e898b8cc0e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df2b4e46-1c1b-480f-af2e-17fb86d7aad2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fcd4432-12f9-411e-b2cd-6fb8443fdbcc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Aim"",
            ""id"": ""d29a76db-611b-4468-a576-54e2583f209e"",
            ""actions"": [
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""4c58cc0b-5c93-4e14-bbe7-a4f667e79ac5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""825be7f1-9eee-43ef-b7e4-488f17deac74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b338ea3a-7eca-472e-9f60-62511bb920fd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c346288-b896-4153-a96b-2795be0fa74a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Attack"",
            ""id"": ""366fc43e-700f-4287-ac51-5a1f0f9101c9"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""11b4f58f-48ce-47ca-a724-27fff12057ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bd80d362-7167-4524-a33a-6e1f45591a97"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_MoveForward = m_Movement.FindAction("MoveForward", throwIfNotFound: true);
        m_Movement_MoveBackward = m_Movement.FindAction("MoveBackward", throwIfNotFound: true);
        m_Movement_MoveLeft = m_Movement.FindAction("MoveLeft", throwIfNotFound: true);
        m_Movement_MoveRight = m_Movement.FindAction("MoveRight", throwIfNotFound: true);
        // Aim
        m_Aim = asset.FindActionMap("Aim", throwIfNotFound: true);
        m_Aim_RotateLeft = m_Aim.FindAction("RotateLeft", throwIfNotFound: true);
        m_Aim_RotateRight = m_Aim.FindAction("RotateRight", throwIfNotFound: true);
        // Attack
        m_Attack = asset.FindActionMap("Attack", throwIfNotFound: true);
        m_Attack_Shoot = m_Attack.FindAction("Shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_MoveForward;
    private readonly InputAction m_Movement_MoveBackward;
    private readonly InputAction m_Movement_MoveLeft;
    private readonly InputAction m_Movement_MoveRight;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveForward => m_Wrapper.m_Movement_MoveForward;
        public InputAction @MoveBackward => m_Wrapper.m_Movement_MoveBackward;
        public InputAction @MoveLeft => m_Wrapper.m_Movement_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Movement_MoveRight;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @MoveForward.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveForward;
                @MoveBackward.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveBackward;
                @MoveBackward.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveBackward;
                @MoveBackward.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveBackward;
                @MoveLeft.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveRight;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @MoveBackward.started += instance.OnMoveBackward;
                @MoveBackward.performed += instance.OnMoveBackward;
                @MoveBackward.canceled += instance.OnMoveBackward;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Aim
    private readonly InputActionMap m_Aim;
    private IAimActions m_AimActionsCallbackInterface;
    private readonly InputAction m_Aim_RotateLeft;
    private readonly InputAction m_Aim_RotateRight;
    public struct AimActions
    {
        private @PlayerInput m_Wrapper;
        public AimActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotateLeft => m_Wrapper.m_Aim_RotateLeft;
        public InputAction @RotateRight => m_Wrapper.m_Aim_RotateRight;
        public InputActionMap Get() { return m_Wrapper.m_Aim; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AimActions set) { return set.Get(); }
        public void SetCallbacks(IAimActions instance)
        {
            if (m_Wrapper.m_AimActionsCallbackInterface != null)
            {
                @RotateLeft.started -= m_Wrapper.m_AimActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_AimActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_AimActionsCallbackInterface.OnRotateLeft;
                @RotateRight.started -= m_Wrapper.m_AimActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_AimActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_AimActionsCallbackInterface.OnRotateRight;
            }
            m_Wrapper.m_AimActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
            }
        }
    }
    public AimActions @Aim => new AimActions(this);

    // Attack
    private readonly InputActionMap m_Attack;
    private IAttackActions m_AttackActionsCallbackInterface;
    private readonly InputAction m_Attack_Shoot;
    public struct AttackActions
    {
        private @PlayerInput m_Wrapper;
        public AttackActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Attack_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActions set) { return set.Get(); }
        public void SetCallbacks(IAttackActions instance)
        {
            if (m_Wrapper.m_AttackActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_AttackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public AttackActions @Attack => new AttackActions(this);
    public interface IMovementActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnMoveBackward(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
    }
    public interface IAimActions
    {
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
    }
    public interface IAttackActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
