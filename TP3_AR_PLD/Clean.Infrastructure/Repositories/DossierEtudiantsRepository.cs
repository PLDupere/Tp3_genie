﻿using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Repositories
{
    public class DossierEtudiantsRepository : EfRepository<Etudiants>, IEtudiantsRepository
    {
        public DossierEtudiantsRepository(CleanContext cleanContext) : base(cleanContext)
        {
        }

        public Etudiants GetByIdDossierEtudiants(int id)
        {
            throw new NotImplementedException();
        }
    }
}
