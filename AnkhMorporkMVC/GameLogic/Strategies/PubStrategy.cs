using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using System;

namespace AnkhMorporkMVC.GameLogic.Strategies
{
    public class PubStrategy : GameEntityStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GameEntityState state)
        {
            if (AreNull(user, state))
                throw new ArgumentException("Arguments can't be null");

            var pubState = (PubState)state;

            if (user.BalancePennies < pubState.InteractionCostPennies)
                return InteractionResult.InsufficientBalance;

            user.Moves += 1;

            if (!pubState.IsOpen)
                return InteractionResult.GameLocationisClosed;

            if (user.Beers == (short)User.MaxBeers)
                return InteractionResult.UserCantCarryMoreBeers;

            user.BalancePennies -= pubState.InteractionCostPennies;
            user.Beers += 1;

            return InteractionResult.InteractionSuccessful;
        }
    }
}
