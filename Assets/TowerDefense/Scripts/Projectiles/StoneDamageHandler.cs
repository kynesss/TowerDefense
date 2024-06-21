using System;
using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class StoneDamageHandler : IProjectileDamageHandler
    {
        private readonly Settings _settings;

        public StoneDamageHandler(Settings settings)
        {
            _settings = settings;
        }
        
        public void ApplyDamage(Collider2D collision)
        {
               
        }
        
        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float Damage { get; private set; } = 10f;
        }
    }
}