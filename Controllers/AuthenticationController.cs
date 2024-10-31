using AkodoAPI.DTOs;
using AkodoAPI.Interfaces;
using AkodoAPI.Models;
using AkodoAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthenticationController(IUserService userService, IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserRegisterDto userDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _userService.Exist(userDto.MobilePhone))
            {
                return BadRequest("User Already Exist");
            }
            // build otp logic
            User user = await _userService.Register(userDto);
            await _userService.GenerateOTP(user);
            await _userRepository.SaveAsync();
            return Ok(new { message = "Verification Code Sent", userId = user.Id });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserLoginDto userDto)
        {
            User user = await _userRepository.GetByPhone(userDto.MobilePhone);
            if (user == null)
            {
                return NotFound("Wrong Mobile Phone Number or Password");
            }
            if (!_userService.ValidatePassword(user, userDto.Password))
            {
                return NotFound("Wrong Mobile Phone Number or Password");
            }
            if (!user.IsVerified)
            {
                return Unauthorized("Account is not verified");
            }
            if (user.IsSuspended)
            {
                return Forbid("Account is suspended");
            }
            await _userService.GenerateOTP(user);
            await _userRepository.SaveAsync();
            return Ok(new { message = "Verification Code Sent", userId = user.Id });
        }

        [HttpPost("VerifyUser/{id}")]
        public async Task<ActionResult> VerifyUser(int id,int otp)
        {
            User user = await _userRepository.GetById(id);
            if(user == null)
            {
                return NotFound("User Not Found");
            }
            if(user.OTP == null)
            {
                return BadRequest("No OTP Was Issued");
            }
            if(!_userService.ValidateOTP(user, otp))
            {
                return Unauthorized("Wrong Verification Code");
            }
            if (!user.IsVerified)
            {
                user.IsVerified = true;
            }
            user.OTP = null;
            await _userRepository.SaveAsync();
            // jwt logic
            var token = _jwtService.GenerateToken(user.Id, user.Type);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return Ok(new {userDto, token});
        }

        [HttpPost("ResendOTP")]
        public async Task<ActionResult> ResendOTP(int id)
        {
            User user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            if (user.OTP == null)
            {
                return BadRequest("No OTP Was Issued");
            }
            await _userService.GenerateOTP(user);
            await _userRepository.SaveAsync();
            return Ok(new { message = "Verification Code Sent", userId = user.Id });
        }

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string phone)
        {
            // build otp logic
            User user = await _userRepository.GetByPhone(phone);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            await _userService.GenerateOTP(user);
            await _userRepository.SaveAsync();
            return Ok(new { message = "Verification Code Sent", userId = user.Id });
        }

        [HttpGet("basic")]
        [Authorize]
        public ActionResult TestAuth()
        {
            int userId = _userService.GetUserId();
            string userRole = _userService.GetUserRole();
            return Ok($"basic: {userId}, {userRole}");
        }

        [HttpGet("student")]
        [Authorize(policy:"Student")]
        public ActionResult TestAuth2()
        {
            int userId = _userService.GetUserId();
            string userRole = _userService.GetUserRole();
            return Ok($"user: {userId}, {userRole}");
        }

        [HttpGet("Owner")]
        [Authorize(policy:"Owner")]
        public ActionResult TestAuth3()
        {
            int userId = _userService.GetUserId();
            string userRole = _userService.GetUserRole();
            return Ok($"admin: {userId}, {userRole}");
        }
    }
}
