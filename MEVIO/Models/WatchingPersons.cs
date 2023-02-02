namespace MEVIO.Models
{
    public class WatchingPersons
    {
        public int Id { get; set; }
        public ICollection<User> Users { get; set; }
        public WatchingPersons()
        {
            Users = new List<User>();
        }
    }
}
