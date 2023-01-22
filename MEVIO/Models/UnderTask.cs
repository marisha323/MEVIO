namespace MEVIO.Models
{
    public class UnderTask
    {
        public int Id { get; set; }
        public string UnderTaskName { get; set; }
        public ICollection<User> ResponsiblePersons { get; set; }
        public ICollection<User> WatchingPersons { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
      
        public UnderTask()
        {
            ResponsiblePersons= new List<User>();
            WatchingPersons= new List<User>();

        }
    }
}
