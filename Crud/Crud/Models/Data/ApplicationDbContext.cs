using Microsoft.EntityFrameworkCore;

namespace Crud.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) {}

        public DbSet<Student> Students { get; set; }
    }
}
