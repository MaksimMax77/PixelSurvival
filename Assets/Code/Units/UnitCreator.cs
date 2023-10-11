using Zenject;

namespace Code.Units
{
   public class UnitCreator
    {
        private Unit.Factory _unitFactory;
        private UserUnit.Factory _unitItemsCollectorFactory;

        [Inject]
        public UnitCreator(Unit.Factory unitFactory, UserUnit.Factory unitItemsCollectorFactory)
        {
            _unitFactory = unitFactory;
            _unitItemsCollectorFactory = unitItemsCollectorFactory;
        }
        
        public Unit CreateUnit(UnitConfiguration unitConfiguration)
        {
            var unit = unitConfiguration.IsItemsCollector ? _unitItemsCollectorFactory.Create() : _unitFactory.Create();
            unit.Install(unitConfiguration);
            return unit;
        }
    }
}
