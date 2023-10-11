using Code.CameraController;
using Code.GOControl;
using Code.Inventory;
using Code.ItemsCreation;
using Code.ItemsCreation.Settings;
using Code.SpawnSystem;
using Code.SpawnSystem.Settings;
using Code.Units;
using Code.Update;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private SquareZone _squareZone;
        [SerializeField] private UnitsSpawnerSettings _unitsSpawnerSettings;
        [SerializeField] private ItemsCreatorSettings _itemsCreatorSettings;
        [SerializeField] private Updater _updater;
        [SerializeField] private GameObjectsControl _gameObjectsControl;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_inventoryView).AsSingle().NonLazy();
            Container.BindInstance(_cameraSettings).AsSingle().NonLazy();
            Container.BindInstance(_itemsCreatorSettings).AsSingle().NonLazy();
            Container.BindInstance(_unitsSpawnerSettings).AsSingle().NonLazy();
            Container.BindInstance(_squareZone).AsSingle().NonLazy();
            Container.BindInstance(_updater).AsSingle().NonLazy();
            Container.BindInstance(_gameObjectsControl).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<InputControl.InputControl>().AsSingle().NonLazy();
            Container.Bind<Inventory.Inventory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InventoryPresenter>().AsSingle().NonLazy();
            Container.Bind<ItemsCreator>().AsSingle().NonLazy();       
            Container.Bind<CameraControl>().AsSingle().NonLazy();       
            Container.BindInterfacesAndSelfTo<UnitsManager>().AsSingle().NonLazy();
            Container.Bind<UnitCreator>().AsSingle().NonLazy();
            Container.Bind<UnitSpawner>().AsSingle().NonLazy();
            
            Container.BindFactory<Unit, Unit.Factory>();
            Container.BindFactory<UserUnit, UserUnit.Factory>();
        }
    }
}