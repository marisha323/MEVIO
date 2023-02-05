namespace MEVIO.Models
{
    public class MeasureChatMessage : ChatMessage // Захід Чат Повідомлення
    {
        public int Id { get; set; }
        public int MeasureChatId { get; set; }
        public virtual MeasureChat MeasureChat { get; set; }
    }
}
