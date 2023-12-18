using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IBackEndSystemService
    {
        Task SendEtudiantsToBackEnd(Etudiants etudiants, string directory);
        Task SendDemandeAideFinancieresToBackEnd(DemandeAideFinancieres demandeAideFinancieres, string directory);
        Task SendDossierEtudiantsToBackEnd(DossierEtudiants dossierEtudiants, string directory);
        Task SendCalculVersementToBackEnd(CalculVersements calculVersements, string directory);
    }
}
