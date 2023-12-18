using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WebAPI.Dtos
{
    public class DossierEtudiantsDtos
    {
        public int Id { get; set; }
        public int EtudiantsId { get; set; }
        public string? AdresseDeCorrespondance { get; set; }
        public string? NumeroDeTelephonePrincipale { get; set; }
        public string? NumeroDeTelephoneSecondaire { get; set; }
        public string? AdresseCourriel { get; set; }
        public bool? Citoyennte { get; set; }
        public string? CodeImmigration { get; set; }
        public DateTime? DateObtentionStatusResidentPermanent { get; set; }
        public string? LangueCorrespondance { get; set; }
    }
}
