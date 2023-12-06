using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface ICalculVersementsService
    {
        Task<CalculVersements> GetCalculVersementsById(int CalculVersementId);
        Task<IReadOnlyList<CalculVersements>> GetAllCalculVersementsByDemandeAideFinancieresId(int demandeAideFinanciereId);
        Task<CalculVersements> CreateCalculVersements(CalculVersements calculVersements);
        Task UpdateCalculVersements(CalculVersements calculVersements);
        Task DeleteCalculVersements(CalculVersements calculVersements);
    }
}
