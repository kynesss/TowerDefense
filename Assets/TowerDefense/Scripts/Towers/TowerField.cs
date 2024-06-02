using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerField : MonoBehaviour
    {
        private SignalBus _signalBus;
       
        public TowerData CurrentTowerData { get; private set; }
        public bool IsEmpty => CurrentTowerData == null;

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
            
        }

        private void Update()
        {
            if (CurrentTowerData == null)
                return;
            
            CurrentTowerData.Update();
        }

        public void BuildTower(TowerData towerData)
        {
            CurrentTowerData = towerData;
        }

        public void UpgradeTower()
        {
            Debug.Log($"Upgrade");
            
            var towerUpgrade = CurrentTowerData.Upgrade;
            BuildTower(towerUpgrade);
        }

        public void SellTower()
        {
            Debug.Log($"Sell");
        }
    }
}
