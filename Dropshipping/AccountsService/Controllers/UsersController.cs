using AccountsService.DTO;
using AccountsService.Helper;
using AccountsService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AuthHelper _jwtTokenHelper;
        private readonly IUserService _userService;
        private readonly AuthHelper _authHelper;
        public UsersController(AuthHelper jwtTokenHelper, IUserService userService, AuthHelper authHelper)
        {
            _jwtTokenHelper = jwtTokenHelper;
            _userService = userService;
            _authHelper = authHelper;
        }

        [HttpPost]
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
    }
}
