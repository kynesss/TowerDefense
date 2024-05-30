using JetBrains.Annotations;
using TowerDefense.Scripts.Towers;

namespace TowerDefense.Scripts.Common.Signals
{
    public class TowerClickedSignal
    {
        [CanBeNull] public TowerField Field { get; private set; }

        public TowerClickedSignal(TowerField field)
        {
            Field = field;
        }
    }
}