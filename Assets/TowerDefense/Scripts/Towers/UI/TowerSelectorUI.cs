using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorUI : MonoBehaviour
    {
        [SerializeField] private TowerSelectorEntryUI selectorEntry;
        
        private SignalBus _signalBus;
        private TowerField _selectedTower;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        private void OnEnable()
        {
            _signalBus.Subscribe<TowerClickedSignal>(OnTowerClicked);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<TowerClickedSignal>(OnTowerClicked);
        }

        private void OnTowerClicked(TowerClickedSignal signal)
        {
            var towerField = signal.Field;
            
            if (towerField == null)
            {
                DeselectField();
            }
            else if (towerField != _selectedTower)
            {
                SelectField(towerField);
            }
        }

        private void SelectField(TowerField towerField)
        {
            selectorEntry.Show(towerField);
            _selectedTower = towerField;
        }

        private void DeselectField()
        {
            selectorEntry.Hide();
            _selectedTower = null;
        }
    }
}
