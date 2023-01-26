namespace MEVIO.Models
{
    public class UserMeasureAcceptStatus : UserAcceptStatus
    {
        public int Id { get; set; }

        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
    }
}
