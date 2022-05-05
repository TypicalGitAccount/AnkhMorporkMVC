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
            var model = new FoolModel();
            model.Name = State.Name;
            model.InteractionCostPennies = State.InteractionCostPennies;
            model.PracticeName = ((FoolState)State).PracticeName;
            model.ImagePath = ImagePaths.FoolImagePath;
            return model;
        }
    }
}
