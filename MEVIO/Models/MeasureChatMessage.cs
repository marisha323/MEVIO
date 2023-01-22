namespace MEVIO.Models
{
    public class MeasureChatMessage : ChatMessage
    {
        public int MeasureChatId { get; set; }
        public virtual MeasureChat MeasureChat { get; set; }
    }
}
