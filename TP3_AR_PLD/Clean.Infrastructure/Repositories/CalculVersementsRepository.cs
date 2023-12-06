using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.SharedKernel.Interfaces;

namespace Clean.Infrastructure.Repositories
{
    public class CalculVersementsRepository :  EfRepository<CalculVersements>, ICalculVersementsRepository
    {
        public CalculVersementsRepository(CleanContext cleanContext) : base(cleanContext)
        {
        }

        public CalculVersements GetByIdWithCalculVersements(int id)
        {
            return _CleanContext.CalculVersements
             .Include(r => r.Id)
             .First();
        }

        public Task<CalculVersements> GetByIdWithCalculVersementsAsync(int id)
        {
            return _CleanContext.CalculVersements
             .Include(r => r.Id)
             .FirstOrDefaultAsync();
        }

    }
}
