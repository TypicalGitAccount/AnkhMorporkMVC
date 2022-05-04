
using AnkhMorporkMVC.GameLogic.PredefinedData;
using System;

namespace AnkhMorporkMVC.GameLogic.States
{
    public class ThieveState : GameEntityState
    {
        private static int theftsCounter = 0;
        public static int TheftsHappened
        {
            get
            {
                return theftsCounter;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("theftsCounter can\'t be < 0!");

                theftsCounter = value;
            }
        }
        public ThieveState(string name) : base(name, (int)Thieves.DefaultFeePennies) { }

        public ThieveState(string name, int reward) : base(name, reward) { }
    }
}
