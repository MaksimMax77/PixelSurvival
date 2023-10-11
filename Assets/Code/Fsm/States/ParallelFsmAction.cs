using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Fsm.Core;
using UnityEngine;

namespace Code.Fsm.States
{
    [CreateAssetMenu(order = 1, menuName = "Fsm/States/ParallelActions", fileName = "ParallelActions")]
    public class ParallelFsmAction : FsmAction
    {
        [SerializeField] private Action[] _nodes;
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new ParallelFsmActionState(this, blackboard);
        }
        
        private class ParallelFsmActionState: FsmState<ParallelFsmAction>
        {
            private IActionState[] _actionStates;
            public ParallelFsmActionState(ParallelFsmAction fsmAction, Blackboard blackboard) : base(fsmAction, blackboard)
            {
            }
            
            public override void OnEnter()
            {
                var length = FsmAction._nodes.Length;
                _actionStates = new IActionState[length];
                
                for (var i = 0; i < length; ++i)
                {
                    var actionState = FsmAction._nodes[i].CreateState(_blackboard);
                    _actionStates[i] = actionState;
                    actionState.OnEnter();
                }
                
                base.OnEnter();
            }

            public override void OnUpdate()
            {
                for(int i = 0, len = _actionStates.Length; i < len; ++i)
                {
                    _actionStates[i].OnUpdate();
                }
                base.OnUpdate();
            }

            public override void OnExit()
            {
                for(int i = 0, len = _actionStates.Length; i < len; ++i)
                {
                    _actionStates[i].OnExit();
                }
                
                base.OnExit();
            }
        }
    }
}
