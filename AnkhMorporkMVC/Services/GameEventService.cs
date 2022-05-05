using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkMVC.Services
{
    public class GameEventService
    {
        protected IUserRepository _userRepository;
        protected IGameEntitiesRepository _entitiesRepository;

        public GameEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository)
        {
            _userRepository = userRepository;
            _entitiesRepository = entitiesRepository;
        }

        public GameLogic.GameTools.User GetUser()
        {
            return _userRepository.Get().ToObject();
        }

        public List<GameEntity> GetEntities()
        {
            var entityModels = _entitiesRepository.Get();
            List<GameEntity> entities = new List<GameEntity>(entityModels.Count);
            foreach(var entity in entityModels)
            {
                entities.Add(entity.ToObject());
            }
            return entities;
        }

        public string GetEntityImgPath()
        {
            return _entitiesRepository.Get()[0].ImagePath;
        }

        public virtual GameEntityEvent GetEvent()
        {
            return GameController.GenerateEvent(new List<Type>() { typeof(AssasinEvent) });
        }

        public virtual string StartGameEvent()
        { 
            var gameEvent = GetEvent();
            var gameEntities = gameEvent.GenerateEntities();
            if (_userRepository.Get() == null)
                _userRepository.CreateUpdate(new UserModel(new GameLogic.GameTools.User()));
            var userModel = _userRepository.Get();
            _entitiesRepository.CreateUpdate(gameEntities);
            return gameEvent.Welcome(userModel.ToObject(), gameEntities);
        }

        public virtual bool ProcessEvent(UserOption eventAnswer, out StringBuilder output)
        {
            var userModel = _userRepository.Get();
            var user = userModel.ToObject();
            if (GetEvent().Run(GetEntities(), user, eventAnswer, out output))
            {
                _userRepository.CreateUpdate(user.ToModel());
                _entitiesRepository.Delete();
                return true;
            }
            return false;
        }

        public virtual GameLogic.GameTools.User GameOver()
        {
            var user = _userRepository.Get().ToObject();
            _userRepository.Delete();
            _entitiesRepository.Delete();
            return user;
        }
    }
}
