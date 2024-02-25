using FileApi.Domen.Entitys.Models;
using Microsoft.EntityFrameworkCore;

namespace FileApi.n.Infrustructure.Persistance
{
    public class ApDbContext : DbContext
    {
        public ApDbContext(DbContextOptions<ApDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Car> Cars {  get; set; }
    }
}
