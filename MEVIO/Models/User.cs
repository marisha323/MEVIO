namespace MEVIO.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public virtual UserRole Role { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public ICollection<User>? CoWorkers { get; set; }
        public string? TelegramJsonId { get; set; }
        public ICollection<Event>? Events { get; set; } //I did not understand if this should be Icollection or not

        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Measure>? Measures { get; set; }
        public ICollection<UserChat>? UserChats { get; set; }
        //and same here
        public DateTime? LastTimeSignIn { get; set; }
        public DateTime Birthdate { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfPassportIssue { get; set; }
        public string TIN { get; set; }
        public bool IsActive { get; set; }
        public User()
        {
            CoWorkers = new List<User>();
            Events = new List<Event>();
            Tasks = new List<Task>();
            Measures = new List<Measure>();
            UserChats = new List<UserChat>();
            IsActive = false;
        }
    }
}
