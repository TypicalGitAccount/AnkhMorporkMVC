using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorpork.GameLogic.Events
{
    public class ThieveEvent : GameEntityEvent
    {
        public override List<GameEntity> GenerateEntities()
        {
            return new List<GameEntity> { new Thieve(randomName()) };
        }

        public override string Welcome(AnkhMorporkMVC.GameLogic.GameTools.User user, List<GameEntity> entities)
        {
            var entity = entities[0];
            return string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.UserBalanceOutput,
                CurrencyConverter.PenniesToString(user.BalancePennies), user.Beers) +
                string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.ResourceManager.GetString("ThieveEventWelcome"),
                entity.State.Name ?? AnkhMorporkMVC.GameLogic.Resources.Events.UnknownEntityName,
                CurrencyConverter.PenniesToString(entity.State.InteractionCostPennies));
        }

        public override bool Run(List<GameEntity> entities, AnkhMorporkMVC.GameLogic.GameTools.User user, UserOption answer, out StringBuilder output, string userInput = null)
        {
            output = new StringBuilder();
            var entity = entities[0];
            if (answer == UserOption.Yes)
            {
                var result = entity.Interact(user);
                if (result == InteractionResult.InteractionSuccessful)
                {
                    output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.ThieveEventSuccess, 
                        entity.State.Name ?? AnkhMorporkMVC.GameLogic.Resources.Events.UnknownEntityName));
                    return true;
                }
                else if (result == InteractionResult.TooMuchThefts)
                {
                    output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.ThieveTooMuchThefts);
                    return true;
                }
                output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.ThieveEventNotEnoughMoney);
            }
            output.Append(string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.ThieveEventFail, 
                entity.State.Name ?? AnkhMorporkMVC.GameLogic.Resources.Events.UnknownEntityName));
            return false;
        }
    }
}
