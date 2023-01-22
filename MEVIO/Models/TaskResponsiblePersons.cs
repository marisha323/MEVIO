namespace MEVIO.Models
{
    public class TaskResponsiblePersons
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int? UnderTaskId { get; set; }
    }
}
