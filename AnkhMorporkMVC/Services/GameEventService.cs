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
        protected ApplicationDbContext _context { get; set; }
        protected IUserRepository _userRepository;
        protected IGameEntitiesRepository _entitiesRepository;

        public GameEventService(ApplicationDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(context);
            _entitiesRepository = new GameEntitiesRepository(context);
        }

        public GameLogic.GameTools.User GetUser()
        {
            return _userRepository.Get().ToObject();
        }

        public List<GameEntity> GetEntities()
        {
            return _entitiesRepository.Get();
        }

        public string StartGameEvent()
        {
            var gameEvent = WebGameController.GenerateEvent(except: new List<Type>() { typeof(AssasinEvent) });
            var gameEntities = gameEvent.GenerateEntities();
            if (_userRepository.Get() == null)
                _userRepository.CreateUpdate(new UserModel(new GameLogic.GameTools.User()));
            var userModel = _userRepository.Get();
            _entitiesRepository.CreateUpdate(gameEntities);
            System.Web.HttpContext.Current.Session["EventType"] = gameEvent.GetType().ToString();
            return gameEvent.Welcome(userModel.ToObject(), gameEntities);
        }

        public string ProcessEvent(UserOption eventAnswer)
        {
            var userModel = _userRepository.Get();
            var eventTypeName = (string)System.Web.HttpContext.Current.Session["EventType"];
            var gameEvent = (GameEntityEvent)Type.GetType(eventTypeName).GetConstructor(new Type[] { }).Invoke(new object[] { });
            StringBuilder output;
            var user = userModel.ToObject();
            if (gameEvent.Run(_entitiesRepository.Get(), user, eventAnswer, out output))
            {
                _userRepository.CreateUpdate(user.ToModel());
                _entitiesRepository.Delete();
                return output.ToString();
            }
            return null;
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
