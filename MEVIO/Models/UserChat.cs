namespace MEVIO.Models
{
    public class UserChat
    {
        public int Id { get; set; }
        public string UserChatName { get; set; }
        public ICollection<UserChatUser> UserChatUsers { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
        public UserChat()
        {
            UserChatUsers = new List<UserChatUser>();
            ChatMessages = new List<ChatMessage>();
        }
    }
}
