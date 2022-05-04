using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.Strategies
{
    public class FoolStrategyTest
    {
        private GameEntityStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new FoolStrategy();
        }

        [TestCase(null, null)]
        public void Interact_NullArgumentsPassed_ThrowsArgumentExcpetion(AnkhMorporkMVC.GameLogic.GameTools.User user, FoolState state)
        {
            Assert.Throws<ArgumentException>(() => strategy.Interact(user, state));
        }

        [Test]
        public void Interact_ValidInteraction_ReturnsInteractionSuccessfulFlag()
        {
            var user = new AnkhMorporkMVC.GameLogic.GameTools.User();

            var result = 
                strategy.Interact(user, new FoolState("TestDummy", FoolRewardPennies.ArchFool.ToString(), (int)FoolRewardPennies.ArchFool));

            Assert.AreEqual(InteractionResult.InteractionSuccessful, result);
            Assert.AreEqual((int)User.StartBalancePennies + (int)FoolRewardPennies.ArchFool, user.BalancePennies);
        }
    }
}
