using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using System;

namespace AnkhMorporkMVC.GameLogic.Strategies
{
    public class AssasinStrategy : GameEntityStrategy
    { 
        public override InteractionResult Interact(GameTools.User user, GameEntityState characterState) 
        {
            if (AreNull(user, characterState))
                throw new ArgumentException("Arguments can't be null");

            if (!(characterState is AssasinState))
                return InteractionResult.InteractionNotImplemented;

            if (characterState.InteractionCostPennies > user.BalancePennies)
                return InteractionResult.InsufficientBalance;

            var state = (AssasinState)characterState;
            if (state.InteractionCostPennies == 0)
                return InteractionResult.InteractionCostNotAssigned;

            if (state.IsOccupied)
                return InteractionResult.AssasinIsOccupied;

            if (state.MinRewardPennies > state.InteractionCostPennies || state.MaxRewardPennies < state.InteractionCostPennies)
                return InteractionResult.RewardNotGuessed;

            user.BalancePennies -= state.InteractionCostPennies;
            user.Moves += 1;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
