namespace MEVIO.Models
{
    public class UserCalendar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Measure>? Measures { get; set; }
    }
}
