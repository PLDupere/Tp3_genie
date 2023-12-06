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
    public interface IDemandeAideFinancieresRepository : IRepository<DemandeAideFinancieres>, IAsyncRepository<DemandeAideFinancieres>
    {
        DemandeAideFinancieres GetByIdWithDemandeAideFinancieres(int id);

        Task<DemandeAideFinancieres> GetByIdWithDemandeAideFinancieresAsync(int id); 
    }
}
