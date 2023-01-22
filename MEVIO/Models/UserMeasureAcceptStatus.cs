namespace MEVIO.Models
{
    public class UserMeasureAcceptStatus : UserAcceptStatus
    {
        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
    }
}
