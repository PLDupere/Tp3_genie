﻿using Clean.SharedKernel.Interfaces;
using Clean.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class DossierEtudiants : BaseEntity, IAggregateRoot
    {
        public int DossierEtudiantsId { get; set; }

        // Cle etrangere du dossier Etudians
        public int EtudiantsId { get; set; }
        public Etudiants Etudiants { get; set; }
        public string? AdresseDeCorrespondance { get; set; }
        public string? NumeroDeTelephonePrincipale { get; set; }
        public string? NumeroDeTelephoneSecondaire { get; set; }
        public string? AdresseCourriel { get; set; }
        public bool? Citoyennte { get; set; }
        public string? CodeImmigration { get; set; }
        public DateTime? DateObtentionStatusResidentPermanent { get; set; }
        public string? LangueCorrespondance { get; set; }

        public DossierEtudiants(int id)
        {
            DossierEtudiantsId = id;
        }

    }
}
