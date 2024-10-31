using AkodoAPI.Helpers;
using AkodoAPI.Interfaces;
using AkodoAPI.Models;
using AkodoAPI.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AkodoAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        

        public IUserRepository UserRepository {get; private set;}

        public IUserService UserService { get; private set; }

        public IJwtService JwtService {get; private set;}

        public IMapper Mapper { get; private set; }

        public IHashHelper HashHelper { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
