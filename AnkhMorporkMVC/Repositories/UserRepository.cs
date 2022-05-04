using AnkhMorporkMVC.Models;
using System.Linq;

namespace AnkhMorporkMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) { _context = context; }

        public void CreateUpdate(UserModel user)
        {
            var userInDb = _context.User.FirstOrDefault();
            if (userInDb == null)
            {
                _context.User.Add(user);
            }
            else
            {
                userInDb.Moves = user.Moves;
                userInDb.Beers = user.Beers;
                userInDb.BalancePennies = user.BalancePennies;
            }
            _context.SaveChanges();
        }

        public void Delete()
        {
            var userModel = _context.User.FirstOrDefault();
            if ( userModel != null )
                _context.User.Remove(_context.User.First());
                _context.SaveChanges();
        }

        public UserModel Get()
        {
            var userModel = _context.User.FirstOrDefault();
            if (userModel == null)
                return null;

            return userModel;
        }
    }
}