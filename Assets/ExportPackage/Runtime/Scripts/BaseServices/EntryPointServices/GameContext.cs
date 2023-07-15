using UnityEngine;

namespace CodeFramework.Runtime.Controllers.BaseServices
{
    public interface IGameContext
    {
        IEntryPoint GameService { get; }
    }

    public abstract class GameContext : MonoBehaviour, IGameContext
    {
        public abstract IEntryPoint GameService { get; }
    }
}