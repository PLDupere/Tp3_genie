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
    public class DossierEtudiantsRepository : EfRepository<DossierEtudiants>, IDossierEtudiantsRepository
    {
        public DossierEtudiantsRepository(CleanContext cleanContext) : base(cleanContext)
        {
        }

        public DossierEtudiants GetByIdWithDossierEtudiants(int id)
        {
            return _CleanContext.DossierEtudiants
          .Include(r => r.Id)
          .First();
        }
    }
}
