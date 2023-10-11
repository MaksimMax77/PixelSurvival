using System.Collections.Generic;
using Code.ActionsSystem;
using Code.ActionsSystem.Actions;
using Code.Fsm.Core;
using Code.Units;
using UnityEngine;

namespace Code.Fsm.Requirements
{
    [CreateAssetMenu(order = 4, menuName = "Fsm/Requirements/DistanceRequirement", 
        fileName = "DistanceRequirement")]
    public class DistanceRequirement : Requirement
    {
        [SerializeField] private float _distance;
        [SerializeField] private bool _isFar;
        [SerializeField] private string _targetValueName;
        public override IActionState CreateState(Blackboard blackboard)
        {
            return new DistanceRequirementState(this, blackboard);
        }
        private class DistanceRequirementState : RequirementState<DistanceRequirement>
        {
            private GameObject _currentGameObject;
            private List<Unit> _targets;
            public DistanceRequirementState(DistanceRequirement action, Blackboard blackboard) : base(action, blackboard)
            {
            }
            
            protected override void Init()
            {
                base.Init();

                if(!_blackboard.TryGetData<Unit>(nameof(Unit), out var value))
                {
                    return;
                }

                _targets = value.Targets;
                _currentGameObject = value.GameObject;
            }
            
            public override bool IsRequirement()
            {
                base.IsRequirement();

                for (int i = 0, len = _targets.Count; i < len; ++i)
                {
                    if (_targets[i].GameObject == null)
                    {
                        continue;
                    }
                    
                    if (FsmAction._isFar && CheckFarDistance(_targets[i].GameObject.transform.position))
                    {
                        Refresh();
                        return true;
                    }

                    if (!FsmAction._isFar && CheckNearDistance(_targets[i].GameObject.transform.position))
                    {
                        _blackboard.AddData(FsmAction._targetValueName, _targets[i]);
                        Refresh();
                        return true;
                    }
                }

                return false;
            }
            private bool CheckNearDistance(Vector3 targetPos)
            {
                return (targetPos - _currentGameObject.transform.position).magnitude <= FsmAction._distance;
            }
            private bool CheckFarDistance(Vector3 targetPos)
            {
                return (targetPos - _currentGameObject.transform.position).magnitude >= FsmAction._distance;
            }
        }
    }
}
