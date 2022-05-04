﻿using System;

namespace AnkhMorporkMVC.GameLogic.States
{
    public class FoolState : GameEntityState
    {
        protected string practiceName;
        public string PracticeName
        {
            get
            {
                return practiceName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentOutOfRangeException("PracticeName can\'t be null or empty string!");

                practiceName = value;
            }
        }
        public FoolState(string name, string practiceName, int rewardPennies) : base(name, rewardPennies) 
        {
            PracticeName = practiceName;
        }
    }
}
