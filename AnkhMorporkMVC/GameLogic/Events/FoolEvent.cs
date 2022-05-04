using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorpork.GameLogic.Events
{
    public class FoolEvent : GameEntityEvent
    {
        protected FoolRewardPennies randomPractice()
        {
            Array values = Enum.GetValues(typeof(FoolRewardPennies));
            return (FoolRewardPennies)values.GetValue(rand.Next(values.Length));
        }

        public override List<GameEntity> GenerateEntities()
        {
            var name = randomName();
            var practice = randomPractice();
            var practiceName = practice.ToString();
            var practiceReward = (int)practice;
            return new List<GameEntity> { new Fool(name, practiceName, practiceReward) };
        }

        public override string Welcome(AnkhMorporkMVC.GameLogic.GameTools.User user, List<GameEntity> entities)
        {
            var entity = entities[0];
            return string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.UserBalanceOutput,
                CurrencyConverter.PenniesToString(user.BalancePennies), user.Beers) +
                string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.ResourceManager.GetString("FoolEventWelcome"),
                entity.State.Name, ((FoolState)entity.State).PracticeName, CurrencyConverter.PenniesToString(entity.State.InteractionCostPennies));
        }

        public override bool Run(List<GameEntity> entities, AnkhMorporkMVC.GameLogic.GameTools.User user, UserOption answer, out StringBuilder output, string userInput = null)
        {
            output = new StringBuilder();
            var entity = entities[0];
            if (answer == UserOption.Yes)
            {
                entity.Interact(user);
                output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.FoolEventSuccess);
            }
            else
            {
                output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.FoolEventFail, entity.State.Name));
            }
            return true;
        }
    }
}
