using UnityEngine;

namespace TowerDefense.Scripts.Projectiles
{
    public class ProjectileAnimationHandler
    {
        private readonly Animator _animator;
        private readonly int _hitTriggerKey = Animator.StringToHash("Hit");

        public ProjectileAnimationHandler(Animator animator)
        {
            _animator = animator;
        }

        public void PlayHitAnimation()
        {
            _animator.SetTrigger(_hitTriggerKey);
        }
    }
}