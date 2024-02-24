using FileApiLesson.Domen.Entitys.Models;
using Microsoft.EntityFrameworkCore;

namespace FileApiLesson.Infrustructure.Persistance
{
    public class AplicationDbContect : DbContext
    {
        public AplicationDbContect(DbContextOptions<AplicationDbContect> options) : base(options)
        {

        }

        public static DbSet<UserProfile> Users { get; set; }
    }
}
