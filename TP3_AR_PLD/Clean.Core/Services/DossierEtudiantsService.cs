using Clean.Core.Entities;
using Clean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public class DossierEtudiantsService : IDossierEtudiantsService
    {
        private readonly IDossierEtudiantsRepository _DossierEtudiantsRepository;
        public DossierEtudiantsService(IDossierEtudiantsRepository dossierEtudiantsRepository)
        {
            _DossierEtudiantsRepository = dossierEtudiantsRepository;
        }

        public async Task<DossierEtudiants> CreateDossierEtudiants(DossierEtudiants dossierEtudiants)
        {
            return await _DossierEtudiantsRepository.AddAsync(dossierEtudiants);
        }

        public async Task<DossierEtudiants> DeleteDossierEtudiants(int id)
        {
            return await _DossierEtudiantsRepository.GetByIdAsync(id);
        }

        public async Task DeleteDossierEtudiants(DemandeAideFinancieres demandeAideFinancieres)
        {
            await _DossierEtudiantsRepository.DeleteAsync(demandeAideFinancieres);
        }

        public async Task<DossierEtudiants> GetDossierEtudiantsId(int etudiantId)
        {
            return await _DossierEtudiantsRepository.GetByIdAsync(etudiantId);
        }

        public async Task UpdateDossierEtudiants(DossierEtudiants dossierEtudiants)
        {
            await _DossierEtudiantsRepository.UpdateAsync(dossierEtudiants);
        }
    }
}
