using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.Repositories;

namespace AnkhMorporkMVC.Services
{
    public class PubEventService : GameEventService
    {
        public PubEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository)
        : base(userRepository, entitiesRepository) { }

        public override GameEntityEvent GetEvent()
        {
            return new PubEvent();
        }
    }
}