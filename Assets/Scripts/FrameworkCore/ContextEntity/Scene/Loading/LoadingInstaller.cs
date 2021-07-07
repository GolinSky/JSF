using FrameworkCore.BaseServices.SceneService.View;
using FrameworkCore.Patterns.MVC.Controller;
using UnityEngine;
using Zenject;

namespace FrameworkCore.ContextEntity.Scene.Loading
{
    public class LoadingInstaller : MonoInstaller
    {
        [SerializeField] private LevelView levelView;
        public override void InstallBindings()
        {
            Container.Bind<IController>().To<LevelController>().WithArguments(levelView).WhenInjectedInto<LevelView>();
        }
    }
}