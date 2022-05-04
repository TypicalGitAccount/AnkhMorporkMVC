using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;

namespace AnkhMorporkMVC.GameLogic.Entities
{
   public class GameEntity
   {
        public GameEntityState State { get; protected set; }
        public GameEntityStrategy Behaviour { get; protected set; }

        public GameEntity(GameEntityState state, GameEntityStrategy behaviour)
        {
            State = state;
            Behaviour = behaviour;
        }

        public virtual InteractionResult Interact(GameTools.User user)
        {
            return Behaviour.Interact(user, State);
        }

        public virtual GameEntityModel ToModel()
        { 
            var model = new GameEntityModel();
            model.Name = State.Name;
            model.InteractionCostPennies = State.InteractionCostPennies;
            return model;
        }
    }
}
