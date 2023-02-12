namespace MEVIO.Models
{
    public class MeasuresClients
    {
        public int Id { get; set; }
        public int? MeasureId { get; set; }
        public virtual Measure Measure { get; set; }

        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
