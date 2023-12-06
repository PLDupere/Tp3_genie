
using Clean.Core.Entities;
using Clean.Core.Specifications;
using Clean.Infrastructure;
using Clean.Infrastructure.Repositories;
using Clean.SharedKernel.Interfaces;

Console.WriteLine("Test dans la base de donnnées");


//EcrireDansBD();
//await LireDansBDAsync();
//await CritereRecherche();
await TestService();

static async Task TestService()
{

}

static async Task CritereRecherche()
{
    using (CleanContext context = new CleanContext())
    {
        // load etudiant par id
        IAsyncRepository<Etudiants> repo1 = new EfRepository<Etudiants>(context);
        RequestByEtudiantsId spec1 = new RequestByEtudiantsId(26);
        var requests1 = await repo1.ListAsync(spec1);
        string codepermanentTEST = "";
        int etudiantIdTEST = 0;
        int demandeAideFinanciereTEST = 0;
        Console.WriteLine("Recherche etudiant par id");
        foreach (Etudiants e in requests1)
        {
            Console.WriteLine("EtudiantId= " + e.Id + "   NemeroAssuranceSociale=" + e.NumeroAssuranceSociale + "   CodePermanent=" + e.CodePermanent);
            codepermanentTEST = e.CodePermanent;
            Console.WriteLine("- - -");
        }
        
        // load etudiant par code permanent
        IAsyncRepository<Etudiants> repo2 = new EfRepository<Etudiants>(context);
        FindEtudiantByCodePermanent spec2 = new FindEtudiantByCodePermanent(codepermanentTEST);
        var requests2 = await repo2.ListAsync(spec2);
        Console.WriteLine("Recherche etudiant par code permanent");
        foreach (Etudiants e in requests2)
        {
            Console.WriteLine("EtudiantId= " + e.Id + "NemeroAssuranceSociale=" + e.NumeroAssuranceSociale + "CodePermanent=" + e.CodePermanent);
            etudiantIdTEST = (int)e.Id;
            Console.WriteLine("- - -");
        }

        // load dossier etudiant par id 
        IAsyncRepository<DossierEtudiants> repo3 = new EfRepository<DossierEtudiants>(context);
        var requests3 = await repo3.GetByIdAsync(etudiantIdTEST);
        Console.WriteLine("Recherche dossier etudiant par id de l'étudiant: " + "==>" + etudiantIdTEST + "<==");

        Console.WriteLine(" Numero de dossier = " + requests3.Id + " Numero de l'étudaint " + requests3.EtudiantsId + " Adresse : " + requests3.AdresseCourriel );
        Console.WriteLine("- - -");

        // load tout les demande d'aide fianciere par etudiant id 
        IAsyncRepository<DemandeAideFinancieres> repo4 = new EfRepository<DemandeAideFinancieres>(context);
        FindAllDemandeAideFinanciereByEtudiantId spec4 = new FindAllDemandeAideFinanciereByEtudiantId(etudiantIdTEST);
        var requests4 = await repo4.ListAsync(spec4);
        Console.WriteLine("Recherche d aide financiere par etudiant id");
        foreach (DemandeAideFinancieres d in requests4)
        {
            Console.WriteLine("Demande aide finaciere Id = " + d.Id + "Code de l'établissement = " + d.CodeDuProgramme + "Etudiant ID =" + d.EtudiantsId);
            demandeAideFinanciereTEST = d.Id;
        }
        Console.WriteLine("- - -");

        // load tout les calcul de versement par demande d'aide financiere 
        IAsyncRepository<CalculVersements> repo5 = new EfRepository<CalculVersements>(context);
        FindCalculVersementByDemandeAideFinanciereID spec5 = new FindCalculVersementByDemandeAideFinanciereID(etudiantIdTEST);
        var requests5 = await repo5.ListAsync(spec5);
        Console.WriteLine("Recherche des calcul de versement par demande d aide financire id ==>" + demandeAideFinanciereTEST);

        foreach (CalculVersements c in requests5)
        {
            Console.WriteLine("calcul et versementId = " + c.Id + " Monantant = " + c.Montants);
        }
        Console.WriteLine("- - -");
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
    Etudiants etudiants = new Etudiants("Rioux","A","321-432-432", dt, "CodeP", "motDePasse");
    context.Etudiants.Add(etudiants);
    context.SaveChanges();
    Console.WriteLine("Création d'un étudiant OK");


    // add DossierEtudiant
    DateTime dt2 = new DateTime(2015, 10, 1);
    DossierEtudiants dossierEtudiants = new DossierEtudiants("99 main streer", "(555) 555-5555", "(434) 221-3232", "qwerty@gmail.com", true, "", dt2, "Français");
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
    CalculVersements calculVersements1 = new CalculVersements("2023", 100, "Bourse", dt4);
    CalculVersements calculVersements2 = new CalculVersements("2023", 200, "Bourse", dt4);
    CalculVersements calculVersements3 = new CalculVersements("2023", 332, "Bourse", dt4);
    // liaison clé
    calculVersements1.DemandeAideFinancieres = demandeAideFinancieres;
    calculVersements2.DemandeAideFinancieres = demandeAideFinancieres;
    calculVersements3.DemandeAideFinancieres = demandeAideFinancieres;

    context.CalculVersements.Add(calculVersements1);
    context.CalculVersements.Add(calculVersements2);
    context.CalculVersements.Add(calculVersements3);

    demandeAideFinancieres.AddCalculVersements(calculVersements1);
    demandeAideFinancieres.AddCalculVersements(calculVersements2);
    demandeAideFinancieres.AddCalculVersements(calculVersements3);
    context.SaveChanges();

    Console.WriteLine("Création d'un calcul et versement OK");

    Console.ReadKey();
    Console.WriteLine("Test compléter avec succes WOOHOO");
    Console.ReadKey();
 }