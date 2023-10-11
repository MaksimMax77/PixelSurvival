using Code.Inventory.Items;
using Code.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Inventory
{
    public class InventoryView : Window
    {
        [SerializeField] private CellView[] _cellViews;
        [SerializeField] private Button _closeButton;
        public CellView[] CellViews => _cellViews;
        public int CellsLength => _cellViews.Length;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        public void OnItemCellUpdate(int index, ItemData item, bool isAdding)
        {
            if (isAdding)
            {
                OnItemAdd(index, item);
            }
            else
            {
                OnItemRemove(index);
            }
        }

        private void OnItemAdd(int index, ItemData itemData)
        {
            _cellViews[index].OnAddItem(itemData.GetSprite(), itemData.amount);
        }

        private void OnItemRemove(int index)
        {
            _cellViews[index].OnRemoveItem();
        }
    }
}
