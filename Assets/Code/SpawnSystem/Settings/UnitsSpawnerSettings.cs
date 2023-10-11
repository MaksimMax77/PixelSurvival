using System;
using Code.Units;
using UnityEngine;

namespace Code.SpawnSystem.Settings
{
    [CreateAssetMenu(order = 3, fileName = "UnitsSpawnerSettings", menuName = "UnitsSpawnerSettings")]
    public class UnitsSpawnerSettings : ScriptableObject
    {
        [SerializeField] private float _spawnTime;
        [SerializeField] private UnitConfigurationContainer[] _configurationContainers;
        public float SpawnTime => _spawnTime;
        public UnitConfigurationContainer[] ConfigurationContainers => _configurationContainers;
    }

    [Serializable]
    public class UnitConfigurationContainer
    {
        public int unitsAmount;
        public UnitConfiguration unitConfiguration;
    }
}