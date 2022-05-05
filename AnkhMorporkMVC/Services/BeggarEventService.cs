using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.Repositories;

namespace AnkhMorporkMVC.Services
{
    public class BeggarEventService : GameEventService
    {
        public BeggarEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository)
        : base(userRepository, entitiesRepository) { }

        public override GameEntityEvent GetEvent()
        {
            return new BeggarEvent();
        }
    }
}
