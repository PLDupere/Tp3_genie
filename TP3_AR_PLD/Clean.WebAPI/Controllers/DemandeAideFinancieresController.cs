using Clean.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/demandeAideFinanciere")]
    public class DemandeAideFinancieresController : ControllerBase
    {
        private readonly List<DemandeAideFinancieresDtos> _demandeAideFinanciere = new List<DemandeAideFinancieresDtos>();

        // Endpoint pour récupérer tous les demandes aide financiere
        [HttpGet]
        public IActionResult GetDemandeAideFinanciere()
        {
            return Ok(_demandeAideFinanciere);
        }

        // Endpoint pour récupérer un étudiant par son ID
        [HttpGet("{id}")]
        public IActionResult GetDemandeAideFianciereById(int id)
        {
            var demande = _demandeAideFinanciere.FirstOrDefault(e => e.Id == id);
            if (demande == null)
            {
                return NotFound($"Aucune demande aide fianciere n'a été trouvé avec l'ID {id}");
            }

            return Ok(demande);
        }

        // Endpoint pour créer un nouvel étudiant
        [HttpPost]
        public IActionResult CreateDemandeAideFinanciere([FromBody] DemandeAideFinancieresDtos demandeAideFinanciereDtos)
        {
            if (demandeAideFinanciereDtos == null)
            {
                return BadRequest("Les données de l'étudiant ne peuvent pas être nulles");
            }
            _demandeAideFinanciere.Add(demandeAideFinanciereDtos);

            return CreatedAtAction(nameof(GetDemandeAideFianciereById), new { id = demandeAideFinanciereDtos.Id }, demandeAideFinanciereDtos);
        }

        // Endpoint pour mettre à jour les demande d'aide financiere d'un étudiant
        [HttpPut("{id}")]
        public IActionResult UpdateDemandeAideFinanciere(int id, [FromBody] DemandeAideFinancieresDtos demandeAideFinanciereDtos)
        {
            var existingDemandeAideFinanciere = _demandeAideFinanciere.FirstOrDefault(e => e.Id == id);
            if (existingDemandeAideFinanciere == null)
            {
                return NotFound($"Aucune demande d'aide financiere n'a été trouvé avec l'ID {id}");
            }

            // Mettre à jour les propriétés d'une demande aide financiere
            existingDemandeAideFinanciere.NomEtablissementEnseignement = demandeAideFinanciereDtos.NomEtablissementEnseignement;
            existingDemandeAideFinanciere.CodeEtablissementEnseignement = demandeAideFinanciereDtos.CodeEtablissementEnseignement;
            existingDemandeAideFinanciere.CodeDuProgramme = demandeAideFinanciereDtos.CodeDuProgramme;
            existingDemandeAideFinanciere.NombreDeCredits = demandeAideFinanciereDtos.NombreDeCredits;
            existingDemandeAideFinanciere.EtatMatrimonial = demandeAideFinanciereDtos.EtatMatrimonial;
            existingDemandeAideFinanciere.DateDebutEtatMatrimonial = demandeAideFinanciereDtos.DateDebutEtatMatrimonial;
            existingDemandeAideFinanciere.RevenusEmploie = demandeAideFinanciereDtos.RevenusEmploie;
            existingDemandeAideFinanciere.RevenusPotentiels = demandeAideFinanciereDtos.RevenusPotentiels;
            existingDemandeAideFinanciere.EtudiantsId = demandeAideFinanciereDtos.EtudiantsId;

            return Ok(existingDemandeAideFinanciere);
        }

        // Endpoint pour supprimer un étudiant par son ID
        [HttpDelete("{id}")]
        public IActionResult DeleteDemandeAideFinanciere(int id)
        {
            var demandeToRemove = _demandeAideFinanciere.FirstOrDefault(e => e.Id == id);
            if (demandeToRemove == null)
            {
                return NotFound($"Aucune demande d'aide financiere n'a été trouvé avec l'ID {id}");
            }

            _demandeAideFinanciere.Remove(demandeToRemove);

            return NoContent();
        }
    }
}
