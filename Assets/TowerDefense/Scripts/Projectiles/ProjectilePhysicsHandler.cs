using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class ProjectilePhysicsHandler
    {
        private readonly Rigidbody2D _rigidbody;

        public ProjectilePhysicsHandler(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void SetPhysicsEnabled(bool enable)
        {
            _rigidbody.simulated = enable;
        }

        public void SetVelocity(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }
    }
}