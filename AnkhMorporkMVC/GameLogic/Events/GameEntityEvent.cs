using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.GameLogic.IO;
using AnkhMorporkMVC.GameLogic.PredefinedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorpork.GameLogic.Events
{
    public abstract class GameEntityEvent
    {
        protected Random rand = new Random();

        protected string randomName()
        {
            var vowels = "aeoui";
            var consonants = "bcdfghjklmnpqrtsvwxz";
            var length = rand.Next(2, 10);
            var name = new StringBuilder(length);
            var vowel = false;

            for (int i = 0; i < length; i++, vowel = !vowel)
            {
                if (vowel)
                {
                    name.Append(vowels[rand.Next(0, vowels.Length - 1)]);
                }
                else
                {
                    name.Append(consonants[rand.Next(0, consonants.Length - 1)]);
                }
            }
            name[0] = char.ToUpper(name[0]);
            return name.ToString();
        }

        protected int randomInteractionCost()
        {
            return rand.Next(1, (int)User.StartBalancePennies / 2);
        }

        public virtual List<GameEntity> GenerateEntities() { throw new NotImplementedException(); }

        public bool ValidUserAnswer(InputProcessor inputProcessor, string input)
        {
            return InputProcessor.ValidInput(input, typeof(string), (val) =>
            {
                var value = (string)val;
                return !string.IsNullOrEmpty(value) && (value == UserOption.Yes.ToString()
                || value == UserOption.No.ToString());
            });
        }

        public virtual string Welcome(AnkhMorporkMVC.GameLogic.GameTools.User user, List<GameEntity> entities)
        { throw new NotImplementedException(); }

        public virtual bool Run(List<GameEntity> entities, AnkhMorporkMVC.GameLogic.GameTools.User user, UserOption answer, out StringBuilder output, string userInput = null) { throw new NotImplementedException();  }
    }
}