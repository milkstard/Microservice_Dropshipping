using AccountsService.Models;

namespace AccountsService.Repostitories
{
    public interface IUserSaltRepository
    {
        public UserSalt? GetUserSaltByEmail(string email);
    }
}