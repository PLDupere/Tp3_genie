using Clean.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Clean.Core.Interfaces;
using Clean.Core.Specifications;

namespace Clean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/demandeAideFinanciere")]
    public class DemandeAideFinancieresController : ControllerBase
    {

        private readonly IDemandeAideFinancieresService _demandeAideFinanciere;
        private readonly IMapper _mapper;
        public DemandeAideFinancieresController(IDemandeAideFinancieresService demandeAideFinanciere, IMapper mapper)
        {
            _demandeAideFinanciere = demandeAideFinanciere;
            _mapper = mapper;
        }

        // Endpoint pour récupérer un étudiant par son ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDemandeAideFianciereById(int id)
        {
            var demande = await _demandeAideFinanciere.GetDemandeAideFinancieresById(id);
            if (demande == null)
            {
                return NotFound($"Aucune demande aide fianciere n'a été trouvé avec l'ID {id}");
            }
            var map = _mapper.Map<IEnumerable<DemandeAideFinancieresDtos>>(demande);
            return Ok(map);
        }

        // Endpoint pour créer un nouvel étudiant
        [HttpPost]
        public async Task<IActionResult> CreateDemandeAideFinanciere([FromBody] DemandeAideFinancieres demandeAideFinanciere)
        {
            if (demandeAideFinanciere == null)
            {
                return BadRequest("Les données de l'étudiant ne peuvent pas être nulles");
            }
            await _demandeAideFinanciere.CreateDemandeAideFinancieres(demandeAideFinanciere);

            return CreatedAtAction(nameof(GetDemandeAideFianciereById), new { id = demandeAideFinanciere.Id }, demandeAideFinanciere);
        }

        // Endpoint pour mettre à jour les demande d'aide financiere d'un étudiant
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDemandeAideFinanciere(int id,[FromBody] DemandeAideFinancieres demandeAideFinanciere)
        {
            var existingDemandeAideFinanciere = await _demandeAideFinanciere.GetDemandeAideFinancieresById(id);
            if (existingDemandeAideFinanciere == null)
            {
                return NotFound($"Aucune demande d'aide financiere n'a été trouvé avec l'ID {id}");
            }

            // Mettre à jour les propriétés d'une demande aide financiere
            existingDemandeAideFinanciere.NomEtablissementEnseignement = demandeAideFinanciere.NomEtablissementEnseignement;
            existingDemandeAideFinanciere.CodeEtablissementEnseignement = demandeAideFinanciere.CodeEtablissementEnseignement;
            existingDemandeAideFinanciere.CodeDuProgramme = demandeAideFinanciere.CodeDuProgramme;
            existingDemandeAideFinanciere.NombreDeCredits = demandeAideFinanciere.NombreDeCredits;
            existingDemandeAideFinanciere.EtatMatrimonial = demandeAideFinanciere.EtatMatrimonial;
            existingDemandeAideFinanciere.DateDebutEtatMatrimonial = demandeAideFinanciere.DateDebutEtatMatrimonial;
            existingDemandeAideFinanciere.RevenusEmploie = demandeAideFinanciere.RevenusEmploie;
            existingDemandeAideFinanciere.RevenusPotentiels = demandeAideFinanciere.RevenusPotentiels;
            existingDemandeAideFinanciere.EtudiantsId = demandeAideFinanciere.EtudiantsId;

            await _demandeAideFinanciere.UpdateDemandeAideFinancieres(existingDemandeAideFinanciere);

            return Ok(existingDemandeAideFinanciere);
        }

        // Endpoint pour supprimer un étudiant par son ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemandeAideFinanciere(int id)
        {
            var demandeToRemove = await _demandeAideFinanciere.GetDemandeAideFinancieresById(id);

            if (demandeToRemove == null)
            {
                return NotFound($"Aucune demande d'aide financiere n'a été trouvé avec l'ID {id}");
            }

            await _demandeAideFinanciere.DeleteDemandeAideFinancieres(demandeToRemove);

            return NoContent();
        }
    }
}
