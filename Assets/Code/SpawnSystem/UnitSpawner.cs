using System.Collections.Generic;
using Code.SpawnSystem.Settings;
using Code.Units;
using Code.Update;
using Zenject;
using Timer = Code.Core.Tools.Timer;

namespace Code.SpawnSystem
{
    public class UnitSpawner: UpdateObject
    {
        private SquareZone _squareZone;  
        private Timer _timer;
        private UnitsManager _unitsManager;
        private float _spawnTime;
        
        [Inject]
        public UnitSpawner(UnitsSpawnerSettings unitsSpawnerSettings, UnitsManager unitsManager, SquareZone squareZone, Updater updater) : base(updater)
        {
            _squareZone = squareZone;
            _unitsManager = unitsManager;
            _spawnTime = unitsSpawnerSettings.SpawnTime;
            _timer = new Timer(_spawnTime);
            CreateUnits(unitsSpawnerSettings.ConfigurationContainers);
        }

        public override void Update()
        {
            Spawn();
        }
        
        private void Spawn()
        {
            if (_unitsManager.DisabledUnitsIsEmpty())
            {
                _timer.TimerZero();
                return;
            }
            
            _timer.UpdateTimer();

            if (!_timer.available)
            {
                return;
            }
            
            var unit = _unitsManager.RespawnUnit();
            SetRandomPos(unit);
            _timer.TimerZero();
        }

        private void CreateUnits(IReadOnlyList<UnitConfigurationContainer> containers)
        {
            for (int i = 0, len = containers.Count; i < len; ++i)
            {
                var unitsAmount = containers[i].unitsAmount;

                for (var j = 0; j < unitsAmount; ++j)
                {
                    var unit = _unitsManager.CreateUnit(containers[i].unitConfiguration, _squareZone);
                    SetRandomPos(unit);
                }
            }
        }

        private void SetRandomPos(Unit unit)
        {
            unit.GameObject.transform.position = _squareZone.GetRandomPosInSquare();
        }
    }
}
