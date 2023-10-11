using UnityEngine;

namespace Code.Inventory.Items
{
    public class CollectibleItem : MonoBehaviour
    {
        [SerializeField] private Sprite _itemSprite;
        [SerializeField] private int _amount;
        public Sprite ItemSprite => _itemSprite;
        public int Amount => _amount;
    }
}
