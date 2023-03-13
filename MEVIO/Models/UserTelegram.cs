namespace MEVIO.Models
{
    public class UserTelegram
    {
        public int Id { get; set; }
        public string TelegramJson { get; set; }
        
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    
    }
}
