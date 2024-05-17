using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Common.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform destination;
        public override void InstallBindings()
        {
            
        }
    }
}