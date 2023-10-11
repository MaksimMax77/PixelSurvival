using Code.ActionsSystem;
using Code.Fsm.Core;
using Code.ObjectMove;
using Code.Units;

namespace Code.Fsm.States.Ai
{
    public class UnitState<T> : FsmAction.FsmState<T> where T : FsmAction
    {
        protected Unit _currentUnit;
        protected Unit _target; 
        
        public UnitState(T action, Blackboard blackboard) : base(action, blackboard)
        {
            SetCurrentUnit();
        }
        protected void SetTarget(string targetUnitValueName)
        {
            _blackboard.TryGetData(targetUnitValueName, out _target);
        }
        
        private void SetCurrentUnit()
        {
            _blackboard.TryGetData(nameof(Unit), out _currentUnit);
        }
    }
}
