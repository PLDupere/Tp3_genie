using Clean.SharedKernel.Interfaces;
using Clean.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class CalculVersements : BaseEntity, IAggregateRoot
    {
        //Attributs
        public int Id { get; set; }

        public string? AnneeEnCours { get; set; }

        public int? Montants { get; set; }

        public string? TypeVersement { get; set; }

        public DateTime? DateVersement { get; set; }

        // Clé étrangere
        //public int? DemandeAideFinanciereId { get; set; }
        public DemandeAideFinancieres? DemandeAideFinancieres { get; set; }

        //Constructeur
        public CalculVersements()
        {
        }

        public CalculVersements(string? anneeEnCours, int? montants, string? typeVersement, DateTime? dateVersement)
        {
            AnneeEnCours = anneeEnCours;
            Montants = montants;
            TypeVersement = typeVersement;
            DateVersement = dateVersement;
        }
    }
}
