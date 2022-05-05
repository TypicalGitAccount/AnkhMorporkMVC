using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.Repositories;

namespace AnkhMorporkMVC.Services
{
    public class ThieveEventService : GameEventService
    {
        public ThieveEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository)
        : base(userRepository, entitiesRepository) {}

        public override GameEntityEvent GetEvent()
        {
            return new ThieveEvent();
        }
    }
}