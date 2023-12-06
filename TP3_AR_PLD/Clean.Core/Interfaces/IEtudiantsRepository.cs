using Clean.Core.Entities;
using Clean.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IEtudiantsRepository : IRepository<Etudiants>, IAsyncRepository<Etudiants>
    {
        Etudiants GetByIdDossierEtudiants(int id);
        Task<Etudiants> GetByIdWithEtudiantsAsync(int id);
    }
}
