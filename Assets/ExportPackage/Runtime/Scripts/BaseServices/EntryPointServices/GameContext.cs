using UnityEngine;

namespace CodeFramework.Runtime.BaseServices
{
    public interface IGameContext
    {
        IGameService GameService { get; }
    }

    public abstract class GameContext : MonoBehaviour, IGameContext
    {
        public abstract IGameService GameService { get; }
    }
}