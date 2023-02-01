namespace MEVIO.Models
{
    public class UserChatMessage : ChatMessage
    {
        public int Id { get; set; }
        public int UserChatId { get; set; }
        public virtual UserChat UserChat { get; set; }
        public bool Status { get; set; }
        public UserChatMessage()
        {
            Status = false;
        }
    }
}
