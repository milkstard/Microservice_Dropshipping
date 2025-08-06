using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsService.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("UserTypeFK")]
        [Required(ErrorMessage = "ForeignKey Id is required")]
        public string UserTypeFK { get; set; }
        [Column("UserSaltId")]
        [Required(ErrorMessage = "ForeignKey Id is required")]
        public int UserSaltId { get; set; }
        public string UserName {  get; set; }
        public string Email { get; set; }
        public string Contact_no { get; set; }
        public string Password { get; set; }
        public string Confirmed_password {  get; set; }
        public DateTime Birth_date { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Updated_date { get; set; }
        [ForeignKey(nameof(UserTypeFK))]
        public UserTypes UserType { get; set; }
        [ForeignKey(nameof(UserSaltId))]
        public UserSalt UserSalt { get; set; }
    }
}

