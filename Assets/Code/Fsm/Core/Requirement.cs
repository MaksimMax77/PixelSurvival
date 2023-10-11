using Code.ActionsSystem;
using Code.ActionsSystem.Actions;

namespace Code.Fsm.Core
{
    public abstract class Requirement : Action
    {
        public abstract override IActionState CreateState(Blackboard blackboard);

        protected class RequirementState<T>: ActionState<T>, IRequirementState where T: Requirement
        {
            protected bool _initialized;
            
            public RequirementState(T action, Blackboard blackboard) : base(action, blackboard)
            {
            }
            
            public virtual bool IsRequirement()
            {
                if (!_initialized)
                {
                    Init();
                }

                return false;
            }
            
            protected void Refresh()
            {
                _initialized = false;
            }
            
            protected virtual void Init()
            {
                _initialized = true;
            }
        }
        
        public interface IRequirementState
        {
            public bool IsRequirement();
        }
 
    }
}
