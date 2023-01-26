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
        public ICollection<int>? EventsId {get; set;} //I did not understand if this should be Icollection or not

        public ICollection<int>? TasksId { get; set;}
        public ICollection<int>? MeasuresId { get; set; }
        //and same here
        public bool IsActive { get; set; }
        public User()
        {
            CoWorkers= new List<User>();
            EventsId= new List<int>();
            TasksId= new List<int>();
            MeasuresId= new List<int>();
            IsActive=false;
        }
    }
}
