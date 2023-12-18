using Clean.Core.Entities;
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
        private readonly List<DossierEtudiantsDtos> _dossierEtudiants = new List<DossierEtudiantsDtos>();

        // Endpoint pour récupérer tous les dossiers étudiants
        [HttpGet]
        public IActionResult GetDossierEtudiants()
        {
            return Ok(_dossierEtudiants);
        }

        // Endpoint pour récupérer un dossier étudiant par son ID
        [HttpGet("{id}")]
        public IActionResult GetDossierEtudiantById(int id)
        {
            var dossier = _dossierEtudiants.FirstOrDefault(e => e.Id == id);
            if (dossier == null)
            {
                return NotFound($"Aucun dossier d'étudiant trouvé avec l'ID {id}");
            }

            return Ok(dossier);
        }

        // Endpoint pour créer un nouveau dossier étudiant
        [HttpPost]
        public IActionResult CreateDossierEtudiant([FromBody] DossierEtudiantsDtos dossierEtudiantDto)
        {
            if (dossierEtudiantDto == null)
            {
                return BadRequest("Les données de l'étudiant ne peuvent pas être nulles");
            }
            _dossierEtudiants.Add(dossierEtudiantDto);

            return CreatedAtAction(nameof(GetDossierEtudiantById), new { id = dossierEtudiantDto.Id }, dossierEtudiantDto);
        }

        // Endpoint pour mettre à jour les informations d'un dossier étudiant
        [HttpPut("{id}")]
        public IActionResult UpdateDossierEtudiant(int id, [FromBody] DossierEtudiantsDtos dossierEtudiantDto)
        {
            var existingDossierEtudiant = _dossierEtudiants.FirstOrDefault(e => e.Id == id);
            if (existingDossierEtudiant == null)
            {
                return NotFound($"Aucun dossier étudiant trouvé avec l'ID {id}");
            }

            // Mettre à jour les propriétés de l'étudiant
            existingDossierEtudiant.EtudiantsId = dossierEtudiantDto.EtudiantsId;
            existingDossierEtudiant.AdresseDeCorrespondance = dossierEtudiantDto.AdresseDeCorrespondance;
            existingDossierEtudiant.NumeroDeTelephonePrincipale = dossierEtudiantDto?.NumeroDeTelephonePrincipale;
            existingDossierEtudiant.NumeroDeTelephoneSecondaire = dossierEtudiantDto.NumeroDeTelephoneSecondaire;
            existingDossierEtudiant.AdresseCourriel = dossierEtudiantDto.AdresseCourriel;
            existingDossierEtudiant.Citoyennte = dossierEtudiantDto.Citoyennte;
            existingDossierEtudiant.CodeImmigration = dossierEtudiantDto.CodeImmigration;
            existingDossierEtudiant.DateObtentionStatusResidentPermanent = dossierEtudiantDto.DateObtentionStatusResidentPermanent;
            existingDossierEtudiant.LangueCorrespondance = dossierEtudiantDto.LangueCorrespondance;

            return Ok(existingDossierEtudiant);
        }

        // Endpoint pour supprimer un étudiant par son ID
        [HttpDelete("{id}")]
        public IActionResult DeleteEtudiant(int id)
        {
            var etudiantToRemove = _dossierEtudiants.FirstOrDefault(e => e.Id == id);
            if (etudiantToRemove == null)
            {
                return NotFound($"Aucun dossier étudiant trouvé avec l'ID {id}");
            }

            _dossierEtudiants.Remove(etudiantToRemove);

            return NoContent();
        }
    }
}
