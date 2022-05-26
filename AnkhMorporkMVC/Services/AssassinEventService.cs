using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.Repositories;
using System;
using System.Text;

namespace AnkhMorporkMVC.Services
{
    public class AssassinEventService : GameEventService
    {
        public AssassinEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository) : base(userRepository, entitiesRepository) { }

        public override GameEntityEvent GetEvent()
        {
            return new AssassinEvent();
        }

        public override bool ProcessEvent(UserOption eventAnswer, out StringBuilder output)
        {
            throw new NotImplementedException();
        }

        public bool ValidateReward(string rewardInput)
        {
            return AssassinEvent.ValidRewardInput(rewardInput);
        }

        public bool ProcessAssassinReward(string rewardInput, UserOption eventAnswer, out StringBuilder output)
        {
            var user = _userRepository.Get().FillProperties();
            var gameEntities = GetEntities();
            if (new AssassinEvent().Run(gameEntities, user, eventAnswer, out output, rewardInput))
            {
                _userRepository.CreateUpdate(user.ToModel());
                return true;
            }
            return false;
        }
    }
}
