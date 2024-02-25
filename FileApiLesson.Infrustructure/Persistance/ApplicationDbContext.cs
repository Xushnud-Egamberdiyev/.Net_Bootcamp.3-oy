using FileApiLesson.Domen.Entitys.Models;
using Microsoft.EntityFrameworkCore;

namespace FileApiLesson.Infrustructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<UserProfile> Users { get; set; }
    }
}
