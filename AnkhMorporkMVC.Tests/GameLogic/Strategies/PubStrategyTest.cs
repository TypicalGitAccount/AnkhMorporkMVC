using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using NUnit.Framework;
using System;

namespace AnkhMorporkMVC.Tests.GameLogic.Strategies
{
    public class PubStrategyTest
    {
        private PubStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new PubStrategy();
        }

        [Test]
        public void Interact_DefaultScenario_ReturnsInteractionSuccesful()
        {
            var user = new AnkhMorporkMVC.GameLogic.GameTools.User();
            var state = new PubState(true);

            var result = strategy.Interact(user, state);
            
            Assert.AreEqual(InteractionResult.InteractionSuccessful, result);
            Assert.AreEqual(1, user.Beers);
            Assert.AreEqual((int)AnkhMorporkMVC.GameLogic.PredefinedData.User.StartBalancePennies - state.InteractionCostPennies, user.BalancePennies);
        }

        [Test]
        public void Interact_PubIsClosed_ReturnsInteractionResultGameLocationIsClosed()
        {
            var result = strategy.Interact(new AnkhMorporkMVC.GameLogic.GameTools.User(), new PubState(false));

            Assert.AreEqual(InteractionResult.GameLocationisClosed, result);   
        }

        [Test]
        public void Interact_UserHasNoMoney_ReturnsInteractionREsultInsufficientBalance()
        {
            var result = strategy.Interact(new AnkhMorporkMVC.GameLogic.GameTools.User(startBalancePennies: 0), new PubState(true));

            Assert.AreEqual(InteractionResult.InsufficientBalance, result);
        }

        [Test]
        public void Interact_UserHasTooMuchBeer_ReturnsInteractionResultUserCantCarryMoreBeers()
        {
            var result = strategy.Interact(new AnkhMorporkMVC.GameLogic.GameTools.User(beers: 2), new PubState(true));

            Assert.AreEqual(InteractionResult.UserCantCarryMoreBeers, result);
        }

        [Test]
        public void Interact_NullArguments_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => strategy.Interact(null, null));
        }
    }
}
