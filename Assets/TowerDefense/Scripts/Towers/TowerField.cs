using TowerDefense.Scripts.Common.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Towers
{
    public class TowerField : MonoBehaviour
    {
        private SignalBus _signalBus;

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
            if (signal.Field != this)
                return;
            
            Debug.Log($"Tower: {gameObject.name}");
        }
    }
}
