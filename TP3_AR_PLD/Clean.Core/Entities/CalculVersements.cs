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

        // Clé étrangere
        public int DemandeAideFinanciereId { get; set; }
        public DemandeAideFinancieres DemandeAideFinancieres { get; set; }

        public string? AnneeEnCours { get; set; }

        public int[]? Montants = new int[12]; // 0 = janvier 1 = février ...

        public string[]? TypeVersement = new string[12]; // pret ou bourse

        public DateTime[]? DateVersement = new DateTime[12]; // 0 = janvier 1 = février ...

        //Constructeur
        public CalculVersements()
        {
        }
    }
}
