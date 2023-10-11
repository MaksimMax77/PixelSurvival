using UnityEngine;

namespace Code.Inventory.Items.DamageableItems
{
    public class DamageableItem : MonoBehaviour
    {
        [SerializeField] private float _damage;
        public float Damage => _damage;
    }
}
