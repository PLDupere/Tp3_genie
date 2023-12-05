using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Repositories
{
    public class EtudiantsRepository : EfRepository<Etudiants>, IEtudiantsRepository
    {
        public EtudiantsRepository(CleanContext cleanContext) : base(cleanContext)
        {
        }

        public Etudiants GetByIdDossierEtudiants(int id)
        {
            throw new NotImplementedException();
        }



    }
}
