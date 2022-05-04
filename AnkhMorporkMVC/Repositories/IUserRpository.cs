using AnkhMorporkMVC.Models;

namespace AnkhMorporkMVC.Repositories
{
    public interface IUserRepository
    {
        void CreateUpdate(UserModel user);
        UserModel Get();
        void Delete();
    }
}
