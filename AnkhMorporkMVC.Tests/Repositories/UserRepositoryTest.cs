using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnkhMorporkMVC.Tests.Repositories
{
    public class UserRepositoryTest
    {
        private Mock<ApplicationDbContext> SetUpMockDb(IQueryable<UserModel> data, Mock<DbSet<UserModel>> mockDbSet)
        {
            mockDbSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockDb = new Mock<ApplicationDbContext>();
            mockDb.Setup(m => m.User).Returns(mockDbSet.Object);

            return mockDb;
        }

        [Test]
        public void Get_GetsUser()
        {
            var testModel = new UserModel(new AnkhMorporkMVC.GameLogic.GameTools.User());
            var data = new List<UserModel>() { testModel }.AsQueryable();
            var mockUserSet = new Mock<DbSet<UserModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            var testRepo = new UserRepository(mockDb.Object);

            Assert.That(testRepo.Get() == testModel);
        }

        [Test]
        public void CreateUpdate_NoUserInDb_CreatesUser()
        {
            var data = new List<UserModel>().AsQueryable();
            var mockUserSet = new Mock<DbSet<UserModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            mockDb.Setup(m => m.User.Add(It.IsAny<UserModel>())).Callback((UserModel u) => data = data.Append(u).AsQueryable());
            var testModel = new UserModel(new AnkhMorporkMVC.GameLogic.GameTools.User());
            var testRepo = new UserRepository(mockDb.Object);

            testRepo.CreateUpdate(testModel);
            
            mockDb.Verify(m => m.User.Add(It.IsAny<UserModel>()), Times.Once());
            Assert.That(data.FirstOrDefault() == testModel);
        }

        [Test]
        public void CreateUpdate_UserInDb_UpdatesUser()
        {
            var oldModel = new UserModel(new AnkhMorporkMVC.GameLogic.GameTools.User());
            var data = new List<UserModel>() { oldModel }.AsQueryable();
            var mockUserSet = new Mock<DbSet<UserModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            mockDb.Setup(m => m.User.Add(It.IsAny<UserModel>())).Callback((UserModel u) => data = data.Append(u).AsQueryable());
            var newModel = new UserModel(new AnkhMorporkMVC.GameLogic.GameTools.User(startBalancePennies:0, beers:2, moves:1));
            var testRepo = new UserRepository(mockDb.Object);

            testRepo.CreateUpdate(newModel);

            Assert.That(data.First().Moves == newModel.Moves);
            Assert.That(data.First().Beers == newModel.Beers);
            Assert.That(data.First().BalancePennies == newModel.BalancePennies);
        }

        [Test] 
        public void Delete_DeletesUser()
        {
            var testModel = new UserModel(new AnkhMorporkMVC.GameLogic.GameTools.User());
            var data = new List<UserModel>() { testModel }.AsQueryable();
            var mockUserSet = new Mock<DbSet<UserModel>>();
            var mockDb = SetUpMockDb(data, mockUserSet);
            mockDb.Setup(m => m.User.Remove(It.IsAny<UserModel>())).Callback((UserModel u) => data = data.Where(m => m != testModel));
            var testRepo = new UserRepository(mockDb.Object);

            testRepo.Delete();

            Assert.That(data.FirstOrDefault() == null);
        }
    }
}
