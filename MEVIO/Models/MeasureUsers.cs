namespace MEVIO.Models
{
    public class MeasureUsers
    {
        public int Id { get; set; }
        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int? UserAcceptStatusId { get; set; }
        public virtual UserAcceptStatus UserAcceptStatus { get; set; }
    }
}
