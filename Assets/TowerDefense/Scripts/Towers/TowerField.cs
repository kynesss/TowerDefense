using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerField : MonoBehaviour
    {
        private TowerFacade.Factory _towerFactory;
        public TowerData CurrentTowerData { get; private set; }
        public TowerFacade CurrentTower { get; private set; }
        public bool IsEmpty => CurrentTowerData == null;

        [Inject]
        private void Construct(TowerFacade.Factory towerFactory)
        {
            _towerFactory = towerFactory;
        }

        public void BuildTower(TowerData towerData)
        {
            CurrentTowerData = towerData;
            CurrentTower = _towerFactory.Create(towerData.Prefab);
            CurrentTower.SetPosition(transform.position);
        }

        public void UpgradeTower()
        {
            DestroyCurrentTower();
            BuildTower(CurrentTowerData.Upgrade);
        }

        public void SellTower()
        {
            DestroyCurrentTower();
        }

        private void DestroyCurrentTower()
        {
            Destroy(CurrentTower.gameObject);
        }
    }
}
