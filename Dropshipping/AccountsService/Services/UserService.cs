using AccountsService.DTO;
using AccountsService.Helper;
using AccountsService.Models;
using AccountsService.Repostitories;

namespace AccountsService.Services
{
    public class UserService : IUserService
    {
        private readonly AuthHelper _authHelper;
        private readonly IUserRepository _userRepository;
        public UserService(AuthHelper authHelper, IUserRepository userRepository) 
        {
            _authHelper = authHelper;
            _userRepository = userRepository; 
        }

        public Users AddUser(Users user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserByLogin(UserLoginDTO userLoginDetails)
        {
            var userName = _userRepository.GetUserByUserName(userLoginDetails.UserName);
            var storedHash = _userRepository.
            if (userName == null)
            {
                return null;
            }

            var userPass = PasswordSaltAndHashHelper.VerifyPassword(userLoginDetails.Password, storedHash, out byte[] salt);
            
        }

        public IEnumerable<Users> GetUsersList()
        {
            throw new NotImplementedException();
        }

        public Users UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
