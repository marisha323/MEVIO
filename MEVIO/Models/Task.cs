namespace MEVIO.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public int CreatorId { get; set; }
        public int? ClientTargetId { get; set; }
        public ICollection<User> ResponsiblePersons { get; set; }
        public ICollection<User>? WatchingPersons { get; set; }
        public ICollection<UnderTask>? UnderTasks { get; set; }
        public bool IsImportant { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
}
