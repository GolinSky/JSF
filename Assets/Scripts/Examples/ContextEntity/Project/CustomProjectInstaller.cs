using UnityEngine.Examples.SerializerEntity;
using UnityEngine.LevelEntity.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SerializerService;
using Zenject;

namespace UnityEngine.Examples.ContextEntity.Project
{
    public class CustomProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(ILoadAsync), typeof(ILevelService)).To<LevelService>().AsSingle().NonLazy();
            Container.Bind<ISerializerService>()
                .To<JsonNewtonsoftSerializer>()
                .AsSingle();
        }
    }
}
