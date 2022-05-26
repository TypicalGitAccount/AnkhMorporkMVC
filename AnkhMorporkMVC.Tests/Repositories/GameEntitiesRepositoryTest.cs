using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkMVC.Tests.Repositories
{
    public class GameEntitiesRepositoryTest
    {
        private Mock<ApplicationDbContext> SetUpMockDb(IQueryable<GameEntityModel> data, Mock<DbSet<GameEntityModel>> mockDbSet)
        {
            mockDbSet.As<IQueryable<GameEntityModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<GameEntityModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<GameEntityModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<GameEntityModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockDb = new Mock<ApplicationDbContext>();
            mockDb.Setup(m => m.GameEntities).Returns(mockDbSet.Object);

            return mockDb;
        }

        [Test]
        public void Get_GetsEntities()
        {
            var testModel = new Thieve("TestDummy").ToModel();
            var data = new List<GameEntityModel>() { testModel }.AsQueryable();
            var mockUserSet = new Mock<DbSet<GameEntityModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            var testRepo = new GameEntitiesRepository(mockDb.Object);


            Assert.That(testRepo.Get()[0] == testModel);
        }

        [Test]
        public void CreateUpdate_NoEntitiesInDb_CreatesEntities()
        {
            var data = new List<GameEntityModel>().AsQueryable();
            var mockUserSet = new Mock<DbSet<GameEntityModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            mockDb.Setup(m => m.GameEntities.Add(It.IsAny<GameEntityModel>())).Callback((GameEntityModel g) => data = data.Append(g).AsQueryable());
            var testModels = new List<GameEntity>() { new Thieve("TestDummy") };
            var testRepo = new GameEntitiesRepository(mockDb.Object);

            testRepo.CreateUpdate(testModels);
            mockDb.Verify(m => m.GameEntities.Add(It.IsAny<GameEntityModel>()), Times.Once());

            var dbObj = data.FirstOrDefault().FillProperties();
            Assert.That(dbObj.State.Name == testModels[0].State.Name);
            Assert.That(dbObj.State.InteractionCostPennies == testModels[0].State.InteractionCostPennies);
        }

        [Test]
        public void CreateUpdate_EntitiesInDb_UpdatesGameEntities()
        {
            var oldModel = new Thieve("TestDummy").ToModel();
            var data = new List<GameEntityModel>() { oldModel }.AsQueryable();
            var mockUserSet = new Mock<DbSet<GameEntityModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            mockDb.Setup(m => m.GameEntities.Add(It.IsAny<GameEntityModel>())).Callback((GameEntityModel u) => data = data.Append(u).AsQueryable());
            mockDb.Setup(m => m.GameEntities.RemoveRange(It.IsAny<IEnumerable<GameEntityModel>>()))
                .Callback((IEnumerable<GameEntityModel> oldModels) => data = data.Except(oldModels));
            var newObj = new Assassin(1, 100, "testAssasin", false);
            var testRepo = new GameEntitiesRepository(mockDb.Object);

            testRepo.CreateUpdate(new List<GameEntity>() { newObj });

            Assert.That(data.Count() == 1);
            Assert.That(data.FirstOrDefault().FillProperties().State is AssasinState);
        }

        [Test]
        public void Delete_DeletesUser()
        {
            var data = new List<GameEntityModel>() { new Thieve("TestDummy").ToModel() }.AsQueryable();
            var mockUserSet = new Mock<DbSet<GameEntityModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            mockDb.Setup(m => m.GameEntities.RemoveRange(It.IsAny<IEnumerable<GameEntityModel>>()))
                .Callback((IEnumerable<GameEntityModel> oldModels) => data = data.Except(oldModels));
            var testRepo = new GameEntitiesRepository(mockDb.Object);

            testRepo.Delete();

            Assert.That(data.FirstOrDefault() == null);
        }
    }
}
