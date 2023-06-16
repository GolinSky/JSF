using UnityEngine;

namespace CodeFramework.Runtime.BaseServices
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