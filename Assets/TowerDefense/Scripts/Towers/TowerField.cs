using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerField : MonoBehaviour
    {
        private TowerFacade.Factory _towerFactory;
        private SignalBus _signalBus;
        private Transform _towerParent;
        public TowerData CurrentTowerData { get; private set; }
        public TowerFacade CurrentTower { get; private set; }
        public bool IsEmpty => CurrentTowerData == null;

        [Inject]
        private void Construct(
            TowerFacade.Factory towerFactory,
            SignalBus signalBus,
            [Inject(Id = "TowerParent")] Transform towerParent)
        {
            _towerFactory = towerFactory;
            _signalBus = signalBus;
            _towerParent = towerParent;
        }

        public void BuildTower(TowerData towerData)
        {
            CurrentTowerData = towerData;
            
            CurrentTower = _towerFactory.Create(towerData.Prefab);
            CurrentTower.SetParentAndPosition(_towerParent, transform.position);

            _signalBus.Fire<TowerBuiltSignal>();
        }

        public void UpgradeTower()
        {
            DestroyCurrentTower();
            BuildTower(CurrentTowerData.Upgrade);
        }

        public void SellTower()
        {
            DestroyCurrentTower();
            CurrentTowerData = null;
            CurrentTower = null;

            _signalBus.Fire<TowerSoldSignal>();
        }

        private void DestroyCurrentTower()
        {
            Destroy(CurrentTower.gameObject);
        }
    }
}