using Email_Domen.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Email_Infrustructur
{
    public class AddAplication : DbContext
    {
        public AddAplication(DbContextOptions<AddAplication> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<DocModel> Document { get; set; }
    }
}
