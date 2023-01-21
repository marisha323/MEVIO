using Microsoft.EntityFrameworkCore;
namespace MEVIO.Models
{
    public class MEVIOContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public MEVIOContext(DbContextOptions<MEVIOContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
