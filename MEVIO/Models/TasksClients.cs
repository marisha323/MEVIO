using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

namespace MEVIO.Models
{
    public class TasksClients
    {

        public int Id { get; set; }
        public int? TaskId { get; set; }
        public virtual Tasks Task { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
