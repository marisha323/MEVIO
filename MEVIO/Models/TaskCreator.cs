namespace MEVIO.Models
{
    public class TaskCreator:User  
    {
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
