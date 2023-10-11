using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Fsm.Core;
using Code.Units;
using UnityEngine;

namespace Code.Fsm.States.Ai
{
    [CreateAssetMenu(fileName = "DeathFsmAction", menuName = "Fsm/States/Unit/AiStates/DeathFsmAction")]
    public class DeathFsmAction : FsmAction
    { 
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new DeathFsmActionState(this, blackboard);
        }
        private class DeathFsmActionState: UnitState<DeathFsmAction>
        {
            public DeathFsmActionState(DeathFsmAction action, Blackboard blackboard) : base(action, blackboard)
            {
            }
            
            public override void OnEnter()
            {
                if (!_blackboard.TryGetData<UnitsManager>(nameof(UnitsManager), out var unitsManager))
                {
                    return;
                }
                unitsManager.KillUnit(_currentUnit);
            }
        }
    }
}
