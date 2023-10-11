using UnityEngine;

namespace Code.GOControl
{
    public enum ObjectType
    {
        Unit, 
        Item,
        Projectile,
        Camera
    }
    
    public class GameObjectsControl: MonoBehaviour
    {
        [SerializeField] private GameObjectsParent[] _parents;
        public GameObject GoInstantiate(ObjectType objectType, GameObject prefab)
        {
            var obj = Instantiate(prefab);
            SetParent(objectType, obj.transform);
            return obj;
        }
        public T GoInstantiate<T>(ObjectType objectType, T prefab) where T: Behaviour
        {
            var obj = Instantiate(prefab);
            SetParent(objectType, obj.gameObject.transform);
            return obj;
        }
        
        public void SetActive(ObjectType objectType, GameObject obj, bool active)
        {
           var parent = GetParentObjectByType(objectType);
            obj.SetActive(active);
            obj.transform.SetParent(active ? parent.EnabledParent : parent.DisabledParent);
        }

        private void SetParent(ObjectType objectType, Transform objTransform)
        {
            for (int i = 0, len = _parents.Length; i < len; ++i)
            {
                if (_parents[i].ObjectType != objectType)
                {
                    continue;
                }
                objTransform.SetParent(_parents[i].EnabledParent);
                return;
            }
        }

        private GameObjectsParent GetParentObjectByType(ObjectType objectType)
        {
            for (int i = 0, len = _parents.Length; i < len; ++i)
            {
                if (_parents[i].ObjectType != objectType)
                {
                    continue;
                }
                return _parents[i];
            }

            return null;
        }
    }
}
