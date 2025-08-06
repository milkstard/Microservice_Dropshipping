using AccountsService.DTO;
using AccountsService.Models;

namespace AccountsService.Services
{
    public interface IUserService
    {
        public IEnumerable<Users> GetUsersList();
        public Users GetUserByLogin(UserLoginDTO userLoginDetails);
        public Users GetUserById(int id);
        public Users AddUser(Users user);
        public Users UpdateUser(Users user);
        public bool DeleteUser(int id);
    }
}
