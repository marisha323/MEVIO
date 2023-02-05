using System.ComponentModel.DataAnnotations.Schema;

namespace MEVIO.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string? Description { get; set; }

        public ICollection<TasksUsers> TasksUsers  { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }//CreatorId
        //public virtual User User { get; set; }
        //[ForeignKey("Client")]
        //public int? ClientId { get; set; }//ClientTarget
        //public virtual Client Client { get; set; }
        public ICollection<TasksClients> TaskClients { get; set; }

        //public ICollection<User> ResponsiblePersons { get; set; }
        //public ICollection<User>? WatchingPersons { get; set; }
        public ICollection<UnderTask> UnderTasks { get; set; }//подзадача
        public bool IsImportant { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }
        public ICollection<WatchingPerson> WatchingPersons { get; set; }
        public ICollection<TaskResponsiblePersons> TaskResponsiblePersons { get; set; }
        public ICollection<TasksWatchingPersons> TasksWatchingPersons { get; set; }

        public Task()
        {
            ResponsiblePersons = new List<ResponsiblePerson>();
            WatchingPersons = new List<WatchingPerson>();
            //ResponsiblePersons = new List<User>();
            UnderTasks = new List<UnderTask>();
            //WatchingPersons= new List<User>();
            TaskClients = new List<TasksClients>();
            TaskResponsiblePersons = new List<TaskResponsiblePersons>();
            TasksWatchingPersons = new List<TasksWatchingPersons>();

            TasksUsers = new List<TasksUsers>();
        }
    }
}
