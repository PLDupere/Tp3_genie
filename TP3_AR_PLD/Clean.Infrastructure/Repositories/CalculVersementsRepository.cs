using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.SharedKernel.Interfaces;

namespace Clean.Infrastructure.Repositories
{
    public class CalculVersementsRepository :  EfRepository<CalculVersements>, ICalculVersementsRepository
    {
        public CalculVersementsRepository(CleanContext cleanContext) : base(cleanContext)
        {
        }
        public CalculVersements GetByIdWithDemandeAideFinancieres(int id)
        {
            throw new NotImplementedException();
        }
    }
}
