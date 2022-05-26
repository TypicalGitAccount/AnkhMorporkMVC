using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Resources;

namespace AnkhMorporkMVC.GameLogic.Entities
{
    public class Assassin : GameEntity
    {
        public Assassin(int rewardMinPennies, int rewardMaxPennies, string characterName, bool isOccupied, int interactionCostPennies=0)
            : base(new AssasinState(rewardMinPennies, rewardMaxPennies, characterName, isOccupied, interactionCostPennies), new AssasinStrategy()) { }

        public Assassin(AssasinState state) : base(state, new AssasinStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new AssassinModel() {
                Name = State.Name,
                InteractionCostPennies = State.InteractionCostPennies,
                minRewardPennies = ((AssasinState)State).MinRewardPennies,
                maxRewardPennies = ((AssasinState)State).MaxRewardPennies,
                IsOccupied = ((AssasinState)State).IsOccupied,
                ImagePath = ImagePaths.AssasinImagePath
            };
            return model;
        }
    }
}
