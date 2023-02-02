namespace MEVIO.Models
{
    public class ResponsiblePersons
    {
        public int Id { get; set; }
        public ICollection<User> Users { get; set; }
        public ResponsiblePersons()
        {
            Users = new List<User>();
        }
    }
}
