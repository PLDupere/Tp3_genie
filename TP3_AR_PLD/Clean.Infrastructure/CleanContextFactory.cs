using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure
{
    public class CleanContextFactory :
    IDesignTimeDbContextFactory<CleanContext>
    {
        public CleanContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new
            DbContextOptionsBuilder<CleanContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=TP3DB;Trusted_Connection=True;");
            return new CleanContext(optionsBuilder.Options);
        }
    }
}
