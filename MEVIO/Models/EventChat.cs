namespace MEVIO.Models
{
    public class EventChat
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public string EventChatName { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<ChatMessage> ChatMessage { get; set; }

        public EventChat()
        {
            Users = new List<User>();
            ChatMessage = new List<ChatMessage>();

        }
    }
}
