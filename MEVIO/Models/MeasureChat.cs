namespace MEVIO.Models
{
    public class MeasureChat
    {
        public int Id { get; set; }
        public int MeasureId { get; set; }
        Name!:string(d:Measure.Name)
        public ICollection<User>?Users { get; set; }
        public ICollection<MeasureChatMessage>? Messages { get; set; }
    }
}
