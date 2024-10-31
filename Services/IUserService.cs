using AkodoAPI.DTOs;
using AkodoAPI.Models;

namespace AkodoAPI.Services
{
    public interface IUserService
    {
        Task<User> Register(UserRegisterDto user);
        Task<bool> VerifyCredentials(string mobilePhone, string password);
        bool IsUserVerified(User user);
        bool IsUserSuspended(User user);
        Task GenerateOTP(User user);
        Task<bool> Exist(string mobilePhone);
        bool ValidateOTP(User user, int otp);
        bool ValidatePassword(User user, string password);
        int GetUserId();
        string GetUserRole();
    }
}