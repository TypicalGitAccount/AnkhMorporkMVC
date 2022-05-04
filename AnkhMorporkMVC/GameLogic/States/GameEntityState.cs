using System;

namespace AnkhMorporkMVC.GameLogic.States
{
    public abstract class GameEntityState
    {
        private int interactionCostPennies;
        public int InteractionCostPennies
        {
            get
            {
                return interactionCostPennies;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Interaction cost can\'t be < 0!");

                interactionCostPennies = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name field can\'t be null or empty string!");
                }

                name = value;
            }
        }

        public GameEntityState(string name, int interactionCost)
        {
            Name = name;
            InteractionCostPennies = interactionCost;
        }
    }
}