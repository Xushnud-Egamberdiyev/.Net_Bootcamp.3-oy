using LearningApiAndEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApiAndEntity.Infracture
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
