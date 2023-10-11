using System;
using UnityEngine;

namespace Code.InputControl
{
    public interface IInputControl
    {
        public event Action<Vector2> Move;
        public event Action<bool> Fire;
        public void Update();
    }
}
