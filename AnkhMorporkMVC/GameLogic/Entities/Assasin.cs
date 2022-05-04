using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;

namespace AnkhMorporkMVC.GameLogic.Entities
{
    public class Assasin : GameEntity
    {
        public Assasin(int rewardMinPennies, int rewardMaxPennies, string characterName, bool isOccupied, int interactionCostPennies=0)
            : base(new AssasinState(rewardMinPennies, rewardMaxPennies, characterName, isOccupied, interactionCostPennies), new AssasinStrategy()) { }

        public Assasin(AssasinState state) : base(state, new AssasinStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new AssasinModel();
            model.Name = State.Name;
            model.InteractionCostPennies = State.InteractionCostPennies;
            model.minRewardPennies = ((AssasinState)State).MinRewardPennies;
            model.maxRewardPennies = ((AssasinState)State).MaxRewardPennies;
            model.IsOccupied = ((AssasinState)State).IsOccupied;
            return model;
        }
    }
}
