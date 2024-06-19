using TowerDefense.Scripts.AI.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TowerDefense.Scripts.AI.UI
{
    public class EnemyHealthUI : MonoBehaviour
    {
        private Canvas _canvas;
        private Image _healthBarImage;
        private SignalBus _signalBus;
        
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _healthBarImage = GetComponentInChildren<Image>();
        }

        private void Start()
        {
            _canvas.worldCamera = Camera.main;
        }

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<EnemyHealthChangedSignal>(OnEnemyHealthChanged);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<EnemyHealthChangedSignal>(OnEnemyHealthChanged);
        }

        private void OnEnemyHealthChanged(EnemyHealthChangedSignal signal)
        {
            _healthBarImage.fillAmount = signal.CurrentHealth / 100f;
        }
    }
}