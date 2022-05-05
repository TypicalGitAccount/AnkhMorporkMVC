using AnkhMorporkMVC.GameLogic.States;
using AnkhMorporkMVC.GameLogic.Strategies;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.Models;
using AnkhMorporkMVC.Resources;

namespace AnkhMorporkMVC.GameLogic.Entities
{
    public class BeerBeggar : GameEntity
    {
        public BeerBeggar(string name)
            : base(new BeggarState(name, BeggarRewardPennies.GuyInDesperateNeedOfABeeer.ToString()
                , (int)BeggarRewardPennies.GuyInDesperateNeedOfABeeer), new BeerBeggarStrategy())
        { }

        public BeerBeggar(BeggarState state) : base(state, new BeerBeggarStrategy()) { }

        public override GameEntityModel ToModel()
        {
            var model = new BeggarModel();
            model.Name = State.Name;
            model.InteractionCostPennies = State.InteractionCostPennies;
            model.PracticeName = ((BeggarState)State).PracticeName;
            model.ImagePath = ImagePaths.BeggarImagePath;
            return model;
        }
    }
}


