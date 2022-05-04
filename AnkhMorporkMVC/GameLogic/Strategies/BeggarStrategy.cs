using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using System;

namespace AnkhMorporkMVC.GameLogic.Strategies
{
    public class BeggarStrategy : GameEntityStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GameEntityState characterState)
        {
            if (AreNull(user, characterState))
                throw new ArgumentException("Arguments can't be null");

            if (user.BalancePennies < characterState.InteractionCostPennies)
                return InteractionResult.InsufficientBalance;

            user.BalancePennies -= characterState.InteractionCostPennies;
            user.Moves += 1;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
