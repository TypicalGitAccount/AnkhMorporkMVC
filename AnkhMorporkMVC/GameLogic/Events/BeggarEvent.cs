using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorpork.GameLogic.Events
{
    public class BeggarEvent : GameEntityEvent
    {
        protected BeggarRewardPennies randomPractice()
        {
            var values = Enum.GetValues(typeof(BeggarRewardPennies));
            return (BeggarRewardPennies)values.GetValue(rand.Next(values.Length));
        }

        public override List<GameEntity> GenerateEntities()
        {
            var name = randomName();
            var practice = randomPractice();
            var practiceName = practice.ToString();
            var practiceReward = (int)practice;
            if (practice == (int)BeggarRewardPennies.GuyInDesperateNeedOfABeeer)
                return new List<GameEntity> { new BeerBeggar(name) };
            return new List<GameEntity> { new Beggar(name, practiceName, practiceReward)};
        }

        public override string Welcome(AnkhMorporkMVC.GameLogic.GameTools.User user, List<GameEntity> entities)
        {
            var entity = entities[0];
            var interactionCostPennies = entity.State.InteractionCostPennies;
            var practiceName = ((BeggarState)entity.State).PracticeName;
            StringBuilder output = new StringBuilder();
            output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.UserBalanceOutput,
                CurrencyConverter.PenniesToString(user.BalancePennies), user.Beers));

            if (entity is BeerBeggar)
            {
                output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.BeerBeggarWelcome,
                    entity.State.Name, practiceName, entity.State.Name));
            } else
            {
                output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.BeggarEventWelcome, entity.State.Name, practiceName,
                    CurrencyConverter.PenniesToString(interactionCostPennies), entity.State.Name));
            }
            return output.ToString();
        }

        public override bool Run(List<GameEntity> entities, AnkhMorporkMVC.GameLogic.GameTools.User user, UserOption answer, out StringBuilder output, string userInput=null)
        {
            output = new StringBuilder();
            var entity = entities[0];

            if (answer == UserOption.Yes)
            {
                var result = entity.Interact(user);
                if (result == InteractionResult.InteractionSuccessful)
                {
                    output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.BeggarEventSuccess,
                        entity.State.Name ?? AnkhMorporkMVC.GameLogic.Resources.Events.UnknownEntityName));
                    return true;
                }

                if (result == InteractionResult.InsufficientBalance)
                    output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.BeggarEventNotEnoughMoney);

                if (entity is BeerBeggar && result == InteractionResult.UserHasNoBeer)
                    output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.BeggarNoBeer);
            }

            output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.BeggarEventFail,
                        entity.State.Name ?? AnkhMorporkMVC.GameLogic.Resources.Events.UnknownEntityName));
            return false;
        }
    }
}
