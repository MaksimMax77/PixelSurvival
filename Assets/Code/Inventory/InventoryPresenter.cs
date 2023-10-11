using System;
using Zenject;

namespace Code.Inventory
{
    public class InventoryPresenter: IDisposable
    {
        private Inventory _inventory;
        private InventoryView _inventoryView;

        [Inject]
        public InventoryPresenter(Inventory inventory, InventoryView inventoryView)
        {
            _inventory = inventory;
            _inventoryView = inventoryView;
            _inventory.Update += _inventoryView.OnItemCellUpdate;
            SubscribeOnDestroyButtonClick();
            _inventory.Init(_inventoryView.CellsLength);
        }
        
        public void Dispose()
        {
            _inventory.Update -= _inventoryView.OnItemCellUpdate;
            UnSubscribeFromDestroyButtonClick();
        }
        
        private void SubscribeOnDestroyButtonClick()
        {
            for (int i = 0, len = _inventoryView.CellViews.Length; i < len; ++i)
            {
                _inventoryView.CellViews[i].DestroyClicked += OnDestroyClick;
            }
        }
        
        private void UnSubscribeFromDestroyButtonClick()
        {
            for (int i = 0, len = _inventoryView.CellViews.Length; i < len; ++i)
            {
                _inventoryView.CellViews[i].DestroyClicked -= OnDestroyClick;
            }
        }

        private void OnDestroyClick(int index)
        {
             _inventory.RemoveItem(index);
        }
    }
}
