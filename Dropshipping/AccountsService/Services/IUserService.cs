using AccountsService.DTO;
using AccountsService.Models;

namespace AccountsService.Services
{
    public interface IUserService
    {
        public IEnumerable<Users> GetUsersList();
        public Users GetUserByLogin(UserLoginDTO userLoginDetails);
        public Users GetUserById(int id);
        public Task<Users> AddUser(UserRegisterDTO userRegister);
        public Users UpdateUser(Users user);
        public bool DeleteUser(int id);
    }
}
