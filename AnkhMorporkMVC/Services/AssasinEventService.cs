using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.Entities;
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
        protected IUserRepository _userRepository;
        protected IGameEntitiesRepository _entitiesRepository;

        public AssasinEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository) {
            _userRepository = userRepository;
            _entitiesRepository = entitiesRepository;  
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

        public bool ProcessEvent(UserOption eventAnswer, out StringBuilder output)
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

        public GameLogic.GameTools.User GetUser()
        {
            return _userRepository.Get().ToObject();
        }

        public List<GameEntity> GetEntities()
        {
            var entityModels = _entitiesRepository.Get();
            List<GameEntity> entities = new List<GameEntity>(entityModels.Count);
            foreach (var entity in entityModels)
            {
                entities.Add(entity.ToObject());
            }
            return entities;
        }

        public string GetEntityImgPath()
        {
            return _entitiesRepository.Get()[0].ImagePath;
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
