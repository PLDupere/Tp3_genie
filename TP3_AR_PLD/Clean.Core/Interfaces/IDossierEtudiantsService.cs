using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IDossierEtudiantsService
    {
        Task<DossierEtudiants> GetDossierEtudiantsId(int etudiantId);
        Task<DossierEtudiants> CreateDossierEtudiants(DossierEtudiants dossierEtudiants);
        Task UpdateDossierEtudiants(DossierEtudiants dossierEtudiants);
        Task DeleteDossierEtudiants(DemandeAideFinancieres demandeAideFinancieres);
    }
}
