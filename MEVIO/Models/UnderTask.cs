namespace MEVIO.Models
{
    public class UnderTask
    {
        public int Id { get; set; }
        public string UnderTaskName { get; set; }
        public ICollection<User> ResponsiblePersons { get; set; }
        public ICollection<User> WatchingPersons { get; set; }
        public int TaskId { get; set; }
    }
}
