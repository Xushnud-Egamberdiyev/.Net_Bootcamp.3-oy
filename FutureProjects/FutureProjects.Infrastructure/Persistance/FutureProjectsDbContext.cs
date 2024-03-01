using FutureProjects.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FutureProjects.Infrastructure.Persistance
{
    public class FutureProjectsDbContext : DbContext
    {
        public FutureProjectsDbContext(DbContextOptions<FutureProjectsDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<FutureProjects.Domain.Entities.Models.User> Users { get; set; }
    }
}
