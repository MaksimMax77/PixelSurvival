using System;
using System.Collections.Generic;
using Code.ItemsCreation;
using Code.SpawnSystem;
using Code.Update;
using Zenject;

namespace Code.Units
{
    public class UnitsManager: UpdateObject, IDisposable
    {
        private List<Unit> _aliveUnits = new List<Unit>();
        private Stack<Unit> _disabledUnits = new Stack<Unit>();
        private UnitCreator _unitCreator;
        private ItemsCreator _itemsCreator;

        [Inject]
        public UnitsManager(UnitCreator unitCreator, 
            ItemsCreator itemsCreator, Updater updater) : base(updater)
        {
            _itemsCreator = itemsCreator;
            _unitCreator = unitCreator;
        }

        public bool DisabledUnitsIsEmpty()
        {
            return _disabledUnits.Count == 0;
        }
        
        public override void Update()
        {
            for (var i = _aliveUnits.Count - 1; i >= 0; --i)
            {
                _aliveUnits[i].Update();
            }
        }
        public Unit CreateUnit(UnitConfiguration unitConfiguration, SquareZone squareZone)
        {
           var unit =  _unitCreator.CreateUnit(unitConfiguration);
           unit.BlackboardAddData(nameof(UnitsManager), this);
           unit.BlackboardAddData(nameof(SquareZone), squareZone);
           unit.Enable();
           AddTargets(unit);
           _aliveUnits.Add(unit);
           return unit;
        }

        public void KillUnit(Unit unit)
        {
            _aliveUnits.Remove(unit);
            _disabledUnits.Push(unit);
            unit.Disable();
            _itemsCreator.CreateRandomItem(unit.GameObject.transform.position);
            RemoveTarget(unit);
        }

        public Unit RespawnUnit()
        {
            var unit = _disabledUnits.Pop();
            _aliveUnits.Add(unit);
            unit.Enable();
            AddTargets(unit);
            unit.Health.RestoreHealth();
            return unit;
        }
        
        public void Dispose()
        {
            for (int i = 0, len = _aliveUnits.Count; i < len; ++i)
            {
                _aliveUnits[i].Update();
            }
            for (int i = 0, len = _disabledUnits.Count; i < len; ++i)
            {
                _disabledUnits.Pop().Dispose();
            }
        }

        #region private
        
        private void AddTargets(Unit unit)
        {
            for (int i = 0, len = _aliveUnits.Count; i < len; ++i)
            {
               unit.AddTarget(_aliveUnits[i]);
               _aliveUnits[i].AddTarget(unit);
            }
        }

        private void RemoveTarget(Unit unit)
        {
            for (int i = 0, len = _aliveUnits.Count; i < len; ++i)
            {
                _aliveUnits[i].Targets.Remove(unit);
            }
        }
        
        #endregion
    }
}
