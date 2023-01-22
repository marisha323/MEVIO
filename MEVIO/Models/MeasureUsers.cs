namespace MEVIO.Models
{
    public class MeasureUsers
    {
        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
