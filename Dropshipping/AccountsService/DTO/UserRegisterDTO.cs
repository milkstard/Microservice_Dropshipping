using System.ComponentModel.DataAnnotations;

namespace AccountsService.DTO
{
    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserType { get; set; }

        [Required]
        public string Contact_no { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string Confirmed_password { get; set; }

        [Required]
        public DateTime Birth_date { get; set; }
    }
}
