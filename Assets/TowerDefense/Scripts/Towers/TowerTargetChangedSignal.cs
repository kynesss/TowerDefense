using JetBrains.Annotations;
using UnityEngine;

namespace TowerDefense.Scripts.Towers
{
    public class TowerTargetChangedSignal
    {
        [CanBeNull] public Transform Target { get; private set; }

        public TowerTargetChangedSignal(Transform target)
        {
            Target = target;
        }
    }
}