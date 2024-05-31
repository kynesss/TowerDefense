using System;
using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerField : MonoBehaviour
    {
        private SignalBus _signalBus;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        
        public Tower CurrentTower { get; private set; }
        public bool IsEmpty => CurrentTower == null;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
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
            if (CurrentTower == null)
                return;
            
            CurrentTower.Update();
        }

        public void BuildTower(Tower tower)
        {
            if (tower == null)
            {
                Debug.LogError($"Tower is null");
                return;
            }

            _spriteRenderer.sprite = tower.TowerSprite;
            //_animator.runtimeAnimatorController = tower.AnimatorController;
            
            CurrentTower = tower;
        }

        public void UpgradeTower()
        {
            var towerUpgrade = CurrentTower.Upgrade;
            BuildTower(towerUpgrade);
        }

        public void DemolishTower()
        {
            
        }
    }
}
