using AccountsService.DTO;
using AccountsService.Helper;
using AccountsService.Models;
using AccountsService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AuthHelper _jwtTokenHelper;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly AuthHelper _authHelper;
        public UsersController(AuthHelper jwtTokenHelper, IUserService userService, AuthHelper authHelper, IMapper mapper)
        {
            _jwtTokenHelper = jwtTokenHelper;
            _userService = userService;
            _authHelper = authHelper;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            //Get the user in the database
            var user = _userService.GetUserByLogin(userLoginDTO);
            if (user == null)
            {
                return Unauthorized();
            }
            //Get the authentication token
            var userAuth = _authHelper.GenerateAuthToken(user);
            
            return userAuth != null ? Ok(userAuth) : Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegister)
        {
            var user = await _userService.AddUser(userRegister);
            if (_mapper == null)
            {
                Console.WriteLine("OK");
            }
            return user != null ? Ok(_mapper.Map<UserRegisterDTO>(user)): Unauthorized();
        }
    }
}