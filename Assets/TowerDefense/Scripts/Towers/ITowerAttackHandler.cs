using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public interface ITowerAttackHandler : ITickable
    {
        bool CanAttack { get; }
        void SpawnProjectile();
    }
}