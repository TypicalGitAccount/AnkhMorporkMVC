using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using System;

namespace AnkhMorporkMVC.GameLogic.Strategies
{
    public class BeerBeggarStrategy : GameEntityStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GameEntityState characterState)
        {

            if (AreNull(user, characterState))
                throw new ArgumentException("Arguments can't be null");

            if (user.Beers == 0)
                return InteractionResult.UserHasNoBeer;
            
            user.Beers -= 1;
            user.Moves += 1;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
