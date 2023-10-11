using Code.ActionsSystem.Actions;

namespace Code.Fsm.Core
{
    public class Transition
    {
        public Requirement.IRequirementState RequirementState
        {
            get;
        }
        public IActionState NextState
        {
            get;
        }

        public Transition(IActionState nextState, Requirement.IRequirementState requirementState)
        {
            NextState = nextState;
            RequirementState = requirementState;
        }
    }
}
