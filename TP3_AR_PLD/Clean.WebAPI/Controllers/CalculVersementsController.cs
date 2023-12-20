using AutoMapper;
using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Clean.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clean.WebAPI.Controllers
{
    [ApiController]
    [Route("api/calculVersement")]
    public class CalculVersementsController : ControllerBase
    {

        private readonly ICalculVersementsService _calculVersements;
        private readonly IMapper _mapper;
        public CalculVersementsController(ICalculVersementsService calculVersements, IMapper mapper)
        {
            _calculVersements = calculVersements;
            _mapper = mapper;
        }

        // Endpoint pour récupérer un calcul de versement
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalculVersementsById(int id)
        {
            var versement = await _calculVersements.GetCalculVersementsById(id);
            if (versement == null)
            {
                return NotFound($"Aucun calcul et versement étudiant trouvé avec l'ID {id}");
            }
            var map = _mapper.Map<IEnumerable<DemandeAideFinancieresDtos>>(versement);
            return Ok(map);
        }

        // Endpoint pour créer un nouvel calcul de versement
        [HttpPost]
        public async Task<IActionResult> CreateCalculVersement([FromBody] CalculVersements calculVersements)
        {
            if (calculVersements == null)
            {
                return BadRequest("Les calculs de versements ne peuvent pas être nulles");
            }
            await _calculVersements.CreateCalculVersements(calculVersements);

            return CreatedAtAction(nameof(GetCalculVersementsById), new { id = calculVersements.Id }, calculVersements);
        }

        // Endpoint pour mettre à jour les calcul de versements
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalculVersement(int id, [FromBody] CalculVersements calculVersements)
        {
            CalculVersements existingCalculVersement = await _calculVersements.GetCalculVersementsById(id);
            if (existingCalculVersement == null)
            {
                return NotFound($"Aucun calcul de versement n'a été trouvé avec l'ID {id}");
            }

            // Mettre à jour les propriétés d'un calcul versements
            existingCalculVersement.AnneeEnCours = calculVersements.AnneeEnCours;
            existingCalculVersement.Montants = calculVersements.Montants;
            existingCalculVersement.TypeVersement = calculVersements.TypeVersement;
            existingCalculVersement.DateVersement = calculVersements.DateVersement;

            await _calculVersements.UpdateCalculVersements(existingCalculVersement);

            return Ok(existingCalculVersement);
        }

        // Endpoint pour supprimer un calcul de versements par son ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(CalculVersements calculVersements)
        {
            var versementToRemove = _calculVersements.DeleteCalculVersements(calculVersements);
            if (versementToRemove == null)
            {
                return NotFound($"Aucun calcul de versement n'a été trouvé.");
            }

            await _calculVersements.DeleteCalculVersements(calculVersements);

            return NoContent();
        }
    }
}
