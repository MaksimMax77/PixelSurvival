using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Core.Tools;
using Code.Fsm.Core;
using UnityEngine;

namespace Code.Fsm.States.Ai
{
    [CreateAssetMenu(fileName = "AttackFsmAction", menuName = "Fsm/States/Unit/AiStates/AttackFsmAction")]
    public class AttackFsmAction : FsmAction
    {
        [SerializeField] private string _targetUnitValueName;
        [SerializeField] private float _attackTime;
        [SerializeField] private float _damage;
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new AttackFsmState(this, blackboard);
        }
        
        private class AttackFsmState: UnitState<AttackFsmAction>
        {
            private Timer _timer;
            
            public AttackFsmState(AttackFsmAction action, Blackboard blackboard) : base(action, blackboard)
            {
            }
            
            public override void OnEnter()
            {
                _timer = new Timer(FsmAction._attackTime);
                SetTarget(FsmAction._targetUnitValueName);
                base.OnEnter();
            }

            public override void OnUpdate()
            {
                _timer.UpdateTimer();
                if (!_timer.available)
                {
                    return;
                }

                _timer.TimerZero();
                
                Attack(FsmAction._damage);
              
                base.OnUpdate();
            }

            private void Attack(float damage)
            {
                _target.Health.HealthRemove(damage);
            }
        }
    }
}
