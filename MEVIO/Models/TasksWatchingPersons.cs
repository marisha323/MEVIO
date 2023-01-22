namespace MEVIO.Models
{
    public class TasksWatchingPersons
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int? UnderTaskId { get; set; }
    }
}
