using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsService.Models
{
    public class UserTypes
    {
        [Key]
        [Column("TypeName")]
        public string TypeName { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
