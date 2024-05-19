using System.Collections.Generic;
using TowerDefense.Scripts.Waves;
using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Levels.Installers
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