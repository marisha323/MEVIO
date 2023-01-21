using Telegram.Bot.Types;

namespace MEVIO.Models
{
    public class MeasureChat
    {
        public int Id { get; set; }
        public int MeasureId { get; set; }
        public string MeasureName { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<MeasureChatMessage> Messages { get; set; }
    }
}
