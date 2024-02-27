using Email_Domen.Entity.Model;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Infrustructur
{
    public class AddAplication : DbContext
    {
        public AddAplication(DbContextOptions<AddAplication> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Login> Logins { get; set; }
    }
}
