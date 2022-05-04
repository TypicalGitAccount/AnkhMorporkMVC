using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.States;

namespace AnkhMorporkMVC.Models
{
    public class FoolModel : GameEntityModel
    {
        public string PracticeName { get; set; }

        public override GameEntity ToObject()
        {
            return new Fool(new FoolState(Name, PracticeName, InteractionCostPennies));
        }
    }
}