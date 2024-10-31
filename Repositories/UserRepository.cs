using AkodoAPI.Interfaces;
using AkodoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AkodoAPI.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task Delete(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.IsDeleted = true;
        }

        public async Task<User> GetByPhone(string mobilePhone)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.MobilePhone == mobilePhone);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
