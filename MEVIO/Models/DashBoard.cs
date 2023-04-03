namespace MEVIO.Models
{
    public class DashBoard
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<Task> Task { get; set; }
        public ICollection<Measure> Measures { get; set; }

        public DashBoard()
        {

            Events = new List<Event>();
            Task = new List<Task>();
            Measures = new List<Measure>();
        }

    }
}
