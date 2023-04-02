namespace MEVIO.Models
{
    public class DashBoard
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Measure> Measures { get; set; }

        public DashBoard()
        {

            Events = new List<Event>();
            Tasks = new List<Tasks>();
            Measures = new List<Measure>();
        }

    }
}
