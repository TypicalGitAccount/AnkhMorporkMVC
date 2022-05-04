using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using Newtonsoft.Json;

namespace AnkhMorporkMVC.GameLogic.Strategies
{
    public abstract class GameEntityStrategy
    {
        protected bool AreNull(GameTools.User user, GameEntityState characterState)
        {
            return user == null || characterState == null;
        }

        public abstract InteractionResult Interact(GameTools.User user, GameEntityState state);
    }
}
