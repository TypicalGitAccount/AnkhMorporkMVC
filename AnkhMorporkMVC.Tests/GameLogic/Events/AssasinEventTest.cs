using AnkhMorporkMVC.GameLogic.Entities;
using Moq;
using NUnit.Framework;
using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkMVC.Tests.GameLogic.Events
{
    public class AssasinEventTest
    {
        private Mock<AssasinEvent> mockEvent;
        private StringBuilder output;

        [SetUp]
        public void SetUp()
        {
            mockEvent = new Mock<AssasinEvent>() { CallBase = true };
            output = new StringBuilder();
        }

        [Test]
        public void Run_EventAcceptedAndRewardGuessed_ReturnsTrue()
        {
            var testAssasin = new Assasin(rewardMinPennies: 1, rewardMaxPennies: 1000, "testDummy", false);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testAssasin });
            var input = "5";

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(),
                UserOption.Yes, out output, input);

            Assert.IsTrue(result);
        }

        [Test]
        public void Run_EventAcceptedAndRewardGuessedButNotEnoughMoney_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 10, rewardMaxPennies: 1000, "testDummy", false);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testAssasin });
            var input = "5";

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(startBalancePennies:1),
                UserOption.Yes, out output, input);

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_EventAcceptedButAssasinOccupied_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 10, rewardMaxPennies: 1000, "testDummy", isOccupied: true);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testAssasin } );
            var input = "5.02";

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(),
                UserOption.Yes, out output, input);

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_EventAcceptedButRewardNotGuessed_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 1000, rewardMaxPennies: 1000, "testDummy", isOccupied: true);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testAssasin });
            var input = "5.02";

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(),
                UserOption.Yes, out output, input);

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_EventRegected_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 10, rewardMaxPennies: 1000, "testDummy", isOccupied: true);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testAssasin });
            var input = "5.02";

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(),
                UserOption.No, out output, input);

            Assert.IsFalse(result);
        }
    }
}
