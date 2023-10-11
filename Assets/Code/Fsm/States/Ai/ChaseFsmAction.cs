using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Fsm.Core;
using UnityEngine;

namespace Code.Fsm.States.Ai
{
    [CreateAssetMenu(fileName = "ChaseAction", menuName = "Fsm/States/Unit/AiStates/ChaseAction")]
    public class ChaseFsmAction : FsmAction
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private string _targetUnitValueName;
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new ChaseActionState(this, blackboard);
        }
    
        private class ChaseActionState: UnitState<ChaseFsmAction>
        {
            public ChaseActionState(ChaseFsmAction action, Blackboard blackboard) : base(action, blackboard)
            {
            }
            public override void OnEnter()
            {
                SetTarget(FsmAction._targetUnitValueName);
                base.OnEnter();
            }

            public override void OnUpdate()
            {
                _onDirectionMover.Move(_currentUnit.GameObject, _target.GameObject.transform.position,
                    FsmAction._moveSpeed);
                base.OnUpdate();
            }
        }
    }
}
