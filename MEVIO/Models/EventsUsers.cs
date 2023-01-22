namespace MEVIO.Models
{
    public class EventsUsers
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
