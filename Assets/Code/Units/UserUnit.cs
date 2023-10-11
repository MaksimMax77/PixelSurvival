using Code.CameraController;
using Code.GOControl;
using Code.Inventory.Items;
using UnityEngine;
using Zenject;

namespace Code.Units
{
    public class UserUnit : Unit
    {
        private Inventory.Inventory _inventory;
        private CameraControl _cameraControl;
        public InputControl.InputControl InputControl
        {
            get;
        }
        
        public UserUnit(GameObjectsControl gameObjectsControl, InputControl.InputControl inputControl, 
            Inventory.Inventory inventory, CameraControl cameraControl) : base(gameObjectsControl)
        {
            InputControl = inputControl;
            _inventory = inventory;
            _cameraControl = cameraControl;
        }

        public override void Install(UnitConfiguration unitConfiguration)
        {
            base.Install(unitConfiguration);
            _cameraControl.SetTarget(GameObject.transform);
            _triggerControl.CollectibleItemTrigger += OnCollectibleItemTrigger;
        }

        public override void Dispose()
        {
            _triggerControl.CollectibleItemTrigger -= OnCollectibleItemTrigger;
            base.Dispose();
        }
        
        private void OnCollectibleItemTrigger(CollectibleItem item)
        {
            _inventory.AddItem(item);
            Object.Destroy(item.gameObject);
        }

        public class Factory : PlaceholderFactory<UserUnit>
        {
        }
    }
}
