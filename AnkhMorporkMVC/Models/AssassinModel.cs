using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.States;

namespace AnkhMorporkMVC.Models
{
    public class AssassinModel : GameEntityModel
    {   
        public int minRewardPennies { get; set; }
        public int maxRewardPennies { get; set; }

        public bool IsOccupied { get; set; }

        public override GameEntity FillProperties()
        {
            return new Assassin(new AssasinState(minRewardPennies, maxRewardPennies, Name, IsOccupied));
        }
    }
}