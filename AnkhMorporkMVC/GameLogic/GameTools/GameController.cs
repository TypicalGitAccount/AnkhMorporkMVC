using AnkhMorpork.GameLogic.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AnkhMorporkMVC.GameLogic.GameTools
{
    public class GameController : IGameController
    {
        public GameEntityEvent GenerateEvent(List<Type> except=null)
        {
            var events = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(typeof(GameEntityEvent))).Except(new List<Type> { typeof(GameEntityEvent) }).ToList();
            if (except != null)
            {
                foreach(var e in except)
                    events.Remove(e);
            }
            var rand = new Random();
            var randIndex = rand.Next(events.Count());
            return (GameEntityEvent)events[randIndex].GetConstructor(new Type[] { }).Invoke(new object[] { });
        }
    }
}
