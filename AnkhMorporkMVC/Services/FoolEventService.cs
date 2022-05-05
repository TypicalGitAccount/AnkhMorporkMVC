using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.Repositories;

namespace AnkhMorporkMVC.Services
{
    public class FoolEventService : GameEventService
    {
        public FoolEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository)
        : base(userRepository, entitiesRepository) { }

        public override GameEntityEvent GetEvent()
        {
            return new FoolEvent();
        }
    }
}