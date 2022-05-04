using System;
using NUnit.Framework;
using Moq;
using AnkhMorporkMVC.GameLogic.States;

namespace AnkhMorporkMVC.Tests.GameLogic.States
{
    public class GuildCharacterStateTest
    {
        private Mock<GameEntityState> state;

        [SetUp]
        public void SetUp()
        {
            state = new Mock<GameEntityState>("name", 10) { 
                CallBase = true
            };
        }

        [TestCase("")]
        [TestCase(null)]
        public void CharacterName_NullOrEmptyStringPassed_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => state.Object.Name = input);
        }

        [Test]
        public void InteractionCost_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.Object.InteractionCostPennies = -2);
        }
    }
}
