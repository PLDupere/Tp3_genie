using Clean.Core.Entities;
using Clean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public class CalculVersementsService : ICalculVersementsService
    {
        private readonly ICalculVersementsRepository _CalculVersementsRespository;
        public CalculVersementsService(ICalculVersementsRepository calculVersementsRepository)
        {
            _CalculVersementsRespository = calculVersementsRepository;
        }
        public async Task<CalculVersements> CreateCalculVersements(CalculVersements calculVersements)
        {
            return await _CalculVersementsRespository.AddAsync(calculVersements);
        }

        public async Task DeleteCalculVersements(CalculVersements calculVersements)
        {
            await _CalculVersementsRespository.DeleteAsync(calculVersements);
        }

        public async Task<IReadOnlyList<CalculVersements>> GetAllCalculVersementsByDemandeAideFinancieresId(int demandeAideFinanciereId)
        {
            CalculVersements calculVersements = await _CalculVersementsRespository.GetByIdAsync(demandeAideFinanciereId);
            return (IReadOnlyList<CalculVersements>)calculVersements;
        }

        public async Task<CalculVersements> GetCalculVersementsById(int CalculVersementId)
        {
            return await _CalculVersementsRespository.GetByIdAsync(CalculVersementId);
        }

        public async Task UpdateCalculVersements(CalculVersements calculVersements)
        {
            await _CalculVersementsRespository.UpdateAsync(calculVersements);
        }
    }
}
