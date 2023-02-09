namespace MEVIO.Models
{
    public class UserTaskAcceptStatus :UserAcceptStatus
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
