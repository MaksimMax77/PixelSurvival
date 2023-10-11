using System.Collections.Generic;
using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using UnityEngine;

namespace Code.Fsm.Core
{
    public abstract class FsmAction : Action
    {
        [SerializeField] private List<TransitionContainer> _transitionContainers = new List<TransitionContainer>();
        public List<TransitionContainer> TransitionContainers => _transitionContainers;
        public abstract override IActionState CreateState(Blackboard blackboard);
        
        public IFsmState CreateFsmState<T>(Blackboard blackboard) where T : FsmAction
        {
            return (IFsmState)CreateState(blackboard);
        }

        public abstract class FsmState<T> : ActionState<T>, IFsmState where T : FsmAction
        
        {
            private readonly List<Transition> _transitions = new List<Transition>();
            public List<Transition> Transitions => _transitions;
            
            protected FsmState(T fsmAction, Blackboard blackboard) : base(fsmAction, blackboard)
            {
            }
            
            public void AddTransition(Transition transition)
            {
                _transitions.Add(transition);
            }
        }
    }
    
                        
    public interface IFsmState : IActionState
    {
        public List<Transition> Transitions { get; }
        public void AddTransition(Transition transition);
    }
}
