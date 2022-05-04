using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.Strategies
{
    public class ThieveStrategyTest
    {
        private ThieveStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new ThieveStrategy();
        }

        [TestCase(null, null)]
        public void Interact_NullArgumentsPassed_ThrowsArgumentExcpetion(AnkhMorporkMVC.GameLogic.GameTools.User user, ThieveState state)
        {
            Assert.Throws<ArgumentException>(() => strategy.Interact(user, state));
        }

        [Test]
        public void Interact_SuccesfulInteraction_ChargesMoneyAndReturnsInteractionSuccesfulFlag()
        {
            var user = new AnkhMorporkMVC.GameLogic.GameTools.User();

            var result = strategy.Interact(user, new ThieveState("TestGuy"));

            Assert.AreEqual((int)User.StartBalancePennies - (int)Thieves.DefaultFeePennies, user.BalancePennies);
            Assert.AreEqual(InteractionResult.InteractionSuccessful, result);
        }

        [Test]
        public void Interact_NotEnughMoney_ReturnsInsufficientBalanceFlag()
        {
            var result = strategy.Interact(new AnkhMorporkMVC.GameLogic.GameTools.User(startBalancePennies:0), new ThieveState("TestGuy"));

            Assert.AreEqual(result, InteractionResult.InsufficientBalance);
        }

        [Test]
        public void Interact_TheftsLimitExceeded_ReturnsTooMuchTheftsFlag()
        {
            var user = new AnkhMorporkMVC.GameLogic.GameTools.User();
            var state = new ThieveState("TestGuy");

            var result = strategy.Interact(user, state);
            for (int i = 1; i <= (int)Thieves.AllowedThefts; i++)
            {
                result = strategy.Interact(user, state);
            }

            Assert.AreEqual(result, InteractionResult.TooMuchThefts);
        }
    }
}
