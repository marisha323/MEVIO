namespace MEVIO.Models
{
    public class MeasureChat
    {
        public int Id { get; set; }
        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }

        public  string  MeasureChatName {get;set;}//


        public ICollection<User>?Users { get; set; }
        public ICollection<MeasureChatMessage>? Messages { get; set; }

        public MeasureChat() { 
        
            Users = new List<User>();
            Messages = new List<MeasureChatMessage>();
        }
    }
}
