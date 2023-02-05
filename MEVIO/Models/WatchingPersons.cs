namespace MEVIO.Models
{
    public class WatchingPerson:User
    {
        public int Id { get; set; }
        public ICollection<User> Users { get; set; }
        public WatchingPerson()
        {
            Users = new List<User>();
        }
    }
}
