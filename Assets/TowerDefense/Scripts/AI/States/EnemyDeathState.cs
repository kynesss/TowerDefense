using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TowerDefense.Scripts.AI.States
{
    public class EnemyDeathState : EnemyStateEntity
    {
        private readonly EnemyStateMachine _stateMachine;
        private readonly EnemyMovementHandler _movementHandler;
        private readonly EnemyAnimationHandler _animationHandler;
        private readonly Collider2D _collider;
        private readonly Settings _settings;
        
        public EnemyDeathState(
            EnemyStateMachine stateMachine, 
            EnemyMovementHandler movementHandler, 
            EnemyAnimationHandler animationHandler, 
            Collider2D collider, Settings settings) : base(stateMachine)
        {
            _stateMachine = stateMachine;
            _movementHandler = movementHandler;
            _animationHandler = animationHandler;
            _collider = collider;
            _settings = settings;
        }

        public override void Initialize()
        {
            Debug.Log($"Initialize Death State!");
            
            _collider.enabled = false;
            _movementHandler.Stop();
            _animationHandler.PlayStateAnimation(EnemyState.Death);
            
            Object.Destroy(_stateMachine.gameObject, _settings.TimeToDestroy);
        }

        public override void Tick()
        {
            
        }

        public override void Dispose()
        {
            Debug.Log($"Dispose Death State!");
        }

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float TimeToDestroy { get; private set; } = 10f;
        }
        
        public class Factory : PlaceholderFactory<EnemyDeathState>
        {
            
        } 
    }
}