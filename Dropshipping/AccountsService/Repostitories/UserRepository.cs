using AccountsService.Models;

namespace AccountsService.Repostitories
{
    public class UserRepository : IUserRepository
    {
        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserByUserName(string userName)
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
