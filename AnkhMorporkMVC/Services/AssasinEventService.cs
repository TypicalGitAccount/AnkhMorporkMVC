using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.IO;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkMVC.Services
{
    public class AssasinEventService : IAssasinEventService
    {
        protected ApplicationDbContext _context;
        protected IUserRepository _userRepository;
        protected IGameEntitiesRepository _entitiesRepository;

        public AssasinEventService(ApplicationDbContext context) {
            _context = context;
            _userRepository = new UserRepository(context);
            _entitiesRepository = new GameEntitiesRepository(context);  
        }

        public string StartGameEvent()
        {
            var gameEvent = new AssasinEvent();
            var gameEntities = gameEvent.GenerateEntities();
            if (_userRepository.Get() == null)
                _userRepository.CreateUpdate(new UserModel(new GameLogic.GameTools.User()));
            _entitiesRepository.CreateUpdate(gameEntities);
            return gameEvent.Welcome(_userRepository.Get().ToObject(), gameEntities);
        }

        public string ProcessEvent(UserOption eventAnswer)
        {
            throw new NotImplementedException();
        }

        public bool ValidateReward(string rewardInput)
        {
            return AssasinEvent.ValidRewardInput(rewardInput);
        }

        public string ProcessAssasinReward(string rewardInput, UserOption eventAnswer)
        {
            var user = _userRepository.Get().ToObject();
            var gameEntities = _entitiesRepository.Get();
            StringBuilder output;
            if (new AssasinEvent().Run(gameEntities, user, eventAnswer, out output, rewardInput))
            {
                _userRepository.CreateUpdate(user.ToModel());
                return output.ToString();
            }
            return null;
        }

        public GameLogic.GameTools.User GetUser()
        {
            return _userRepository.Get().ToObject();
        }

        public List<GameEntity> GetEntities()
        {
            return _entitiesRepository.Get();
        }

        public GameLogic.GameTools.User GameOver()
        {
            var user = _userRepository.Get().ToObject();
            _userRepository.Delete();
            _entitiesRepository.Delete();
            return user;
        }
    }
}
