using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.Repositories;
using System;
using System.Text;

namespace AnkhMorporkMVC.Services
{
    public class AssasinEventService : GameEventService
    {
        public AssasinEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository) : base(userRepository, entitiesRepository) { }

        public override GameEntityEvent GetEvent()
        {
            return new AssasinEvent();
        }

        public override bool ProcessEvent(UserOption eventAnswer, out StringBuilder output)
        {
            throw new NotImplementedException();
        }

        public bool ValidateReward(string rewardInput)
        {
            return AssasinEvent.ValidRewardInput(rewardInput);
        }

        public bool ProcessAssasinReward(string rewardInput, UserOption eventAnswer, out StringBuilder output)
        {
            var user = _userRepository.Get().ToObject();
            var gameEntities = GetEntities();
            if (new AssasinEvent().Run(gameEntities, user, eventAnswer, out output, rewardInput))
            {
                _userRepository.CreateUpdate(user.ToModel());
                return true;
            }
            return false;
        }
    }
}
