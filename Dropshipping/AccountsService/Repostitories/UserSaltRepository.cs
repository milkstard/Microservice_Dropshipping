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
         
        public async Task<UserSalt?> CreateUserSalt(UserSalt usersalt)
        {
            var data = _dbContextClass.UserSalts.Add(usersalt);
            var success = await _dbContextClass.SaveChangesAsync();

            return success > 0 ? data.Entity : null;
        }
    }
} 
