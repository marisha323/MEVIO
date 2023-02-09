using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

namespace MEVIO.Models
{
    public class TasksClients
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
