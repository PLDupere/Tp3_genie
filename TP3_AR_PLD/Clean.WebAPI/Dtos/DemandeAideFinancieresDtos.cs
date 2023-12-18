using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WebAPI.Dtos
{
    public class DemandeAideFinancieresDtos
    {
        public int Id { get; set; }
        public string? NomEtablissementEnseignement { get; set; }
        public string? CodeEtablissementEnseignement { get; set; }
        public string? CodeDuProgramme { get; set; }
        public int? NombreDeCredits { get; set; }
        public string? EtatMatrimonial { get; set; }
        public DateTime? DateDebutEtatMatrimonial { get; set; }
        public int? RevenusEmploie { get; set; }
        public int? AutresRevenus { get; set; }
        public int? RevenusPotentiels { get; set; }
        public int? EtudiantsId { get; set; }
    }
}
