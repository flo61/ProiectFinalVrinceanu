using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vacanta.Models;

namespace vacanta.Data
{
    public class vacantaContext : DbContext
    {
        public vacantaContext (DbContextOptions<vacantaContext> options)
            : base(options)
        {
        }

        public DbSet<vacanta.Models.Luna> Luna { get; set; } = default!;

        public DbSet<vacanta.Models.Continent> Continent { get; set; }

        public DbSet<vacanta.Models.Tara> Tara { get; set; }

        public DbSet<vacanta.Models.Oras> Oras { get; set; }

        public DbSet<vacanta.Models.Vizitat> Vizitat { get; set; }
    }
}
