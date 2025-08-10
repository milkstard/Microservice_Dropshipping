using AccountsService.Models;

namespace AccountsService.Repostitories
{
    public interface IUserRepository
    {
        public IEnumerable<Users> GetUsersList();
        public Users GetUserById(Guid id);
        public Users GetUserByEmail(string userName);
        public Users UpdateUser(Users user);
        public bool DeleteUser(Guid id);
    }
}
