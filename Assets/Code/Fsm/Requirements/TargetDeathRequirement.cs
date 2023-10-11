using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Fsm.Core;
using Code.Units;
using UnityEngine;

namespace Code.Fsm.Requirements
{
    [CreateAssetMenu(order = 4, menuName = "Fsm/Requirements/TargetDeathRequirement", 
        fileName = "TargetDeathRequirement")]
    public class TargetDeathRequirement : Requirement
    {
        [SerializeField] private string _targetUnitValueName;
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new TargetDeathRequirementState(this, blackboard);
        }
        
        private class TargetDeathRequirementState : RequirementState<TargetDeathRequirement>
        {
            private Unit _targetUnit;
            
            public TargetDeathRequirementState(TargetDeathRequirement action, Blackboard blackboard) : base(action, blackboard)
            {
            }
            
            protected override void Init()
            {
                if(!_blackboard.TryGetData(FsmAction._targetUnitValueName, out _targetUnit))
                {
                    return;
                }
                base.Init();
            }
            public override bool IsRequirement()
            {
                base.IsRequirement();
            
                if (_targetUnit.Health.CurrentHealth.Value <= 0)
                {
                    Refresh();
                    return true;
                }

                return false;
            }

        }
    }
}
