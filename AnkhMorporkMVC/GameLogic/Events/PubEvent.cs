using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorpork.GameLogic.Events
{
    public class PubEvent : GameEntityEvent
    {
        private bool randomIsOpen() { return rand.Next() % 1 == 0;  }

        public override List<GameEntity> GenerateEntities()
        {
            return new List<GameEntity> { new AnkhMorporkMVC.GameLogic.Entities.Pub(randomIsOpen()) };
        }

        public override string Welcome(AnkhMorporkMVC.GameLogic.GameTools.User user, List<GameEntity> entities)
        {
            return string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.UserBalanceOutput,
                CurrencyConverter.PenniesToString(user.BalancePennies), user.Beers) +
                string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.MendedDrumWelcome,
                CurrencyConverter.PenniesToString(AnkhMorporkMVC.GameLogic.PredefinedData.Pub.InteractionCostPennies));
        }

        public override bool Run(List<GameEntity> entities, AnkhMorporkMVC.GameLogic.GameTools.User user, UserOption answer, out StringBuilder output, string userInput = null)
        {
            output = new StringBuilder();
            if (answer == UserOption.Yes)
            {
                var pub = (AnkhMorporkMVC.GameLogic.Entities.Pub)GenerateEntities()[0];
                var result = pub.Interact(user);
                switch (result)
                { 
                    case InteractionResult.GameLocationisClosed:
                        output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.PubWasClosed);
                        break;
                    case InteractionResult.UserCantCarryMoreBeers:
                        output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.TooMuchBeer);
                        break;
                    case InteractionResult.InsufficientBalance:
                        output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.PubNotEnoughMoney);
                        break;
                    default:
                        output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.PubInteractionSuccesfull);
                        break;
                }
            }

            return true;
        }
    }
}
