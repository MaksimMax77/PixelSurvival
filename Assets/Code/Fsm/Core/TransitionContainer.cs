using System;
using UnityEngine;

namespace Code.Fsm.Core
{
    [Serializable]
    public class TransitionContainer
    {
        [SerializeField] private FsmAction _fsmAction;
        [SerializeField] private Requirement _requirement;
        public Requirement Requirement => _requirement;
        public FsmAction FsmAction => _fsmAction;
    }
}
