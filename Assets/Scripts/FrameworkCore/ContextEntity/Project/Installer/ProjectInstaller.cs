using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.MonoBehaviourEntity.Service;
using UnityEngine;
using Zenject;

namespace FrameworkCore.ContextEntity.Project.Installer
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private MonoBehaviourUpdater monoBehaviourUpdater;
        public override void InstallBindings()
        {
            Container.Bind<ILevelService>().To<LevelService>().AsSingle().NonLazy();
                //var b = Container.InstantiatePrefabForComponent<MonoBehaviourUpdater>(monoBehaviourUpdater);
           Container.Bind<IUpdater>().FromComponentInNewPrefab(monoBehaviourUpdater).AsSingle();
        }
    }
}