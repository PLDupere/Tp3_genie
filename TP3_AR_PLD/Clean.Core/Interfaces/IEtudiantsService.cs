using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IEtudiantsService
    {
        Task<Etudiants> GetEtudianstById(int id);
        Task<Etudiants> GetEtudiantsByCodePermanant(string codePermanent);
        Task<Etudiants> CreateEtudiants(Etudiants etudiants);
        Task UpdateEtudiants(Etudiants etudiants);
        Task DeleteEtudiants(Etudiants etudiants);

    }
}
