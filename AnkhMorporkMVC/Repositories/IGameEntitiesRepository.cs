using AnkhMorporkMVC.GameLogic.Entities;
using System.Collections.Generic;

namespace AnkhMorporkMVC.Repositories
{
    public interface IGameEntitiesRepository
    {
        void CreateUpdate(List<GameEntity> entities);
        List<GameEntity> Get();
        void Delete();
    }
}
