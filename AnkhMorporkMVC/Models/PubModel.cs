using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.States;

namespace AnkhMorporkMVC.Models
{
    public class PubModel : GameEntityModel
    {
        public bool IsOpen { get; set; }

        public override GameEntity ToObject()
        {
            return new Pub(new PubState(Name, InteractionCostPennies, IsOpen));
        }
    }
}