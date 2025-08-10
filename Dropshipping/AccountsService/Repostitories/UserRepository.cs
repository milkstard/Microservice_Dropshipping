using AccountsService.Helper;
using AccountsService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountsService.Repostitories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextClass _dbContext;
        public UserRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserByEmail(string email)
        {
            /*var user = _dbContext.Users.Where(user => user.Email == email).FirstOrDefault();*/
            var user = _dbContext.Users.Include(userDB => userDB.UserSalt).Include(userDB => userDB.UserType).FirstOrDefault(userDB => userDB.Email == email);

            return user;
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
