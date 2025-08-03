namespace AccountsService.Models
{
    public class UserTypes
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
