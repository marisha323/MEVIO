namespace MEVIO.Models
{
    public class TasksWatchingPersons
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? TaskId { get; set; }
        public virtual Tasks Task { get; set; }
        public int? UnderTaskId { get; set; }
        public virtual UnderTask UnderTask { get; set; }
    }
}
