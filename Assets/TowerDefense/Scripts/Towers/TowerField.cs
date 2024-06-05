using System;
using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerField : MonoBehaviour
    {
        private TowerFacade.Factory _towerFactory;
        private SignalBus _signalBus;
        public TowerData CurrentTowerData { get; private set; }
        public TowerFacade CurrentTower { get; private set; }
        public bool IsEmpty => CurrentTowerData == null;

        [Inject]
        private void Construct(TowerFacade.Factory towerFactory, SignalBus signalBus)
        {
            _towerFactory = towerFactory;
            _signalBus = signalBus;
        }

        public void BuildTower(TowerData towerData)
        {
            CurrentTowerData = towerData;
            CurrentTower = _towerFactory.Create(towerData.Prefab);
            CurrentTower.SetPosition(transform.position);
            
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
