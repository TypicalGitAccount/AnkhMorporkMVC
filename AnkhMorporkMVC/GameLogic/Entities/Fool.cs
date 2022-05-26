using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Resources;

namespace AnkhMorporkMVC.GameLogic.Entities
{
    public class Fool : GameEntity
    {
        public Fool(string name, string practiceName, int rewardPennies) :
            base(new FoolState(name, practiceName, rewardPennies), new FoolStrategy()) {}

        public Fool(FoolState state) : base(state, new FoolStrategy()) {}

        public override GameEntityModel ToModel()
        {
            var model = new FoolModel() {
                Name = State.Name,
                InteractionCostPennies = State.InteractionCostPennies,
                PracticeName = ((FoolState)State).PracticeName,
                ImagePath = ImagePaths.FoolImagePath
            };
            return model;
        }
    }
}
