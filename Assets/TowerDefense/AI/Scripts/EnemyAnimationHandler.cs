using System;
using TowerDefense.AI.Scripts.Signals;
using TowerDefense.Scripts.AI.States;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts
{
    public class EnemyAnimationHandler : IInitializable, IDisposable
    {
        private readonly Animator _animator;
        private readonly SignalBus _signalBus;
        private int AttackKey => Animator.StringToHash("IsAttacking");
        private int DieKey => Animator.StringToHash("Die");
        private int GetHitKey => Animator.StringToHash("GetHit");
        
        public EnemyAnimationHandler(Animator animator, SignalBus signalBus)
        {
            _animator = animator;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EnemyStateChangedSignal>(OnEnemyStateChanged);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EnemyStateChangedSignal>(OnEnemyStateChanged);
        }

        private void OnEnemyStateChanged(EnemyStateChangedSignal signal)
        {
            Debug.Log($"Current state: {signal.CurrentState} Previous State: {signal.PreviousState}");
            var currentState = signal.CurrentState;
            
            if (currentState == EnemyState.Death)
                _animator.SetTrigger(DieKey);
            
            _animator.SetBool(AttackKey, currentState == EnemyState.Attack);
        }
    }
}
