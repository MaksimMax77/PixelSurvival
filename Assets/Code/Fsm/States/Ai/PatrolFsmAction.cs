using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Fsm.Core;
using Code.ObjectMove;
using UnityEngine;

namespace Code.Fsm.States.Ai
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "Fsm/States/Unit/AiStates/PatrolState")]
    public class PatrolFsmAction : FsmAction
    {
        [SerializeField] private Vector3[] _movePoints;
        [SerializeField] private float _moveSpeed;

        public override IActionState CreateState(Blackboard blackboard)
        {
            return new PatrolFsmActionState(this, blackboard);
        }
        private class PatrolFsmActionState: UnitState<PatrolFsmAction>
        {
            private int _vectorIndex;
            private float _moveSpeed;
            private Vector3[] _movePoints;
            private Vector3 _startPos;
            public PatrolFsmActionState(PatrolFsmAction action, Blackboard blackboard) : base(action, blackboard)
            {
                _moveSpeed = FsmAction._moveSpeed;
                _startPos = _currentUnit.GameObject.transform.position;
                _movePoints = FsmAction._movePoints;
            }
            
            public override void OnUpdate()
            {
                var pointPos = _movePoints[_vectorIndex];
                var patrolPoint = new Vector3(_startPos.x + pointPos.x, _startPos.y + pointPos.y, _startPos.z+ pointPos.z);
                
                if (!OnDirectionMover.Move(_currentUnit.GameObject, patrolPoint, _moveSpeed))
                {
                    IncrementIndex();
                }
                base.OnUpdate();
            }
            
            private void IncrementIndex()
            {
                ++_vectorIndex;
                if (_vectorIndex >= _movePoints.Length)
                {
                    _vectorIndex = 0;
                }
            }
        }
    }
}
