using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WebAPI.Dtos
{
    public class CalculVersementsDtos
    {
        public int Id { get; set; }
        public string? AnneeEnCours { get; set; }
        public int? Montants { get; set; }
        public string? TypeVersement { get; set; }
        public DateTime? DateVersement { get; set; }
    }
}
