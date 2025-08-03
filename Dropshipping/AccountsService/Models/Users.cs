using System;
using System.ComponentModel.DataAnnotations;

namespace AccountsService.Models
{
    public class Users
    {
        [Key]
        [Required(ErrorMessage = "PrimaryKey Id is required")]
        public Guid Id { get; set; }
        public Guid UserTypes { get; set; }
        public string User {  get; set; }
        public string Email { get; set; }
        public string Contact_no { get; set; }
        public string Password { get; set; }
        public string Confirmed_password {  get; set; }
        public DateTime Birth_date { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Updated_date { get; set; }
        public UserTypes UserType { get; set; }
    }
}

