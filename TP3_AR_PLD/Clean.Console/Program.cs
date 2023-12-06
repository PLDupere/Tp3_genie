﻿
using Clean.Core.Entities;
using Clean.Infrastructure;
using Clean.Infrastructure.Repositories;
using Clean.SharedKernel.Interfaces;

Console.WriteLine("Test dans la base de donnnées");


//EcrireDansBD();
//await LireDansBDAsync();
await CritereRecherche();

static async Task CritereRecherche()
{
    using (CleanContext context = new CleanContext())
    {
        // ici ***************************************************************************************************
    }
}

static async Task LireDansBDAsync()
{
    using (CleanContext context = new CleanContext())
    {
        IAsyncRepository<Etudiants> e = new EfRepository<Etudiants>(context);
        Etudiants etudiants = await e.GetByIdAsync(5);
        if (etudiants != null)
            Console.WriteLine("Nom étudiant : " + etudiants.Nom);
        else Console.WriteLine("Etudiants introuvable");

        IAsyncRepository<DossierEtudiants> d = new EfRepository<DossierEtudiants>(context);
        DossierEtudiants dossierEtudiants = await d.GetByIdAsync(5);
        if (dossierEtudiants != null)
            Console.WriteLine("Dossier de l'étudiant : " + dossierEtudiants.AdresseCourriel);
        else Console.WriteLine("Etudiants introuvable");
    }
}

 static void EcrireDansBD()
 {
    // create context
    var context = new CleanContext();

    // add Etudiant
    DateTime dt = new DateTime(2005, 12, 31);
    Etudiants etudiants = new Etudiants("Dup","PL","321-432-432", dt, "Q12323", "motDePasse");
    context.Etudiants.Add(etudiants);
    context.SaveChanges();
    Console.WriteLine("Création d'un étudiant OK");


    // add DossierEtudiant
    DateTime dt2 = new DateTime(2015, 10, 1);
    DossierEtudiants dossierEtudiants = new DossierEtudiants("1 main streer", "(555) 555-5555", "(434) 221-3232", "qwerty@gmail.com", true, "", dt2, "Français");
    // liaison clé
    etudiants.DossierEtudiants = dossierEtudiants;
    context.DossierEtudiants.Add(dossierEtudiants);
    context.SaveChanges();

    Console.WriteLine("Création d'un dossier étudiant OK");


    // add DemandeAideFinanciere
    DateTime dt3 = new DateTime(2010, 3, 15);
    DemandeAideFinancieres demandeAideFinancieres = new DemandeAideFinancieres("UQAR", "U777", "INF", 12, "Celibataire", dt3, 800, 0, 200);
    // liaison clé
    demandeAideFinancieres.Etudiants = etudiants;
    context.DemandeAideFinanciere.Add(demandeAideFinancieres);
    etudiants.AddDemandeAideFinanciere(demandeAideFinancieres);
    context.SaveChanges();


    Console.WriteLine("Création d'une demande d'aide financiere OK");

    // add CalculVersement
    DateTime dt4 = DateTime.Today;
    CalculVersements calculVersements = new CalculVersements("2023", 432, "Bourse", dt4);
    // liaison clé
    calculVersements.DemandeAideFinancieres = demandeAideFinancieres;
    context.CalculVersements.Add(calculVersements);
    demandeAideFinancieres.AddCalculVersements(calculVersements);
    context.SaveChanges();

    Console.WriteLine("Création d'un calcul et versement OK");

    Console.ReadKey();
    Console.WriteLine("Test compléter avec succes WOOHOO");
    Console.ReadKey();
 }