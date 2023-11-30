using Clean.SharedKernel;
using Clean.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class Etudiants : BaseEntity, IAggregateRoot
    {
        //Attributs
        public int EtudiantsId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NumeroAssuranceSociale { get; set; }
        public DateTime DateDeNaissance{ get; set; }
        public string CodePermanent { get; set; }
        public string? MotDePasse { get; set; }

        // 1 Etudiants a 1 dossierEtidiants
        public DossierEtudiants DossierEtudiants { get; set; }

        // 1 Etudiants a plusieurs DemandeAideFinanciere
        public List <DemandeAideFinancieres> DemandeAideFinancieres { get; set; }
        public void AddDemandeAideFinanciere(DemandeAideFinancieres demandeAideFinanciere)
        {
            DemandeAideFinancieres.Add(demandeAideFinanciere);
        }

        //Contructeur
        public Etudiants(int id, string nom, string prenom, string numeroAssuranceSociale, DateTime dateDeNaissance, string codePermanent)
        {
            EtudiantsId = id;
            Nom = nom;
            Prenom = prenom;
            NumeroAssuranceSociale = numeroAssuranceSociale;
            DateDeNaissance = dateDeNaissance;
            CodePermanent = codePermanent;
        }
    }
}
