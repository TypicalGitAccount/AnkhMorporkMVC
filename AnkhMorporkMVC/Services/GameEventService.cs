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
    public class GameEventService : IGameEventService
    {
        protected IUserRepository _userRepository;
        protected IGameEntitiesRepository _entitiesRepository;
        protected IGameController _gameController;

        public GameEventService(IUserRepository userRepository, IGameEntitiesRepository entitiesRepository, IGameController gameController)
        {
            _userRepository = userRepository;
            _entitiesRepository = entitiesRepository;
            _gameController = gameController;   
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

        public string StartGameEvent()
        {
            var gameEvent = _gameController.GenerateEvent(new List<Type>() { typeof(AssasinEvent) });
            var gameEntities = gameEvent.GenerateEntities();
            if (_userRepository.Get() == null)
                _userRepository.CreateUpdate(new UserModel(new GameLogic.GameTools.User()));
            var userModel = _userRepository.Get();
            _entitiesRepository.CreateUpdate(gameEntities);
            System.Web.HttpContext.Current.Session["EventType"] = gameEvent.GetType().ToString();
            return gameEvent.Welcome(userModel.ToObject(), gameEntities);
        }

        public bool ProcessEvent(UserOption eventAnswer, out StringBuilder output)
        {
            var userModel = _userRepository.Get();
            var eventTypeName = (string)System.Web.HttpContext.Current.Session["EventType"];
            var gameEvent = (GameEntityEvent)Type.GetType(eventTypeName).GetConstructor(new Type[] { }).Invoke(new object[] { });
            var user = userModel.ToObject();
            if (gameEvent.Run(GetEntities(), user, eventAnswer, out output))
            {
                _userRepository.CreateUpdate(user.ToModel());
                _entitiesRepository.Delete();
                return true;
            }
            return false;
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
