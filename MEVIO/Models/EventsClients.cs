namespace MEVIO.Models
{
    public class EventsClients
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
