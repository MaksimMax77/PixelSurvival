using System;
using System.Collections.Generic;

namespace Code.SubscribeSystem
{
    public class SubscribeManager: IDisposable
    {
        private Dictionary<Type, Delegate> _delegates = new Dictionary<Type, Delegate>();

        public void AddDelegate(Type type, Delegate @delegate)
        {
            _delegates.Add(type, @delegate);
        }
        
        public void Dispose()
        {
        }
    }
}
