using Clean.Core.Entities;
using Clean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clean.Core.Services
{
    public class EtudiantsService : IEtudiantsService
    {
        private readonly IEtudiantsRepository _EtudiantsRepository;
        public EtudiantsService(IEtudiantsRepository etudiantsRepository)
        {
            _EtudiantsRepository = etudiantsRepository;
        }
        public async Task<Etudiants> CreateEtudiants(Etudiants etudiants)
        {
            return await _EtudiantsRepository.AddAsync(etudiants);
        }

        public async Task DeleteEtudiants(Etudiants etudiants)
        {
            await _EtudiantsRepository.DeleteAsync(etudiants);
        }

        public async Task<Etudiants> GetEtudianstById(int id)
        {
            return await _EtudiantsRepository.GetByIdAsync(id);
        }

        public async Task<Etudiants> GetEtudiantsByCodePermanant(string codePermanent)
        {
            return await _EtudiantsRepository.GetByEtudiantWithCodePermanentAsync(codePermanent);
        }
        public async Task UpdateEtudiants(Etudiants etudiants)
        {
            await _EtudiantsRepository.UpdateAsync(etudiants);
        }
    }
}
