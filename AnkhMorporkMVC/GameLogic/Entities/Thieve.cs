using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Resources;

namespace AnkhMorporkMVC.GameLogic.Entities
{ 
    public class Thieve : GameEntity
    {
        public Thieve(string name) : base(new ThieveState(name), new ThieveStrategy()) { }

        public Thieve(ThieveState state) : base(state, new ThieveStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new ThieveModel()
            { Name = State.Name, InteractionCostPennies = State.InteractionCostPennies, 
                ImagePath = ImagePaths.ThieveImagePath, TheftsHappened = ThieveState.TheftsHappened };
            return model;
        }
    }
}
