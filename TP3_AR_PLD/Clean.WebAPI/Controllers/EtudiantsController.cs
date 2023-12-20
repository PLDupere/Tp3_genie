
using AutoMapper;
using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Clean.Infrastructure;
using Clean.Infrastructure.Repositories;
using Clean.SharedKernel.Interfaces;
using Clean.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Clean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/etudiants")]
    public class EtudiantsController : ControllerBase
    {

        private readonly IEtudiantsService _etudiants;
        private readonly IMapper _mapper;
        public EtudiantsController(IEtudiantsService etudiantsService, IMapper mapper)
        {
            _etudiants = etudiantsService;
            _mapper = mapper;
        }

        [HttpPost("identification")]
        public IActionResult Identification([FromBody] IdentificationDtos credentials)
        {
            var token = "tokentest123";
            return Ok(new { token });
        }

        // Endpoint pour récupérer un étudiant par son ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEtudiantById(int id)
        {
            var etudiant = await _etudiants.GetEtudianstById(id);
            if (etudiant == null)
            {
                return NotFound($"Aucun étudiant trouvé avec l'ID {id}");
            }
            var map = _mapper.Map<IEnumerable<EtudiantsDtos>>(etudiant);

            return Ok(map);
        }
        
        // Endpoint pour créer un nouvel étudiant
        [HttpPost]
        public async Task<IActionResult> CreateEtudiant([FromBody] Etudiants etudiant)
        {
            if (etudiant == null)
            {
                return BadRequest("Les données de l'étudiant ne peuvent pas être nulles");
            }
            await _etudiants.CreateEtudiants(etudiant);

            return CreatedAtAction(nameof(GetEtudiantById), new { id = etudiant.Id }, etudiant);
        }

        // Endpoint pour mettre à jour les informations d'un étudiant
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEtudiant(int id, [FromBody] Etudiants etudiant)
        {
            var existingEtudiant = await _etudiants.GetEtudianstById(id);
            if (existingEtudiant == null)
            {
                return NotFound($"Aucun étudiant trouvé avec l'ID {id}");
            }

            // Mettre à jour les propriétés de l'étudiant
            existingEtudiant.Nom = etudiant.Nom;
            existingEtudiant.Prenom = etudiant.Prenom;
            existingEtudiant.NumeroAssuranceSociale = etudiant.NumeroAssuranceSociale;
            existingEtudiant.DateDeNaissance = etudiant.DateDeNaissance;
            existingEtudiant.CodePermanent = etudiant.CodePermanent;
            existingEtudiant.MotDePasse = etudiant.MotDePasse;

            await _etudiants.UpdateEtudiants(existingEtudiant);

            return Ok(existingEtudiant);
        }

        // Endpoint pour supprimer un étudiant par son ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(Etudiants etudiants)
        {
            var etudiantToRemove = await _etudiants.GetEtudianstById((int)etudiants.Id);

            if (etudiantToRemove == null)
            {
                return NotFound($"Aucun étudiant trouvé avec l'ID {etudiants.Id}");
            }

            await _etudiants.DeleteEtudiants(etudiantToRemove);

            return NoContent();
        }
        
    }
}
