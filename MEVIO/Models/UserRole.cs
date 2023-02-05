namespace MEVIO.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public  string UserRoleName { get; set; }
        public ICollection<User> Users { get; set; }
        //"Client","Admin","Manager","Director"
    }
}
