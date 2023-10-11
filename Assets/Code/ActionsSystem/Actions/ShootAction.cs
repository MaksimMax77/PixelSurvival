using Code.Core.Tools;
using Code.GOControl;
using Code.Weapons;
using UnityEngine;

namespace Code.ActionsSystem.Actions
{
    [CreateAssetMenu(order = 1, menuName = "Actions/ShootAction", fileName = "ShootAction")]
    public class ShootAction : Action
    {
        [SerializeField] private float _shootTime;
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new ShootActionState(this, blackboard);
        }
        private class ShootActionState : UnitActionState<ShootAction>
        {
            private Gun _gun;
            private Timer _timer;
            private GameObjectsControl _gameObjectsControl;
 
            public ShootActionState(ShootAction action, Blackboard blackboard) : base(action, blackboard)
            {
            }

            public override void OnEnter()
            {
                _gameObjectsControl = _currentUnit.GameObjectsControl;
                _gun = _currentUnit.GameObject.GetComponent<Gun>();
                _timer = new Timer(FsmAction._shootTime);
                _inputControl.Fire += OnFire;
                base.OnEnter();
            }

            public override void OnExit()
            {
                _inputControl.Fire -= OnFire;
                base.OnExit();
            }

            private void OnFire(bool fire)
            {
                if (_gun.Effect != null)
                {
                    _gun.Effect.SetActive(fire);
                }

                if (!fire)
                {
                    _timer.TimerZero();
                    return;
                }
                
                _timer.UpdateTimer();
                
                if (!_timer.available)
                {
                    return;
                }

                var projectile = _gameObjectsControl.GoInstantiate(ObjectType.Projectile, _gun.Projectile);
                projectile.transform.position = _gun.ProjectilePos.position;
                projectile.SetDirection(_currentUnit.GameObject.transform.right);
                _timer.TimerZero();
            }
        }
    }
}
