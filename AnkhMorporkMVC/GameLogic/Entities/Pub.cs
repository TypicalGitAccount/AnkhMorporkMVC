using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;

namespace AnkhMorporkMVC.GameLogic.Entities
{
    public class Pub : GameEntity
    { 
        public Pub(bool isOpen) : base(new PubState(isOpen), new PubStrategy()) { }

        public Pub(PubState state) : base(state, new PubStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new PubModel();
            model.Name = State.Name;
            model.InteractionCostPennies = State.InteractionCostPennies;
            model.IsOpen = ((PubState)State).IsOpen;
            return model;
        }
    }
}
