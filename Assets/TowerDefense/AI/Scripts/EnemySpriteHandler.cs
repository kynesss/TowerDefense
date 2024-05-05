using Pathfinding;
using UnityEngine;
using Zenject;

namespace TowerDefense.AI.Scripts
{
    public class EnemySpriteHandler : ITickable
    {
        private readonly IAstarAI _ai;
        private readonly SpriteRenderer _renderer;

        public EnemySpriteHandler(IAstarAI ai, SpriteRenderer renderer)
        {
            _ai = ai;
            _renderer = renderer;
        }

        public void SetVisible(bool visible)
        {
            _renderer.enabled = visible;
        }

        public void Tick()
        {
            if (_renderer.enabled == false)
                return;

            _renderer.flipX = _ai.velocity.x < 0f;
        }
    }
}