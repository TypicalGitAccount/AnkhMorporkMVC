using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AnkhMorpork.GameLogic.Events
{
    public class AssassinEvent : GameEntityEvent
    {
        protected int RandomMinRewardPennies()
        {
            return rand.Next((int)AssassinRewardPennies.MinRewardPennies, (int)AssassinRewardPennies.MaxRewardPennies);
        }

        protected int RandomMaxRewardPennies(int minRewardPennies)
        {
            return rand.Next(minRewardPennies, (int)AssassinRewardPennies.MaxRewardPennies);
        }

        private GameEntity RandomAssassin()
        {
            var random = new Random();
            var rewardMin = RandomMinRewardPennies();
            var rewardMax = RandomMaxRewardPennies(rewardMin);
            var name = randomName();
            var isOccupied = random.Next(2) == 1;

            return new Assassin(rewardMin, rewardMax, name, isOccupied);
        }

        public override List<GameEntity> GenerateEntities()
        {
            var random = new Random();
            List<GameEntity> entities = new List<GameEntity>();
            for ( int i = 0; i < random.Next((int)AssassinGang.MinMembers, (int)AssassinGang.MaxMembers); i++ )
            {
                entities.Add(RandomAssassin());
            }

            return entities;
        }

        public static bool ValidRewardInput(string input)
        {
            return InputProcessor.ValidInput(input, typeof(decimal), (val) =>
            {
                decimal value;
                var result = decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-US"), out value);

                return result && value >= (int)AssassinRewardPennies.MinRewardPennies && 
                value <= CurrencyConverter.PenniesToDollars((int)AssassinRewardPennies.MaxRewardPennies);
            });
        }

        public override string Welcome(AnkhMorporkMVC.GameLogic.GameTools.User user, List<GameEntity> entities)
        {
            return string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.UserBalanceOutput,
                CurrencyConverter.PenniesToString(user.BalancePennies), user.Beers) +
                AnkhMorporkMVC.GameLogic.Resources.Events.AssassinEventWelcome;
        }

        public override bool Run(List<GameEntity> entities, AnkhMorporkMVC.GameLogic.GameTools.User user, UserOption answer, out StringBuilder output, string userInput = null)
        {
            output = new StringBuilder();
            if (answer == UserOption.Yes)
            {
                decimal.TryParse(userInput, out decimal result);
                var guessedRewardPennies = CurrencyConverter.DollarsToPennies(result);

                foreach (var assassin in entities)
                {
                    assassin.State.InteractionCostPennies = guessedRewardPennies;
                    if (assassin.Interact(user) == InteractionResult.InteractionSuccessful)
                    {
                        output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.AssassinEventSuccess);
                        return true;
                    }
                }
                output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.AssassinEventRewardGuessedWrong);
            }
            output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.AssasinEventFail);
            return false;
        }
    }
}
