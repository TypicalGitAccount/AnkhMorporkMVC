using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Resources;

namespace AnkhMorporkMVC.GameLogic.Entities
{
    public class Beggar : GameEntity
    {
        public Beggar(string name, string practiceName, int rewardPennies)
            : base(new BeggarState(name, practiceName, rewardPennies), new BeggarStrategy())  { }

        public Beggar(BeggarState state) : base(state, new BeggarStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new BeggarModel() {
                Name = State.Name,
                InteractionCostPennies = State.InteractionCostPennies,
                PracticeName = ((BeggarState)State).PracticeName,
                ImagePath = ImagePaths.BeggarImagePath
            };
            return model;
        }
    }
}
