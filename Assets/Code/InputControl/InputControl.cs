using System;
using Code.Update;
using InputControl;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Code.InputControl
{
    public class InputControl : UpdateObject, IInputControl, IDisposable 
    {
        public event Action<Vector2> Move;
        public event Action<bool> Fire;
        private InputActions _inputActions;
        private Vector2 _moveInputDir;
        private bool _moveCanceled; 
        private bool _firePerformed;

        [Inject]
        public InputControl(Updater updater) : base(updater)
        {
            _moveCanceled = true;
            _inputActions = new InputActions();
            _inputActions.Gamepad.Move.performed += OnMovePerformed;
            _inputActions.Gamepad.Move.canceled += OnMoveCanceled;
            _inputActions.Gamepad.Fire.performed += OnFirePerformed;
            _inputActions.Gamepad.Fire.canceled += OnFireCanceled;
            _inputActions.Enable();
        }
        
        public override void Update()
        {
            if (!_moveCanceled)
            {
                Move?.Invoke(_moveInputDir);
            }
            
            Fire?.Invoke(_firePerformed);
        }
        
        public void Dispose()
        {
            _inputActions.Gamepad.Move.performed -= OnMovePerformed;
            _inputActions.Gamepad.Move.canceled -= OnMoveCanceled;
            _inputActions.Gamepad.Fire.performed -= OnFirePerformed;
            _inputActions.Gamepad.Fire.canceled -= OnFireCanceled;
            _inputActions.Disable();
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            _moveCanceled = false;
            _moveInputDir = obj.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            _moveCanceled = true;
            Move?.Invoke(obj.ReadValue<Vector2>());
        }

        private void OnFirePerformed(InputAction.CallbackContext obj)
        {
            _firePerformed = true;
        }
        
        private void OnFireCanceled(InputAction.CallbackContext obj)
        {
            _firePerformed = false;
        }
    }
}
