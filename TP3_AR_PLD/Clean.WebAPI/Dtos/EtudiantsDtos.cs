using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WebAPI.Dtos
{
    public class EtudiantsDtos
    {
        public int? Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? NumeroAssuranceSociale { get; set; }
        public DateTime? DateDeNaissance { get; set; }
        public string? CodePermanent { get; set; }
        public string? MotDePasse { get; set; }
    }
}
