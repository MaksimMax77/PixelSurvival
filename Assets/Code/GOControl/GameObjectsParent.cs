using System;
using UnityEngine;

namespace Code.GOControl
{
    [Serializable]
    public class GameObjectsParent 
    {
        [SerializeField] private Transform _enabledParent;
        [SerializeField] private Transform _disabledParent;
        [SerializeField] private ObjectType objectType;
        public Transform EnabledParent => _enabledParent;
        public Transform DisabledParent => _disabledParent;
        public ObjectType ObjectType => objectType;
    }
}
