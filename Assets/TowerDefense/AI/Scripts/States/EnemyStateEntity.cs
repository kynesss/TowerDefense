using System;
using Zenject;

namespace TowerDefense.AI.Scripts.States
{
    public abstract class EnemyStateEntity : IInitializable, ITickable, IDisposable
    {
        protected readonly EnemyStateMachine StateMachine;
        protected EnemyStateEntity(EnemyStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public abstract void Initialize();
        public abstract void Tick();
        public abstract void Dispose();
    }
}