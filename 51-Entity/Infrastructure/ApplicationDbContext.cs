using _51_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace _51_Entity.Infrastructure
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<car> Cars { get; set; }
    }
}
