using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public interface IProjectileDamageHandler
    {
        void ApplyDamage(Collider2D collision);
    }
}