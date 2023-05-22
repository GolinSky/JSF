using CodeFramework.Runtime.BaseServices;

namespace CodeFramework
{
    public class SimpleGameContext : GameContext
    {
        public override IGameService GameService => new SimpleGameService();
    }
}
