namespace MEVIO.Views.Calendar
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateEnd { get; set; }
        public bool IsFullDay { get; set; }
        public string EventDescription { get; set; }
    }
}
