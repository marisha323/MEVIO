namespace MEVIO.Models
{
    public class UserEventAcceptStatus:UserAcceptStatus
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
