using Clean.Core.Entities;
using Clean.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface ICalculVersementsRepository : IRepository<CalculVersements>, IAsyncRepository<CalculVersements>
    {
        CalculVersements GetByIdWithCalculVersements(int id);

        Task<CalculVersements> GetByIdWithCalculVersementsAsync(int id);
    }
}
