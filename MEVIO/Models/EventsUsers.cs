namespace MEVIO.Models
{
    public class EventsUsers
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public virtual Event Event { get; set; }

        public bool IsCreator { get; set; }     //added 15.03.23

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
