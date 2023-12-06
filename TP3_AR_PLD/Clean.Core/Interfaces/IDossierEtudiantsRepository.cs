using Clean.Core.Entities;
using Clean.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IDossierEtudiantsRepository : IRepository<DossierEtudiants>, IAsyncRepository<DossierEtudiants>
    {
        DossierEtudiants GetByIdWithDossierEtudiants(int id);

        Task<DossierEtudiants> GetByIdWithDossierEtudiantsAsync(int id);
    }
}
