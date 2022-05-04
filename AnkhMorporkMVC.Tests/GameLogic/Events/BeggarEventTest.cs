using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkMVC.Tests.GameLogic.Events
{
    public class BeggarEventTest 
    {
        private Mock<BeggarEvent> mockEvent;
        private StringBuilder output;

        [SetUp]
        public void SetUp()
        {
            mockEvent = new Mock<BeggarEvent>() { CallBase = true };
            output = new StringBuilder();
        }

        [Test]
        public void Run_UserAcceptedScenario_ReturnsTrue()
        {
            var testBeggar = new Beggar("TestDummy", BeggarRewardPennies.Dribbler.ToString(), (int)BeggarRewardPennies.Dribbler);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testBeggar });

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(),
                UserOption.Yes, out output);

            Assert.IsTrue(result);
        }

        [Test]
        public void Run_UserAcceptedScenarioDutNotEnoughMoney_ReturnsFalse()
        {
            var testBeggar = new Beggar("TestDummy", BeggarRewardPennies.Dribbler.ToString(), (int)BeggarRewardPennies.Dribbler);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testBeggar });

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(startBalancePennies: 10),
                UserOption.Yes, out output);

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_UserRejectedScenario_ReturnsFalse()
        {
            var testBeggar = new Beggar("TestDummy", BeggarRewardPennies.Dribbler.ToString(), (int)BeggarRewardPennies.Dribbler);
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testBeggar });

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(), UserOption.No, out output);

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_UserAcceptedBeerBeggar_ReturnsTrue()
        {
            var testBeggar = new BeerBeggar("TestDummy");
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testBeggar });

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(beers:2), UserOption.Yes, out output);
            
            Assert.IsTrue(result);
        }

        [Test]
        public void Run_UserAcceptedbutNotEnoughBeer_ReturnsFalse()
        {
            var testBeggar = new BeerBeggar("TestDummy");
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testBeggar });

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(),
                UserOption.Yes, out output);

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_UserRejected_ReturnsFalse()
        {
            var testBeggar = new BeerBeggar("TestDummy");
            mockEvent.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testBeggar });

            var result = mockEvent.Object.Run(mockEvent.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(beers:1),
                UserOption.No, out output);

            Assert.IsFalse(result);
        }
    }
}
