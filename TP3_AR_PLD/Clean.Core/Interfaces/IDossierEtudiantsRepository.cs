using Clean.Core.Entities;
using Clean.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    internal interface IDossierEtudiantsRepository : IAsyncRepository<DossierEtudiants>, IRepository<DossierEtudiants>
    {
        DossierEtudiants GetByIdWithEtudiants(int id);
    }
}
