using Clean.SharedKernel.Interfaces;
using Clean.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class DemandeAideFinancieres : BaseEntity, IAggregateRoot
    {
        //Attribut
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

        // Clé étrangère
        public int? EtudiantsId { get; set; }
        public Etudiants? Etudiants { get; set; }

        // 1 DemandeAideFinanciere a n CalculVersements
        public List<CalculVersements>? CalculVersements { get; set; }
        public void AddCalculVersements(CalculVersements calculVersements)
        {
            CalculVersements.Add(calculVersements);
        }


        // Contructeur
        public DemandeAideFinancieres()
        {
        }

        public DemandeAideFinancieres(string? nomEtablissementEnseignement, string? codeEtablissementEnseignement, string? codeDuProgramme, int? nombreDeCredits, string? etatMatrimonial, DateTime? dateDebutEtatMatrimonial, int? revenusEmploie, int? autresRevenus, int? revenusPotentiels)
        {
            NomEtablissementEnseignement = nomEtablissementEnseignement;
            CodeEtablissementEnseignement = codeEtablissementEnseignement;
            CodeDuProgramme = codeDuProgramme;
            NombreDeCredits = nombreDeCredits;
            EtatMatrimonial = etatMatrimonial;
            DateDebutEtatMatrimonial = dateDebutEtatMatrimonial;
            RevenusEmploie = revenusEmploie;
            AutresRevenus = autresRevenus;
            RevenusPotentiels = revenusPotentiels;
        }
    }
}
