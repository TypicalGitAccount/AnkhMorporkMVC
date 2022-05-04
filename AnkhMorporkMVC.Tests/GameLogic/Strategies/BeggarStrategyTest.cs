using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using NUnit.Framework;
using System;

namespace AnkhMorporkMVC.Tests.GameLogic.Strategies
{
    public class BeggarStrategyTest
    {
        private BeggarStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new BeggarStrategy();
        }

        [TestCase(null, null)]
        public void Interact_NullArgumentsPassed_ThrowsArgumentExcpetion(AnkhMorporkMVC.GameLogic.GameTools.User user, BeggarState state)
        {
            Assert.Throws<ArgumentException>(() => strategy.Interact(user, state));
        }

        [Test]
        public void Interact_ValidInteraction_ReturnsInteractionSuccessfulFlag()
        {
            var user = new AnkhMorporkMVC.GameLogic.GameTools.User();
            var result = 
                strategy.Interact(user, new BeggarState("TestDummy", 
                BeggarRewardPennies.Twitcher.ToString(), (int)BeggarRewardPennies.Twitcher));

            Assert.AreEqual(result, InteractionResult.InteractionSuccessful);
            Assert.AreEqual((int)AnkhMorporkMVC.GameLogic.PredefinedData.User.StartBalancePennies - (int)BeggarRewardPennies.Twitcher, user.BalancePennies);
        }

        public void Interact_NotEnoughMoney_ReturnsInsufficientBalanceFlag()
        {
            var result =
                strategy.Interact(new AnkhMorporkMVC.GameLogic.GameTools.User(startBalancePennies: 0), new BeggarState("TestDummy", 
                BeggarRewardPennies.Twitcher.ToString(), (int)BeggarRewardPennies.Twitcher));

            Assert.AreEqual(result, InteractionResult.InsufficientBalance);
        }
    }
}
