using Code.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Windows
{
    public class GameWindow : Window
    {
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private InventoryView _inventoryView;

        private void Awake()
        {
            _inventoryButton.onClick.AddListener(_inventoryView.Open);
        }

        private void OnDestroy()
        {
            _inventoryButton.onClick.RemoveListener(_inventoryView.Open);
        }
    }
}
