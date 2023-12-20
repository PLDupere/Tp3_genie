using AutoMapper;
using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Clean.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/dossierEtudiants")]
    public class DossierEtudiantsController : ControllerBase
    {

        private readonly IDossierEtudiantsService _dossierEtudiants;
        private readonly IMapper _mapper;
        public DossierEtudiantsController(IDossierEtudiantsService dossierEtudiants, IMapper mapper)
        {
            _dossierEtudiants = dossierEtudiants;
            _mapper = mapper;
        }

        // Endpoint pour récupérer un dossier étudiant par son ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDossierEtudiantById(int id)
        {
            var dossier = _dossierEtudiants.GetDossierEtudiantsId(id);
            if (dossier == null)
            {
                return NotFound($"Aucun dossier d'étudiant trouvé avec l'ID {id}");
            }

            return Ok(dossier);
        }

        // Endpoint pour créer un nouveau dossier étudiant
        [HttpPost]
        public async Task<IActionResult> CreateDossierEtudiant([FromBody] DossierEtudiants dossierEtudiant)
        {
            if (dossierEtudiant == null)
            {
                return BadRequest("Les données de l'étudiant ne peuvent pas être nulles");
            }
            await _dossierEtudiants.CreateDossierEtudiants(dossierEtudiant);

            return CreatedAtAction(nameof(GetDossierEtudiantById), new { id = dossierEtudiant.Id }, dossierEtudiant);
        }

        // Endpoint pour mettre à jour les informations d'un dossier étudiant
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDossierEtudiant([FromBody] DossierEtudiants dossierEtudiant)
        {
            var existingDossierEtudiant = await _dossierEtudiants.GetDossierEtudiantsId(dossierEtudiant.Id);

            if (existingDossierEtudiant == null)
            {
                return NotFound($"No student record found with ID {dossierEtudiant.Id}");
            }

            existingDossierEtudiant.EtudiantsId = dossierEtudiant.EtudiantsId;
            existingDossierEtudiant.AdresseDeCorrespondance = dossierEtudiant.AdresseDeCorrespondance;
            existingDossierEtudiant.NumeroDeTelephonePrincipale = dossierEtudiant?.NumeroDeTelephonePrincipale;
            existingDossierEtudiant.NumeroDeTelephoneSecondaire = dossierEtudiant.NumeroDeTelephoneSecondaire;
            existingDossierEtudiant.AdresseCourriel = dossierEtudiant.AdresseCourriel;
            existingDossierEtudiant.Citoyennte = dossierEtudiant.Citoyennte;
            existingDossierEtudiant.CodeImmigration = dossierEtudiant.CodeImmigration;
            existingDossierEtudiant.DateObtentionStatusResidentPermanent = dossierEtudiant.DateObtentionStatusResidentPermanent;
            existingDossierEtudiant.LangueCorrespondance = dossierEtudiant.LangueCorrespondance;

            await _dossierEtudiants.UpdateDossierEtudiants(existingDossierEtudiant);
            return Ok(existingDossierEtudiant);
        }

        // Endpoint pour supprimer un étudiant par son ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDossierEtudiant(DossierEtudiants dossierEtudiants)
        {
            var dossierEtudiantToRemove = await _dossierEtudiants.GetDossierEtudiantsId(dossierEtudiants.Id);

            if (dossierEtudiantToRemove == null)
            {
                return NotFound($"No student record found with ID {dossierEtudiants.Id}");
            }

            await _dossierEtudiants.DeleteDossierEtudiants(dossierEtudiants);

            return NoContent();
        }
    }
}
