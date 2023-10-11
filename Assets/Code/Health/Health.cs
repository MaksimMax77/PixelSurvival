using Code.Core;

namespace Code.Health
{
    public class Health
    {
        public float MaxHealth { get; }
        public ObservableProperty<float> CurrentHealth { get; }

        public Health(float health)
        {
            MaxHealth = health;
            CurrentHealth = new ObservableProperty<float>(health);
        }

        public void HealthRemove(float valueToRemove)
        {
            CurrentHealth.Value -= valueToRemove;
            
            if (CurrentHealth.Value <= 0)
            {
                CurrentHealth.Value = 0;
            }
        }

        public void RestoreHealth()
        {
            CurrentHealth.Value = MaxHealth;
        }
    }
}
