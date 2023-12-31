//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Code/InputControl/InputActions.inputactions
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

namespace InputControl
{
    public partial class @InputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Gamepad"",
            ""id"": ""885f9c10-ea8c-44e8-86b2-60336c7e2588"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b50c5033-f007-426a-83b1-ca630d9f9b94"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d835ab39-e2e1-4e2b-973c-c6b79c342459"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d5c8145-6173-483c-bcb3-32e58b7d11c2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba39401b-1c85-4ac2-b9e8-efa75e945a3d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gamepad
            m_Gamepad = asset.FindActionMap("Gamepad", throwIfNotFound: true);
            m_Gamepad_Move = m_Gamepad.FindAction("Move", throwIfNotFound: true);
            m_Gamepad_Fire = m_Gamepad.FindAction("Fire", throwIfNotFound: true);
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

        // Gamepad
        private readonly InputActionMap m_Gamepad;
        private List<IGamepadActions> m_GamepadActionsCallbackInterfaces = new List<IGamepadActions>();
        private readonly InputAction m_Gamepad_Move;
        private readonly InputAction m_Gamepad_Fire;
        public struct GamepadActions
        {
            private @InputActions m_Wrapper;
            public GamepadActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Gamepad_Move;
            public InputAction @Fire => m_Wrapper.m_Gamepad_Fire;
            public InputActionMap Get() { return m_Wrapper.m_Gamepad; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GamepadActions set) { return set.Get(); }
            public void AddCallbacks(IGamepadActions instance)
            {
                if (instance == null || m_Wrapper.m_GamepadActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GamepadActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }

            private void UnregisterCallbacks(IGamepadActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Fire.started -= instance.OnFire;
                @Fire.performed -= instance.OnFire;
                @Fire.canceled -= instance.OnFire;
            }

            public void RemoveCallbacks(IGamepadActions instance)
            {
                if (m_Wrapper.m_GamepadActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGamepadActions instance)
            {
                foreach (var item in m_Wrapper.m_GamepadActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GamepadActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GamepadActions @Gamepad => new GamepadActions(this);
        public interface IGamepadActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
        }
    }
}
