using System;
using TowerDefense.AI.Scripts;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EnemySettingsInstaller", menuName = "Installers/EnemySettingsInstaller")]
public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
{
    public EnemySettings Settings;
    
    public override void InstallBindings()
    {
        Container.BindInstance(Settings.SomeSettings).IfNotBound();
    }

    [Serializable]
    public class EnemySettings
    {
        public Enemy.Settings SomeSettings;
    }
}