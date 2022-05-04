using AnkhMorpork.GameLogic.Events;
using AnkhMorporkMVC.GameLogic.IO;
using System;
using System.Collections.Generic;

namespace AnkhMorporkMVC.GameLogic.GameTools
{
    public interface IGameController
    {
        List<Type> GameEvents { get; set; }
        User User { get; set; }
        InputProcessor InputProcessor { get; set; }

        GameEntityEvent GenerateEvent();
    }
}
