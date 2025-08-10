using AccountsService.Models;

namespace AccountsService.Helper
{
    public static class AccountSeederClass
    {
        public static void AccountDataPopulate(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDataUserType(serviceScope.ServiceProvider.GetService<DbContextClass>());
                SeedDataUser(serviceScope.ServiceProvider.GetService<DbContextClass>());
            }
        }

        private static void SeedDataUserType(DbContextClass context)
        {
            var userTypes = new List<UserTypes> { 
                new UserTypes
                {
                    TypeName = "Administrator"
                },
                new UserTypes
                {
                    TypeName = "Seller"
                },
                new UserTypes
                {
                    TypeName = "Customer"
                }
            };
            if(!context.UserTypes.Any())
            {
                context.UserTypes.AddRange(userTypes);
                context.SaveChanges();
            }
        }

        private static void SeedDataUser(DbContextClass context)
        {
            if (!context.Users.Any())
            {
                var userSalt = CreateSaltPassword("admin123", context);
                var user = new List<Users> {
                    new Users
                    {
                        UserTypeFK = "Administrator",
                        UserSaltId = GetSaltId(context, userSalt.Salt, userSalt.Hash),
                        UserName = "admin",
                        Email = "admin@admin.com",
                        Contact_no = "+63-927238",
                        Password = userSalt.Hash,
                        Confirmed_password = userSalt.Hash,
                        Birth_date = new DateTime(2000, 02, 09),
                        Created_date = DateTime.Now

                    }
                };

                context.Users.AddRange(user);
                context.SaveChanges();
            }
        }

        private static UserSalt CreateSaltPassword(string password, DbContextClass context)
        {
            var hashedPass = PasswordSaltAndHashHelper.HashPassword(password, out byte[] salt);

            context.UserSalts.Add(new UserSalt
            {
                Salt = salt,
                Hash = hashedPass
            });
            context.SaveChanges();
            return new UserSalt{ Hash = hashedPass, Salt = salt};
        }

        private static int GetSaltId(DbContextClass context, byte[] salt, string hash)
        {
            var saltId = context.UserSalts.Where(userSalt =>
               userSalt.Salt == salt && userSalt.Hash == hash).Select(userSalt => userSalt.Id).FirstOrDefault();
            
            return saltId;
        }
    }
}
