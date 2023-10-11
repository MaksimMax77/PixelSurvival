using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Fsm.Core;
using Code.Units;
using UnityEngine;

namespace Code.Fsm.Requirements
{
    [CreateAssetMenu(order = 4, menuName = "Fsm/Requirements/DeathRequirement", 
        fileName = "DeathRequirement")]
    public class DeathRequirement : Requirement
    {
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new DeathRequirementState(this, blackboard);
        }
        private class DeathRequirementState: RequirementState<DeathRequirement>
        {
            private Unit _currentUnit;
            public DeathRequirementState(DeathRequirement action, Blackboard blackboard) : base(action, blackboard)
            {
            }
            
            public override bool IsRequirement()
            {
                base.IsRequirement();
                return _currentUnit.Health.CurrentHealth.Value <= 0;
            }

            protected override void Init()
            {
                if(!_blackboard.TryGetData(nameof(Unit), out _currentUnit))
                {
                    return;
                }
                base.Init();
            }
        }
    }
}
