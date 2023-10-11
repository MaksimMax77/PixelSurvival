using Code.Units;

namespace Code.ActionsSystem.Actions
{
    public class UnitActionState<T>  : Action.ActionState<T> where T : Action
    {
        protected Unit _currentUnit;
        protected InputControl.InputControl _inputControl;
        
        public UnitActionState(T action, Blackboard blackboard) : base(action, blackboard)
        {
            _blackboard.TryGetData(nameof(Unit), out _currentUnit);
            if (_currentUnit is not UserUnit unit)
            {
                return;
            }
            _inputControl = unit.InputControl;
        }
    }
}
