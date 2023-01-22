namespace MEVIO.Models
{
    public class TaskChatMessage: ChatMessage
    {
        public int TaskChatId { get; set; }
        public virtual TaskChat TaskChat { get; set; }
    }
}
