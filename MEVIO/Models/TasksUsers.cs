using System.ComponentModel.DataAnnotations.Schema;

namespace MEVIO.Models
{
    public class TasksUsers
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public virtual Task Task { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
