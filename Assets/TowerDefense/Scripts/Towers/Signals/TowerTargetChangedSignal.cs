﻿using JetBrains.Annotations;
using TowerDefense.Scripts.AI;

namespace TowerDefense.Scripts.Towers.Signals
{
    public class TowerTargetChangedSignal
    {
        [CanBeNull] public EnemyStateMachine Target { get; private set; }

        public TowerTargetChangedSignal(EnemyStateMachine target)
        {
            Target = target;
        }
    }
}