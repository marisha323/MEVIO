namespace MEVIO.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        //UserId
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime DateTime { get; set; }
        public string? Text { get; set; }
        public string? FilePath { get; set; }
        public string? ImagePath { get; set; }
    }
}
