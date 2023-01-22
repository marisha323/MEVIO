namespace MEVIO.Models
{
    public class MeasurePowerBi
    {
        public int Id { get; set; }
        public int MeasureId { get; set; }
        public ICollection<Client> Clients { get; set; }
        public int ContractsCount { get; set; }
    }
}
