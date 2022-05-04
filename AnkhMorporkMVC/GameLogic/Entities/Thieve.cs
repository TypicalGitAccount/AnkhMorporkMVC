using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;
using Newtonsoft.Json;

namespace AnkhMorporkMVC.GameLogic.Entities
{ 
    public class Thieve : GameEntity
    {
        public Thieve(string name) : base(new ThieveState(name), new ThieveStrategy()) { }

        public Thieve(ThieveState state) : base(state, new ThieveStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new ThieveModel();
            model.Name = State.Name;
            model.InteractionCostPennies = State.InteractionCostPennies;
            model.TheftsHappened = ThieveState.TheftsHappened;
            return model;
        }
    }
}
