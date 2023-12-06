using Clean.Core.Entities;
using Clean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public class DemandeAideFiancieresService : IDemandeAideFinancieresService
    {
        private readonly IDemandeAideFinancieresRepository _DemandeAideFinancieresRepository;
        public DemandeAideFiancieresService(IDemandeAideFinancieresRepository demandeAideFinancieresRepository)
        {
            _DemandeAideFinancieresRepository = demandeAideFinancieresRepository;
        }

        public async Task<DemandeAideFinancieres> CreateDemandeAideFinancieres(DemandeAideFinancieres demandeAideFinancieres)
        {
            return await _DemandeAideFinancieresRepository.AddAsync(demandeAideFinancieres);
        }

        public async Task DeleteDemandeAideFinancieres(DemandeAideFinancieres demandeAideFinancieres)
        {
            await _DemandeAideFinancieresRepository.DeleteAsync(demandeAideFinancieres);
        }

        public async Task<IReadOnlyList<DemandeAideFinancieres>> GetAllDemandeAideFinancieresByEtudiantsId(int etudiantId)
        {
            DemandeAideFinancieres demandeAideFinancieres = await _DemandeAideFinancieresRepository.GetByIdAsync(etudiantId);
            return (IReadOnlyList<DemandeAideFinancieres>)demandeAideFinancieres;
        }

        public async Task<DemandeAideFinancieres> GetDemandeAideFinancieresById(int demandeAideFinanciereId)
        {
            return await _DemandeAideFinancieresRepository.GetByIdAsync(demandeAideFinanciereId);
        }

        public async Task UpdateDemandeAideFinancieres(DemandeAideFinancieres demandeAideFinancieres)
        {
            await _DemandeAideFinancieresRepository.UpdateAsync(demandeAideFinancieres);
        }
    }
}
