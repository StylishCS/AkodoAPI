using AkodoAPI.Models;

namespace AkodoAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByPhone(string mobilePhone);
        Task<User> GetById(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
        Task SaveAsync();
    }
}