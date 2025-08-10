using AccountsService.Helper;
using AccountsService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountsService.Repostitories
{
    public class UserSaltRepository : IUserSaltRepository
    {   
        private readonly DbContextClass _dbContextClass;
        public UserSaltRepository(DbContextClass dbContextClass) 
        {
            _dbContextClass = dbContextClass;
        }
        public UserSalt? GetUserSaltByEmail(string email)
        {
            var userSalt = _dbContextClass.Users.Include(userDB => userDB.UserSalt).Where(userDB => userDB.Email == email).Select(user => user.UserSalt).FirstOrDefault(userSaltDB => userSaltDB.User.Email == email);

            return userSalt;
        }
    }
}
