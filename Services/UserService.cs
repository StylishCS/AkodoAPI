using AkodoAPI.DTOs;
using AkodoAPI.Helpers;
using AkodoAPI.Interfaces;
using AkodoAPI.Models;
using AutoMapper;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace AkodoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IHashHelper _hashHelper;
        private readonly IUserRepository _userRepository;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHashHelper hashHelper, IUserRepository userRepository, HttpClient httpClient, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _hashHelper = hashHelper;
            _userRepository = userRepository;
            _httpClient = httpClient;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<User> Register(UserRegisterDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.Password = _hashHelper.Hash(user.Password);
            await _userRepository.Create(user);
            return user;
        }
        public async Task<bool> VerifyCredentials(string mobilePhone, string password)
        {
            User user = await _userRepository.GetByPhone(mobilePhone);
            if(user == null)
            {
                return false;
            }
            return _hashHelper.Verify(user.Password, password);
        }
        public async Task GenerateOTP(User user)
        {
            Random r = new Random();
            int otp = r.Next(1000, 10000);
            user.OTP = _hashHelper.Hash(otp.ToString());

            string environment = Environment.GetEnvironmentVariable("SMS_ENVIRONMENT")!;
            string username = Environment.GetEnvironmentVariable("SMS_USERNAME")!;
            string password = Environment.GetEnvironmentVariable("SMS_PASSWORD")!;
            string sender = Environment.GetEnvironmentVariable("SMS_SENDER")!;
            string template = Environment.GetEnvironmentVariable("SMS_TEMPLATE")!;

            string url = $"https://smsmisr.com/api/OTP/?environment={environment}" +
                         $"&username={username}&password={password}" +
                         $"&sender={sender}&mobile={user.MobilePhone}" +
                         $"&template={template}&otp={otp}";

            var response = await _httpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
        }
        public bool IsUserVerified(User user)
        {
            return user.IsVerified;
        }
        public bool IsUserSuspended(User user)
        {
            return user.IsSuspended;
        }

        public async Task<bool> Exist(string mobilePhone)
        {
            return await _userRepository.GetByPhone(mobilePhone) != null;
        }

        public bool ValidateOTP(User user, int otp)
        {
            return _hashHelper.Verify(otp.ToString(), user.OTP);
        }

        public int GetUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        public string GetUserRole()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role)!;
        }

        public bool ValidatePassword(User user, string password)
        {
            return _hashHelper.Verify(password, user.Password);
        }
    }
}
