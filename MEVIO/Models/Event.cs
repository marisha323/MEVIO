namespace MEVIO.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName{ get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; }//CreaterId
        public virtual User User { get; set; }

        public int? ClientId { get; set; }//ClientTargetId
        public virtual Client Client { get; set; }

        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int? EventChatId { get; set; }
        public virtual EventChat EventChat { get; set; }
        public ICollection<User>? Users { get; set; }

        public Event()
        {
            Users = new List<User>();
        }
    }
}
