using AnkhMorporkMVC.Models;
using Moq;
using NUnit.Framework;

namespace AnkhMorporkMVC.Tests.Services
{
    public class GameEventServiceTest
    {
        [Test]
        public void StartGameEvent_IsFirstEvent_CreatesUserAndGameEntities()
        {
            var mockDb = new Mock<ApplicationDbContext>();
            //mockDb.Setup(db => db.G);
        }
    }
}
