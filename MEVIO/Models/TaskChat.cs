namespace MEVIO.Models
{
    public class TaskChat
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public string TaskChatName { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<EventChatMessage>? Messages { get; set; }

        public TaskChat()
        {
            Users = new List<User>();
            Messages = new List<EventChatMessage>();
        }
    }
}
