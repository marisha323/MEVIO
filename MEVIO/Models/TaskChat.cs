namespace MEVIO.Models
{
    public class TaskChat
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        Name!:string(d:Task.Name)
        public ICollection<User>? Users { get; set; }
        public ICollection<EventChatMessage>? Messages { get; set; }
    }
}
