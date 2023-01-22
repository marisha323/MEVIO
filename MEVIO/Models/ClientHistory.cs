namespace MEVIO.Models
{
    public class ClientHistory
    {
        public int Id { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Measure>? Measures { get; set; }
        public bool IsAgreement{ get; set; }
        public int ClientId { get; set; }
    }
}
