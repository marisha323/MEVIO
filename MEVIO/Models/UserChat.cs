namespace MEVIO.Models
{
    public class UserChat
    {
        public int Id { get; set; }
        public string UserChatName { get; set; }
        public ICollection<UserChatMessage> UserChatMessages { get; set; }
        public UserChat()
        {
            UserChatMessages = new List<UserChatMessage>();
        }
    }
}
