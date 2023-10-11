using System.Collections.Generic;

namespace Code.ActionsSystem
{
    public class Blackboard
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();
        public void AddData(string key, object value)
        {
            if (_data.TryAdd(key, value))
            {
                return;
            }
            OverwriteData(key, value);
        }

        public void RemoveData(string key)
        {
            _data.Remove(key);
        }

        public bool TryGetData<T>(string key, out T t)
        {
            if (_data.TryGetValue(key, out var value))
            {
                t = (T)value; 
                return true;
            }

            t = default;
            return false;
        }
        private void OverwriteData(string key, object newValue)
        {
            if (!_data.TryGetValue(key, out var value))
            {
                return;
            }

            value = newValue;
        }
    }
}
