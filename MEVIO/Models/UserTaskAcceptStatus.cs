namespace MEVIO.Models
{
    public class UserTaskAcceptStatus :UserAcceptStatus
    {
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
