using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsService.Models
{
    public class UserSalt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Stash {  get; set; }
        public byte[] Salt { get; set; }
        public Users User { get; set; }
    }
}
