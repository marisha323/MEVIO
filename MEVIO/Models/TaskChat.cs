namespace MEVIO.Models
{
    public class TaskChat
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public virtual Tasks Task { get; set; }

        public string TaskChatName { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }

        public TaskChat()
        {
            Users = new List<User>();
            ChatMessages = new List<ChatMessage>();
        }
    }
}
