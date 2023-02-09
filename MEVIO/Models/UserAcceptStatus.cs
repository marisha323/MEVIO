namespace MEVIO.Models
{
    public class UserAcceptStatus
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsAccept { get; set; } //принял не принял преглашения
        public int? MeasureUsersId { get; set; }
        public virtual MeasureUsers MeasureUsers { get; set; }
    }
}
