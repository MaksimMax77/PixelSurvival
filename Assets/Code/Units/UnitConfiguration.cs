using System;
using Code.Fsm.Core;
using UnityEngine;

namespace Code.Units
{
    public enum UnitType
    {
        Human,
        MutantDog
    }
    
    [Serializable]
    public class UnitConfiguration
    {
        [SerializeField] private UnitType _unitType;
        [SerializeField] private GameObject _unitObject;
        [SerializeField] private UnitType[] _enemyTypes;
        [SerializeField] private float _maxHealth;
        [SerializeField] private bool _isUserUnit;
        [SerializeField] private FsmAction _rootAction; 
        public UnitType UnitType => _unitType;
        public GameObject UnitObject => _unitObject;
        public UnitType[] EnemyTypes => _enemyTypes;
        public float MaxHealth => _maxHealth;
        public bool IsUserUnit => _isUserUnit;
        public FsmAction RootAction => _rootAction;
    }
}
