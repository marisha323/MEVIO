namespace MEVIO.Models
{
    public class UnderTask
    {
        public int Id { get; set; }
        public string UnderTaskName { get; set; }
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }
        public ICollection<WatchingPerson> WatchingPersons { get; set; }
        public ICollection<TaskResponsiblePersons> TaskResponsiblePersons { get; set; }
        public ICollection<TasksWatchingPersons> TasksWatchingPersons { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
      
        public UnderTask()
        {
            ResponsiblePersons= new List<ResponsiblePerson>();
            WatchingPersons= new List<WatchingPerson>();
            TaskResponsiblePersons=new List<TaskResponsiblePersons>();
            TasksWatchingPersons=new List<TasksWatchingPersons>();

        }
    }
}
