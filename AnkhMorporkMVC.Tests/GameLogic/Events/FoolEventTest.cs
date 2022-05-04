using Ankh_Morpork.Tests.Events;
using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkMVC.Tests.GameLogic.Events
{
    public class FoolEventTest
    {
        [TestCase(UserOption.Yes)]
        [TestCase(UserOption.No)]
        public void Run_UserEntersAnswer_ReturnsTrue(UserOption userInput)
        {
            var testFool = new Fool("TestDummy", FoolRewardPennies.ArchFool.ToString(), (int)FoolRewardPennies.ArchFool);
            var eventMock = new Mock<FoolEvent>() { CallBase = true };
            eventMock.Setup(x => x.GenerateEntities()).Returns(new List<GameEntity> { testFool });
            StringBuilder output;
            var result = eventMock.Object.Run(eventMock.Object.GenerateEntities(), new AnkhMorporkMVC.GameLogic.GameTools.User(), 
                userInput, out output);

            Assert.IsTrue(result);
        }
    }
}
