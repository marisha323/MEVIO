using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Views.Calendar
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateEnd { get; set; }
        [BindProperty(Name = "time1")]
        public DateTime Time1 { get; set; }
        [BindProperty(Name = "time2")]
        public DateTime Time2 { get; set; }
        public bool IsFullDay { get; set; }
        public string EventDescription { get; set; }
    }
}
