using AkodoAPI.Helpers;
using AkodoAPI.Services;
using AutoMapper;

namespace AkodoAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserService UserService { get; }
        IJwtService JwtService {  get; }
        IMapper Mapper { get; }
        IHashHelper HashHelper { get; }
        Task SaveAsync();
    }
}
