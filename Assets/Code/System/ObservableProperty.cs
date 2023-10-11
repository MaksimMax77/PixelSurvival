namespace Code.Core
{
    public class ObservableProperty<T>
    {
        public delegate void OldNewValuesDelegate(T oldValue, T newValue);

        public event OldNewValuesDelegate OnChange;

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                var oldValue = _value;
                _value = value;
                OnChange?.Invoke(oldValue, _value);
            }
        }

        public ObservableProperty(T value)
        {
            _value = value;
        }
    }
}