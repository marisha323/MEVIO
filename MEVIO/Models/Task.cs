namespace MEVIO.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }//CreatorId
        public virtual User User{ get; set; }

        public int? ClientId { get; set; }//ClientTarget
        public virtual Client Client { get; set; }

        public ICollection<User> ResponsiblePersons { get; set; }
        public ICollection<User>? WatchingPersons { get; set; }
        public ICollection<UnderTask>? UnderTasks { get; set; }//подзадача
        public bool IsImportant { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public Task()
        {
            ResponsiblePersons = new List<User>();
            UnderTasks = new List<UnderTask>();
            WatchingPersons= new List<User>();

        }
    }
}
