using UnityEngine;

namespace Code.ActionsSystem.Actions
{
    public abstract class Action : ScriptableObject
    {
        public abstract IActionState CreateState(Blackboard blackboard);
        
        public abstract class ActionState<T>: IActionState where T: Action
        {
            protected T FsmAction;
            protected Blackboard _blackboard;

            public ActionState(T fsmAction, Blackboard blackboard)
            {
                FsmAction = fsmAction;
                _blackboard = blackboard;
            }

            public virtual void OnEnter(){}
            public virtual void OnUpdate(){}
            public virtual void OnExit(){}
        }
    }
    
    public interface IActionState
    {
        public virtual void OnEnter(){}
        public virtual void OnUpdate(){}
        public virtual void OnExit(){}
    }
}
