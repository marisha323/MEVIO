namespace MEVIO.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }

        //ClientStatus
        public int? ClientStatusId { get; set; }
        public virtual ClientStatus ClientStatus { get; set; }

        public int? MeasurePowerBiId { get; set; }
        public virtual MeasurePowerBi MeasurePowerBi { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfPassportIssue { get; set; }
        public string TIN { get; set; }
        public ICollection<TasksClients> TaskClients { get; set; }
        public ICollection<EventsClients> EventsClients { get; set; }
        public ICollection<MeasuresClients> MeasuresClients { get; set; }
        public Client()
        {
            TaskClients = new List<TasksClients>();
            EventsClients = new List<EventsClients>();
            MeasuresClients = new List<MeasuresClients>();
        }
    }
    

}
