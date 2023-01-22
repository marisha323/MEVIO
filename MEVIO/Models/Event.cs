namespace MEVIO.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName{ get; set; }
        public string? Description { get; set; }
        public int CreatorId { get; set; }
        public int? ClientTargetId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int? EvemtChatId { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
