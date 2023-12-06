using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IDemandeAideFinancieresService
    {
        Task<DemandeAideFinancieres> GetDemandeAideFinancieresById(int demandeAideFinanciereId);
        Task<IReadOnlyList<DemandeAideFinancieres>> GetAllDemandeAideFinancieresByEtudiantsId(int etudiantId);
        Task<DemandeAideFinancieres> CreateDemandeAideFinancieres(DemandeAideFinancieres demandeAideFinancieres);
        Task UpdateDemandeAideFinancieres(DemandeAideFinancieres demandeAideFinancieres);
        Task DeleteDemandeAideFinancieres(DemandeAideFinancieres demandeAideFinancieres);
    }
}
