using UnityEngine;

namespace TowerDefense.AI.Scripts
{
    public interface IEnemyMovementHandler
    {
        void MoveTo(Vector3 destination);
        void Stop();
    }
}