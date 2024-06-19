namespace TowerDefense.Scripts.AI.Signals
{
    public class EnemyHealthChangedSignal
    {
        public float LastHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public EnemyHealthChangedSignal(float lastHealth, float currentHealth)
        {
            LastHealth = lastHealth;
            CurrentHealth = currentHealth;
        }
    }
}