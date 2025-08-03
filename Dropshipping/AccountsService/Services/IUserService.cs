using AccountsService.Models;

namespace AccountsService.Services
{
    public interface IUserService
    {
        public IEnumerable<Users> GetUsersList();
        public Users GetUserByLogin(int id);
        public Users GetUserById(int id);
        public Users GetUserByUserName(string name);
        public Users AddUser(Users user);
        public Users UpdateUser(Users user);
        public bool DeleteUser(int id);
    }
}
