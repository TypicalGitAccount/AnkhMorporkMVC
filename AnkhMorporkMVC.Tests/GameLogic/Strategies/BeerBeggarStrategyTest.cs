using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using NUnit.Framework;
using System;

namespace AnkhMorporkMVC.Tests.GameLogic.Strategies
{
    public class BeerBeggarStrategytest
    {
        private BeerBeggarStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new BeerBeggarStrategy();
        }

        public void Interact_DefaultScenario_ReturnsInteractionResultInteractionSuccesful()
        {
            var user = new AnkhMorporkMVC.GameLogic.GameTools.User(beers:1);
            var state = new BeggarState("testBeggar", BeggarRewardPennies.GuyInDesperateNeedOfABeeer.ToString(),
                (int)BeggarRewardPennies.GuyInDesperateNeedOfABeeer);

            var result = strategy.Interact(user, state);

            Assert.AreEqual(InteractionResult.InteractionSuccessful, result);
            Assert.AreEqual(0, (int)user.Beers);
        }

        [Test]
        public void Interact_UserHasNoBeer_ReturnsInteractionResultUserHasNoBeer()
        {
            var result = strategy.Interact(new AnkhMorporkMVC.GameLogic.GameTools.User(beers:0), 
                new BeggarState("testBeggar", BeggarRewardPennies.GuyInDesperateNeedOfABeeer.ToString(), 
                (int)BeggarRewardPennies.GuyInDesperateNeedOfABeeer)); 

            Assert.AreEqual(InteractionResult.UserHasNoBeer, result);
            
        }

        [Test]
        public void Interact_NullArgumentsPassed_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => strategy.Interact(null, null));
        }
    }
}
