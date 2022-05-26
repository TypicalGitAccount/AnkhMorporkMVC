using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Resources;

namespace AnkhMorporkMVC.GameLogic.Entities
{
    public class Pub : GameEntity
    { 
        public Pub(bool isOpen) : base(new PubState(isOpen), new PubStrategy()) { }

        public Pub(PubState state) : base(state, new PubStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new PubModel()
            {
                Name = State.Name,
                InteractionCostPennies = State.InteractionCostPennies,
                IsOpen = ((PubState)State).IsOpen,
                ImagePath = ImagePaths.PubImagePath
            };
            return model;
        }
    }
}
