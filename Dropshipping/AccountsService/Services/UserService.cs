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
        private readonly IUserSaltRepository _userSaltRepository;
        public UserService(AuthHelper authHelper, IUserRepository userRepository, IUserSaltRepository userSaltRepository) 
        {
            _authHelper = authHelper;
            _userRepository = userRepository; 
            _userSaltRepository = userSaltRepository;
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
            //var userName = _userRepository.GetUserByEmail(userLoginDetails.Email);
            /*var storedHash = _userSaltRepository.GetUserSaltByEmail(userLoginDetails.Email);*/
            var user = _userRepository.GetUserByEmail(userLoginDetails.Email);
            if (user == null)
            {
                return null;
            }

            var userPass = PasswordSaltAndHashHelper.VerifyPassword(userLoginDetails.Password, user.UserSalt.Hash, user.UserSalt.Salt);

            return userPass ? user: null;
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
