using AnkhMorpork.GameLogic.Events;
using System;
using System.Collections.Generic;

namespace AnkhMorporkMVC.GameLogic.GameTools
{
    public interface IGameController
    {
        GameEntityEvent GenerateEvent(List<Type> except = null);
    }
}
