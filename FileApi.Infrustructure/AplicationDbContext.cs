using FileApi.Domain.Entitys.Models;
using Microsoft.EntityFrameworkCore;

namespace FileApi.Infrustructure
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        DbSet<Car> Cars { get; set; }
    }
}
