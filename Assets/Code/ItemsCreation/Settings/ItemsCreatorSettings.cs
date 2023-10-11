using UnityEngine;

namespace Code.ItemsCreation.Settings
{
    [CreateAssetMenu(order = 4, fileName = "ItemsCreatorSettings", menuName = "ItemsCreatorSettings")]
    public class ItemsCreatorSettings: ScriptableObject
    {
        [SerializeField] private GameObject[] _gameObjects;
        public GameObject[] GameObjects => _gameObjects;
    }
}
