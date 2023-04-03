using System.ComponentModel.DataAnnotations.Schema;

namespace MEVIO.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string? Description { get; set; }//описання
    
        public int? UserId { get; set; }//CreaterId
        public virtual User User { get; set; }


        public ICollection<EventsClients> EventsClients { get; set; }//ClientTargetId
        
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int? EventChatId { get; set; }
        public virtual EventChat EventChat { get; set; }
        public ICollection<EventsUsers> EventsUsers { get; set; }
        //public int? UserCalendarId { get; set; }
        //public virtual UserCalendar UserCalendar { get; set; }
        public ICollection<UserEventAcceptStatus> UserEventAcceptStatuses { get; set; }
      
        
        public Event()
        {
            EventsUsers = new List<EventsUsers>();
            EventsClients = new List<EventsClients>();
            UserEventAcceptStatuses = new List<UserEventAcceptStatus>();
        }
    }
}
