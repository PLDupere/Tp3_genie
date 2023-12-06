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
    public class EtudiantsRepository : EfRepository<Etudiants>, IEtudiantsRepository
    {
        public EtudiantsRepository(CleanContext cleanContext) : base(cleanContext)
        {
        }

        public Task<Etudiants> GetByEtudiantWithCodePermanentAsync(string codePermanent)
        {
            return _CleanContext.Etudiants
            .Include(r => r.CodePermanent)
            .FirstOrDefaultAsync();
        }

        public Etudiants GetByIdDossierEtudiants(int id)
        {
            return _CleanContext.Etudiants
            .Include(r => r.Id)
            .First();
        }

        public Task<Etudiants> GetByIdWithEtudiantsAsync(int id)
        {
            return _CleanContext.Etudiants
             .Include(r => r.Id)
             .FirstOrDefaultAsync();
        }

    }
}
