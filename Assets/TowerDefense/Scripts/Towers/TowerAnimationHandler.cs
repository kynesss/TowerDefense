using System;
using TowerDefense.Scripts.Towers.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerAnimationHandler : IInitializable, IDisposable
    {
        private static int IsAttackingHash => Animator.StringToHash("IsAttacking");
        
        private readonly Animator _animator;
        private readonly SignalBus _signalBus;

        public TowerAnimationHandler(
            Animator animator, 
            SignalBus signalBus)
        {
            _animator = animator;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<TowerTargetChangedSignal>(OnTowerTargetChanged);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<TowerTargetChangedSignal>(OnTowerTargetChanged);
        }

        private void OnTowerTargetChanged(TowerTargetChangedSignal signal)
        {
            _animator.SetBool(IsAttackingHash, signal.Target != null);
        }
    }
}