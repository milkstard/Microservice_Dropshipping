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

        public Users GetUserByEmailAndPassword(string email)
        {
            /*var user = _dbContext.Users.Where(user => user.Email == email).FirstOrDefault();*/
            var user = _dbContext.Users.Include(userDB => userDB.UserSalt).Include(userDB => userDB.UserType).FirstOrDefault(userDB => userDB.Email == email);

            return user;
        }

        public Users? GetUserByEmail(string email)
        {
            /*var user = _dbContext.Users.Where(user => user.Email == email).FirstOrDefault();*/
            var user = _dbContext.Users.Where(userDB => userDB.Email == email).FirstOrDefault();

            return user;
        }

        public Users? GetUserByUserName(string username)
        {
            var user = _dbContext.Users.Where(userDB => userDB.UserName == username).FirstOrDefault();

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

        public async Task<Users?> AddUser(Users userRegister)
        {
            var data = _dbContext.Users.Add(userRegister);
            var successAdd = await _dbContext.SaveChangesAsync();

            return successAdd > 0 ? data.Entity : null;
        }
    }
}
