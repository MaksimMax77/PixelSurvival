using System;
using System.Collections.Generic;
using Code.Inventory.Data;
using Code.Inventory.Items;

namespace Code.Inventory
{
    public class Inventory
    {
        public event Action<int, ItemData, bool> Update;
        private List<Cell> _cells;
        private int _cellsCount;
        private InventoryDataSerializer _inventoryDataSerializer;

        public void Init(int cellsCount)
        {
            _inventoryDataSerializer = new InventoryDataSerializer();
            _cells = _inventoryDataSerializer.LoadCells();
            
            _cellsCount = cellsCount;

            if (_cells != null)
            {
                UpdateLoadedCells();
                return;
            }
            
            CellsInstall(_cellsCount);
        }

        public void AddItem(CollectibleItem item)
        {
            for (var i = 0; i < _cellsCount; ++i)
            {
                if (_cells[i].seted)
                {
                    continue;
                }

                var itemData = new ItemData
                {
                    amount = item.Amount
                };
                itemData.SetSpriteData(item.ItemSprite);

                var cell = new Cell
                {
                    itemData = itemData,
                    seted = true
                }; 
                
                _cells[i] = cell;
                
                Update?.Invoke(i, itemData, true);
                _inventoryDataSerializer.SaveCells(_cells);
                return;
            }
        }

        private void CellsInstall(int cellsCount)
        {
            _cells = new List<Cell>();
            for (var i = 0; i < cellsCount; ++i)
            {
                _cells.Add(new Cell());
            }
        }

        private void UpdateLoadedCells()
        {
            for (var i = 0; i < _cellsCount; ++i)
            {
                if (!_cells[i].seted)
                {
                    continue;
                }
                
                Update?.Invoke(i,_cells[i].itemData, true);
            }
        }

        public void RemoveItem(int index)
        {
            _cells[index] = new Cell();
            _inventoryDataSerializer.SaveCells(_cells);
            Update?.Invoke(index, null, false);
        }
    }
}
