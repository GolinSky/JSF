using UnityEngine.LevelEntity.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using Zenject;

namespace UnityEngine.ContextEntity.Project
{
    public class CustomProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(ILoadAsync), typeof(ILevelService)).To<LevelService>().AsSingle().NonLazy();
        }
    }
}
