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
        [SerializeField] private bool _controlledByInput;
        [SerializeField] private bool _isItemsCollector;
        [SerializeField] private bool _cameraTarget;
        [SerializeField] private FsmAction _rootAction; 
        public UnitType UnitType => _unitType;
        public GameObject UnitObject => _unitObject;
        public UnitType[] EnemyTypes => _enemyTypes;
        public float MaxHealth => _maxHealth;
        public bool ControlledByInput => _controlledByInput;
        public bool IsItemsCollector => _isItemsCollector;
        public bool CameraTarget => _cameraTarget;
        public FsmAction RootAction => _rootAction;
    }
}
