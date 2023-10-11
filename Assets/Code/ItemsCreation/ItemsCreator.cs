using Code.GOControl;
using Code.ItemsCreation.Settings;
using Code.SpawnSystem;
using UnityEngine;
using Zenject;

namespace Code.ItemsCreation
{
    public class ItemsCreator
    {
        private SquareZone _squareZone;
        private ItemsCreatorSettings _itemsCreatorSettings;
        private GameObjectsControl _gameObjectsControl;
        
        [Inject]
        public ItemsCreator(GameObjectsControl gameObjectsControl, SquareZone squareZone, ItemsCreatorSettings itemsCreatorSettings)
        {
            _squareZone = squareZone;
            _gameObjectsControl = gameObjectsControl;
            _itemsCreatorSettings = itemsCreatorSettings;
            CreateObjects();
        }

        public void CreateRandomItem(Vector3 pos)
        {
            var randomIndex = Random.Range(0, _itemsCreatorSettings.GameObjects.Length);
            var item = _gameObjectsControl.GoInstantiate(ObjectType.Item,_itemsCreatorSettings.GameObjects[randomIndex]);
            item.transform.position = pos;
        }
        private void CreateObjects()
        {
            for (int i = 0, len = _itemsCreatorSettings.GameObjects.Length; i < len; ++i)
            {
                var obj = _gameObjectsControl.GoInstantiate(ObjectType.Item, _itemsCreatorSettings.GameObjects[i]);
                obj.transform.position = _squareZone.GetRandomPosInSquare();
            }
        }
    }
}
