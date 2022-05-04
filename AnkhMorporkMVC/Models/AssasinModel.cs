using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.States;

namespace AnkhMorporkMVC.Models
{
    public class AssasinModel : GameEntityModel
    {   
        public int minRewardPennies { get; set; }
        public int maxRewardPennies { get; set; }

        public bool IsOccupied { get; set; }

        public override GameEntity ToObject()
        {
            return new Assasin(new AssasinState(minRewardPennies, maxRewardPennies, Name, IsOccupied));
        }
    }
}