using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Ankh_Morpork.Tests.Events
{
    public class ThieveEventTest
    {
        private Mock<ThieveEvent> mockEvent;

        [SetUp]
        public void SetUp()
        {
            mockEvent = new Mock<ThieveEvent>() { CallBase = true };
        }

        [Test]
        public void Run_UserAcceptedScenario_ReturnsTrue()
        {
            var testThieve = new Thieve("TestDummy");
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testThieve });
            StringBuilder output;
            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(),
                UserOption.Yes, out output);

            Assert.IsTrue(result);
        }

        [Test]
        public void Run_UserAcceptedScenarioDutNotEnoughMoney_ReturnsFalse()
        {
            var testThieve = new Thieve("TestDummy");
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testThieve });
            StringBuilder output;
            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(startBalancePennies: 1),
                UserOption.Yes, out output);

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_UserRejectedScenario_ReturnsFalse()
        {
            var testThieve = new Thieve("TestDummy");
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testThieve });
            StringBuilder output;
            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(), UserOption.No, out output);

            Assert.IsFalse(result);
        }
    }
}
