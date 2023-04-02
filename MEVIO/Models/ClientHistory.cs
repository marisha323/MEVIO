namespace MEVIO.Models
{
    public class ClientHistory
    {
        public int Id { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Task> Task { get; set; }
        public ICollection<Measure> Measures { get; set; }
        public bool IsAgreement { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }

        public ClientHistory()
        {
            Events = new List<Event>();
            Task = new List<Task>();
            Measures = new List<Measure>();
        }
    }
}
