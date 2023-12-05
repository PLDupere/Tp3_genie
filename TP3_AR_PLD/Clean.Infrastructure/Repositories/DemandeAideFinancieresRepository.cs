using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Repositories
{
    public class DemandeAideFinancieresRepository : EfRepository<DemandeAideFinancieres>, IDemandeAideFinancieresRepository
    {
        public DemandeAideFinancieresRepository(CleanContext cleanContext) : base(cleanContext)
        {
        }

        public DemandeAideFinancieres GetByIdWithDemandeAideFinancieres(int id)
        {
            return _CleanContext.DemandeAideFinanciere
            .Include(r => r.Id)
            .First();
        }
    }
}
