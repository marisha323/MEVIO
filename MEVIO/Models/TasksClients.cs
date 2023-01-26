namespace MEVIO.Models
{
    public class TasksClients
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
