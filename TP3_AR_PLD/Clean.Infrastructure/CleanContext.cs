using Clean.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure
{
    public class CleanContext : DbContext
    {
        public DbSet<CalculVersements> CalculVersements { get; set; }
        public DbSet<DemandeAideFinancieres> DemandeAideFinanciere { get; set; }
        public DbSet<DossierEtudiants> DossierEtudiants { get; set; }
        public DbSet<Etudiants> Etudiants { get; set; }

        public CleanContext(DbContextOptions options) :
                             base(options)
        { }

        public CleanContext() : base(new
               DbContextOptionsBuilder<CleanContext>()

               .UseSqlServer(@"Server=.;Database=TP3DB;Trusted_Connection=True;")
               .Options)
        { }

    }
}
