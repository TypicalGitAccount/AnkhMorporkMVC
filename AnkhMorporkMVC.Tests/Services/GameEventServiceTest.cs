using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Repositories;
using AnkhMorporkMVC.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AnkhMorporkMVC.Tests.Services
{
    public class GameEventServiceTest
    {
        [Test]
        public void StartGameEvent_IsFirstEvent_CreatesUserAndGameEntities()
        {
            var mockGameController = new Mock<IGameController>(MockBehavior.Loose);
            var gameEvent = new ThieveEvent();
            mockGameController.Setup(c => c.GenerateEvent(It.IsAny<List<Type>>())).Returns(gameEvent);

            var mockUserRepo = new Mock<IUserRepository>(MockBehavior.Loose);
            UserModel testUser = null;
            mockUserRepo.Setup(r => r.Get()).Returns(testUser);
            mockUserRepo.Setup(r => r.CreateUpdate(It.IsAny<UserModel>())).Callback((UserModel m) => testUser = m);

            List<GameEntity> testEntities;
            var mockEntitiesRepo = new Mock<IGameEntitiesRepository>(MockBehavior.Loose);
            mockEntitiesRepo.Setup(r => r.CreateUpdate(It.IsAny<List<GameEntity>>())).Callback((List<GameEntity> l) => testEntities = l);

            var testService = new GameEventService(mockUserRepo.Object, mockEntitiesRepo.Object, mockGameController.Object);
            testService.StartGameEvent();

            //var newUserModel = new UserModel(new User());
            //Assert.That(testUser.Moves == newUserModel.Moves);
            //Assert.That(testUser.BalancePennies == newUserModel.BalancePennies);
            //Assert.That(testUser.Beers == newUserModel.Beers);
        }
    }
}
