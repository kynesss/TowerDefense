using TowerDefense.Scripts.AI;
using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class ArrowDamageHandler : IProjectileDamageHandler
    {
        public void ApplyDamage(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyStateMachine>(out var enemy))
            {
                enemy.TakeDamage(10f);
            }
        }
    }
}