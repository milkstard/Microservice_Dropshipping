using AccountsService.Models;

namespace AccountsService.Repostitories
{
    public interface IUserRepository
    {
        public IEnumerable<Users> GetUsersList();
        public Task<Users> AddUser(Users userRegister);
        public Users GetUserById(Guid id);
        public Users GetUserByEmailAndPassword(string userName);
        public Users? GetUserByEmail(string email);
        public Users? GetUserByUserName(string username);
        public Users UpdateUser(Users user);
        public bool DeleteUser(Guid id);
    }
}
