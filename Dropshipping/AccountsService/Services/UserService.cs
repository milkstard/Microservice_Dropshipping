using AccountsService.Models;
using AccountsService.Repostitories;

namespace AccountsService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
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

        public Users GetUserByLogin(int id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserByUserName(string name)
        {
            throw new NotImplementedException();
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
