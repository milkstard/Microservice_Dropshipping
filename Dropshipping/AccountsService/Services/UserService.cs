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

        public async Task<Users?> AddUser(UserRegisterDTO userRegister)
        {
            //Check if username and email is existing
            var getUserByUserName = _userRepository.GetUserByUserName(userRegister.UserName);
            var getUserByEmail = _userRepository.GetUserByEmail(userRegister.Email);
            //var mapUserRegister = null;
            if (getUserByUserName == null && getUserByEmail == null)
            {
                var hashPassword = PasswordSaltAndHashHelper.HashPassword(userRegister.Password, out byte[] salt);
                var userSalt = await _userSaltRepository.CreateUserSalt(new UserSalt
                {
                    Salt = salt,
                    Hash = hashPassword
                });
                var mapUserRegister = new Users
                {
                    UserTypeFK = userRegister.UserType,
                    UserSaltId = userSalt.Id,
                    UserName = userRegister.UserName,
                    Email = userRegister.Email,
                    Contact_no = userRegister.Password,
                    Password = userSalt.Hash,
                    Confirmed_password = userSalt.Hash,
                    Birth_date = userRegister.Birth_date,
                    Created_date = DateTime.Now
                };
                return await _userRepository.AddUser(mapUserRegister);
            }

            return null;  
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
            //var userName = _userRepository.GetUserByEmailAndPassword(userLoginDetails.Email);
            /*var storedHash = _userSaltRepository.GetUserSaltByEmail(userLoginDetails.Email);*/
            var user = _userRepository.GetUserByEmailAndPassword(userLoginDetails.Email);
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
