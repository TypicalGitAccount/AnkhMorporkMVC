using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.States;

namespace AnkhMorporkMVC.Models
{
    public class ThieveModel : GameEntityModel
    {
        public int TheftsHappened { get; set; }

        public override GameEntity ToObject()
        {
            return new Thieve(new ThieveState(Name, InteractionCostPennies));
        }
    }
}