using System;
using Code.Inventory.Items;
using Code.Inventory.Items.DamageableItems;
using UnityEngine;

namespace Code.Trigger
{
    public class TriggerControl : MonoBehaviour
    {
        public event Action<CollectibleItem> CollectibleItemTrigger;
        public event Action<DamageableItem> DamageableItemTrigger;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (TryGetItemType<CollectibleItem>(col.gameObject, out var collectibleItem))
            {
                CollectibleItemTrigger?.Invoke(collectibleItem);
            }

            if (TryGetItemType<DamageableItem>(col.gameObject, out var damageableItem))
            {
                DamageableItemTrigger?.Invoke(damageableItem);
            }
        }

        private bool TryGetItemType<T>(GameObject obj, out T t) where T: MonoBehaviour
        {
            var item = obj.GetComponent<T>();
            t = item;
            return item != null;
        }
    }
}
