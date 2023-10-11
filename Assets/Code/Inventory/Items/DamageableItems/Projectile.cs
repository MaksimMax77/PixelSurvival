using UnityEngine;

namespace Code.Inventory.Items.DamageableItems
{
    public class Projectile : DamageableItem
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _destroyTime;
        private Vector3 _direction;

        public void SetDirection(Vector3 dir)
        {
            _direction = dir;
        }
        private void Update()
        {
            Destroy(gameObject, _destroyTime);
            transform.position += _direction * _speed * Time.deltaTime;
        }
    }
}
