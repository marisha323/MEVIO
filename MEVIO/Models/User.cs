namespace MEVIO.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public ICollection<User>? CoWorkers { get; set; }
        public string? TelegramJsonId { get; set; }
        public ICollection<int>? Events {get; set;} //I did not understand if this should be Icollection or not

        public ICollection<int>? Tasks { get; set;}
        public ICollection<int>? Measures { get; set; }
 //and same here

        public User()
        {
            CoWorkers= new List<User>();
            Events= new List<int>();
            Tasks= new List<int>();
            Measures= new List<int>();
        }
    }
}
