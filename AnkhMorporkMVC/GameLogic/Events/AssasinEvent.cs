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
    public class AssasinEvent : GameEntityEvent
    {
        protected int randomMinRewardPennies()
        {
            return rand.Next((int)AssasinRewardPennies.MinRewardPennies, (int)AssasinRewardPennies.MaxRewardPennies);
        }

        protected int randomMaxRewardPennies(int minRewardPennies)
        {
            return rand.Next(minRewardPennies, (int)AssasinRewardPennies.MaxRewardPennies);
        }

        private GameEntity RandomAssasin()
        {
            var random = new Random();
            var rewardMin = randomMinRewardPennies();
            var rewardMax = randomMaxRewardPennies(rewardMin);
            var name = randomName();
            var isOccupied = random.Next(2) == 1;

            return new Assasin(rewardMin, rewardMax, name, isOccupied);
        }

        public override List<GameEntity> GenerateEntities()
        {
            var random = new Random();
            List<GameEntity> entities = new List<GameEntity>();
            for ( int i = 0; i < random.Next((int)AssasinGang.MinMembers, (int)AssasinGang.MaxMembers); i++ )
            {
                entities.Add(RandomAssasin());
            }

            return entities;
        }

        public static bool ValidRewardInput(string input)
        {
            return InputProcessor.ValidInput(input, typeof(decimal), (val) =>
            {
                decimal value;
                var result = decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-US"), out value);

                return result && value >= (int)AssasinRewardPennies.MinRewardPennies && 
                value <= CurrencyConverter.PenniesToDollars((int)AssasinRewardPennies.MaxRewardPennies);
            });
        }

        public override string Welcome(AnkhMorporkMVC.GameLogic.GameTools.User user, List<GameEntity> entities)
        {
            return string.Format(AnkhMorporkMVC.GameLogic.Resources.Events.UserBalanceOutput,
                CurrencyConverter.PenniesToString(user.BalancePennies), user.Beers) +
                AnkhMorporkMVC.GameLogic.Resources.Events.AssasinEventWelcome;
        }

        public override bool Run(List<GameEntity> entities, AnkhMorporkMVC.GameLogic.GameTools.User user, UserOption answer, out StringBuilder output, string userInput = null)
        {
            output = new StringBuilder();
            if (answer == UserOption.Yes)
            {
                decimal.TryParse(userInput, out decimal result);
                var guessedRewardPennies = CurrencyConverter.DollarsToPennies(result);

                foreach (var assasin in entities)
                {
                    assasin.State.InteractionCostPennies = guessedRewardPennies;
                    if (assasin.Interact(user) == InteractionResult.InteractionSuccessful)
                    {
                        output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.AssasinEventSuccess);
                        return true;
                    }
                }
                output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.AssasinEventRewardGuessedWrong);
            }
            output.Append(AnkhMorporkMVC.GameLogic.Resources.Events.AssasinEventFail);
            return false;
        }
    }
}
