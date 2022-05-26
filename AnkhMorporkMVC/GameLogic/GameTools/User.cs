using AnkhMorporkMVC.Models;
using Newtonsoft.Json;
using System;

namespace AnkhMorporkMVC.GameLogic.GameTools
{
    [JsonObject]
    public class User
    {
        private int moves;
        public int Moves
        {
            get => moves;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Moves parameter can't be < 0");

                moves = value;
            }
        }
        private int balancePennies;
        public int BalancePennies
        {
            get => balancePennies;
            set
            {
                if (value < 0f)
                    throw new ArgumentOutOfRangeException("Balance can\'t be < 0!");

                balancePennies = value;
            }
        }

        private byte beers = (byte)PredefinedData.User.StartBeers;

        public byte Beers
        {
            get => beers;

            set { beers = value; }
        }

        public User(int startBalancePennies = (int)PredefinedData.User.StartBalancePennies, byte beers = (byte)PredefinedData.User.StartBeers, int moves=0)
        {
            Moves = moves;
            BalancePennies = startBalancePennies;
            Beers = beers;
        }

        public UserModel ToModel()
        {
            var model = new UserModel() { Moves = this.Moves, BalancePennies = this.BalancePennies, Beers = this.Beers };
            return model;
        }
    }
}
