using TowerDefense.Scripts.Towers;

namespace TowerDefense.Scripts.Common.Signals
{
    public class TowerClickedSignal
    {
        public TowerField Field { get; private set; }

        public TowerClickedSignal(TowerField field)
        {
            Field = field;
        }
    }
}