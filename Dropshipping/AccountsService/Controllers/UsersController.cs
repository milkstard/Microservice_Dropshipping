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

        public UsersController(AuthHelper jwtTokenHelper, IUserService userService)
        {
            _jwtTokenHelper = jwtTokenHelper;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            //Get the user in the database
            var userExist = _userService.GetUserByLogin(userLoginDTO);
            return userExist is null ? Unauthorized() : Ok(userExist);
            //var loginResult = _jwtTokenHelper.GenerateAuthToken(userExist);
            //return loginResult is null ? Unauthorized() : Ok(loginResult);
        }
    }
}
