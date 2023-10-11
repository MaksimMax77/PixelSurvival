using Code.SpawnSystem;
using UnityEngine;

namespace Code.ActionsSystem.Actions
{
    [CreateAssetMenu(order = 1, menuName = "Actions/MoveUnitAction", fileName = "MoveUnitAction")]
    public class MoveAction: Action
    {
        [SerializeField] private float _speed;
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new MoveActionState(this, blackboard);
        }
        private class MoveActionState : UnitActionState<MoveAction>
        {
            private SquareZone _squareZone;
    
            public MoveActionState(MoveAction action, Blackboard blackboard) : base(action, blackboard)
            {
                _blackboard.TryGetData(nameof(SquareZone), out _squareZone);
            }

            public override void OnEnter()
            {
                _inputControl.Move += OnMove;
                base.OnEnter();
            }

            public override void OnExit()
            {
                _inputControl.Move -= OnMove;
                base.OnExit();
            }

            private void OnMove(Vector2 dir)
            {

                var pos = _currentUnit.GameObject.transform.position +=
                    new Vector3(dir.x, dir.y) * FsmAction._speed * Time.deltaTime;

                pos = _squareZone.GetClampedPos(pos);

                _currentUnit.GameObject.transform.position = pos;
                
                UnitFlip(dir.x);
            }
            
            private void UnitFlip(float horizontal)
            {
                switch (horizontal)
                {
                    case < 0:
                        _currentUnit.GameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                        break;
                    case > 0:
                        _currentUnit.GameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                }
            }
        }
    }
}
