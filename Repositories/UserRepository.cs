using Microsoft.EntityFrameworkCore;
using SimpleCRUDApp.Models;

namespace SimpleCRUDApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserById(int userId)
        {
            return await _context.Users
                .Where(x => !x.Deleted)
                .SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<List<User>> GetUsersList()
        {
            return await _context.Users
                .Where(x => !x.Deleted)
                .OrderBy(x=>x.Name)
                .ToListAsync();
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }

}
