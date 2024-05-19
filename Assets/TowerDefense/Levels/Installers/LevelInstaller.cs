using System.Collections.Generic;
using TowerDefense.Waves.Scripts;
using UnityEngine;
using Zenject;

namespace TowerDefense.Levels.Installers
{
    [CreateAssetMenu(fileName = "LevelInstaller", menuName = "Installers/LevelInstaller")]
    public class LevelInstaller : ScriptableObjectInstaller<LevelInstaller>
    {
        [field: SerializeField] public List<Wave> Waves { get; private set; }
    
        public override void InstallBindings()
        {
            Container.BindInstance(Waves).IfNotBound();
        }
    }
}