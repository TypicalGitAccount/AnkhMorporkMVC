using AnkhMorporkMVC.GameLogic.PredefinedData;
using System.Collections.Generic;
using AnkhMorporkMVC.GameLogic.Entities;

namespace AnkhMorporkMVC.Services
{
    public interface IGameEventService
    {
        GameLogic.GameTools.User GetUser();

        List<GameEntity> GetEntities();

        /// <summary>
        /// Starts a game event
        /// </summary>
        /// <returns>welcome message for user, containing event info</returns>
        string StartGameEvent();

        /// <summary>
        /// Processes game event
        /// </summary>
        /// <param name="eventAnswer"></param>
        /// <returns>output containing event info on success, null otherwise</returns>
        string ProcessEvent(UserOption eventAnswer);

        /// <summary>
        /// Ends the game
        /// </summary>
        /// <returns>user object to display</returns>
        GameLogic.GameTools.User GameOver();
    }
}
