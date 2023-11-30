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
        public string DemandeAideFinanciereId { get; set; }
        public string NomEtablissementEnseignement { get; set; }
        public string CodeEtablissementEnseignement { get; set; }
        public string CodeDuProgramme { get; set; }
        public int NombreDeCredits { get; set; }
        public string EtatMatrimonial { get; set; }
        public DateTime DateDebutEtatMatrimonial { get; set; }
        public int RevenusEmploie { get; set; }
        public int AutresRevenus { get; set; }
        public int RevenusPotentiels { get; set; }

        // 1 DemandeAideFinanciere a 1 CalculVersements
        public CalculVersements CalculVersements { get; set; }
        

        //Contructeur
        public DemandeAideFinancieres(string id, string nomEtablissementEnseignement, string codeEtablissementEnseignement, 
            string codeDuProgramme, int nombreDeCredits, string etatMatrimonial, DateTime dateDebutEtatMatrimonial, 
            int revenusEmploie, int autresRevenus, int revenusPotentiels)
        {
            DemandeAideFinanciereId = id;
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
