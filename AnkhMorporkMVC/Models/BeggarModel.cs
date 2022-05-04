using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.States;

namespace AnkhMorporkMVC.Models
{
    public class BeggarModel : GameEntityModel
    {
        public string PracticeName { get; set; }

        public override GameEntity ToObject()
        {
            return new Beggar(new BeggarState(Name, PracticeName, InteractionCostPennies));
        }
    }
}