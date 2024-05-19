using TowerDefense.Scripts.AI.States;
using UnityEngine;

namespace TowerDefense.Scripts.AI
{
    public class EnemyAnimationHandler
    {
        private static int WalkAnimationHash => Animator.StringToHash("IsWalking");
        private static int AttackAnimationHash => Animator.StringToHash("IsAttacking");
        private static int DeathAnimationHash => Animator.StringToHash("Die");
        
        private readonly Animator _animator;

        public EnemyAnimationHandler(Animator animator)
        {
            _animator = animator;
        }

        public void PlayStateAnimation(EnemyState state)
        {
            var isWalking = state is EnemyState.Walk or EnemyState.Follow;
            var isAttacking = state is EnemyState.Attack;
            var isDead = state is EnemyState.Death;
            
            _animator.SetBool(WalkAnimationHash, isWalking);
            _animator.SetBool(AttackAnimationHash, isAttacking);

            if (isDead)
            {
                _animator.SetTrigger(DeathAnimationHash);
            }
        }
    }
}