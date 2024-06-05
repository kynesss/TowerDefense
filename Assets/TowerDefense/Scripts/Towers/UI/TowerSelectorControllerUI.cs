using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers.UI
{
    public class TowerSelectorControllerUI : MonoBehaviour
    {
        [SerializeField] private TowerSelectorUI selector;
        
        private TowerField _selectedTower;
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            selector.Hide();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<TowerClickedSignal>(OnTowerClicked);
            _signalBus.Subscribe<TowerBuiltSignal>(OnTowerBuilt);
            _signalBus.Subscribe<TowerSoldSignal>(OnTowerSold);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<TowerClickedSignal>(OnTowerClicked);
            _signalBus.Unsubscribe<TowerBuiltSignal>(OnTowerBuilt);
            _signalBus.Unsubscribe<TowerSoldSignal>(OnTowerSold);
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

        private void OnTowerBuilt()
        {
            DeselectField();
        }

        private void OnTowerSold()
        {
            DeselectField();
        }

        private void SelectField(TowerField towerField)
        {
            selector.Show(towerField);
            _selectedTower = towerField;
        }

        private void DeselectField()
        {
            selector.Hide();
            _selectedTower = null;
        }
    }
}
