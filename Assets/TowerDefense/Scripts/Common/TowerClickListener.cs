using System;
using System.Collections.Generic;
using TowerDefense.Scripts.Common.Signals;
using TowerDefense.Scripts.Towers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TowerDefense.Scripts.Common
{
    public class TowerClickListener : ITickable
    {
        private readonly SignalBus _signalBus;
        private readonly Settings _settings;

        public TowerClickListener(SignalBus signalBus, Settings settings)
        {
            _signalBus = signalBus;
            _settings = settings;
        }

        public void Tick()
        {
            if (Input.touchCount == 0)
                return;

            var touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Began)
                return;
            
            var ray = Camera.main!.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin,  ray.direction, Mathf.Infinity, _settings.TowerLayer);

            TowerField towerField = null;
            
            if (hit.collider != null) 
                towerField = hit.collider.GetComponent<TowerField>();
            
            _signalBus.Fire(new TowerClickedSignal(towerField));
        }
        
        [Serializable]
        public class Settings
        {
            [field: SerializeField] public LayerMask TowerLayer { get; private set; }
        }
    }
}