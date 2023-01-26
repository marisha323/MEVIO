namespace MEVIO.Models
{
    public class EventChatMessage: ChatMessage
    {
        public int Id { get; set; }
        public int EventChatId { get; set; }
        public virtual EventChat EventChat{ get; set; }

    }
}
