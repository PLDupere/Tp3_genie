using Clean.Core.Entities;
using Clean.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface ICalculVersementsRepository : IRepository<CalculVersements>
    {
        CalculVersements GetByIdWithDemandeAideFinancieres(int id);
    }
}
