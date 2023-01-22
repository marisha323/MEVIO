namespace MEVIO.Models
{
    public class EventChatMessage: ChatMessage
    {
        public int EventChatId { get; set; }
        public virtual EventChat EventChat{ get; set; }

    }
}
