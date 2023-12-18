
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
        private readonly List<DemandeAideFinanciereDtos> _etudiants = new List<DemandeAideFinanciereDtos>();

        // Endpoint pour récupérer tous les étudiants
        [HttpGet]
        public IActionResult GetEtudiants()
        {
            return Ok(_etudiants);
        }

        // Endpoint pour récupérer un étudiant par son ID
        [HttpGet("{id}")]
        public IActionResult GetEtudiantById(int id)
        {
            var etudiant = _etudiants.FirstOrDefault(e => e.Id == id);
            if (etudiant == null)
            {
                return NotFound($"Aucun étudiant trouvé avec l'ID {id}");
            }

            return Ok(etudiant);
        }

        // Endpoint pour créer un nouvel étudiant
        [HttpPost]
        public IActionResult CreateEtudiant([FromBody] DemandeAideFinanciereDtos etudiantDto)
        {
            if (etudiantDto == null)
            {
                return BadRequest("Les données de l'étudiant ne peuvent pas être nulles");
            }
            _etudiants.Add(etudiantDto);

            return CreatedAtAction(nameof(GetEtudiantById), new { id = etudiantDto.Id }, etudiantDto);
        }

        // Endpoint pour mettre à jour les informations d'un étudiant
        [HttpPut("{id}")]
        public IActionResult UpdateEtudiant(int id, [FromBody] DemandeAideFinanciereDtos etudiantDto)
        {
            var existingEtudiant = _etudiants.FirstOrDefault(e => e.Id == id);
            if (existingEtudiant == null)
            {
                return NotFound($"Aucun étudiant trouvé avec l'ID {id}");
            }

            // Mettre à jour les propriétés de l'étudiant
            existingEtudiant.Nom = etudiantDto.Nom;
            existingEtudiant.Prenom = etudiantDto.Prenom;
            existingEtudiant.NumeroAssuranceSociale = etudiantDto.NumeroAssuranceSociale;
            existingEtudiant.DateDeNaissance = etudiantDto.DateDeNaissance;
            existingEtudiant.CodePermanent = etudiantDto.CodePermanent;
            existingEtudiant.MotDePasse = etudiantDto.MotDePasse;

            return Ok(existingEtudiant);
        }

        // Endpoint pour supprimer un étudiant par son ID
        [HttpDelete("{id}")]
        public IActionResult DeleteEtudiant(int id)
        {
            var etudiantToRemove = _etudiants.FirstOrDefault(e => e.Id == id);
            if (etudiantToRemove == null)
            {
                return NotFound($"Aucun étudiant trouvé avec l'ID {id}");
            }

            _etudiants.Remove(etudiantToRemove);

            return NoContent();
        }
    }
}
