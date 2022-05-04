using AnkhMorporkMVC.GameLogic.Entities;
using AnkhMorporkMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnkhMorporkMVC.Repositories
{
    public class GameEntitiesRepository : IGameEntitiesRepository
    {
        private ApplicationDbContext _context;

        public GameEntitiesRepository(ApplicationDbContext context) { _context = context; }

        public void CreateUpdate(List<GameEntity> entities)
        {
            if (_context.GameEntities.Any())
            {
                _context.GameEntities.RemoveRange(_context.GameEntities);
            }
            foreach (var entity in entities)
            {
                _context.GameEntities.Add(entity.ToModel());
            }
            _context.SaveChanges();
        }

        public List<GameEntity> Get()
        {
            var entityModels = _context.GameEntities;
            if (!entityModels.Any())
                return null;

            List<GameEntity> entities = new List<GameEntity>();
            foreach(var model in entityModels)
                entities.Add(model.ToObject());
            return entities;
        }

        public void Delete()
        {
            _context.GameEntities.RemoveRange(_context.GameEntities);
            _context.SaveChanges();
        }
    }
}