using SimpleCRUDApp.Models;

namespace SimpleCRUDApp.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(int userId);
        Task<List<User>> GetUsersList();
        Task Add(User user);
        Task<bool> SaveChangesAsync();
    }

}
