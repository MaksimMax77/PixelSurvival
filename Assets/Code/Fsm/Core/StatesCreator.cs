using System.Collections.Generic;
using System.Linq;
using Code.ActionsSystem;

namespace Code.Fsm.Core
{
    public static class StatesCreator 
    {
        public static IFsmState CreateStates(FsmAction fsmAction, Blackboard blackboard)
        {
            var rootState = CreateStates(fsmAction, blackboard, new Dictionary<FsmAction, IFsmState>());
            return rootState;
        }
        private static IFsmState CreateStates(FsmAction fsmAction, Blackboard blackboard,
            Dictionary<FsmAction, IFsmState> states)
        {
            if (!states.TryGetValue(fsmAction, out var rootFsmState))
            {
                rootFsmState = (IFsmState)fsmAction.CreateState(blackboard);
                if (rootFsmState == null)
                {
                    return null;
                }
                states.Add(fsmAction, rootFsmState);
            }

            for (int i = 0, len = fsmAction.TransitionContainers.Count; i < len; ++i)
            {
                var transitionContainer = fsmAction.TransitionContainers[i];
                
                if (states.TryGetValue(transitionContainer.FsmAction, out var transitionState))
                {
                    rootFsmState.AddTransition(new Transition(transitionState,  (Requirement.IRequirementState) transitionContainer.Requirement.CreateState(blackboard)));
                    continue;
                }
                
                transitionState = (IFsmState)transitionContainer.FsmAction.CreateState(blackboard);
                rootFsmState.AddTransition(new Transition(transitionState,
                    (Requirement.IRequirementState) transitionContainer.Requirement.CreateState(blackboard)));
                states.TryAdd(transitionContainer.FsmAction, transitionState);
                CreateStates(transitionContainer.FsmAction, blackboard, states);
            }
            
            return states.Values.First();
        }
    }
}
