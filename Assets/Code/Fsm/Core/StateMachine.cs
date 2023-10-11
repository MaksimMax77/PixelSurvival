using Code.ActionsSystem;

namespace Code.Fsm.Core
{
    public class StateMachine
    {
        private IFsmState _currentState;
        private IFsmState _rootState;
        private FsmAction _rootFsmAction;
        public Blackboard Blackboard
        {
            get;
        }
        public StateMachine(FsmAction rootFsmAction)
        {
            _rootFsmAction = rootFsmAction;
            Blackboard = new Blackboard();
        }

        public void Restart()
        {
            _rootState ??= StatesCreator.CreateStates(_rootFsmAction, Blackboard);
            _currentState = _rootState;
            _currentState.OnEnter();
        }
        public void Update()
        {
            if (_currentState == null)
            {
                return;
            }
            
            if (CheckTransitionsRequirements(_currentState, out var nextState))
            {
                _currentState.OnExit();
                _currentState = nextState;
                _currentState.OnEnter();
            }
            _currentState.OnUpdate();
        }
        private bool CheckTransitionsRequirements(IFsmState currentState, out IFsmState nextState)
        {
            for (int i = 0, len = currentState.Transitions.Count; i < len; ++i)
            {
                if (!currentState.Transitions[i].RequirementState.IsRequirement())
                {
                    continue;
                }
                nextState = (IFsmState) currentState.Transitions[i].NextState;
                return true;
            }

            nextState = null;
            return false;
        }
    }
}
