using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.Models;
using System.Collections.Generic;

namespace AnkhMorporkMVC.Repositories
{
    public interface IGameEntitiesRepository
    {
        void CreateUpdate(List<GameEntity> entities);
        List<GameEntityModel> Get();
        void Delete();
    }
}
