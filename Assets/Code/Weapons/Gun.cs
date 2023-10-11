using Code.Inventory.Items.DamageableItems;
using UnityEngine;

namespace Code.Weapons
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject _effect;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _projectilePos;
        public GameObject Effect => _effect;
        public Projectile Projectile => _projectile;
        public Transform ProjectilePos => _projectilePos;
    }
}
