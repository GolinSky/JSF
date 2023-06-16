using CodeFramework.Runtime.BaseServices;

namespace CodeFramework
{
    public class SimpleGameContext : GameContext
    {
        public override IEntryPoint GameService => new SimpleGameService();
    }
}
