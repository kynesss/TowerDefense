using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorControllerUI : MonoBehaviour
    {
        private TowerSelectorUI _selector;
        private TowerField _selectedTower;
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Awake()
        {
            _selector = GetComponentInChildren<TowerSelectorUI>();
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
            _selector.Setup(towerField);
            _selectedTower = towerField;
        }

        private void DeselectField()
        {
            _selector.Hide();
            _selectedTower = null;
        }
    }
}
